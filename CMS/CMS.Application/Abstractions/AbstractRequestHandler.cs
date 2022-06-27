using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CMS.Application.Interfaces;
using MediatR;

namespace CMS.Application.Abstractions
{
    public abstract class AbstractRequestHandler
    {
        protected IMediator Mediator
        {
            get;
        }

        protected ICMSDbContext DbContext
        {
            get;
        }

        protected IMapper Mapper
        {
            get;
        }

        public AbstractRequestHandler(
            IMediator mediator,
            ICMSDbContext dbContext,
            IMapper mapper)
        {
            this.Mediator = mediator;
            this.DbContext = dbContext;
            this.Mapper = mapper;
        }
    }
}
