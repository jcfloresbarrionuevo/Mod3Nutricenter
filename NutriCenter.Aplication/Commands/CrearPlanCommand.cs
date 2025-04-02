namespace NutriCenter.Aplication.Commands;

public record CrearPlanCommand
(
	string Nombre,
	int DuracionDias,
	string CedulaCliente,
	string NombreCliente,
	//
	List<CrearRecetasTiempos> Detalle
);
