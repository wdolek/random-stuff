using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using MineField.Entities;

namespace MineField
{
    public class FieldParser : IParser
    {
        /// <summary>
        /// Maximum dimension of mine field
        /// </summary>
        private readonly int _maxDimension;

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldParser"/> class. 
        /// </summary>
        /// <param name="maxDimension">
        /// Maximum dimension
        /// </param>
        public FieldParser(int maxDimension = 100)
        {
            if (maxDimension < 0)
            {
                throw new ArgumentException(
                    String.Format("Negative dimension is not allowed in this universe, {0}", maxDimension),
                    "maxDimension");
            }

            _maxDimension = maxDimension;
        }

        /// <summary>
        /// Parse mine field represented by string
        /// </summary>
        /// <param name="width">
        /// Field width
        /// </param>
        /// <param name="height">
        /// Field height
        /// </param>
        /// <param name="field">
        /// Data
        /// </param>
        /// <returns>
        /// Async task with result of instance of <see cref="Field"/>
        /// </returns>
        public async Task<Field> ParseAsync(int width, int height, string field)
        {
            // check input
            ValidateDimension(width, "Width");
            ValidateDimension(height, "Height");

            if (String.IsNullOrEmpty(field))
            {
                throw new ArgumentNullException("field");
            }

            var mines = new List<MinePoint>();
            await ParseFieldAsync(width, field, mines);

            return new Field(width, height, mines);
        }

        /// <summary>
        /// Validate dimension
        /// </summary>
        /// <param name="dimension">
        /// Either width or height of field
        /// </param>
        /// <param name="name">
        /// Name of property
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown when invalid input is passed
        /// </exception>
        // ReSharper disable once UnusedParameter.Local
        private void ValidateDimension(int dimension, string name)
        {
            if ((dimension < 0) || (dimension > _maxDimension))
            {
                throw new ArgumentException(String.Format("{0} must be within interval 0-{1}", name, _maxDimension));
            }
        }

        /// <summary>
        /// Parse given field representation
        /// </summary>
        /// <param name="width">
        /// Field width
        /// </param>
        /// <param name="field">
        /// Field content
        /// </param>
        /// <param name="mines">
        /// List of mines
        /// </param>
        /// <returns>
        /// Async task
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown when lenght of line does not match width of mine field
        /// </exception>
        private async Task ParseFieldAsync(int width, string field, IList<MinePoint> mines)
        {
            using (var reader = new StringReader(field))
            {
                var lineNumber = 0;
                string line;

                while ((line = await reader.ReadLineAsync().ConfigureAwait(false)) != null)
                {
                    if (line.Length != width)
                    {
                        throw new Exception("Field format missmatch, invalid number of cols");
                    }

                    ParseLine(lineNumber, line, mines);
                    ++lineNumber;
                }
            }            
        }
        
        /// <summary>
        /// Parse line
        /// </summary>
        /// <param name="lineNumber">Line number</param>
        /// <param name="line">Line content</param>
        /// <param name="mines">List of mines</param>
        private void ParseLine(int lineNumber, string line, IList<MinePoint> mines)
        {
            for (var i = 0; i < line.Length; i++)
            {
                if (line[i] == Constants.Mine)
                {
                    mines.Add(new MinePoint(i, lineNumber));
                }
            }
        }
    }
}
