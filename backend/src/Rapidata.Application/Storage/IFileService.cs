namespace Rapidata.Application.Storage;

public interface IFileService
{
    Task<FileResult> GetFile(string bucket, string fileName, CancellationToken cancellationToken);
    Task UploadFile(string bucket, string fileName, Stream content, CancellationToken cancellationToken);
    Task DeleteAllFilesInBucket(string bucket, CancellationToken cancellationToken);
}
