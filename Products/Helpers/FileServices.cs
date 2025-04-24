namespace Products.Helpers
{
    public class FileServices
    {
        private readonly IWebHostEnvironment _environment;
        public FileServices(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public async Task<string> Upload(IFormFile file, string folderName)
        {
            var fileName = "";
            if (file != null && file.Length > 0)
            {
                var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();
                fileName = $"{Guid.NewGuid()}{fileExtension}";
                var uploadsFolder = Path.Combine(_environment.WebRootPath, folderName);
                var filePath = Path.Combine(uploadsFolder, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            return fileName;
        }
    }
}
