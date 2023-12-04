

using System;
using System.Collections.Generic;
using ModeloFilmersGen.ApplicationCore.IRepository.Pruebadeesquemaproyecto;

namespace ModeloFilmersGen.ApplicationCore.CP.Pruebadeesquemaproyecto
{
public abstract class GenericBasicCP
{
protected GenericSessionCP CPSession;
protected GenericUnitOfWorkRepository unitRepo;

protected GenericBasicCP (GenericSessionCP currentSession)
{
        this.CPSession = currentSession;
        this.unitRepo = this.CPSession.UnitRepo;
}
protected GenericBasicCP()
{
        this.CPSession = null;
        this.unitRepo = null;
}
}
}

