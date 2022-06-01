using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;


namespace Plateform_RH_Finlogik.Application.Features.Posts.Queries.GetPostsList
{
    public class GetPostsListQueryHandler : IRequestHandler<GetPostsListQuery, List<PostListVm>>
    {

        private readonly IAsyncRepository<Post> _postRepository;
        private readonly IMapper _mapper;

        public GetPostsListQueryHandler(IMapper mapper, IAsyncRepository<Post> postRepository)
        {
            _mapper = mapper;
            _postRepository = postRepository;
        }

        public async Task<List<PostListVm>> Handle(GetPostsListQuery request, CancellationToken cancellationToken)
        {
            var allPosts = (await _postRepository.GetAllAsync()).Where(x => x.IsDeleted == false).OrderByDescending(x=>x.Id);
            return _mapper.Map<List<PostListVm>>(allPosts);
        }
    }
}







