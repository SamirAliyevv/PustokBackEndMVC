using Pustok.Entities;

namespace Pustok.Helpers
{
    public static  class FileManager
    {
        public static  string Save(IFormFile file,string rootPath,string folder)
        {
            string NewFileName = Guid.NewGuid().ToString() + (file.FileName.Length <= 64 ? file.FileName : file.FileName.Substring(file.FileName.Length - 64));
            string path = Path.Combine(rootPath,NewFileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return NewFileName;
        }
        public static void Delete(string rootPath, string folder,string fileName)
        {
            string path = Path.Combine(rootPath, folder,fileName);

            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
