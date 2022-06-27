using AutoMapper;

namespace CMS.Application.Mappings
{
    public interface IMapTo<T>
    {
        public void Mapping(Profile profile) => profile.CreateMap(this.GetType(), typeof(T));
    }
}
