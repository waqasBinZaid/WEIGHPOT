#include <ApplicationServices/ApplicationServices.h>
#include "rockey.h"
RockeyPtr rockey;


static OSErr CreateBundleFromFSRef(FSRef *theRef, CFBundleRef *theBundle)
{
//	FSRef theRef;
	CFURLRef theBundleURL = NULL;
	
	/* Turn the FSRef into a CFURL */
	theBundleURL = CFURLCreateFromFSRef(kCFAllocatorSystemDefault, theRef);
	if (theBundleURL != NULL)
	{
		/* Turn the CFURL into a bundle reference */
		*theBundle = CFBundleCreate(kCFAllocatorSystemDefault, theBundleURL);
		CFRelease(theBundleURL);
	}
	
	return 0;
}
CFBundleRef GetRockey(CFBundleRef theBundle,RockeyPtr* rockeycall)
{
	OSErr theErr;
	Boolean isLoaded;
	FSRef theRef;
	/* Start with no bundle */
	theBundle = NULL;
	
	printf("call getrockey.\n");
	theErr = FSPathMakeRef("/System/Library/Rockey/Rockey4ndBundle.bundle",&theRef,NULL);
	if (theErr == noErr)
		theErr = CreateBundleFromFSRef(&theRef, &theBundle);

	if ((theErr == noErr) && (theBundle != NULL))
	{
		isLoaded = CFBundleLoadExecutable(theBundle);
		
		if (isLoaded)
		{
			/* Lookup the function in the bundle by name */
			*rockeycall = (void *) CFBundleGetFunctionPointerForName(theBundle, CFSTR("Rockey"));
			
			/* Call the function if it was found */
			if (*rockeycall != NULL)
			{
				printf("call rockey succeed\n");
				return theBundle;
			
			/* Dispose of the function pointer to the bundled Mach-O routine */
			}
			CFBundleUnloadExecutable(theBundle);
			
		}
		else
			CFRelease(theBundle);

	}
	return NULL;
}
void FreeRockey(CFBundleRef theBundle,RockeyPtr rockeycall)
{
	if(rockeycall)
		DisposePtr((Ptr) rockeycall);
	if(theBundle)
	{
	 	CFBundleUnloadExecutable(theBundle);
		CFRelease(theBundle);
	}
}
