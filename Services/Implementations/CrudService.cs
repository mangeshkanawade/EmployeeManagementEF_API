using AutoMapper;
using EmployeeManagementEF.Repositories.Interfaces;
using EmployeeManagementEF.Services.Interfaces;
using EmployeeManagementEF.Shared;
namespace EmployeeManagementEF.Services.Implementations
{
    public class CrudService<TEntity> : ICrudService<TEntity> where TEntity : class
    {
        public IRepository<TEntity> _repository;

        protected readonly IMapper _mapper;
        public CrudService(IRepository<TEntity> repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public virtual Result<TCreateResponse> Create<TCreateRequest, TCreateResponse>(TCreateRequest input, string createdById)
        {
            TEntity model = _mapper.Map<TCreateRequest, TEntity>(input);

            if (model.GetType().GetProperty("CreatedBy") != null)
                model.GetType().GetProperty("CreatedBy").SetValue(model, createdById);

            if (model.GetType().GetProperty("CreatedOn") != null)
                model.GetType().GetProperty("CreatedOn").SetValue(model, System.DateTime.UtcNow);

            model = _repository.Create(model);
            return new Result<TCreateResponse>(ResultType.Success, "Created", _mapper.Map<TEntity, TCreateResponse>(model));
        }

        public virtual Result<TUpdateResponse> Update<TUpdateRequest, TUpdateResponse>(TUpdateRequest input, string id, string updatedById)
        {
            TEntity model = GetById(new Guid(id));

            if (model == null)
                return new Result<TUpdateResponse>(ResultType.NotFound, "Not Found", _mapper.Map<TEntity, TUpdateResponse>(model));

            if (model.GetType().GetProperty("ModifiedBy") != null)
                model.GetType().GetProperty("ModifiedBy").SetValue(model, updatedById);

            if (model.GetType().GetProperty("ModifiedOn") != null)
                model.GetType().GetProperty("ModifiedOn").SetValue(model, System.DateTime.UtcNow);

            _mapper.Map<TUpdateRequest, TEntity>(input, model);



            model = _repository.Update(model);
            return new Result<TUpdateResponse>(ResultType.Success, "Updated", _mapper.Map<TEntity, TUpdateResponse>(model));
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return this._repository.GetAll();
        }

        public virtual TEntity GetById(Guid Id)
        {
            return _repository.GetById(Id);
        }

        public virtual Result<bool> Delete(Guid Id)
        {
            _repository.Delete(Id);
            return new Result<bool>(ResultType.Success, "Deleted", true);
        }
    }
}
