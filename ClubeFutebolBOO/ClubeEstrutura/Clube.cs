/*
*	<copyright file="Clube.cs"
*		Copyright (c) 2025 All Rights Reserved
*	</copyright>
* 	<author>a31508goncalobraga</author>
*	<description></description>
**/

using System;

namespace ClubeFutebol.BOO.ClubeEstrutura
{
    [Serializable]
    public class Clube : IComparable<Clube>
    {
        #region Atributos

        string nome;              // nome do clube
        short anoFundacao;        // ano da fundação
        string email;             // email de contacto
        int numeroTelefonico;     // número de contacto
        string pais;              // país onde atua

        #endregion

        #region Construtores

        public Clube()         // construtor default
        {
            nome = string.Empty;
            anoFundacao = 0;
            email = string.Empty;
            numeroTelefonico = 0;
            pais = string.Empty;
        }

        public Clube(string nome, short anoFundacao, string email, int numeroTelefonico, string pais)
        {
            Nome = nome;
            AnoFundacao = anoFundacao;
            Email = email;
            NumeroTelefonico = numeroTelefonico;
            Pais = pais;
        }

        #endregion

        #region Propriedades

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public short AnoFundacao
        {
            get { return anoFundacao; }
            set
            {
                if (value >= 1863)
                    anoFundacao = value;
                else
                    anoFundacao = 0;
            }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public int NumeroTelefonico
        {
            get { return numeroTelefonico; }
            set { numeroTelefonico = value; }

        }

        public string Pais
        {
            get { return pais; }
            set { pais = value; }
        }

        #endregion


        #region Metodos

        public int CompareTo(Clube other)
        {
            if (other == null)
                return 1;

            return this.Nome.CompareTo(other.Nome);
        }


        #endregion


        #region Overrides

        public override string ToString()
        {
            return $"{Nome} ({Pais}) - Fundado em {AnoFundacao}";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Clube))
                return false;

            Clube other = (Clube)obj;
            return this.Nome == other.Nome;
        }

        public override int GetHashCode()
        {
            return Nome.GetHashCode();
        }

        #endregion
    }
}
