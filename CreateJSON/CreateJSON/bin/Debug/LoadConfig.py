import json
import subprocess
import time

import xml.etree.ElementTree as ET
tree = ET.parse('DeviceConfig.xml')
root = tree.getroot()
time.sleep(5)
print 'hello'
for nodes in root.findall('device'):    
    uniqueIdentifier = nodes.find('uniqueIdentifier')    
    manufacturer = nodes.find('manufacturer')    
    deviceName = nodes.find('deviceName')    
    manufactureDate = nodes.find('manufactureDate')
    expiryDate = nodes.find('expiryDate')
    deviceModel = nodes.find('deviceModel')    
    deviceType = nodes.find('deviceType')    
    serialNo = nodes.find('serialNo')    
    deviceDataFormat = nodes.find('deviceDataFormat')    
    connector = nodes.find('connector')
    status = nodes.find('status')
    organization = nodes.find('organization')
    protocol = nodes.find('protocol')
    dateFormat = nodes.find('dateFormat')
    dateSource = nodes.find('dateSource')
    timeZone = nodes.find('timeZone')
    deviceVersion=nodes.find('deviceVersion')
    software_rev=nodes.find('software_rev')
VsCaptureData = {
    'uniqueIdentifier': uniqueIdentifier.text,
    'manufacturer': manufacturer.text,
    'deviceName': deviceName.text,
    'manufactureDate': manufactureDate.text,
    'expiryDate': expiryDate.text,
    'deviceModel': deviceModel.text,
    'deviceType': deviceType.text,
    'serialNo': serialNo.text,
    'deviceDataFormat': deviceDataFormat.text,
    'connector': connector.text,
    'status': status.text,
    'organization': organization.text,
    'protocol': protocol.text,
    'dateFormat' : dateFormat.text,
    'dateSource' : dateSource.text,
    'timeZone' : timeZone.text,
    'deviceVersion':deviceVersion.text,
    'software_rev' :software_rev.text
}
print 'hello'
jsonObject = json.dumps(VsCaptureData)
print jsonObject
print uniqueIdentifier.text,manufacturer.text,deviceName.text,manufactureDate.text,expiryDate.text,deviceModel.text,deviceType.text,serialNo.text,deviceDataFormat.text,connector.text,protocol.text 
subprocess.call(['CreateJSON.exe',jsonObject])
#subprocess.call(['java', '-jar', 'PublishHL7NK.jar', jsonObject])
#f = open("logfile.txt","w")
#subprocess.call(['mono','--gc=sgen','/home/pi/MindrayConfig/VSCaptureMRay.exe',jsonObject], stdout=f)
