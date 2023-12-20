
using System;
using System.Text;

using System.Collections.Generic;
using ModeloFilmersGen.ApplicationCore.Exceptions;
using ModeloFilmersGen.ApplicationCore.EN.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.IRepository.Pruebadeesquemaproyecto;
using ModeloFilmersGen.ApplicationCore.CEN.Pruebadeesquemaproyecto;



/*PROTECTED REGION ID(usingModeloFilmersGen.ApplicationCore.CP.Pruebadeesquemaproyecto_Comunidades_borrarComunidad) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ModeloFilmersGen.ApplicationCore.CP.Pruebadeesquemaproyecto
{
public partial class ComunidadesCP : GenericBasicCP
{
public void BorrarComunidad (int p_oid)
{
        /*PROTECTED REGION ID(ModeloFilmersGen.ApplicationCore.CP.Pruebadeesquemaproyecto_Comunidades_borrarComunidad) ENABLED START*/

        ComunidadesCEN comunidadesCEN = null;



        try
        {
                CPSession.SessionInitializeTransaction ();
                comunidadesCEN = new  ComunidadesCEN (CPSession.UnitRepo.ComunidadesRepository);
                MensajeCEN mensajeCEN = new MensajeCEN (CPSession.UnitRepo.MensajeRepository);

                ComunidadesEN comEN = comunidadesCEN.DamePorOID (p_oid);
                IList<MensajeEN> menList = comEN.Menesajes;

                foreach (var item in menList) {
                        mensajeCEN.BorrarMensaje (item.Id);
                }


                comunidadesCEN.BorrarSoloComunidad (p_oid);

                CPSession.Commit ();
        }
        catch (Exception ex)
        {
                CPSession.RollBack ();
                throw ex;
        }
        finally
        {
                CPSession.SessionClose ();
        }


        /*PROTECTED REGION END*/
}
}
}
