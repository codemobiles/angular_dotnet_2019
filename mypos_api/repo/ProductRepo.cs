using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using mypos_api.Database;
using mypos_api.Models;

namespace mypos_api.repo
{
    public class ProductRepo : IProductRepo
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductRepo(DatabaseContext context,
         IHttpContextAccessor httpContextAccessor,
        IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnvironment = webHostEnvironment;
            this._httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public DatabaseContext _context { get; }

        public Task<Products> AddProduct(Products product)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteProduct(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Products> EditProduct(Products product, int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Products> GetProduct()
        {
            return _context.Products.ToList();
        }

        public Products GetProduct(int id)
        {
            throw new System.NotImplementedException();
        }

        // Note: recommended used async Task
        public async Task<String> UploadProductImages()
        {


            var files = _httpContextAccessor.HttpContext.Request.Form.Files;

            if (files.Count > 0)
            {
                const string folder = "/images/";
                string filePath = _webHostEnvironment.WebRootPath + folder;   //wwwroot/images

                string fileName = "";
                //var fileNameArray = new List<String>(); // multiple images case

                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                // S3 
                foreach (var formFile in files)
                {
                    fileName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(formFile.FileName); // unique name
                    string fullPath = filePath + fileName;

                    if (formFile.Length > 0)
                    {
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            await formFile.CopyToAsync(stream);
                        }
                    }

                    // fileNameArray.Add(fileName); // multiple images case
                }

                return fileName;
                //return fileNameArray; // multiple images case
            }
            return String.Empty;
            //return null;      // multiple images case
        }
    }
}