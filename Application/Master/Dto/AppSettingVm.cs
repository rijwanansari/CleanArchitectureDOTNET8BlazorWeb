namespace Application.Master.Dto
{
    public record AppSettingVm
    {
        public int Id { get; init; }
        public string ReferenceKey { get; init; } = string.Empty;
        public string Value { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public string Type { get; init; } = string.Empty;
    }
}
