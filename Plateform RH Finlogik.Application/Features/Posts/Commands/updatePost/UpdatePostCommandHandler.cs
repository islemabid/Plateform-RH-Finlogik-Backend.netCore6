using AutoMapper;
using MediatR;
using Plateform_RH_Finlogik.Application.Exceptions;
using Plateform_RH_Finlogik.Application.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.Posts.Commands.updatePost
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand>
    {
        private readonly IAsyncRepository<Post> _postRepository;
        private readonly IMapper _mapper;

        public UpdatePostCommandHandler(IMapper mapper, IAsyncRepository<Post> postRepository)
        {
            _mapper = mapper;
            _postRepository = postRepository;
        }

        public async Task<Unit> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {

            var postToUpdate = await _postRepository.GetByIDAsync(request.Id);

            if (postToUpdate == null)
            {
                throw new NotFoundException(nameof(Post), request.Id);
            }



            _mapper.Map(request, postToUpdate, typeof(UpdatePostCommand), typeof(Post));

            await _postRepository.UpdateAsync(postToUpdate);

            return Unit.Value;
        }

    }

}