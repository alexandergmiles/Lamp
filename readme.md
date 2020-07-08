# Lamp V0.I
The Lamp project looks to provide an API to control TP-Link Kasa bulbs on your network. For this to work, you need to be aware of the devices IP address, and have set it up via the Kasa app. This in time will be integrated into the platform.

As well as providing simple control for the bulbs, a data scraping platform will run in the background, exposing a stream of data for the bulb. 

### LampEngine task list
The Kasa range has various types of bulbs. We used the differentiation between products as our classes within the library.  
#### Base bulb
- [x] Connect app to bulb
- [x] Get bulb info
- [x] Set power state (on/off)
- [x] Get current colour
- [x] Set brightness
- [ ] Scheduler
- [ ] Bulb groups
- [ ] Saving bulb configurations locally
- [ ] Analytics of bulb being collected
- [ ] Data collection

#### Bulb utilities
- [ ] Connect bulb to network
- [ ] Scan for any connected bulbs
- [ ] Web app portal to control everything


#### Basic Usage
```CSharp
//Using a string for sake of ease - I don't know what class of address or what subnet you're putting it on
var networkAddress = "192.168.x.xxx";

//Creates the bulb
IBulb bulb = new Bulb(networkAddress);

//Returns info on the current bulb
var bulbInfo = bulb.GetBulbInfo();

//Let's set the Brightness of the bulb
//This will set the brightness level of the bulb to 10%. It will also retain the current colour
var brightnessResult = lamp.SetBrightness(10);
```

Command | Usage | Parameters |  Returns
--------|-------|------------|----------
Reboot  | Bulb.Reboot(delay) | Delay - an int of seconds to delay reboot | Operation result
GetColour |Bulb.GetColour() | None |LightState
