using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrkEngine
{
    public class OBJModel
    {
        private List<Vector3f> m_positions;
        private List<Vector2f> m_texCoords;
        private List<Vector3f> m_normals;
        private List<OBJIndex> m_indices;
        private bool           m_hasTexCoords;
        private bool           m_hasNormals;

		public OBJModel(String fileName)
		{
			m_positions = new List<Vector3f>();
			m_texCoords = new List<Vector2f>();
			m_normals = new List<Vector3f>();
			m_indices = new List<OBJIndex>();
			m_hasTexCoords = false;
			m_hasNormals = false;

			string meshReader = null;

			try
			{
				meshReader = File.ReadAllText(fileName);
				string line;

				while (( line = meshReader ) != null)
				{
					string[] tokens = line.Split(' ');
					tokens = Util.RemoveEmptyStrings(tokens);

					if (tokens.Length == 0 || tokens[0].Equals("#"))
						continue;
					else if (tokens[0].Equals("v"))
					{
						m_positions.Add(new Vector3f(float.Parse(tokens[1]),
								float.Parse(tokens[2]),
								float.Parse(tokens[3])));
					}
					else if (tokens[0].Equals("vt"))
					{
						m_texCoords.Add(new Vector2f(float.Parse(tokens[1]),
								1.0f - float.Parse(tokens[2])));
					}
					else if (tokens[0].Equals("vn"))
					{
						m_normals.Add(new Vector3f(float.Parse(tokens[1]),
								float.Parse(tokens[2]),
								float.Parse(tokens[3])));
						
					}
					else if (tokens[0].Equals("f"))
					{
						for (int i = 0; i < tokens.Length - 3; i++)
						{
							m_indices.Add(ParseOBJIndex(tokens[1]));
							m_indices.Add(ParseOBJIndex(tokens[2 + i]));
							m_indices.Add(ParseOBJIndex(tokens[3 + i]));
						}
					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				Environment.Exit(1);
				//System.exit(1);
			}
		}

		public IndexedModel ToIndexedModel()
		{
			IndexedModel result = new IndexedModel();
			IndexedModel normalModel = new IndexedModel();
			Dictionary<OBJIndex, int> resultIndexMap = new Dictionary<OBJIndex, int>();
			Dictionary<int, int> normalIndexMap = new Dictionary<int, int>();
			Dictionary<int, int> indexMap = new Dictionary<int, int>();

			for (int i = 0; i < m_indices.Count(); i++)
			{
				OBJIndex currentIndex = m_indices[i];

				Vector3f currentPosition = m_positions[currentIndex.VertexIndex];
				Vector2f currentTexCoord;
				Vector3f currentNormal;

				if (m_hasTexCoords)
					currentTexCoord = m_texCoords[currentIndex.TexCoordIndex];
				else
					currentTexCoord = new Vector2f(0, 0);

				if (m_hasNormals)
					currentNormal = m_normals[currentIndex.NormalIndex];
				else
					currentNormal = new Vector3f(0, 0, 0);

				int modelVertexIndex = resultIndexMap[currentIndex];

				if (modelVertexIndex == null)
				{
					modelVertexIndex = result.Positions.Count();
					resultIndexMap.Add(currentIndex, modelVertexIndex);

					result.Positions.Add(currentPosition);
					result.TexCoords.Add(currentTexCoord);
					if (m_hasNormals)
						result.Normals.Add(currentNormal);
				}

				int normalModelIndex = normalIndexMap[currentIndex.VertexIndex];

				if (normalModelIndex == null)
				{
					normalModelIndex = normalModel.Positions.Count();
					normalIndexMap.Add(currentIndex.VertexIndex, normalModelIndex);

					normalModel.Positions.Add(currentPosition);
					normalModel.TexCoords.Add(currentTexCoord);
					normalModel.Normals.Add(currentNormal);
					normalModel.Tangents.Add(new Vector3f(0, 0, 0));
				}

				result.Indices.Add(modelVertexIndex);
				normalModel.Indices.Add(normalModelIndex);
				indexMap.Add(modelVertexIndex, normalModelIndex);
			}

			if (!m_hasNormals)
			{
				normalModel.CalculateNormals();

				for (int i = 0; i < result.Positions.Count(); i++)
					result.Normals.Add(normalModel.Normals[indexMap[i]]);
			}

			normalModel.CalculateTangents();

			for (int i = 0; i < result.Positions.Count(); i++)
				result.Tangents.Add(normalModel.Tangents[indexMap[i]]);

			//		for(int i = 0; i < result.GetTexCoords().size(); i++)
			//			result.GetTexCoords().Get(i).SetY(1.0f - result.GetTexCoords().Get(i).GetY());

			return result;
		}

		private OBJIndex ParseOBJIndex(String token)
		{
			string[] values = token.Split('/');

			OBJIndex result = new OBJIndex();
			result.VertexIndex = (int.Parse(values[0]) - 1);

			if (values.Length > 1)
			{
				if (!values[1].IsEmpty())
				{
					m_hasTexCoords = true;
					result.TexCoordIndex = (int.Parse(values[1]) - 1);
				}

				if (values.Length > 2)
				{
					m_hasNormals = true;
					result.NormalIndex = (int.Parse(values[2]) - 1);
				}
			}

			return result;
		}
	}
}
