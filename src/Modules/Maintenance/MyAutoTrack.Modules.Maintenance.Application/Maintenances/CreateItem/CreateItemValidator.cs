using FluentValidation;

namespace MyAutoTrack.Modules.Maintenance.Application.Maintenances.CreateItem;

internal sealed class CreateItemValidator : AbstractValidator<CreateItemCommand>
{
    public CreateItemValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);
        
        RuleFor(x => x.Type)
            .NotEmpty()
            .MaximumLength(100);
        
        RuleFor(x => x.Price)
            .GreaterThan(0);
        
        RuleFor(x => x.Inventory)
            .GreaterThanOrEqualTo(0);
    }
}