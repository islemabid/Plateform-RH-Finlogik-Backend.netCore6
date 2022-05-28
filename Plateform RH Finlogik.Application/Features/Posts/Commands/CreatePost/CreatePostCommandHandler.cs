using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.Posts.Commands.CreatePost
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, int>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        public CreatePostCommandHandler(IMapper mapper, IPostRepository postRepository)
        {
            _mapper = mapper;
            _postRepository = postRepository;

        }

        public async Task<int> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            if (request != null && request.ShortDescription!="" && request.LongDescription!="")
            {
                var @post = _mapper.Map<Post>(request);

                @post = await _postRepository.AddAsync(@post);



                return @post.Id;
            }
            else
            {
                throw new Exception($"failed");
            }

        }

    }
}

