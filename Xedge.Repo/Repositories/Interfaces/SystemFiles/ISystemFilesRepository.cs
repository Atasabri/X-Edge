using Xedge.Infrastructure.Manage_Files;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xedge.Repo.Repositories.Interfaces.SystemFiles
{
    public interface ISystemFilesRepository
    {
        /// <summary>
        /// Saving Image To Uploads Folder in Root Folder Asynchronous
        /// </summary>
        /// <param name="savingFileData"></param>
        /// <returns></returns>
        Task SaveFileAsync(SavingFileData savingFileData);
        /// <summary>
        /// Check If File Is Exist Or Not
        /// </summary>
        /// <param name="fileBaseData"></param>
        /// <returns></returns>
        bool CheckFileExist(FileBaseData fileBaseData);
        /// <summary>
        /// Deleting File From Uploads Folder In Root Folder Asynchronous
        /// </summary>
        /// <param name="fileBaseData"></param>
        /// <returns></returns>
        Task DeleteFileAsync(FileBaseData fileBaseData);
        /// <summary>
        /// Saving Multi Files To Uploads Folder in Root Folder Asynchronous
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        Task SaveFilesAsync(List<SavingFileData> files);
    }
}
