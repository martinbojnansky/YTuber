﻿"use strict";
/*!
  Copyright (C) Microsoft. All rights reserved.
  This library is supported for use in Windows Store apps only.
*/
function setScreenSize(n,t){var r=parseInt(n),i;r=r===NaN?-1:r;i=parseInt(t);i=i===NaN?-1:i;Ormma._setScreenSize(r,i)}function invokeInit(){Ormma.getState()==ORMMA_EVENT_LOADING&&Ormma._setState(ORMMA_STATE_DEFAULT);Ormma._init()}function reportError(n,t){Ormma._throwError(n,t)}function setOrmmaState(n){Ormma._setState(n)}function setOrmmaPlacementType(n){Ormma._setPlacementType(n)}function setOrmmaLocale(n){Ormma._setLocale(n)}function setSize(n,t){var r=parseInt(n),i;r=r===NaN?-1:r;i=parseInt(t);i=i===NaN?-1:i;Ormma._setSize(r,i)}function setMaxSize(n,t){var r=parseInt(n),i;r=r===NaN?-1:r;i=parseInt(t);i=i===NaN?-1:i;Ormma._setMaxSize(r,i)}function setOrientation(n){var t=parseInt(n);t=t===NaN?-1:t;Ormma._setOrientation(t)}function fireShake(){Ormma._shake()}function updateTiltCoords(n,t,i){Ormma._tiltChange({x:n,y:t,z:i})}function fireViewable(n){var t=stringToBoolean(n);Ormma._viewableChange(t)}function setCapability(n,t){Ormma._setCapability(n,stringToBoolean(t))}function stringToBoolean(n){return n.toLowerCase()==="true"?!0:!1}function fireResponse(n,t){var i={url:escape(n),response:escape(t)};Ormma._sendResponse(i)}function setNetwork(n){Ormma._setNetwork(n)}function setSdkVersion(n,t,i){Ormma._setSdkVersion(n,t,i)}function fireClickEvent(){Ormma._clicked()}var ORMMA_STATE_UNKNOWN="unknown",ORMMA_STATE_HIDDEN="hidden",ORMMA_STATE_DEFAULT="default",ORMMA_STATE_EXPANDED="expanded",ORMMA_STATE_RESIZED="resized",ORMMA_STATE_SUSPENDED="suspended",ORMMA_EVENT_ERROR="error",ORMMA_EVENT_HEADING_CHANGE="headingChange",ORMMA_EVENT_KEYBOARD_CHANGE="keyboardChange",ORMMA_EVENT_LOCATION_CHANGE="locationChange",ORMMA_EVENT_NETWORK_CHANGE="networkChange",ORMMA_EVENT_ORIENTATION_CHANGE="orientationChange",ORMMA_EVENT_VIEWABLE_CHANGE="viewableChange",ORMMA_EVENT_READY="ready",ORMMA_EVENT_LOADING="loading",ORMMA_EVENT_RESPONSE="response",ORMMA_EVENT_SCREEN_CHANGE="screenChange",ORMMA_EVENT_SHAKE="shake",ORMMA_EVENT_SIZE_CHANGE="sizeChange",ORMMA_EVENT_STATE_CHANGE="stateChange",ORMMA_EVENT_TILT_CHANGE="tiltChange",MAPLE_EVENT_CLICK="click",ORMMA_FEATURE_SCREEN="screen",ORMMA_FEATURE_ORIENTATION="orientation",ORMMA_FEATURE_LOCATION="location",ORMMA_FEATURE_SMS="sms",ORMMA_FEATURE_PHONE="phone",ORMMA_FEATURE_EMAIL="email",ORMMA_FEATURE_HEADING="heading",ORMMA_FEATURE_SHAKE="shake",ORMMA_FEATURE_TILT="tilt",ORMMA_FEATURE_NETWORK="network",ORMMA_FEATURE_CALENDAR="calendar",ORMMA_FEATURE_CAMERA="camera",ORMMA_FEATURE_MAP="map",ORMMA_FEATURE_AUDIO="audio",ORMMA_FEATURE_VIDEO="video",ORMMA_FEATURE_LEVEL1="level-1",ORMMA_FEATURE_LEVEL2="level-2",ORMMA_FEATURE_LEVEL3="level-3",ORMMA_FEATURE_INLINEVIDEO="inlineVideo",ORMMA_API_VERSION="1.1.0",MRAID_API_VERSION="1.0",MAPLE_MAX_STATE_DATA_SIZE=65536,ORMMA_PLACEMENTTYPE_INLINE="inline",ORMMA_PLACEMENTTYPE_INTERSTITIAL="interstitial",MSG_TYPE_ADRENDERED="rendered",MSG_TYPE_OPEN="web",MSG_TYPE_EXPAND="expand",MSG_TYPE_CLOSE="close",MSG_TYPE_RESIZE="resize",MSG_TYPE_HIDE="hide",MSG_TYPE_SHOW="show",MSG_TYPE_SETEXPANDPROPERTIES="setexpandproperties",MSG_TYPE_SETUSERENGAGED="setuserengaged",MSG_TYPE_TILT="tilt",MSG_TYPE_SHAKE="shake",MSG_TYPE_LISTENER="listener",MSG_TYPE_VALUESTART="start",MSG_TYPE_VALUESTOP="stop",MSG_TYPE_GETTILT="gettilt",MSG_TYPE_GETORIENTATION="getorientation",MSG_TYPE_REFRESH="refresh",MSG_TYPE_REQUEST="request",MSG_TYPE_VIEWABLECHANGE="viewableChange",MSG_TYPE_ERROR="error",MSG_TYPE_USECUSTOMCLOSE="usecustomclose";(function(){function f(){this.listeners=[]}function n(){}function u(n){return typeof n=="undefined"||n===null||n<=0?!1:!0}function t(n){window.msAdSDK&&typeof window.msAdSDK.notify=="function"?window.msAdSDK.notify(n):window.external.notify(n)}function r(t,r){if(n("raising event "+t+" with data "+r),i.listeners[t]!==null&&typeof i.listeners[t]!="undefined")try{var f=i.listeners[t].slice(),u;switch(t){case ORMMA_EVENT_ERROR:for(u=0;u<f.length;u++)f[u](r.message,r.action);break;case ORMMA_EVENT_NETWORK_CHANGE:for(u=0;u<f.length;u++)f[u](r.online,r.connection);break;case ORMMA_EVENT_ORIENTATION_CHANGE:for(u=0;u<f.length;u++)f[u](r);break;case ORMMA_EVENT_READY:for(u=0;u<f.length;u++)f[u]();break;case ORMMA_EVENT_SCREEN_CHANGE:for(u=0;u<f.length;u++)f[u](r.width,r.height);break;case ORMMA_EVENT_SHAKE:for(u=0;u<f.length;u++)f[u]();break;case ORMMA_EVENT_SIZE_CHANGE:for(u=0;u<f.length;u++)f[u](r.width,r.height);break;case ORMMA_EVENT_STATE_CHANGE:for(u=0;u<f.length;u++)f[u](r);break;case ORMMA_EVENT_TILT_CHANGE:for(u=0;u<f.length;u++)f[u](r.x,r.y,r.z);break;case ORMMA_EVENT_VIEWABLE_CHANGE:for(u=0;u<f.length;u++)f[u](r);break;case ORMMA_EVENT_RESPONSE:for(u=0;u<f.length;u++)f[u](unescape(r.url),unescape(r.response));break;case MAPLE_EVENT_CLICK:for(u=0;u<f.length;u++)f[u]();break;case ORMMA_EVENT_HEADING_CHANGE:case ORMMA_EVENT_KEYBOARD_CHANGE:case ORMMA_EVENT_LOCATION_CHANGE:default:return!1}}catch(e){n("exception thrown while firing event: "+e.message)}else n("no listeners for event "+t)}var i=new f;window.ORMMA=window.ormma=window.Ormma=window.MAPLE=window.maple=window.Maple={_maxSize:{width:0,height:0},_dimensions:{},_defaultDimensions:{},_screenSize:null,_tiltCapability:!1,_shakeCapability:!1,_expandProperties:{width:0,height:0,useCustomClose:!1,lockOrientation:!1,isModal:!0},_shakeProperties:{},_resizeProperties:{transition:"none"},_placementType:ORMMA_PLACEMENTTYPE_INLINE,_state:ORMMA_EVENT_LOADING,_locale:null,_location:null,_orientation:-1,_lastTiltCoords:{x:0,y:0,z:0},_lastNetworkState:ORMMA_STATE_UNKNOWN,_sdkInfo:null,_msOrientationModes:{portaitPrimary:{ieProperty:"portrait-primary",orientationDegrees:0},landscapePrimary:{ieProperty:"landscape-primary",orientationDegrees:270},portaitSecondary:{ieProperty:"portrait-secondary",orientationDegrees:180},landscapeSecondary:{ieProperty:"landscape-secondary",orientationDegrees:90},unknown:{ieProperty:"",orientationDegrees:-1}},addEventListener:function(r,u){if((i.listeners[r]===null||typeof i.listeners[r]=="undefined")&&(i.listeners[r]=[]),r!==ORMMA_EVENT_TILT_CHANGE||this._tiltCapability){if(r===ORMMA_EVENT_SHAKE&&!this._shakeCapability){this._throwError("shake","shake capability is not supported, event listener not added");return}}else{this._throwError("tilt","tilt capability is not supported, event listener not added");return}n("adding listener for "+r);i.listeners[r].push(u);r===ORMMA_EVENT_TILT_CHANGE?t(MSG_TYPE_TILT+":"+MSG_TYPE_LISTENER+"="+MSG_TYPE_VALUESTART):r===ORMMA_EVENT_SHAKE?t(MSG_TYPE_SHAKE+":"+MSG_TYPE_LISTENER+"="+MSG_TYPE_VALUESTART):r===ORMMA_EVENT_ORIENTATION_CHANGE?t(MSG_TYPE_GETORIENTATION+":"+MSG_TYPE_LISTENER+"="+MSG_TYPE_VALUESTART):r===ORMMA_EVENT_VIEWABLE_CHANGE&&t(MSG_TYPE_VIEWABLECHANGE+":"+MSG_TYPE_LISTENER+"="+MSG_TYPE_VALUESTART)},removeEventListener:function(r,u){if(n("removing listener for "+r),i.listeners[r]!==null&&typeof i.listeners[r]!="undefined"){if(u===undefined||u===null||u==="")i.listeners[r].length=0;else for(var e=i.listeners[r],f=0;f<e.length;f++)if(e[f]===u){e.splice(f,1);break}if(i.listeners[r]===null||typeof i.listeners[r]=="undefined"||i.listeners[r].length===0)if(r===ORMMA_EVENT_TILT_CHANGE){if(!this._tiltCapability){this._throwError("tilt","tilt capability is not supported, no event listener");return}n("stopping tilt device for event: "+r+" (no more client listeners)");t(MSG_TYPE_TILT+":"+MSG_TYPE_LISTENER+"="+MSG_TYPE_VALUESTOP)}else if(r===ORMMA_EVENT_SHAKE){if(!this._shakeCapability){this._throwError("shake","shake capability is not supported, no event listener");return}n("stopping shake device for event: "+r+" (no more client listeners)");t(MSG_TYPE_SHAKE+":"+MSG_TYPE_LISTENER+"="+MSG_TYPE_VALUESTOP)}else r===ORMMA_EVENT_ORIENTATION_CHANGE?(n("stopping orientation changed event: "+r+" (no more client listeners)"),t(MSG_TYPE_GETORIENTATION+":"+MSG_TYPE_LISTENER+"="+MSG_TYPE_VALUESTOP)):r===ORMMA_EVENT_VIEWABLE_CHANGE?(n("stopping viewable changed event: "+r+" (no more client listeners)"),t(MSG_TYPE_VIEWABLECHANGE+":"+MSG_TYPE_LISTENER+"="+MSG_TYPE_VALUESTOP)):r===MAPLE_EVENT_CLICK&&n("stopping clickEvent : "+r+" (no more client listeners)")}},close:function(){n("sending close request");t(MSG_TYPE_CLOSE)},expand:function(i,r){var u,f;if(!(this.getState()===ORMMA_STATE_DEFAULT||this.getState()===ORMMA_STATE_RESIZED)){reportError("expand","can only expand from resized or default states");return}(typeof i=="undefined"||i===null)&&(i="");(typeof r=="undefined"||r===null)&&(r=!0);typeof this._expandProperties=="object"&&(u=JSON.stringify(this._expandProperties),t(MSG_TYPE_SETEXPANDPROPERTIES+":"+u));n("sending expand request");f={url:i,islegacy:r};t(MSG_TYPE_EXPAND+":"+JSON.stringify(f))},getDefaultPosition:function(){return this._defaultDimensions},getExpandProperties:function(){return this._expandProperties?this._expandProperties:Ormma._expandProperties},getNetwork:function(){return this._lastNetworkState},getOrientation:function(){var n=this._msOrientationToOrmmaDegrees(window.screen.msOrientation);return this._orientation=this._orientation===n?this._orientation:n,this._orientation},getPlacementType:function(){return this._placementType},getScreenSize:function(){return this._screenSize===null&&(this._screenSize={width:screen.availWidth,height:screen.availHeight}),this._screenSize},getShakeProperties:function(){return this._shakeProperties},getSize:function(){return typeof this._dimensions=="undefined"&&(this._dimensions={}),this._dimensions},getState:function(){return this._state},getTilt:function(){if(n("calling getTilt"),!this._tiltCapability){this._throwError("tilt","tilt capability is not supported");return}return t(MSG_TYPE_TILT+":"+MSG_TYPE_GETTILT+"="+MSG_TYPE_REFRESH),this._lastTiltCoords},getVersion:function(){return ORMMA_API_VERSION},hide:function(){n("calling hide");t(MSG_TYPE_HIDE)},isViewable:function(){n("[not impl] isViewable called")},open:function(i){n("sending website request: "+i);var r=JSON.stringify({url:i});t(MSG_TYPE_OPEN+":"+r)},request:function(n,i){var r={url:n,display:typeof i!="undefined"&&i!==null?i:"ignore"};return t(MSG_TYPE_REQUEST+":"+JSON.stringify(r)),!1},resize:function(i,r){if(i>this._maxSize.width||i<0){this._throwError("resize","width is greater than max allowed width ("+this._maxSize.width+") or less than zero.");return}if(r>this._maxSize.height||r<0){this._throwError("resize","height is greater than max allowed height  ("+this._maxSize.height+") or less than zero.");return}n("calling resize:width="+i+"&height="+r);var u={width:i,height:r};t(MSG_TYPE_RESIZE+":"+JSON.stringify(u))},setExpandProperties:function(i){var r,f;this._expandProperties=typeof i!="object"?{}:i;r=typeof this.getScreenSize=="function"?this.getScreenSize():window.ormma.getScreenSize();this._expandProperties.width=u(this._expandProperties.width)&&this._expandProperties.width<r.width?this._expandProperties.width:r.width;this._expandProperties.height=u(this._expandProperties.height)&&this._expandProperties.height<r.height?this._expandProperties.height:r.height;this._expandProperties.useCustomClose=typeof this._expandProperties.useCustomClose=="undefined"?!1:this._expandProperties.useCustomClose;this._expandProperties.lockOrientation=typeof this._expandProperties.lockOrientation=="undefined"?!1:this._expandProperties.lockOrientation;this._expandProperties.isModal=!0;f=JSON.stringify(this._expandProperties);n("setting expand properties: "+f);t(MSG_TYPE_SETEXPANDPROPERTIES+":"+f)},setShakeProperties:function(t){this._shakeProperties=typeof t!="object"?{}:t;n("setting shake properties: "+JSON.stringify(this._shakeProperties))},show:function(){n("calling show");t(MSG_TYPE_SHOW)},supports:function(n){switch(n){case ORMMA_FEATURE_SCREEN:case ORMMA_FEATURE_ORIENTATION:case ORMMA_FEATURE_LEVEL1:case ORMMA_FEATURE_LEVEL2:case ORMMA_FEATURE_NETWORK:case ORMMA_FEATURE_INLINEVIDEO:return!0;case ORMMA_FEATURE_SHAKE:return this._shakeCapability;case ORMMA_FEATURE_TILT:return this._tiltCapability;case ORMMA_FEATURE_PHONE:case ORMMA_FEATURE_SMS:case ORMMA_FEATURE_EMAIL:case ORMMA_FEATURE_LOCATION:case ORMMA_FEATURE_HEADING:case ORMMA_FEATURE_CALENDAR:case ORMMA_FEATURE_AUDIO:case ORMMA_FEATURE_VIDEO:case ORMMA_FEATURE_LEVEL3:default:return!1}},useCustomClose:function(i){typeof i=="boolean"?(n("calling usecustomclose:"+i),typeof this._expandProperties=="object"&&(this._expandProperties.useCustomClose=i),t(MSG_TYPE_USECUSTOMCLOSE+":"+i)):reportError("useCustomClose","parameter 'flag' is not a boolean value")},adAnchorReady:function(){var n=document.getElementById("msMainAdDiv");n!==null&&(n.style.visibility="visible");t(MSG_TYPE_ADRENDERED)},adError:function(n,i){var r,u;r=typeof n=="string"&&n!==null?n:"unknown action";u=typeof i=="string"&&i!==null?i:"an unknown error occurred.";t(MSG_TYPE_ERROR+":"+JSON.stringify({action:r,message:u}))},getLocale:function(){if(this._locale!==null)return this._locale},getSdkVersion:function(){if(this._sdkInfo!==null)return this._sdkInfo},hasListenerForClickEvent:function(){return typeof i.listeners[MAPLE_EVENT_CLICK]!="undefined"&&i.listeners[MAPLE_EVENT_CLICK]!==null&&i.listeners[MAPLE_EVENT_CLICK].length>0?!0:!1},setUserEngaged:function(i){this._isUserEngaged=typeof i=="boolean"?i:!1;n("setting user engaged: "+this._isUserEngaged);t(MSG_TYPE_SETUSERENGAGED+":engaged="+this._isUserEngaged)},_clicked:function(){r(MAPLE_EVENT_CLICK,null)},_tiltChange:function(n){this._lastTiltCoords=n;r(ORMMA_EVENT_TILT_CHANGE,n)},_shake:function(){r(ORMMA_EVENT_SHAKE)},_viewableChange:function(n){window.mraid._isViewable=n;r(ORMMA_EVENT_VIEWABLE_CHANGE,n)},_sendResponse:function(n){r(ORMMA_EVENT_RESPONSE,n)},_throwError:function(n,t){var i={message:t,action:n};r(ORMMA_EVENT_ERROR,i)},_init:function(){n("Ormma is ready");r(ORMMA_EVENT_READY,null);typeof window.ORMMAReady=="function"&&(n("Ormma calling ORMMAReady()"),window.ORMMAReady())},_setOrientation:function(n){var t=this._orientation;this._orientation=n;t!==this._orientation&&r(ORMMA_EVENT_ORIENTATION_CHANGE,this._orientation)},_setPlacementType:function(n){n===ORMMA_PLACEMENTTYPE_INLINE?this._placementType=n:n===ORMMA_PLACEMENTTYPE_INTERSTITIAL&&(this._placementType=n)},_setState:function(n){var t=this._state;this._state=n;t!==n&&r(ORMMA_EVENT_STATE_CHANGE,this._state)},_setLocale:function(n){this._locale=n},_setSize:function(n,t){typeof this._dimensions=="undefined"&&(this._dimensions={});var i=typeof this._dimensions.width=="undefined"?0:this._dimensions.width,u=typeof this._dimensions.height=="undefined"?0:this._dimensions.height;this._dimensions.width=n;this._dimensions.height=t;(i!==n||u!==t)&&r(ORMMA_EVENT_SIZE_CHANGE,this._dimensions)},_setSdkVersion:function(n,t,i){this._sdkInfo={sdkVersion:n,client:t,runtimeType:i,appName:navigator.appName,appVersion:navigator.appVersion,userAgent:navigator.userAgent,platform:navigator.platform}},_setCapability:function(n,t){typeof t=="boolean"&&(n===ORMMA_FEATURE_TILT?this._tiltCapability=t:n===ORMMA_FEATURE_SHAKE&&(this._shakeCapability=t))},_setMaxSize:function(n,t){typeof this._maxSize=="undefined"&&(this._maxSize={});this._maxSize.width=n;this._maxSize.height=t},_setScreenSize:function(n,t){(this._screenSize===null||typeof this._screenSize=="undefined")&&(this._screenSize={});var i=typeof this._screenSize.width=="undefined"?0:this._screenSize.width,u=typeof this._screenSize.height=="undefined"?0:this._screenSize.height;this._screenSize.width=n;this._screenSize.height=t;this._expandProperties.width===i&&(this._expandProperties.width=n);this._expandProperties.height===u&&(this._expandProperties.height=t);this.setExpandProperties(this._expandProperties);(i!==this._screenSize.width||u!==this._screenSize.height)&&r(ORMMA_EVENT_SCREEN_CHANGE,this._screenSize)},_setNetwork:function(t){n("setting network state: "+t);typeof this._lastNetworkState=="undefined"&&(this._lastNetworkState="");t!==this._lastNetworkState&&(this._lastNetworkState=t,r(ORMMA_EVENT_NETWORK_CHANGE,{online:t!=="offline",connection:t}))},_msOrientationToOrmmaDegrees:function(n){switch(n){case this._msOrientationModes.landscapePrimary.ieProperty:return this._msOrientationModes.landscapePrimary.orientationDegrees;case this._msOrientationModes.landscapeSecondary.ieProperty:return this._msOrientationModes.landscapeSecondary.orientationDegrees;case this._msOrientationModes.portaitSecondary.ieProperty:return this._msOrientationModes.portaitSecondary.orientationDegrees;case this._msOrientationModes.portaitPrimary.ieProperty:return this._msOrientationModes.portaitPrimary.orientationDegrees;default:return this._msOrientationModes.unknown.orientationDegrees}}};window.mraid=window.MRAID=window.Mraid={_isViewable:!1,addEventListener:function(n,t){this._mraidSupportedEvts===null&&(this._mraidSupportedEvts=this._initEventList());this._mraidSupportedEvts[n]&&window.ormma.addEventListener(n,t)},removeEventListener:function(n,t){this._mraidSupportedEvts===null&&(this._mraidSupportedEvts=this._initEventList());this._mraidSupportedEvts[n]&&window.ormma.removeEventListener(n,t)},expand:function(n){typeof n=="undefined"||n===null?window.ormma.expand("",!1):window.ormma.expand(n,!1)},getState:function(){return window.ormma._state},getVersion:function(){return MRAID_API_VERSION},isViewable:function(){return window.mraid._isViewable},_mraidSupportedEvts:null,_initEventList:function(){var n=[];return n[ORMMA_EVENT_ERROR]=n[ORMMA_EVENT_READY]=n[ORMMA_EVENT_STATE_CHANGE]=n[ORMMA_EVENT_VIEWABLE_CHANGE]=!0,n},supports:function(n){return window.ormma.supports(n)},getSize:function(){return window.ormma.getSize()},open:function(n){return window.ormma.open(n)},close:function(){return window.ormma.close()},getExpandProperties:function(){return window.ormma.getExpandProperties()},getPlacementType:function(){return window.ormma.getPlacementType()},setExpandProperties:function(n){return window.ormma.setExpandProperties(n)},useCustomClose:function(n){return window.ormma.useCustomClose(n)}}})();
// SIG // Begin signature block
// SIG // MIIauwYJKoZIhvcNAQcCoIIarDCCGqgCAQExCzAJBgUr
// SIG // DgMCGgUAMGcGCisGAQQBgjcCAQSgWTBXMDIGCisGAQQB
// SIG // gjcCAR4wJAIBAQQQEODJBs441BGiowAQS9NQkAIBAAIB
// SIG // AAIBAAIBAAIBADAhMAkGBSsOAwIaBQAEFLdwjo6oSoC4
// SIG // ehr35YeyY1yn1FCsoIIVgjCCBMMwggOroAMCAQICEzMA
// SIG // AACP13YVuc1FinQAAAAAAI8wDQYJKoZIhvcNAQEFBQAw
// SIG // dzELMAkGA1UEBhMCVVMxEzARBgNVBAgTCldhc2hpbmd0
// SIG // b24xEDAOBgNVBAcTB1JlZG1vbmQxHjAcBgNVBAoTFU1p
// SIG // Y3Jvc29mdCBDb3Jwb3JhdGlvbjEhMB8GA1UEAxMYTWlj
// SIG // cm9zb2Z0IFRpbWUtU3RhbXAgUENBMB4XDTE1MTAwNzE4
// SIG // MTQwNVoXDTE3MDEwNzE4MTQwNVowgbMxCzAJBgNVBAYT
// SIG // AlVTMRMwEQYDVQQIEwpXYXNoaW5ndG9uMRAwDgYDVQQH
// SIG // EwdSZWRtb25kMR4wHAYDVQQKExVNaWNyb3NvZnQgQ29y
// SIG // cG9yYXRpb24xDTALBgNVBAsTBE1PUFIxJzAlBgNVBAsT
// SIG // Hm5DaXBoZXIgRFNFIEVTTjpGNTI4LTM3NzctOEE3NjEl
// SIG // MCMGA1UEAxMcTWljcm9zb2Z0IFRpbWUtU3RhbXAgU2Vy
// SIG // dmljZTCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoC
// SIG // ggEBAKSXCL1GVhhx/mnpXuaSknagHAzBH/jAyusxgKPz
// SIG // FF/HbeQC0cvShTFODRwBkvP5fKG6gHayNPaIIvm+OXKJ
// SIG // D4X+BUox/RcZyOHygOQ9c786kkmb9g6Pwz8EwAZ9ICQy
// SIG // BIPfHlq3030okgXiIrQiCOMWK3EM5izXToSu3PbOGtve
// SIG // 79mKErK+ssMLIthgk0e5X+t/Q0Kb1HsFHgII0uXYn08y
// SIG // TmOj9c2mYWi3tyQX0Gg/1zcCkVB2dYCqWR0egSn0gNUK
// SIG // 9svEiB+kp46DT+YP4tUiS3vARbsEbpHRJAEpDzJYs01V
// SIG // pNIigwq6tiuCam+EyHQun7cZ5Sy00OqNdBoKLN8CAwEA
// SIG // AaOCAQkwggEFMB0GA1UdDgQWBBRAgoBoYnKeYCAGmN8c
// SIG // enak4MI7hzAfBgNVHSMEGDAWgBQjNPjZUkZwCu1A+3b7
// SIG // syuwwzWzDzBUBgNVHR8ETTBLMEmgR6BFhkNodHRwOi8v
// SIG // Y3JsLm1pY3Jvc29mdC5jb20vcGtpL2NybC9wcm9kdWN0
// SIG // cy9NaWNyb3NvZnRUaW1lU3RhbXBQQ0EuY3JsMFgGCCsG
// SIG // AQUFBwEBBEwwSjBIBggrBgEFBQcwAoY8aHR0cDovL3d3
// SIG // dy5taWNyb3NvZnQuY29tL3BraS9jZXJ0cy9NaWNyb3Nv
// SIG // ZnRUaW1lU3RhbXBQQ0EuY3J0MBMGA1UdJQQMMAoGCCsG
// SIG // AQUFBwMIMA0GCSqGSIb3DQEBBQUAA4IBAQBLLLMnOQ9u
// SIG // ElE0nhqb0/qeH6aHALv5as8qj/FBmUERjn49BKm6lUN5
// SIG // SRTehiTCQsPnqh4Tj6NBhRMiHGh/VEGImNuVFcoloGaP
// SIG // 9j6/7xQFdO7l4d5F8C3r96brxB2vidsCr7qv4MRomHB1
// SIG // dv5C9BC3S3+53jYRYmRgqB7hNJn+ZVEhgJYT+QIXfpzv
// SIG // WFWGhex8GW48YjGxoLEVUjJsYhK7+kPsiZj9VnONRUOw
// SIG // lksxbV2vhrWJljS01VXFdT9e7jm+4bVzWnKp9/bhNfrL
// SIG // CWvZpcE90nx2EjuVDXuDMBfW3cnEiFXPKcTR3T25ysNx
// SIG // yiP4Vq46cmmuqV//QmxpnZTbMIIE7DCCA9SgAwIBAgIT
// SIG // MwAAAQosea7XeXumrAABAAABCjANBgkqhkiG9w0BAQUF
// SIG // ADB5MQswCQYDVQQGEwJVUzETMBEGA1UECBMKV2FzaGlu
// SIG // Z3RvbjEQMA4GA1UEBxMHUmVkbW9uZDEeMBwGA1UEChMV
// SIG // TWljcm9zb2Z0IENvcnBvcmF0aW9uMSMwIQYDVQQDExpN
// SIG // aWNyb3NvZnQgQ29kZSBTaWduaW5nIFBDQTAeFw0xNTA2
// SIG // MDQxNzQyNDVaFw0xNjA5MDQxNzQyNDVaMIGDMQswCQYD
// SIG // VQQGEwJVUzETMBEGA1UECBMKV2FzaGluZ3RvbjEQMA4G
// SIG // A1UEBxMHUmVkbW9uZDEeMBwGA1UEChMVTWljcm9zb2Z0
// SIG // IENvcnBvcmF0aW9uMQ0wCwYDVQQLEwRNT1BSMR4wHAYD
// SIG // VQQDExVNaWNyb3NvZnQgQ29ycG9yYXRpb24wggEiMA0G
// SIG // CSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQCS/G82u+ED
// SIG // uSjWRtGiYbqlRvtjFj4u+UfSx+ztx5mxJlF1vdrMDwYU
// SIG // EaRsGZ7AX01UieRNUNiNzaFhpXcTmhyn7Q1096dWeego
// SIG // 91PSsXpj4PWUl7fs2Uf4bD3zJYizvArFBKeOfIVIdhxh
// SIG // RqoZxHpii8HCNar7WG/FYwuTSTCBG3vff3xPtEdtX3gc
// SIG // r7b3lhNS77nRTTnlc95ITjwUqpcNOcyLUeFc0Tvwjmfq
// SIG // MGCpTVqdQ73bI7rAD9dLEJ2cTfBRooSq5JynPdaj7woY
// SIG // SKj6sU6lmA5Lv/AU8wDIsEjWW/4414kRLQW6QwJPIgCW
// SIG // Ja19NW6EaKsgGDgo/hyiELGlAgMBAAGjggFgMIIBXDAT
// SIG // BgNVHSUEDDAKBggrBgEFBQcDAzAdBgNVHQ4EFgQUif4K
// SIG // MeomzeZtx5GRuZSMohhhNzQwUQYDVR0RBEowSKRGMEQx
// SIG // DTALBgNVBAsTBE1PUFIxMzAxBgNVBAUTKjMxNTk1KzA0
// SIG // MDc5MzUwLTE2ZmEtNGM2MC1iNmJmLTlkMmIxY2QwNTk4
// SIG // NDAfBgNVHSMEGDAWgBTLEejK0rQWWAHJNy4zFha5TJoK
// SIG // HzBWBgNVHR8ETzBNMEugSaBHhkVodHRwOi8vY3JsLm1p
// SIG // Y3Jvc29mdC5jb20vcGtpL2NybC9wcm9kdWN0cy9NaWND
// SIG // b2RTaWdQQ0FfMDgtMzEtMjAxMC5jcmwwWgYIKwYBBQUH
// SIG // AQEETjBMMEoGCCsGAQUFBzAChj5odHRwOi8vd3d3Lm1p
// SIG // Y3Jvc29mdC5jb20vcGtpL2NlcnRzL01pY0NvZFNpZ1BD
// SIG // QV8wOC0zMS0yMDEwLmNydDANBgkqhkiG9w0BAQUFAAOC
// SIG // AQEApqhTkd87Af5hXQZa62bwDNj32YTTAFEOENGk0Rco
// SIG // 54wzOCvYQ8YDi3XrM5L0qeJn/QLbpR1OQ0VdG0nj4E8W
// SIG // 8H6P8IgRyoKtpPumqV/1l2DIe8S/fJtp7R+CwfHNjnhL
// SIG // YvXXDRzXUxLWllLvNb0ZjqBAk6EKpS0WnMJGdAjr2/TY
// SIG // pUk2VBIRVQOzexb7R/77aPzARVziPxJ5M6LvgsXeQBkH
// SIG // 7hXFCptZBUGp0JeegZ4DW/xK4xouBaxQRy+M+nnYHiD4
// SIG // BfspaxgU+nIEtwunmmTsEV1PRUmNKRot+9C2CVNfNJTg
// SIG // FsS56nM16Ffv4esWwxjHBrM7z2GE4rZEiZSjhjCCBbww
// SIG // ggOkoAMCAQICCmEzJhoAAAAAADEwDQYJKoZIhvcNAQEF
// SIG // BQAwXzETMBEGCgmSJomT8ixkARkWA2NvbTEZMBcGCgmS
// SIG // JomT8ixkARkWCW1pY3Jvc29mdDEtMCsGA1UEAxMkTWlj
// SIG // cm9zb2Z0IFJvb3QgQ2VydGlmaWNhdGUgQXV0aG9yaXR5
// SIG // MB4XDTEwMDgzMTIyMTkzMloXDTIwMDgzMTIyMjkzMlow
// SIG // eTELMAkGA1UEBhMCVVMxEzARBgNVBAgTCldhc2hpbmd0
// SIG // b24xEDAOBgNVBAcTB1JlZG1vbmQxHjAcBgNVBAoTFU1p
// SIG // Y3Jvc29mdCBDb3Jwb3JhdGlvbjEjMCEGA1UEAxMaTWlj
// SIG // cm9zb2Z0IENvZGUgU2lnbmluZyBQQ0EwggEiMA0GCSqG
// SIG // SIb3DQEBAQUAA4IBDwAwggEKAoIBAQCycllcGTBkvx2a
// SIG // YCAgQpl2U2w+G9ZvzMvx6mv+lxYQ4N86dIMaty+gMuz/
// SIG // 3sJCTiPVcgDbNVcKicquIEn08GisTUuNpb15S3GbRwfa
// SIG // /SXfnXWIz6pzRH/XgdvzvfI2pMlcRdyvrT3gKGiXGqel
// SIG // cnNW8ReU5P01lHKg1nZfHndFg4U4FtBzWwW6Z1KNpbJp
// SIG // L9oZC/6SdCnidi9U3RQwWfjSjWL9y8lfRjFQuScT5EAw
// SIG // z3IpECgixzdOPaAyPZDNoTgGhVxOVoIoKgUyt0vXT2Pn
// SIG // 0i1i8UU956wIAPZGoZ7RW4wmU+h6qkryRs83PDietHdc
// SIG // pReejcsRj1Y8wawJXwPTAgMBAAGjggFeMIIBWjAPBgNV
// SIG // HRMBAf8EBTADAQH/MB0GA1UdDgQWBBTLEejK0rQWWAHJ
// SIG // Ny4zFha5TJoKHzALBgNVHQ8EBAMCAYYwEgYJKwYBBAGC
// SIG // NxUBBAUCAwEAATAjBgkrBgEEAYI3FQIEFgQU/dExTtMm
// SIG // ipXhmGA7qDFvpjy82C0wGQYJKwYBBAGCNxQCBAweCgBT
// SIG // AHUAYgBDAEEwHwYDVR0jBBgwFoAUDqyCYEBWJ5flJRP8
// SIG // KuEKU5VZ5KQwUAYDVR0fBEkwRzBFoEOgQYY/aHR0cDov
// SIG // L2NybC5taWNyb3NvZnQuY29tL3BraS9jcmwvcHJvZHVj
// SIG // dHMvbWljcm9zb2Z0cm9vdGNlcnQuY3JsMFQGCCsGAQUF
// SIG // BwEBBEgwRjBEBggrBgEFBQcwAoY4aHR0cDovL3d3dy5t
// SIG // aWNyb3NvZnQuY29tL3BraS9jZXJ0cy9NaWNyb3NvZnRS
// SIG // b290Q2VydC5jcnQwDQYJKoZIhvcNAQEFBQADggIBAFk5
// SIG // Pn8mRq/rb0CxMrVq6w4vbqhJ9+tfde1MOy3XQ60L/svp
// SIG // LTGjI8x8UJiAIV2sPS9MuqKoVpzjcLu4tPh5tUly9z7q
// SIG // QX/K4QwXaculnCAt+gtQxFbNLeNK0rxw56gNogOlVuC4
// SIG // iktX8pVCnPHz7+7jhh80PLhWmvBTI4UqpIIck+KUBx3y
// SIG // 4k74jKHK6BOlkU7IG9KPcpUqcW2bGvgc8FPWZ8wi/1wd
// SIG // zaKMvSeyeWNWRKJRzfnpo1hW3ZsCRUQvX/TartSCMm78
// SIG // pJUT5Otp56miLL7IKxAOZY6Z2/Wi+hImCWU4lPF6H0q7
// SIG // 0eFW6NB4lhhcyTUWX92THUmOLb6tNEQc7hAVGgBd3TVb
// SIG // Ic6YxwnuhQ6MT20OE049fClInHLR82zKwexwo1eSV32U
// SIG // jaAbSANa98+jZwp0pTbtLS8XyOZyNxL0b7E8Z4L5UrKN
// SIG // MxZlHg6K3RDeZPRvzkbU0xfpecQEtNP7LN8fip6sCvsT
// SIG // J0Ct5PnhqX9GuwdgR2VgQE6wQuxO7bN2edgKNAltHIAx
// SIG // H+IOVN3lofvlRxCtZJj/UBYufL8FIXrilUEnacOTj5XJ
// SIG // jdibIa4NXJzwoq6GaIMMai27dmsAHZat8hZ79haDJLmI
// SIG // z2qoRzEvmtzjcT3XAH5iR9HOiMm4GPoOco3Boz2vAkBq
// SIG // /2mbluIQqBC0N1AI1sM9MIIGBzCCA++gAwIBAgIKYRZo
// SIG // NAAAAAAAHDANBgkqhkiG9w0BAQUFADBfMRMwEQYKCZIm
// SIG // iZPyLGQBGRYDY29tMRkwFwYKCZImiZPyLGQBGRYJbWlj
// SIG // cm9zb2Z0MS0wKwYDVQQDEyRNaWNyb3NvZnQgUm9vdCBD
// SIG // ZXJ0aWZpY2F0ZSBBdXRob3JpdHkwHhcNMDcwNDAzMTI1
// SIG // MzA5WhcNMjEwNDAzMTMwMzA5WjB3MQswCQYDVQQGEwJV
// SIG // UzETMBEGA1UECBMKV2FzaGluZ3RvbjEQMA4GA1UEBxMH
// SIG // UmVkbW9uZDEeMBwGA1UEChMVTWljcm9zb2Z0IENvcnBv
// SIG // cmF0aW9uMSEwHwYDVQQDExhNaWNyb3NvZnQgVGltZS1T
// SIG // dGFtcCBQQ0EwggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAw
// SIG // ggEKAoIBAQCfoWyx39tIkip8ay4Z4b3i48WZUSNQrc7d
// SIG // GE4kD+7Rp9FMrXQwIBHrB9VUlRVJlBtCkq6YXDAm2gBr
// SIG // 6Hu97IkHD/cOBJjwicwfyzMkh53y9GccLPx754gd6udO
// SIG // o6HBI1PKjfpFzwnQXq/QsEIEovmmbJNn1yjcRlOwhtDl
// SIG // KEYuJ6yGT1VSDOQDLPtqkJAwbofzWTCd+n7Wl7PoIZd+
// SIG // +NIT8wi3U21StEWQn0gASkdmEScpZqiX5NMGgUqi+YSn
// SIG // EUcUCYKfhO1VeP4Bmh1QCIUAEDBG7bfeI0a7xC1Un68e
// SIG // eEExd8yb3zuDk6FhArUdDbH895uyAc4iS1T/+QXDwiAL
// SIG // AgMBAAGjggGrMIIBpzAPBgNVHRMBAf8EBTADAQH/MB0G
// SIG // A1UdDgQWBBQjNPjZUkZwCu1A+3b7syuwwzWzDzALBgNV
// SIG // HQ8EBAMCAYYwEAYJKwYBBAGCNxUBBAMCAQAwgZgGA1Ud
// SIG // IwSBkDCBjYAUDqyCYEBWJ5flJRP8KuEKU5VZ5KShY6Rh
// SIG // MF8xEzARBgoJkiaJk/IsZAEZFgNjb20xGTAXBgoJkiaJ
// SIG // k/IsZAEZFgltaWNyb3NvZnQxLTArBgNVBAMTJE1pY3Jv
// SIG // c29mdCBSb290IENlcnRpZmljYXRlIEF1dGhvcml0eYIQ
// SIG // ea0WoUqgpa1Mc1j0BxMuZTBQBgNVHR8ESTBHMEWgQ6BB
// SIG // hj9odHRwOi8vY3JsLm1pY3Jvc29mdC5jb20vcGtpL2Ny
// SIG // bC9wcm9kdWN0cy9taWNyb3NvZnRyb290Y2VydC5jcmww
// SIG // VAYIKwYBBQUHAQEESDBGMEQGCCsGAQUFBzAChjhodHRw
// SIG // Oi8vd3d3Lm1pY3Jvc29mdC5jb20vcGtpL2NlcnRzL01p
// SIG // Y3Jvc29mdFJvb3RDZXJ0LmNydDATBgNVHSUEDDAKBggr
// SIG // BgEFBQcDCDANBgkqhkiG9w0BAQUFAAOCAgEAEJeKw1wD
// SIG // RDbd6bStd9vOeVFNAbEudHFbbQwTq86+e4+4LtQSooxt
// SIG // YrhXAstOIBNQmd16QOJXu69YmhzhHQGGrLt48ovQ7DsB
// SIG // 7uK+jwoFyI1I4vBTFd1Pq5Lk541q1YDB5pTyBi+FA+mR
// SIG // KiQicPv2/OR4mS4N9wficLwYTp2OawpylbihOZxnLcVR
// SIG // DupiXD8WmIsgP+IHGjL5zDFKdjE9K3ILyOpwPf+FChPf
// SIG // wgphjvDXuBfrTot/xTUrXqO/67x9C0J71FNyIe4wyrt4
// SIG // ZVxbARcKFA7S2hSY9Ty5ZlizLS/n+YWGzFFW6J1wlGys
// SIG // OUzU9nm/qhh6YinvopspNAZ3GmLJPR5tH4LwC8csu89D
// SIG // s+X57H2146SodDW4TsVxIxImdgs8UoxxWkZDFLyzs7BN
// SIG // Z8ifQv+AeSGAnhUwZuhCEl4ayJ4iIdBD6Svpu/RIzCzU
// SIG // 2DKATCYqSCRfWupW76bemZ3KOm+9gSd0BhHudiG/m4LB
// SIG // J1S2sWo9iaF2YbRuoROmv6pH8BJv/YoybLL+31HIjCPJ
// SIG // Zr2dHYcSZAI9La9Zj7jkIeW1sMpjtHhUBdRBLlCslLCl
// SIG // eKuzoJZ1GtmShxN1Ii8yqAhuoFuMJb+g74TKIdbrHk/J
// SIG // mu5J4PcBZW+JC33Iacjmbuqnl84xKf8OxVtc2E0bodj6
// SIG // L54/LlUWa8kTo/0xggSlMIIEoQIBATCBkDB5MQswCQYD
// SIG // VQQGEwJVUzETMBEGA1UECBMKV2FzaGluZ3RvbjEQMA4G
// SIG // A1UEBxMHUmVkbW9uZDEeMBwGA1UEChMVTWljcm9zb2Z0
// SIG // IENvcnBvcmF0aW9uMSMwIQYDVQQDExpNaWNyb3NvZnQg
// SIG // Q29kZSBTaWduaW5nIFBDQQITMwAAAQosea7XeXumrAAB
// SIG // AAABCjAJBgUrDgMCGgUAoIG+MBkGCSqGSIb3DQEJAzEM
// SIG // BgorBgEEAYI3AgEEMBwGCisGAQQBgjcCAQsxDjAMBgor
// SIG // BgEEAYI3AgEVMCMGCSqGSIb3DQEJBDEWBBQAV3rD7efe
// SIG // w40k78wfTxQfqYTt0jBeBgorBgEEAYI3AgEMMVAwTqAM
// SIG // gAoAQQBkAFMARABLoT6APGh0dHA6Ly9lZHdlYi9zaXRl
// SIG // cy9JU1NFbmdpbmVlcmluZy9FbmdGdW4vU2l0ZVBhZ2Vz
// SIG // L0hvbWUuYXNweDANBgkqhkiG9w0BAQEFAASCAQAeyp4y
// SIG // Mbikd3v9YD1GPYeKuL2pfrz8YYZNOnXkdvWsl7yqmo0P
// SIG // uQsQ/V5tsd78hpqfrMnAjeDg07OFcoK/UDA/hCYOzdDy
// SIG // 0k7X0KMz8I2Pa8lcTaasykjzfWl0ycHyjy2um941H3on
// SIG // +qYab0YFo+CgRXvCSmnyhqfMYobRamgtlgOidQo02Tej
// SIG // GJbx4p6MN1UiKsgpEaR2nfPfc10fCyslDdAqEFN1UVR8
// SIG // KvKNG68oPLFmgA2phM/H9lou3oVJW1jQW9OXes/wRluP
// SIG // csYCVfAijjFgVVStfYer+/tdrflTJGoFQbyw8nEjwOo8
// SIG // XKoKEybnNcyVJ81m43ceoGiDlIqFoYICKDCCAiQGCSqG
// SIG // SIb3DQEJBjGCAhUwggIRAgEBMIGOMHcxCzAJBgNVBAYT
// SIG // AlVTMRMwEQYDVQQIEwpXYXNoaW5ndG9uMRAwDgYDVQQH
// SIG // EwdSZWRtb25kMR4wHAYDVQQKExVNaWNyb3NvZnQgQ29y
// SIG // cG9yYXRpb24xITAfBgNVBAMTGE1pY3Jvc29mdCBUaW1l
// SIG // LVN0YW1wIFBDQQITMwAAAI/XdhW5zUWKdAAAAAAAjzAJ
// SIG // BgUrDgMCGgUAoF0wGAYJKoZIhvcNAQkDMQsGCSqGSIb3
// SIG // DQEHATAcBgkqhkiG9w0BCQUxDxcNMTYwMTA3MjExNjIx
// SIG // WjAjBgkqhkiG9w0BCQQxFgQU+9kGndi8ihTMepy6JqdD
// SIG // kKTp/FUwDQYJKoZIhvcNAQEFBQAEggEAZlkDY1qFMeDh
// SIG // umCiVvCNSRYcY28Vwv+zm4jRYCrehR1a2NSxEn9nEECs
// SIG // 6+Hh5SvYbnGmw1h4Qxn9aEIFp7uAgtaAY+AfHG2G3KiF
// SIG // 9E3qNREuInohRahSZAobYkAFUWEpfZV6LhBpXk/CIqoG
// SIG // 4v/clMx2cSPK2fcopx660KklZphyca43y7pG00nxq5IX
// SIG // Hlzd6P8onMPxjW0wzcKRLVcf6whs6nRoCy3BXE+KPkiH
// SIG // VuneGXkQU4doKXGE+BPfkh6s5vSC3zRUnNiIzMtkuxrh
// SIG // oY2b6iZj8Esrt7kghUPh9m4ohSaXdkLzRUaUj2vVTZYq
// SIG // BOmpW81zQtxg1llqyCtBLw==
// SIG // End signature block
