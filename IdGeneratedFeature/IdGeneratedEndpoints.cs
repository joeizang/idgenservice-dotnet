using System;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using idgenapi.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace idgenapi.IdGeneratedFeature;

public static class IdGeneratedEndpoints
{
    public static IEndpointRouteBuilder MapIdGeneratedEndPoints(this IEndpointRouteBuilder builder)
    {
        var idGenGroup = builder.MapGroup("/api/idgen");

        idGenGroup.MapPost("", async (IValidator<IdCreateDto> Validator, 
                [FromBody]IdCreateDto dto, IdGenApiContext context) =>
        {
            var ulid = Ulid.NewUlid();
            var idGenerated = new IdGenerated(dto.ServerName, dto.ServerIp, ulid.ToString(),
                ulid.ToGuid().ToString());
            context.IdsGenerated.Add(idGenerated);
            await context.SaveChangesAsync();
            return Results.Created($"/api/idgen/{idGenerated.Id}", idGenerated.MapToDto());
        })
        .AddEndpointFilter<IdGeneratedEndPointFilter>()
        .Produces(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest);

        idGenGroup.MapGet("", async (IdGenApiContext context) =>
            {
                var ids = await context.IdsGenerated.AsNoTracking()
                    .Select(x => x.MapToDto())
                    .ToListAsync(CancellationToken.None);
                return Results.Ok(ids);
            })
            .Produces(StatusCodes.Status200OK);

        return builder;
    }
}
