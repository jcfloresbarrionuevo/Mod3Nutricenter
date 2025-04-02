namespace NutriCenter.Aplication.Commands;

public record CrearTiempoCommand(
	string Nombre,
	TimeSpan Hora
);
