﻿using System;
using System.Collections.Generic;
using System.IO;
using Bookie.Common;
using Bookie.Common.Model;
using Bookie.Core.Interfaces;
using Bookie.Data.Interfaces;
using Bookie.Data.Repositories;
using MoonPdfLib.MuPdf;

namespace Bookie.Core.Domains
{
    public class CoverImageDomain : ICoverImageDomain
    {
        private readonly ICoverImageRepository _coverImageRepository;

        public CoverImageDomain()
        {
            _coverImageRepository = new CoverImageRepository();
        }

        public IList<CoverImage> GetAllCoverImages()
        {
            return _coverImageRepository.GetAll();
        }

        public CoverImage GetCoverImageByUrl(string coverImageUrl)
        {
            return _coverImageRepository.GetSingle(x => x.FullPathAndFileNameWithExtension.Equals(coverImageUrl));
        }

        public void AddCoverImage(params CoverImage[] coverimage)
        {
            foreach (var b in coverimage)
            {
                b.CreatedDateTime = DateTime.Now;
                b.ModifiedDateTime = DateTime.Now;
            }
            _coverImageRepository.Add(coverimage);
            throw new NotImplementedException();
        }

        public void UpdateCoverImage(params CoverImage[] coverimage)
        {
            _coverImageRepository.Update(coverimage);
        }

        public void RemoveCoverImage(params CoverImage[] coverimage)
        {
            _coverImageRepository.Remove(coverimage);
        }

        public CoverImage GenerateCoverImageFromPdf(Book book)
        {
            if (!File.Exists(book.BookFile.FullPathAndFileNameWithExtension))
            {
                return EmptyCoverImage();
            }
            string outImageName = book.Title;
            foreach (char c in Path.GetInvalidFileNameChars())
            {
                outImageName = outImageName.Replace(c.ToString(), String.Empty);
            }
            outImageName += ".jpg";

            var savedImageUrl = Globals.CoverImageFolder + "\\" + outImageName;
            var file = new FileSource(book.BookFile.FullPathAndFileNameWithExtension);
            var img = MuPdfWrapper.ExtractPage(file, 1);

            img.Save(savedImageUrl);

            if (book.CoverImage == null)
            {
                book.CoverImage = new CoverImage();
            }

            if (book.Id == 0)
            {
                book.CoverImage.EntityState = EntityState.Added;
            }
            else
            {
                book.CoverImage.Id = book.CoverImage.Id;
                book.CoverImage.EntityState = EntityState.Modified;
            }

            book.CoverImage.FileNameWithExtension = Path.GetFileName(savedImageUrl);
            book.CoverImage.FullPathAndFileNameWithExtension = Globals.CoverImageFolder
                                                                   + Path.GetFileNameWithoutExtension(
                                                                       savedImageUrl) + ".jpg";
            book.CoverImage.FileExtension = ".jpg";
            return book.CoverImage;
        }

        CoverImage ICoverImageDomain.EmptyCoverImage()
        {
            return EmptyCoverImage();
        }

        public static CoverImage EmptyCoverImage()
        {
            var cover = new CoverImage();
            cover.FileNameWithExtension = Path.GetFileName(String.Empty);
            cover.FullPathAndFileNameWithExtension = Globals.CoverImageFolder
                                                                   + Path.GetFileNameWithoutExtension(
                                                                       String.Empty) + ".jpg";
            cover.FileExtension = ".jpg";
            return cover;
        }
    }
}