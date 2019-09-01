# -*- coding:gb2312 -*-
import is3

from System.Collections.ObjectModel import ObservableCollection
from System.Windows.Media import Colors

##  ���ع���
def LoadPrj():
    print("---Load Project---")
    is3.mainframe.LoadProject('iS3Demo.xml')     #--->ע�����ع�������XML�ļ����滻ExampleΪ��Ӧ�Ĺ�������
    is3.prj = is3.mainframe.prj
    is3.MainframeWrapper.loadDomainPanels()
    return

##  ���ع�����ά   
def add3dview():
    print ("--- Add 3D map ---")
    #--->ע��������ά������.unity3d�ļ����滻�ɶ�Ӧ�Ĺ���ID
    is3.addView3d('Map3D', 'iS3Demo.unity3d')    
    return

##  ���ع��̶�ά��ͼ
def addBaseMap():
    print("--- Add base map ---")
    #--->ע�����õ�ͼ���ƣ���ͼ����ʾ��Χ��XMin��YMin��XMax��YMax��
    emap = is3.EngineeringMap('BaseMap',12661378,-82283,12867753,13760, 0.1)  
    #--->ע�����õ�ͼ����Ϊƽ��ͼ�����Ϳ�ѡFootPrintMap��ƽ�棩��GeneralProfileMap�����棩  
    emap.MapType = is3.EngineeringMapType.FootPrintMap                             
    #--->ע�����õ�ͼ�ļ����滻ExampleΪ��Ӧ�Ĺ�������
    emap.LocalTileFileName1 = 'iS3DemoTest.tpk'                                        
    #--->ע�����õ�ͼ���ݿ��ļ����滻ExampleΪ��Ӧ�Ĺ�������
    emap.LocalGeoDbFileName = 'iS3Demo.geodatabase'                                
    #--->ע����ӵ�ͼ��iS3��
    viewWP = is3.MainframeWrapper.addView(emap)                                    
    #--->ע������ͼ���ݿ�������Ҫ����ʽ��ӵ���ͼ��
    addMapLayer(viewWP)                                                            
    return

##  ���ض�ά���ݿ�Ԫ�ص����̵�ͼ��
def addMapLayer(viewWP): 
    layerDef = is3.LayerDef()
    layerDef.Name = 'MonPoint'                                                     
    #--->ע��ԭ��ArcMap�ڴ��ʱ��Ӧ��ͼ������
    layerDef.GeometryType = is3.GeometryType.Point                               
    #--->ע��ͼ��Ҫ�صı�����ʽ��Point(��),Polyline(��),Polygon(��)
    layerDef.Color = Colors.Green                                                  
    #--->ע��ͼ��Ҫ�ص���ɫ
    layerDef.FillStyle = is3.SimpleFillStyle.Solid
    layerDef.EnableLabel = True
    layerDef.LabelTextExpression = '[Name]'
    layerWrapper = is3.addGdbLayer(viewWP, layerDef)
    return

def Load():
    LoadPrj()                                                                     #--->ע�����ع���
    addBaseMap()                                                                  #--->ע�����ع��̶�ά
    add3dview()                                                                   #--->ע�����ع�����ά


##�������
Load()
