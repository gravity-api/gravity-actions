## Description
Executes the extraction rules collection provided under this WebAutomation and return or populates the data collected. Due to the nature of this action, it _**supports only XPath locator**_. This action will executes the extraction on the _**page Source**_.

> You must mark the extraction rule with ```PageSource = false;``` (default) in order for this plugin to collect your extractions.

> The page Source is the ```HTML``` code received when the page is called back from the server and after executing all client side code (what you see when ```inspect element``` is open).

## Scope
**Web**, **Mobile Web**, **Mobile Native**.

## Properties
| Property             | Description                                           |
|----------------------|-------------------------------------------------------|
| _**argument**_       | Plugin conditions and additional information.         |

## Command Line Arguments (CLI)
### _extractions_
Comma separated, zero-based index of the extractions to execute, under your extraction rules collection. Leaving this value empty, will execute all ```PageSource``` based extractions. Each extraction will be returned under a separate extraction results.

| Value          | Description                                                                             |
|----------------|-----------------------------------------------------------------------------------------|
| _**0,1,4**_    | Executes extraction rules 0, 1 and 4 if their ```PageSource``` attribute is ```false``` |

## W3C Web Driver Protocol
_None_