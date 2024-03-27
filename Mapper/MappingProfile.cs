using AutoMapper;
using EmployeeManagementEF.Data.Models;
using EmployeeManagementEF.Models;

namespace EmployeeManagementEF.Mapper {
    public class MappingProfile : Profile {
        public MappingProfile() {
            CreateMap<Employee, EmployeeModel>();
            CreateMap<EmployeeModel, Employee>();
        }
    }
}
