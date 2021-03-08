using AutoMapper;
using FiledTest.Domain.DTO;
using FiledTest.Domain.Models;

namespace FiledTest.Domain.Maps
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<RequestPaymentDTO, Payment>().ForMember(member => member.PaymentState, option => new PaymentState());
        }
    }
}
