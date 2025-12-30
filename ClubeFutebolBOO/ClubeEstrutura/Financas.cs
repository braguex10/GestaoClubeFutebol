/*
*	<copyright file="~Financas.cs"
*		Copyright (c) 2025 All Rights Reserved
*	</copyright>
* 	<author>a31508goncalobraga</author>
*	<description></description>
**/

using System;

namespace ClubeFutebol.BOO.ClubeEstrutura
{
    [Serializable]
    public class Financas
    {
        #region Atributos

        float saldoClube;
        float orcamentoSalarios;
        float orcamentoTransferencias;

        #endregion

        #region Construtores

        public Financas()
        {
            saldoClube = 0f;
            orcamentoSalarios = 0f;
            orcamentoTransferencias = 0f;
        }

        public Financas(float saldoClube, float orcamentoSalarios, float orcamentoTransferencias)
        {
            SaldoClube = saldoClube;
            OrcamentoSalarios = orcamentoSalarios;
            OrcamentoTransferencias = orcamentoTransferencias;
        }

        #endregion

        #region Propriedades

        public float SaldoClube
        {
            get { return saldoClube; }
            set { saldoClube = value; }
        }

        public float OrcamentoSalarios
        {
            get { return orcamentoSalarios; }
            set { orcamentoSalarios = value; }
        }

        public float OrcamentoTransferencias
        {
            get { return orcamentoTransferencias; }
            set { orcamentoTransferencias = value; }
        }

        #endregion

        #region Overrides

        public override string ToString()
        {
            return $"Saldo: {saldoClube} | Salários: {orcamentoSalarios} | Transferências: {orcamentoTransferencias}";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Financas))
                return false;

            Financas other = (Financas)obj;
            return saldoClube == other.saldoClube &&
                   orcamentoSalarios == other.orcamentoSalarios &&
                   orcamentoTransferencias == other.orcamentoTransferencias;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + saldoClube.GetHashCode();
            hash = hash * 23 + orcamentoSalarios.GetHashCode();
            hash = hash * 23 + orcamentoTransferencias.GetHashCode();
            return hash;
        }

        #endregion
    }
}
