## Description
Executes the extraction rules collection provided under this WebAutomation and return or populates the data collected. Due to the nature of this action, it _**supports only XPath locator**_. This action will executes the extraction on the _**page Source**_.

> If you set the extraction rule with ```PageSource = true;``` (not default), the data will be extracted from the entire source (```<HTML>```). If not set or set ```PageSource = false;```, the extratcion will take plase on the page ```<BODY>``` after all client side code was loaded.

> The page Source is the ```Source HTML``` code received when the page is called back from the server before executing any client side code (what you see when ```view page source``` is open).

## Scope
**Web**, **Mobile Web**.

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