using SchoolEducationPortal.Models;
using System.ComponentModel.DataAnnotations;

namespace SchoolEducationPortal.Services.FileUpload
{

    public abstract class FileUploadViewModelBase
    {
       
        public FileInformation FileInfo { get; set; } = new();
        [Display(Name = "Upload Order Copy")]
        [Required(ErrorMessage = "Enter a File to Upload")]
        public IFormFile? FileToUpload { get; set; }
        public FileUploadSettings UploadSettings { get; set; } = new();
        public string ErrorMessage { get; set; } = string.Empty;

        public virtual async Task<FileInformation> Save()
        {

            FileInformation ret = null;
            // Ensure user selected a file for upload
            if (FileToUpload != null && FileToUpload.Length > 0)
            {
                // Get all File Properties
                GetFileProperties();

                if (Validate())
                {
                    // Save File to Data Store
                   ret = await SaveToDataStoreAsync();
                    if (ret != null)
                    {
                        // If an image type, create a thumbnail
                        //if (FileInfo.Type.StartsWith("image"))
                        //{
                        //    GenerateThumbnail();
                        //}
                    }
                }
            }

            return ret;
        }

        protected virtual void GetFileProperties()
        {
            if (FileToUpload != null)
            {
                // Get the file name
                FileInfo.FileName = FileToUpload.FileName;
                // Get the file's length
                FileInfo.Length = FileToUpload.Length;
                // Get the file's type
                FileInfo.Type = FileToUpload.ContentType;
            }
        }

        public virtual bool Validate()
        {
            bool ret = false;
            string[] validTypes = UploadSettings.ValidFileTypes.Split(",");
            string[] extensions = UploadSettings.InvalidFileExtensions.Split(",");

            // Check for valid "accept" types
            ret = validTypes.Any(f => FileInfo.Type.StartsWith(f));

            if (ret)
            {
                // Check for invalid file extensions
                ret = !extensions.Any(f => Path.GetExtension(FileInfo.FileName) == f);
            }

            if (!ret)
            {
                ErrorMessage = "You are Trying to Upload an Invalid File Type";
            }

            return ret;
        }

        // Override to save to a data store
        protected abstract Task<FileInformation> SaveToDataStoreAsync();

        

        /// <summary>
        /// Generate a thumbnail for the uploaded image
        /// </summary>
        //public void GenerateThumbnail()
        //{
        //    // Set FileNameThumbnail property
        //    FileInfo.FileNameThumbnail =
        //      Path.GetFileNameWithoutExtension(FileInfo.FileNameOnServer)
        //        + "-Thumb" + Path.GetExtension(FileInfo.FileNameOnServer).ToLower();

        //    // Load the original image
        //    using Image image = Image.Load(FileInfo.FileNameOnServer);
        //    // Resize the image to a percentage of the size
        //    image.Mutate(x => x
        //      .Resize(
        //        (int)(image.Width * UploadSettings.ThumbScale),
        //        (int)(image.Height * UploadSettings.ThumbScale)));
        //    // Save the thumbnail
        //    image.Save(Path.Combine(FileInfo.ServerLocation, FileInfo.FileNameThumbnail));
        //}
    }
}