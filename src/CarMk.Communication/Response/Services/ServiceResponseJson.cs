namespace CarMk.Communication.Response.Services;

public record ServiceResponseJson(
    string Id,
    string Description,
    string ServiceGroup,
    bool Active,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);