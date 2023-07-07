using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HomeBudgetApp.Application.Commons.Interfaces;
using MediatR;

namespace HomeBudgetApp.Application.UseCases.Expences.Queries.GetExpences
{
    public class GetExpencesQueryHandler : IRequestHandler<GetToDoListsQuery, ToDoListDto[]>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetExpencesQueryHandler(
            IApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ToDoListDto[]> Handle(GetToDoListsQuery request, CancellationToken cancellationToken)
        {
            ToDoList[] ToDoLists = await _context.ToDoLists.ToArrayAsync();

            return _mapper.Map<ToDoListDto[]>(ToDoLists);
        }
    }
}
