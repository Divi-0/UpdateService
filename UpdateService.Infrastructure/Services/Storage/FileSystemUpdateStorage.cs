using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UpdateService.Domain;
using UpdateService.Domain.Exceptions;
using UpdateService.Domain.Services.Storage.Interfaces;

namespace UpdateService.Infrastructure.Services.Storage
{
    public class FileSystemUpdateStorage : IUpdateStorage
    {
        private readonly string _path;
        private readonly string _fileName;

        public FileSystemUpdateStorage(IConfiguration configuration)
        {
            _path = configuration["FILE_SYSTEM_PATH"];

            if (string.IsNullOrWhiteSpace(_path))
            {
                _path = @".\Files";
            }

            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }

            _fileName = configuration["FILE_NAME"];

            if (string.IsNullOrWhiteSpace(_fileName))
            {
                throw new ArgumentNullException("FILE_NAME", "env value FILE_NAME needs to be set");
            }
        }

        public Task<List<Version>> GetAllAvailableVersions()
        {
            List<Version> versions = new List<Version>();

            foreach (string item in Directory.GetDirectories(_path))
            {
                string version = Path.GetFileName(item); //gets the the version number from the folder name

                versions.Add(new Version(version));
            }

            return Task.FromResult(versions);
        }

        public Task<NewVersion> GetVersion(Version version)
        {
            string versionDirectory = string.Empty;
            string versionNumber = string.Empty;

            try
            {
                foreach (string item in Directory.GetDirectories(_path))
                {
                    versionNumber = Path.GetFileName(item);
                    if (version.CompareTo(new Version(versionNumber)) < 0)
                    {
                        versionDirectory = item;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            if (string.IsNullOrWhiteSpace(versionDirectory))
            {
                throw new NoHigherVersionFoundException($"Version {version} does not exist");
            }

            try
            {
                string filePath = Path.Combine(versionDirectory, _fileName);

                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException(filePath);
                }

                return Task.FromResult(new NewVersion
                {
                    VersionNumber = versionNumber,
                    Data = File.ReadAllBytes(filePath)
                });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
