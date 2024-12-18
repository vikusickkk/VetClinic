using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.BL.Admins.Entities;
using VetClinic.DataAccess.Entities;
using VetClinic.DataAccess;

namespace VetClinic.BL.Admins
{
    public class AdminsProvider : IAdminsProvider
    {
        private readonly IRepository<AdminEntity> _adminRepository;
        private readonly IMapper _mapper;

        public AdminsProvider(IRepository<AdminEntity> adminsRepository, IMapper mapper)
        {
            _adminRepository = adminsRepository;
            _mapper = mapper;
        }

        public IEnumerable<AdminModel> GetAdmins(AdminModelFilter modelFilter = null)
        {
            var vetclinicId = modelFilter.VetClinicID;
            var email = modelFilter.Email;

            var admins = _adminRepository.GetAll(x =>
            (vetclinicId == null || vetclinicId == x.VetClinicID) &&
            (email == null || email == x.Email));

            return _mapper.Map<IEnumerable<AdminModel>>(admins);
        }

        public AdminModel GetAdminInfo(Guid id)
        {
            var admin = _adminRepository.GetById(id);
            if (admin is null)
                throw new ArgumentException("Admin not found.");

            return _mapper.Map<AdminModel>(admin);
        }

    }
}
