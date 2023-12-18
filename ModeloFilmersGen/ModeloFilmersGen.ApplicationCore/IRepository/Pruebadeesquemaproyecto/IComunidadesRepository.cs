
using System;
using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.CP.Pruebadeesquemaproyecto;

namespace ModeloFilmersGen.ApplicationCore.IRepository.Pruebadeesquemaproyecto
{
public partial interface IComunidadesRepository
{
void setSessionCP (GenericSessionCP session);

ComunidadesEN ReadOIDDefault (int id
                              );

void ModifyDefault (ComunidadesEN comunidades);

System.Collections.Generic.IList<ComunidadesEN> ReadAllDefault (int first, int size);



int CrearComunidad (ComunidadesEN comunidades);

void ModificarComunidad (ComunidadesEN comunidades);


void BorrarSoloComunidad (int id
                          );


ComunidadesEN DamePorOID (int id
                          );


System.Collections.Generic.IList<ComunidadesEN> DameTodos (int first, int size);


System.Collections.Generic.IList<ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto.ComunidadesEN> DameComunidadPorNombre (string p_nombre);
}
}
