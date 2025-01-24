

using TechnicalEducationPortal.Models;

namespace SchoolEducationPortal.Services.FileUpload
{

    public class FileSystemViewModel : FileUploadViewModelBase
    {
        /// <summary>
        /// Save to Server File System 
        /// </summary>
        /// <returns>A Task with true=successful, false=unsuccessful</returns>
        protected override async Task<FileInformation> SaveToDataStoreAsync()
        {


            if (FileToUpload != null)
            {
                // Set Server Location to Store File
                FileInfo.ServerLocation = UploadSettings.UploadFolderPath + @"\";

                bool existFolder = Directory.Exists(FileInfo.ServerLocation + FileInfo.DocumentType);

                //if Directory not existed. Create the directory
                if (!existFolder)
                    Directory.CreateDirectory(Path.Combine(FileInfo.ServerLocation, FileInfo.DocumentType));
                FileInfo.ServerLocation = Path.Combine(FileInfo.ServerLocation, FileInfo.DocumentType);
                string ext = Path.GetExtension(FileInfo.FileName).ToLower();
                
                string filename = "RO" + FileInfo.RequestId.Replace(".", "") + FileInfo.RequestDate.ToString().Replace("-", "").Replace("/", "").Replace(" ", "").Replace(":", "").Replace("PM","").Replace("AM","");
                FileInfo.FileName = filename + ext;
                if (FileInfo.Type.StartsWith("image"))
                {
                    // Create a random file name for this new file
                    // Leave the file extension in place if it is an image file
                    ext = Path.GetExtension(FileInfo.FileName).ToLower();
                    filename = Path.GetFileNameWithoutExtension(Path.GetRandomFileName());
                    FileInfo.FileNameOnServer = Path.Combine(FileInfo.ServerLocation, filename + ext);
                }
                else
                {
                    // Create a random file name for this new file
                    FileInfo.FileNameOnServer = Path.Combine(FileInfo.ServerLocation, filename + ext); //Path.GetRandomFileName());
                }
                //Check the Directory Exist or Not

                // Create a stream to write the file to
                using var stream = File.Create(FileInfo.FileNameOnServer);

                // Upload file and copy to the stream
                await FileToUpload.CopyToAsync(stream);
            }

            return FileInfo;
        }

        public static byte[] ReadFile(string filePath)
        {
            byte[] buffer;
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            try
            {
                int length = (int)fileStream.Length;  // get file length
                buffer = new byte[length];            // create buffer
                int count;                            // actual number of bytes read
                int sum = 0;                          // total number of bytes read

                // read until Read method returns 0 (end of the stream has been reached)
                while ((count = fileStream.Read(buffer, sum, length - sum)) > 0)
                    sum += count;  // sum is a buffer offset for next reading
            }
            finally
            {
                fileStream.Close();
            }
            return buffer;
        }
    }
}
