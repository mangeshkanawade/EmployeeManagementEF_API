using EmployeeManagementEF.Shared;

namespace EmployeeManagementEF.Services.Interfaces
{
    public interface ICrudService<TEntity> where TEntity : class
    {
        TEntity GetById(Guid Id);
        IEnumerable<TEntity> GetAll();
        Result<TCreateResponse> Create<TCreateRequest, TCreateResponse>(TCreateRequest input, string createdById);
        Result<TUpdateResponse> Update<TUpdateRequest, TUpdateResponse>(TUpdateRequest input, string id, string updatedById);
        Result<bool> Delete(Guid Id);
    }
}
