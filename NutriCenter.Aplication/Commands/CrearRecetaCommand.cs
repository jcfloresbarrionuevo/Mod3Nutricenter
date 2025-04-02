namespace NutriCenter.Aplication.Commands;

public record CrearRecetaCommand
(
	string Nombre,
	string Descripcion,
	decimal CostoMonto,
	string CostoMoneda,
	List<CrearIngredienteCommand> Ingredientes
);
