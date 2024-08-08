namespace Api.DataTransferObjects.v1;

public record User(int Id, string Username, string Password, string Role) { }