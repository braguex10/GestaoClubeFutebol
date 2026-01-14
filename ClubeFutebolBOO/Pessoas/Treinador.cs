/*
*	<copyright file="Treinador.cs"
*		Copyright (c) 2025 All Rights Reserved
*	</copyright>
* 	<author>a31508goncalobraga</author>
*	<description></description>
**/

using System;

namespace ClubeFutebol.BOO.Pessoas
{
    [Serializable]
    /// <summary>
    /// Classe derivada de Pessoa para representar um treinador de uma equipa
    /// </summary>
    public class Treinador : Pessoa
    {
        #region Atributos

        short anosExperiencia;
        string tatica;

        #endregion

        #region Construtor
        /// <summary>Construtor Vazio</summary>
        public Treinador()
        {
            anosExperiencia = 0;
            tatica = string.Empty;
        }


        /// <summary>Construtor Completo</summary>
        public Treinador(short anosExperiencia, string tatica, string nome, byte idade, string nacionalidade, string genero, int numeroSocio, int contacto)
                            : base(nome, idade, nacionalidade, genero, numeroSocio, contacto)  // pois estes valores sao herdados de pessao
        {
            AnosExperiencia = anosExperiencia;
            Tatica = tatica;
        }
        #endregion

        #region Propriedades

        public short AnosExperiencia
        {
            get { return anosExperiencia; }
            set { anosExperiencia = value; }

        }

        public string Tatica
        {
            get { return tatica; }
            set { tatica = value; }

        }
        #endregion

        #region Overrides

        public override string ToString()
        {
            return $"{Nome} - {AnosExperiencia} anos de experiência ({Tatica})";
        }


        #endregion
    }

}




