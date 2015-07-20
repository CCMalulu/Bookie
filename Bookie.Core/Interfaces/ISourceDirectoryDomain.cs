﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Bookie.Common.Model;

namespace Bookie.Core.Interfaces
{
    public interface ISourceDirectoryDomain
    {
        IList<SourceDirectory> GetAllSourceDirectories();

        SourceDirectory GetSourceByUrlWithBooks(string sourceUrl);

        void AddSourceDirectory(params SourceDirectory[] sourceDirectory);

        void UpdateSourceDirectory(params SourceDirectory[] sourceDirectory);

        void RemoveSourceDirectory(params SourceDirectory[] sourceDirectory);

        bool Exists(string sourceUrl);

        SourceDirectory GetSourceDirectoryForBook(Book book);

        Task<IList<SourceDirectory>> GetAllSourceDirectoriesAsync();
    }
}