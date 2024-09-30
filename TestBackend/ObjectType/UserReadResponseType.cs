using TestBackend.Interactor.Dtos;

namespace TestBackend.ObjectType
{
    public class UserReadResponseType : ObjectType<UserReadResponse>
    {
        protected override void Configure(IObjectTypeDescriptor<UserReadResponse> descriptor)
        {
            descriptor.Field(x => x.Id).Type<NonNullType<IdType>>();
            descriptor.Field(x => x.Name).Type<StringType>();
            descriptor.Field(x => x.Email).Type<StringType>();
        }
    }
}