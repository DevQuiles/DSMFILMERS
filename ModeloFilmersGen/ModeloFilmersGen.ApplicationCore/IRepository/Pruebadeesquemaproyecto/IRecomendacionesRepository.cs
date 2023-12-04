
using System;
using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.CP.Pruebadeesquemaproyecto;

namespace ModeloFilmersGen.ApplicationCore.IRepository.Pruebadeesquemaproyecto
{
public partial interface IRecomendacionesRepository
{
void setSessionCP (GenericSessionCP session);

RecomendacionesEN ReadOIDDefault (int id
                                  );

void ModifyDefault (RecomendacionesEN recomendaciones);

System.Collections.Generic.IList<RecomendacionesEN> ReadAllDefault (int first, int size);




System.Collections.Generic.IList<RecomendacionesEN> DameTodos (int first, int size);


int CrearRecomendacionDefault (RecomendacionesEN recomendaciones);
}
}
