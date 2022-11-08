using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using UnityEditor;
using UnityEngine;

namespace AosSdk.Core.Utils.EditorUtils
{
#if UNITY_EDITOR
    [ExecuteAlways]
    public class AosDescriptor : MonoBehaviour
    {
        [MenuItem("AOS/Generate Aos scene description XML")]
        private static void CollectAosData()
        {
            var objectIds = new Dictionary<string, string>();
            
            var aosSceneDescription = new List<AosObjectType>();

            var aosObjects = FindObjectsOfType<AosObjectBase>();
            foreach (var obj in aosObjects)
            {
                foreach (var pair in objectIds.Where(pair => pair.Value == obj.ObjectId))
                {
                    EditorUtility.DisplayDialog("XML generate error", $"Failed to generate AOS Descriptor XML: GameObject {obj.name} ObjectId is same as {pair.Key}'s ObjectId", "OK");
                    return;
                }

                if (obj.ObjectId == string.Empty)
                {
                    EditorUtility.DisplayDialog("XML generate error", $"Failed to generate AOS Descriptor XML: GameObject {obj.name} has empty ObjectId", "OK");
                    return;
                }
                
                objectIds.Add(obj.name, obj.ObjectId);
                
                var aosActions = new List<AosActionType>();
                var aosEvents = new List<AosEventType>();

                var aosType = obj.GetType();

                if (!(Attribute.GetCustomAttribute(aosType, typeof(AosObject)) is AosObject aosObjectAttribute))
                {
                    continue;
                }

                var objectName = aosObjectAttribute.ObjectName;

                foreach (var aosMethod in aosType.GetMethods())
                {
                    if (!(Attribute.GetCustomAttribute(aosMethod, typeof(AosAction)) is AosAction aosActionAttribute))
                    {
                        continue;
                    }

                    var actionReturnType = aosMethod.ReturnType.ToString();

                    aosActions.Add(new AosActionType
                    {
                        methodDescription = aosActionAttribute.ActionName,
                        methodName = aosMethod.Name,
                        returnType = actionReturnType.Substring(actionReturnType.IndexOf('.') + 1),
                        parameters = aosMethod.GetParameters()
                            .Select(parameter => new AosActionParameterInfoType
                            {
                                parameterName = parameter.Name,
                                parameterType = parameter.ParameterType.Name,
                                parameterDescription =
                                    Attribute.GetCustomAttribute(parameter, typeof(AosParameter)) is
                                        AosParameter aosParameterAttribute
                                        ? aosParameterAttribute.ParameterName
                                        : null
                            })
                            .ToArray()
                    });
                }

                foreach (var aosEvent in aosType.GetEvents())
                {
                    if (!(Attribute.GetCustomAttribute(aosEvent, typeof(AosEvent)) is AosEvent aosEventAttribute))
                    {
                        continue;
                    }

                    aosEvents.Add(new AosEventType
                    {
                        eventDescription = aosEventAttribute.EventName, eventName = aosEvent.Name
                    });
                }

                aosSceneDescription.Add(new AosObjectType
                {
                    aosObjectId = obj.ObjectId,
                    aosObjectDescription = objectName,
                    aosObjectActions = aosActions.ToArray(),
                    aosObjectEvents = aosEvents.ToArray()
                });
            }

            GenerateXmlFile(aosSceneDescription);
        }

        [MenuItem("AOS/Clean Aos objects id")]
        private static void CleanAosObjectsId()
        {
            foreach (var obj in FindObjectsOfType<AosObjectBase>())
            {
                obj.ObjectId = string.Empty;
            }
        }

        private static void GenerateXmlFile(List<AosObjectType> sceneDescription)
        {
            var path = $"{Application.dataPath}/AOSDescriptor.xml";
            var writer = new XmlTextWriter(new FileStream(path, FileMode.Create), Encoding.UTF8);

            try
            {
                var serializer = new XmlSerializer(typeof(List<AosObjectType>));
                serializer.Serialize(writer, sceneDescription);
                Debug.Log($"Aos scene description saved at {path}");
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                throw;
            }
            finally
            {
                writer.Close();
            }
        }
    }
#endif
}