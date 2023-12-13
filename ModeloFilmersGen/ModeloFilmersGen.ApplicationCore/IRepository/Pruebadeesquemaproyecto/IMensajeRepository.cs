
using System;
using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.CP.Pruebadeesquemaproyecto;

namespace ModeloFilmersGen.ApplicationCore.IRepository.Pruebadeesquemaproyecto
{
public partial interface IMensajeRepository
{
void setSessionCP (GenericSessionCP session);

MensajeEN ReadOIDDefault (int id
                          );

void ModifyDefault (MensajeEN mensaje);

System.Collections.Generic.IList<MensajeEN> ReadAllDefault (int first, int size);



int CrearMensaje (MensajeEN mensaje);

MensajeEN DamePorOID (int id
                      );


System.Collections.Generic.IList<MensajeEN> DameTodos (int first, int size);


void ModificarMensaje (MensajeEN mensaje);


void BorrarMensaje (int id
                    );
}
}
