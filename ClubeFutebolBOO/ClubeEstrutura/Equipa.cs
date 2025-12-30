/*
*	<copyright file="Equipa.cs"
*		Copyright (c) 2025 All Rights Reserved
*	</copyright>
* 	<author>a31508goncalobraga</author>
*	<description></description>
**/

using System;
using ClubeFutebol.BOO.Pessoas;

namespace ClubeFutebol.BOO.ClubeEstrutura
{
    [Serializable]
    public class Equipa
    {
        #region Atributos

        string escalao;
        string liga;
        string nomeClube;                 // associação lógica ao Clube
        Treinador treinadorPrincipal;

        #endregion

        #region Construtores 

        public Equipa()
        {
            escalao = string.Empty;
            liga = string.Empty;
            nomeClube = string.Empty;
            treinadorPrincipal = null;
        }

        public Equipa(string escalao, string liga, string nomeClube)
        {
            Escalao = escalao;
            Liga = liga;
            NomeClube = nomeClube;
            treinadorPrincipal = null;
        }

        #endregion

        #region Propriedades

        public string Escalao
        {
            get { return escalao; }
            set { escalao = value; }
        }

        public string Liga
        {
            get { return liga; }
            set { liga = value; }
        }

        public string NomeClube
        {
            get { return nomeClube; }
            set { nomeClube = value; }
        }

        public Treinador TreinadorPrincipal
        {
            get { return treinadorPrincipal; }
            set { treinadorPrincipal = value; }
        }

        public bool TemTreinador
        {
            get { return treinadorPrincipal != null; }
        }

        #endregion

        #region Overrides

        public override string ToString()
        {
            return $"{Escalao} | {Liga} | Clube: {NomeClube}";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Equipa))
                return false;

            Equipa other = (Equipa)obj;
            return this.Escalao == other.Escalao &&
                   this.Liga == other.Liga &&
                   this.NomeClube == other.NomeClube;
        }

        public override int GetHashCode()
        {
            return (Escalao + Liga + NomeClube).GetHashCode();
        }

        #endregion
    }
}