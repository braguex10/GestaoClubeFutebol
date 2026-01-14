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
    /// <summary>
    /// Classe que representa a equipa ligada a um certo clube
    /// Por exemplo equipa sénior, júnior, etc
    /// </summary>
    public class Equipa
    {
        #region Atributos

        string escalao;
        string liga;
        string nomeClube;                 // associação lógica ao Clube
        Treinador treinadorPrincipal;

        #endregion

        #region Construtores 
        /// <summary>Construtor Vazio</summary>
        public Equipa()         // construtor vazio, inicializa os atributos vazios
        {
            escalao = string.Empty;
            liga = string.Empty;
            nomeClube = string.Empty;
            treinadorPrincipal = null;
        }
        /// <summary>Construtor Completo</summary>
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


        public bool TemTreinador     //propriedade lógica, verifica se a equipa tem treinador
        {
            get { return treinadorPrincipal != null; }
        }

        #endregion

        #region Overrides

        public override string ToString()  // como a equipa aparece em texto
        {
            return $"{Escalao} | {Liga} | Clube: {NomeClube}";
        }

        public override bool Equals(object obj)  // quando é que duas equipas sao iguais
        {
            if (!(obj is Equipa))
                return false;

            Equipa other = (Equipa)obj;
            return this.Escalao == other.Escalao &&
                   this.Liga == other.Liga &&
                   this.NomeClube == other.NomeClube;
        }

        public override int GetHashCode() // obter o codigo para usar em colecoes
        {
            return (Escalao + Liga + NomeClube).GetHashCode();
        }

        #endregion
    }
}