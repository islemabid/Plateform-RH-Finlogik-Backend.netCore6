using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Features.Posts.Commands.CreatePost
{
    public  class CreatePostCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public bool IsDeleted { get; set; } = false;


    }
}
