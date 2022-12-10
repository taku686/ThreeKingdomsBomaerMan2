#include "pch-cpp.hpp"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <limits>
#include <stdint.h>


struct VirtualActionInvoker0
{
	typedef void (*Action)(void*, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeObject* obj)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		((Action)invokeData.methodPtr)(obj, invokeData.method);
	}
};
template <typename T1, typename T2, typename T3, typename T4, typename T5>
struct VirtualActionInvoker5
{
	typedef void (*Action)(void*, T1, T2, T3, T4, T5, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		((Action)invokeData.methodPtr)(obj, p1, p2, p3, p4, p5, invokeData.method);
	}
};
template <typename T1, typename T2, typename T3, typename T4, typename T5, typename T6>
struct VirtualActionInvoker6
{
	typedef void (*Action)(void*, T1, T2, T3, T4, T5, T6, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		((Action)invokeData.methodPtr)(obj, p1, p2, p3, p4, p5, p6, invokeData.method);
	}
};
template <typename R>
struct VirtualFuncInvoker0
{
	typedef R (*Func)(void*, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeObject* obj)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		return ((Func)invokeData.methodPtr)(obj, invokeData.method);
	}
};
template <typename R, typename T1>
struct VirtualFuncInvoker1
{
	typedef R (*Func)(void*, T1, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		return ((Func)invokeData.methodPtr)(obj, p1, invokeData.method);
	}
};
template <typename R, typename T1, typename T2, typename T3, typename T4>
struct VirtualFuncInvoker4
{
	typedef R (*Func)(void*, T1, T2, T3, T4, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1, T2 p2, T3 p3, T4 p4)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		return ((Func)invokeData.methodPtr)(obj, p1, p2, p3, p4, invokeData.method);
	}
};
template <typename R, typename T1, typename T2, typename T3, typename T4, typename T5>
struct VirtualFuncInvoker5
{
	typedef R (*Func)(void*, T1, T2, T3, T4, T5, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		return ((Func)invokeData.methodPtr)(obj, p1, p2, p3, p4, p5, invokeData.method);
	}
};
template <typename T1, typename T2, typename T3, typename T4, typename T5, typename T6, typename T7>
struct InvokerActionInvoker7
{
	static inline void Invoke (Il2CppMethodPointer methodPtr, const RuntimeMethod* method, void* obj, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7)
	{
		void* params[7] = { &p1, &p2, &p3, &p4, &p5, &p6, &p7 };
		method->invoker_method(methodPtr, method, obj, params, NULL);
	}
};
template <typename T1, typename T2, typename T3, typename T4, typename T5, typename T6, typename T7, typename T8>
struct InvokerActionInvoker8;
template <typename T1, typename T2, typename T3, typename T4, typename T5, typename T6, typename T7, typename T8>
struct InvokerActionInvoker8<T1*, T2, T3, T4, T5, T6, T7, T8>
{
	static inline void Invoke (Il2CppMethodPointer methodPtr, const RuntimeMethod* method, void* obj, T1* p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8)
	{
		void* params[8] = { p1, &p2, &p3, &p4, &p5, &p6, &p7, &p8 };
		method->invoker_method(methodPtr, method, obj, params, NULL);
	}
};

// System.Collections.Generic.List`1<Cinemachine.CinemachineExtension>
struct List_1_tF512ECCA426FF10471372F52B5C8784FC96A7EAC;
// System.Collections.Generic.List`1<Cinemachine.CameraState/CustomBlendable>
struct List_1_tECB13E82883EA864AEBA60A256302E1C8CFD6EF4;
// System.Collections.Generic.List`1<Cinemachine.CinemachineBrain/BrainFrame>
struct List_1_tC7A631B4A35E461A5E78F0D0C4D482812E731DEB;
// System.Collections.Generic.List`1<Cinemachine.CinemachineImpulseManager/ImpulseEvent>
struct List_1_t0EB1E63A5485B6AA5D47FE017C2ACC80AC10A529;
// UnityEngine.AnimationCurve[]
struct AnimationCurveU5BU5D_t2C4A38D7EFA8095F32316A4D9CE4CBB6840FB7EC;
// Cinemachine.CinemachineComponentBase[]
struct CinemachineComponentBaseU5BU5D_t479D9A9F2F2C4AB6F50F6C64FAC4BC8EC602C077;
// Cinemachine.CinemachineOrbitalTransposer[]
struct CinemachineOrbitalTransposerU5BU5D_tFB9047628E48134B27783E21772FA8EAD7CA791F;
// Cinemachine.CinemachineVirtualCamera[]
struct CinemachineVirtualCameraU5BU5D_tC79623529FA0FC8916013356D0E0CB81EC16CFE7;
// System.Delegate[]
struct DelegateU5BU5D_tC5AB7E8F745616680F337909D3A8E6C722CDF771;
// System.IntPtr[]
struct IntPtrU5BU5D_tFD177F8C806A6921AD7150264CCC62FA00CAD832;
// UnityEngine.Keyframe[]
struct KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3;
// System.Diagnostics.StackTrace[]
struct StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF;
// System.String[]
struct StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248;
// UnityEngine.Vector4[]
struct Vector4U5BU5D_tC0F3A7115F85007510F6D173968200CD31BCF7AD;
// Cinemachine.CinemachineCore/Stage[]
struct StageU5BU5D_tF198CE3C6DE5C3D67552DAB4B9680F3BFF319981;
// Cinemachine.CinemachineFreeLook/Orbit[]
struct OrbitU5BU5D_t1525789A40884DD43BBE283E26E989EC19733A28;
// UnityEngine.AnimationCurve
struct AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354;
// System.AsyncCallback
struct AsyncCallback_t7FEF460CBDCFB9C5FA2EF776984778B9A4145F4C;
// UnityEngine.Camera
struct Camera_tA92CC927D7439999BC82DBEDC0AA45B470F9E184;
// Cinemachine.CinemachineBasicMultiChannelPerlin
struct CinemachineBasicMultiChannelPerlin_tDAA09E3E93032C713228E84CA33B21293E9A9269;
// Cinemachine.CinemachineBlend
struct CinemachineBlend_t727AC6579F9C674EB8E01FC3ACB846B20786FF5E;
// Cinemachine.CinemachineBlenderSettings
struct CinemachineBlenderSettings_t55EA371578F7C0ADACF81ACF631C0838A459ED18;
// Cinemachine.CinemachineBrain
struct CinemachineBrain_tA44C6B1C4F0BD2B34EFCD06EE4C4AFE46685CBE9;
// Cinemachine.CinemachineFreeLook
struct CinemachineFreeLook_t397C813915C4BDC42D63DE82DF52897738FCBA1A;
// Cinemachine.CinemachineImpulseDefinition
struct CinemachineImpulseDefinition_t3F6992431B5EE7132783754081C473BABF2F4705;
// Cinemachine.CinemachineImpulseManager
struct CinemachineImpulseManager_t19F063379BE6FCCBDB8F5D04F1ABAD447FACBA8F;
// Cinemachine.CinemachineImpulseSource
struct CinemachineImpulseSource_t48D0DCECD3CD8432BF4442EB45399BBD383A1B83;
// Cinemachine.CinemachineVirtualCamera
struct CinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50;
// Cinemachine.CinemachineVirtualCameraBase
struct CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE;
// UnityEngine.Component
struct Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3;
// UnityEngine.Coroutine
struct Coroutine_t85EA685566A254C23F3FD77AB5BDFFFF8799596B;
// System.Delegate
struct Delegate_t;
// System.DelegateData
struct DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E;
// UnityEngine.GameObject
struct GameObject_t76FEDD663AB33C991A9C9A23129337651094216F;
// System.IAsyncResult
struct IAsyncResult_t7B9B5A0ECB35DCEC31B8A8122C37D687369253B5;
// Cinemachine.ICinemachineCamera
struct ICinemachineCamera_tE6F5FB0E83AB8D13CB7B8B47B2AE09A161C513F5;
// Cinemachine.ICinemachineTargetGroup
struct ICinemachineTargetGroup_t3741E5378B5C1636777589A1BE1811E9E96ADF1B;
// System.Collections.IDictionary
struct IDictionary_t6D03155AF1FA9083817AA5B6AD7DEEACC26AB220;
// System.Collections.IEnumerator
struct IEnumerator_t7B609C2FFA6EB5167D9C62A0C32A21DE2F666DAA;
// MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker
struct MMCinemachineCameraShaker_tFF3CD059083D1A332500FCCEEC5CBFD51EAFDAF5;
// MoreMountains.FeedbacksForThirdParty.MMCinemachineClippingPlanesShaker
struct MMCinemachineClippingPlanesShaker_t7851747D89A493856A718862B75850B59C99DB3D;
// MoreMountains.FeedbacksForThirdParty.MMCinemachineFieldOfViewShaker
struct MMCinemachineFieldOfViewShaker_t1BCC979BAE60EE46A3082B43C9024218559403C5;
// MoreMountains.FeedbacksForThirdParty.MMCinemachineFreeLookZoom
struct MMCinemachineFreeLookZoom_t6535271BE733083A975D4068708827E4A05DEC1E;
// MoreMountains.FeedbacksForThirdParty.MMCinemachineOrthographicSizeShaker
struct MMCinemachineOrthographicSizeShaker_t094C6772F057FE073685EB9E6AB0B65C7EAE909C;
// MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityBrainListener
struct MMCinemachinePriorityBrainListener_t1EAF821E7E0F7C672716F9DA1E639F23DF709D3A;
// MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityListener
struct MMCinemachinePriorityListener_tEE3ED7BDA2BD945CC38862163B4A793F89E6158A;
// MoreMountains.FeedbacksForThirdParty.MMCinemachineZoom
struct MMCinemachineZoom_t270C67D5C8B1AC74F711331A3953C83F4E27E61A;
// MoreMountains.FeedbacksForThirdParty.MMF_CinemachineImpulse
struct MMF_CinemachineImpulse_t90A334FA345704DE6CAFD89E9F3B45D577717131;
// MoreMountains.FeedbacksForThirdParty.MMF_CinemachineImpulseClear
struct MMF_CinemachineImpulseClear_t27C051FD2457C2ED6BF2929DD9603D9F4E3120A9;
// MoreMountains.FeedbacksForThirdParty.MMF_CinemachineImpulseSource
struct MMF_CinemachineImpulseSource_t9F058F7B40FDDD3C398BE92118D7F7BD2D861D49;
// MoreMountains.FeedbacksForThirdParty.MMF_CinemachineTransition
struct MMF_CinemachineTransition_t3F8513D5C3668F4DB53E0940D604A0D346CF24D8;
// MoreMountains.Feedbacks.MMF_Feedback
struct MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D;
// MoreMountains.Feedbacks.MMF_Player
struct MMF_Player_t93550CF1D39E682D9FF480A11FF0138923CBAE6C;
// MoreMountains.Feedbacks.MMFeedback
struct MMFeedback_tE51A2F7A01B1E3BE46047E5A0D6BA5C79199FDCA;
// MoreMountains.FeedbacksForThirdParty.MMFeedbackCinemachineImpulse
struct MMFeedbackCinemachineImpulse_tDA995C9877C6AC10EA0176B19A8F0E526467E55D;
// MoreMountains.FeedbacksForThirdParty.MMFeedbackCinemachineImpulseClear
struct MMFeedbackCinemachineImpulseClear_t593754874A893902A94F35E475262D9F5E410CBF;
// MoreMountains.FeedbacksForThirdParty.MMFeedbackCinemachineTransition
struct MMFeedbackCinemachineTransition_t66579D56518B0A6FEC7B8EF5936D080172E93109;
// MoreMountains.Feedbacks.MMFeedbackTiming
struct MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD;
// MoreMountains.Feedbacks.MMFeedbacks
struct MMFeedbacks_t38A4A1D812AE5F7C3C3033318C408D55AE462AD6;
// MoreMountains.Feedbacks.MMSequence
struct MMSequence_t10D0481DC725D195973AC5C741491AD1E69EA20C;
// MoreMountains.Feedbacks.MMShaker
struct MMShaker_t48AAF716B7D3FC0C6FB15A32772D7DF0D57FCC31;
// System.Reflection.MethodInfo
struct MethodInfo_t;
// UnityEngine.MonoBehaviour
struct MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71;
// Cinemachine.NoiseSettings
struct NoiseSettings_tFCB86EB3704D64D89D6D747BEAE83E1757EF68F1;
// System.NotSupportedException
struct NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A;
// UnityEngine.Object
struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C;
// System.Runtime.Serialization.SafeSerializationManager
struct SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6;
// Cinemachine.SignalSourceAsset
struct SignalSourceAsset_t187094A020026D70B16096697802137226248D2B;
// System.String
struct String_t;
// UnityEngine.Transform
struct Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1;
// System.Void
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915;
// UnityEngine.WaitForFixedUpdate
struct WaitForFixedUpdate_t86F5BC0B6A668AEF2903DE9ADB52062E457BD1B7;
// UnityEngine.WaitForSeconds
struct WaitForSeconds_tF179DF251655B8DF044952E70A60DF4B358A3DD3;
// Cinemachine.AxisState/IInputAxisProvider
struct IInputAxisProvider_tABB3BFF96A8D4C6D50FA42166CCF7AAF18F959E7;
// Cinemachine.CinemachineBrain/BrainEvent
struct BrainEvent_t849EB8BA11F9477DD4D1CCD463DF1C798A74B5E3;
// Cinemachine.CinemachineBrain/VcamActivatedEvent
struct VcamActivatedEvent_tBE585CFE82663479F5588F34F5039F7CCAE50154;
// Cinemachine.CinemachineFreeLook/CreateRigDelegate
struct CreateRigDelegate_tD6770756AD0D0BCB403556417C56015FBFB8343B;
// Cinemachine.CinemachineFreeLook/DestroyRigDelegate
struct DestroyRigDelegate_t28E835CF0AF2A9C3FE1C77889839F4B7A6D761B6;
// Cinemachine.CinemachineVirtualCamera/CreatePipelineDelegate
struct CreatePipelineDelegate_tC9ED5364DE6A2A753E8C9FF767C2C37C5CBB6BFC;
// Cinemachine.CinemachineVirtualCamera/DestroyPipelineDelegate
struct DestroyPipelineDelegate_tDBA135A8B9ACD670F6144200C281F32F728BB842;
// MoreMountains.Feedbacks.MMCameraClippingPlanesShakeEvent/Delegate
struct Delegate_t9335CDEAFF0FB08FD5B9E989B907490B098870E3;
// MoreMountains.Feedbacks.MMCameraFieldOfViewShakeEvent/Delegate
struct Delegate_tB0BC9D7A574413E043B438F0A068AD7FB33AB277;
// MoreMountains.Feedbacks.MMCameraOrthographicSizeShakeEvent/Delegate
struct Delegate_tD173B266ED8EA45E3B0FEDA511537B9BCB52E868;
// MoreMountains.Feedbacks.MMCameraShakeEvent/Delegate
struct Delegate_t8F3069CFED90E34B40CF5BB68B095ACF9775E0CA;
// MoreMountains.Feedbacks.MMCameraShakeStopEvent/Delegate
struct Delegate_tB9EED8DE5A66B26FCB9ADEDD1A910A2862B48662;
// MoreMountains.Feedbacks.MMCameraZoomEvent/Delegate
struct Delegate_tA4CF453D6F49220E972ED8A4794892E9E1017260;
// MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker/<ShakeCameraCo>d__25
struct U3CShakeCameraCoU3Ed__25_t0B875CE45C13DC2DE65A0CFE1DD74167BC71FF6D;
// MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityBrainListener/<ResetBlendDefinition>d__8
struct U3CResetBlendDefinitionU3Ed__8_t970EC43B233ACC0456765A17D202202B7079A1DC;
// MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityEvent/Delegate
struct Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D;

IL2CPP_EXTERN_C RuntimeClass* AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* CinemachineBlendDefinition_t6A16D5B51D440E317D413EC8612647EDA0A6580B_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Delegate_t8F3069CFED90E34B40CF5BB68B095ACF9775E0CA_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Delegate_t9335CDEAFF0FB08FD5B9E989B907490B098870E3_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Delegate_tA4CF453D6F49220E972ED8A4794892E9E1017260_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Delegate_tB0BC9D7A574413E043B438F0A068AD7FB33AB277_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Delegate_tB9EED8DE5A66B26FCB9ADEDD1A910A2862B48662_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Delegate_tD173B266ED8EA45E3B0FEDA511537B9BCB52E868_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* MMCinemachinePriorityEvent_t171D76AEBB1D62D1F95FA9594669EA08940AA0E9_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* MMF_CinemachineImpulseClear_t27C051FD2457C2ED6BF2929DD9603D9F4E3120A9_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* MMF_CinemachineImpulseSource_t9F058F7B40FDDD3C398BE92118D7F7BD2D861D49_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* MMF_CinemachineImpulse_t90A334FA345704DE6CAFD89E9F3B45D577717131_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* MMF_CinemachineTransition_t3F8513D5C3668F4DB53E0940D604A0D346CF24D8_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* MMFeedbackCinemachineImpulseClear_t593754874A893902A94F35E475262D9F5E410CBF_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* MMFeedbackCinemachineImpulse_tDA995C9877C6AC10EA0176B19A8F0E526467E55D_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* MMFeedbackCinemachineTransition_t66579D56518B0A6FEC7B8EF5936D080172E93109_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* TimescaleModes_t567213DC39EEE1AA073F8E8473E19F2B71FC9A68_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* U3CResetBlendDefinitionU3Ed__8_t970EC43B233ACC0456765A17D202202B7079A1DC_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* U3CShakeCameraCoU3Ed__25_t0B875CE45C13DC2DE65A0CFE1DD74167BC71FF6D_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* WaitForSeconds_tF179DF251655B8DF044952E70A60DF4B358A3DD3_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C const RuntimeMethod* CinemachineVirtualCamera_GetCinemachineComponent_TisCinemachineBasicMultiChannelPerlin_tDAA09E3E93032C713228E84CA33B21293E9A9269_m63C03133A16FCEF5C276CB88AD2FB3EB89DD2AD1_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* GameObject_GetComponent_TisCinemachineBrain_tA44C6B1C4F0BD2B34EFCD06EE4C4AFE46685CBE9_mC1162BCB892B08F7E1B985427405E11FA407A3CE_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* GameObject_GetComponent_TisCinemachineFreeLook_t397C813915C4BDC42D63DE82DF52897738FCBA1A_m55FDBF088D5B4E935514B4B81F63DE1044B0101D_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* GameObject_GetComponent_TisCinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE_m24E4FA934917769BC3E78C1CE434B56A2B0346C5_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* GameObject_GetComponent_TisCinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50_m1A2DDA6B545C821D4E79E784051FDF79464CAD2D_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* U3CResetBlendDefinitionU3Ed__8_System_Collections_IEnumerator_Reset_m643CB5C475512A99ABB6530903238B2DABB0BC10_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* U3CShakeCameraCoU3Ed__25_System_Collections_IEnumerator_Reset_m4ADC8BB3251C00B25EAFD66E20DFC4F9367A02EA_RuntimeMethod_var;
struct AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshaled_com;
struct Delegate_t_marshaled_com;
struct Delegate_t_marshaled_pinvoke;
struct Exception_t_marshaled_com;
struct Exception_t_marshaled_pinvoke;

struct DelegateU5BU5D_tC5AB7E8F745616680F337909D3A8E6C722CDF771;
struct KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3;

IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// <Module>
struct U3CModuleU3E_t7BD3C49F530DDA7B848449E6B33F96DE8683F779 
{
};
struct Il2CppArrayBounds;

// Cinemachine.CinemachineImpulseManager
struct CinemachineImpulseManager_t19F063379BE6FCCBDB8F5D04F1ABAD447FACBA8F  : public RuntimeObject
{
	// System.Collections.Generic.List`1<Cinemachine.CinemachineImpulseManager/ImpulseEvent> Cinemachine.CinemachineImpulseManager::m_ExpiredEvents
	List_1_t0EB1E63A5485B6AA5D47FE017C2ACC80AC10A529* ___m_ExpiredEvents_2;
	// System.Collections.Generic.List`1<Cinemachine.CinemachineImpulseManager/ImpulseEvent> Cinemachine.CinemachineImpulseManager::m_ActiveEvents
	List_1_t0EB1E63A5485B6AA5D47FE017C2ACC80AC10A529* ___m_ActiveEvents_3;
	// System.Boolean Cinemachine.CinemachineImpulseManager::IgnoreTimeScale
	bool ___IgnoreTimeScale_4;
};

struct CinemachineImpulseManager_t19F063379BE6FCCBDB8F5D04F1ABAD447FACBA8F_StaticFields
{
	// Cinemachine.CinemachineImpulseManager Cinemachine.CinemachineImpulseManager::sInstance
	CinemachineImpulseManager_t19F063379BE6FCCBDB8F5D04F1ABAD447FACBA8F* ___sInstance_0;
};

// MoreMountains.Feedbacks.MMFeedbackTiming
struct MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD  : public RuntimeObject
{
	// MoreMountains.Feedbacks.TimescaleModes MoreMountains.Feedbacks.MMFeedbackTiming::TimescaleMode
	int32_t ___TimescaleMode_0;
	// System.Boolean MoreMountains.Feedbacks.MMFeedbackTiming::ExcludeFromHoldingPauses
	bool ___ExcludeFromHoldingPauses_1;
	// System.Boolean MoreMountains.Feedbacks.MMFeedbackTiming::ContributeToTotalDuration
	bool ___ContributeToTotalDuration_2;
	// System.Single MoreMountains.Feedbacks.MMFeedbackTiming::InitialDelay
	float ___InitialDelay_3;
	// System.Single MoreMountains.Feedbacks.MMFeedbackTiming::CooldownDuration
	float ___CooldownDuration_4;
	// System.Boolean MoreMountains.Feedbacks.MMFeedbackTiming::InterruptsOnStop
	bool ___InterruptsOnStop_5;
	// System.Int32 MoreMountains.Feedbacks.MMFeedbackTiming::NumberOfRepeats
	int32_t ___NumberOfRepeats_6;
	// System.Boolean MoreMountains.Feedbacks.MMFeedbackTiming::RepeatForever
	bool ___RepeatForever_7;
	// System.Single MoreMountains.Feedbacks.MMFeedbackTiming::DelayBetweenRepeats
	float ___DelayBetweenRepeats_8;
	// MoreMountains.Feedbacks.MMFeedbackTiming/MMFeedbacksDirectionConditions MoreMountains.Feedbacks.MMFeedbackTiming::MMFeedbacksDirectionCondition
	int32_t ___MMFeedbacksDirectionCondition_9;
	// MoreMountains.Feedbacks.MMFeedbackTiming/PlayDirections MoreMountains.Feedbacks.MMFeedbackTiming::PlayDirection
	int32_t ___PlayDirection_10;
	// System.Boolean MoreMountains.Feedbacks.MMFeedbackTiming::ConstantIntensity
	bool ___ConstantIntensity_11;
	// System.Boolean MoreMountains.Feedbacks.MMFeedbackTiming::UseIntensityInterval
	bool ___UseIntensityInterval_12;
	// System.Single MoreMountains.Feedbacks.MMFeedbackTiming::IntensityIntervalMin
	float ___IntensityIntervalMin_13;
	// System.Single MoreMountains.Feedbacks.MMFeedbackTiming::IntensityIntervalMax
	float ___IntensityIntervalMax_14;
	// MoreMountains.Feedbacks.MMSequence MoreMountains.Feedbacks.MMFeedbackTiming::Sequence
	MMSequence_t10D0481DC725D195973AC5C741491AD1E69EA20C* ___Sequence_15;
	// System.Int32 MoreMountains.Feedbacks.MMFeedbackTiming::TrackID
	int32_t ___TrackID_16;
	// System.Boolean MoreMountains.Feedbacks.MMFeedbackTiming::Quantized
	bool ___Quantized_17;
	// System.Int32 MoreMountains.Feedbacks.MMFeedbackTiming::TargetBPM
	int32_t ___TargetBPM_18;
};

// System.ValueType
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F  : public RuntimeObject
{
};
// Native definition for P/Invoke marshalling of System.ValueType
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_pinvoke
{
};
// Native definition for COM marshalling of System.ValueType
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_com
{
};

// UnityEngine.YieldInstruction
struct YieldInstruction_tFCE35FD0907950EFEE9BC2890AC664E41C53728D  : public RuntimeObject
{
};
// Native definition for P/Invoke marshalling of UnityEngine.YieldInstruction
struct YieldInstruction_tFCE35FD0907950EFEE9BC2890AC664E41C53728D_marshaled_pinvoke
{
};
// Native definition for COM marshalling of UnityEngine.YieldInstruction
struct YieldInstruction_tFCE35FD0907950EFEE9BC2890AC664E41C53728D_marshaled_com
{
};

// MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker/<ShakeCameraCo>d__25
struct U3CShakeCameraCoU3Ed__25_t0B875CE45C13DC2DE65A0CFE1DD74167BC71FF6D  : public RuntimeObject
{
	// System.Int32 MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker/<ShakeCameraCo>d__25::<>1__state
	int32_t ___U3CU3E1__state_0;
	// System.Object MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker/<ShakeCameraCo>d__25::<>2__current
	RuntimeObject* ___U3CU3E2__current_1;
	// MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker/<ShakeCameraCo>d__25::<>4__this
	MMCinemachineCameraShaker_tFF3CD059083D1A332500FCCEEC5CBFD51EAFDAF5* ___U3CU3E4__this_2;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker/<ShakeCameraCo>d__25::amplitude
	float ___amplitude_3;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker/<ShakeCameraCo>d__25::frequency
	float ___frequency_4;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker/<ShakeCameraCo>d__25::useUnscaledTime
	bool ___useUnscaledTime_5;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker/<ShakeCameraCo>d__25::infinite
	bool ___infinite_6;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker/<ShakeCameraCo>d__25::duration
	float ___duration_7;
};

// MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityBrainListener/<ResetBlendDefinition>d__8
struct U3CResetBlendDefinitionU3Ed__8_t970EC43B233ACC0456765A17D202202B7079A1DC  : public RuntimeObject
{
	// System.Int32 MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityBrainListener/<ResetBlendDefinition>d__8::<>1__state
	int32_t ___U3CU3E1__state_0;
	// System.Object MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityBrainListener/<ResetBlendDefinition>d__8::<>2__current
	RuntimeObject* ___U3CU3E2__current_1;
	// MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityBrainListener MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityBrainListener/<ResetBlendDefinition>d__8::<>4__this
	MMCinemachinePriorityBrainListener_t1EAF821E7E0F7C672716F9DA1E639F23DF709D3A* ___U3CU3E4__this_2;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityBrainListener/<ResetBlendDefinition>d__8::delay
	float ___delay_3;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityBrainListener/<ResetBlendDefinition>d__8::<timer>5__2
	float ___U3CtimerU3E5__2_4;
};

// System.Boolean
struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22 
{
	// System.Boolean System.Boolean::m_value
	bool ___m_value_0;
};

struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_StaticFields
{
	// System.String System.Boolean::TrueString
	String_t* ___TrueString_5;
	// System.String System.Boolean::FalseString
	String_t* ___FalseString_6;
};

// Cinemachine.CinemachineBlendDefinition
struct CinemachineBlendDefinition_t6A16D5B51D440E317D413EC8612647EDA0A6580B 
{
	// Cinemachine.CinemachineBlendDefinition/Style Cinemachine.CinemachineBlendDefinition::m_Style
	int32_t ___m_Style_0;
	// System.Single Cinemachine.CinemachineBlendDefinition::m_Time
	float ___m_Time_1;
	// UnityEngine.AnimationCurve Cinemachine.CinemachineBlendDefinition::m_CustomCurve
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___m_CustomCurve_2;
};

struct CinemachineBlendDefinition_t6A16D5B51D440E317D413EC8612647EDA0A6580B_StaticFields
{
	// UnityEngine.AnimationCurve[] Cinemachine.CinemachineBlendDefinition::sStandardCurves
	AnimationCurveU5BU5D_t2C4A38D7EFA8095F32316A4D9CE4CBB6840FB7EC* ___sStandardCurves_3;
};

// UnityEngine.Color
struct Color_tD001788D726C3A7F1379BEED0260B9591F440C1F 
{
	// System.Single UnityEngine.Color::r
	float ___r_0;
	// System.Single UnityEngine.Color::g
	float ___g_1;
	// System.Single UnityEngine.Color::b
	float ___b_2;
	// System.Single UnityEngine.Color::a
	float ___a_3;
};

// System.Int32
struct Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C 
{
	// System.Int32 System.Int32::m_value
	int32_t ___m_value_0;
};

// System.IntPtr
struct IntPtr_t 
{
	// System.Void* System.IntPtr::m_value
	void* ___m_value_0;
};

struct IntPtr_t_StaticFields
{
	// System.IntPtr System.IntPtr::Zero
	intptr_t ___Zero_1;
};

// UnityEngine.Keyframe
struct Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 
{
	// System.Single UnityEngine.Keyframe::m_Time
	float ___m_Time_0;
	// System.Single UnityEngine.Keyframe::m_Value
	float ___m_Value_1;
	// System.Single UnityEngine.Keyframe::m_InTangent
	float ___m_InTangent_2;
	// System.Single UnityEngine.Keyframe::m_OutTangent
	float ___m_OutTangent_3;
	// System.Int32 UnityEngine.Keyframe::m_WeightedMode
	int32_t ___m_WeightedMode_4;
	// System.Single UnityEngine.Keyframe::m_InWeight
	float ___m_InWeight_5;
	// System.Single UnityEngine.Keyframe::m_OutWeight
	float ___m_OutWeight_6;
};

// MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityEvent
struct MMCinemachinePriorityEvent_t171D76AEBB1D62D1F95FA9594669EA08940AA0E9 
{
	union
	{
		struct
		{
		};
		uint8_t MMCinemachinePriorityEvent_t171D76AEBB1D62D1F95FA9594669EA08940AA0E9__padding[1];
	};
};

struct MMCinemachinePriorityEvent_t171D76AEBB1D62D1F95FA9594669EA08940AA0E9_StaticFields
{
	// MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityEvent/Delegate MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityEvent::OnEvent
	Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* ___OnEvent_0;
};

// UnityEngine.Quaternion
struct Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 
{
	// System.Single UnityEngine.Quaternion::x
	float ___x_0;
	// System.Single UnityEngine.Quaternion::y
	float ___y_1;
	// System.Single UnityEngine.Quaternion::z
	float ___z_2;
	// System.Single UnityEngine.Quaternion::w
	float ___w_3;
};

struct Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974_StaticFields
{
	// UnityEngine.Quaternion UnityEngine.Quaternion::identityQuaternion
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___identityQuaternion_4;
};

// System.Single
struct Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C 
{
	// System.Single System.Single::m_value
	float ___m_value_0;
};

// UnityEngine.Vector2
struct Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 
{
	// System.Single UnityEngine.Vector2::x
	float ___x_0;
	// System.Single UnityEngine.Vector2::y
	float ___y_1;
};

struct Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7_StaticFields
{
	// UnityEngine.Vector2 UnityEngine.Vector2::zeroVector
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___zeroVector_2;
	// UnityEngine.Vector2 UnityEngine.Vector2::oneVector
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___oneVector_3;
	// UnityEngine.Vector2 UnityEngine.Vector2::upVector
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___upVector_4;
	// UnityEngine.Vector2 UnityEngine.Vector2::downVector
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___downVector_5;
	// UnityEngine.Vector2 UnityEngine.Vector2::leftVector
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___leftVector_6;
	// UnityEngine.Vector2 UnityEngine.Vector2::rightVector
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___rightVector_7;
	// UnityEngine.Vector2 UnityEngine.Vector2::positiveInfinityVector
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___positiveInfinityVector_8;
	// UnityEngine.Vector2 UnityEngine.Vector2::negativeInfinityVector
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___negativeInfinityVector_9;
};

// UnityEngine.Vector3
struct Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 
{
	// System.Single UnityEngine.Vector3::x
	float ___x_2;
	// System.Single UnityEngine.Vector3::y
	float ___y_3;
	// System.Single UnityEngine.Vector3::z
	float ___z_4;
};

struct Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_StaticFields
{
	// UnityEngine.Vector3 UnityEngine.Vector3::zeroVector
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___zeroVector_5;
	// UnityEngine.Vector3 UnityEngine.Vector3::oneVector
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___oneVector_6;
	// UnityEngine.Vector3 UnityEngine.Vector3::upVector
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___upVector_7;
	// UnityEngine.Vector3 UnityEngine.Vector3::downVector
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___downVector_8;
	// UnityEngine.Vector3 UnityEngine.Vector3::leftVector
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___leftVector_9;
	// UnityEngine.Vector3 UnityEngine.Vector3::rightVector
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___rightVector_10;
	// UnityEngine.Vector3 UnityEngine.Vector3::forwardVector
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___forwardVector_11;
	// UnityEngine.Vector3 UnityEngine.Vector3::backVector
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___backVector_12;
	// UnityEngine.Vector3 UnityEngine.Vector3::positiveInfinityVector
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___positiveInfinityVector_13;
	// UnityEngine.Vector3 UnityEngine.Vector3::negativeInfinityVector
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___negativeInfinityVector_14;
};

// System.Void
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915 
{
	union
	{
		struct
		{
		};
		uint8_t Void_t4861ACF8F4594C3437BB48B6E56783494B843915__padding[1];
	};
};

// UnityEngine.WaitForSeconds
struct WaitForSeconds_tF179DF251655B8DF044952E70A60DF4B358A3DD3  : public YieldInstruction_tFCE35FD0907950EFEE9BC2890AC664E41C53728D
{
	// System.Single UnityEngine.WaitForSeconds::m_Seconds
	float ___m_Seconds_0;
};
// Native definition for P/Invoke marshalling of UnityEngine.WaitForSeconds
struct WaitForSeconds_tF179DF251655B8DF044952E70A60DF4B358A3DD3_marshaled_pinvoke : public YieldInstruction_tFCE35FD0907950EFEE9BC2890AC664E41C53728D_marshaled_pinvoke
{
	float ___m_Seconds_0;
};
// Native definition for COM marshalling of UnityEngine.WaitForSeconds
struct WaitForSeconds_tF179DF251655B8DF044952E70A60DF4B358A3DD3_marshaled_com : public YieldInstruction_tFCE35FD0907950EFEE9BC2890AC664E41C53728D_marshaled_com
{
	float ___m_Seconds_0;
};

// Cinemachine.AxisState/Recentering
struct Recentering_tB00B86249E96CFC65822315C710253B1E02459EF 
{
	// System.Boolean Cinemachine.AxisState/Recentering::m_enabled
	bool ___m_enabled_0;
	// System.Single Cinemachine.AxisState/Recentering::m_WaitTime
	float ___m_WaitTime_1;
	// System.Single Cinemachine.AxisState/Recentering::m_RecenteringTime
	float ___m_RecenteringTime_2;
	// System.Single Cinemachine.AxisState/Recentering::mLastAxisInputTime
	float ___mLastAxisInputTime_3;
	// System.Single Cinemachine.AxisState/Recentering::mRecenteringVelocity
	float ___mRecenteringVelocity_4;
	// System.Int32 Cinemachine.AxisState/Recentering::m_LegacyHeadingDefinition
	int32_t ___m_LegacyHeadingDefinition_5;
	// System.Int32 Cinemachine.AxisState/Recentering::m_LegacyVelocityFilterStrength
	int32_t ___m_LegacyVelocityFilterStrength_6;
};
// Native definition for P/Invoke marshalling of Cinemachine.AxisState/Recentering
struct Recentering_tB00B86249E96CFC65822315C710253B1E02459EF_marshaled_pinvoke
{
	int32_t ___m_enabled_0;
	float ___m_WaitTime_1;
	float ___m_RecenteringTime_2;
	float ___mLastAxisInputTime_3;
	float ___mRecenteringVelocity_4;
	int32_t ___m_LegacyHeadingDefinition_5;
	int32_t ___m_LegacyVelocityFilterStrength_6;
};
// Native definition for COM marshalling of Cinemachine.AxisState/Recentering
struct Recentering_tB00B86249E96CFC65822315C710253B1E02459EF_marshaled_com
{
	int32_t ___m_enabled_0;
	float ___m_WaitTime_1;
	float ___m_RecenteringTime_2;
	float ___mLastAxisInputTime_3;
	float ___mRecenteringVelocity_4;
	int32_t ___m_LegacyHeadingDefinition_5;
	int32_t ___m_LegacyVelocityFilterStrength_6;
};

// Cinemachine.CameraState/CustomBlendable
struct CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB 
{
	// UnityEngine.Object Cinemachine.CameraState/CustomBlendable::m_Custom
	Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* ___m_Custom_0;
	// System.Single Cinemachine.CameraState/CustomBlendable::m_Weight
	float ___m_Weight_1;
};

// Cinemachine.CinemachineOrbitalTransposer/Heading
struct Heading_t2A3E10FE1156F914633F9E348691BC649C373B6E 
{
	// Cinemachine.CinemachineOrbitalTransposer/Heading/HeadingDefinition Cinemachine.CinemachineOrbitalTransposer/Heading::m_Definition
	int32_t ___m_Definition_0;
	// System.Int32 Cinemachine.CinemachineOrbitalTransposer/Heading::m_VelocityFilterStrength
	int32_t ___m_VelocityFilterStrength_1;
	// System.Single Cinemachine.CinemachineOrbitalTransposer/Heading::m_Bias
	float ___m_Bias_2;
};

// Cinemachine.CinemachineVirtualCameraBase/TransitionParams
struct TransitionParams_tB597191957C5719625DEDBA130A4C3437346CDCA 
{
	// Cinemachine.CinemachineVirtualCameraBase/BlendHint Cinemachine.CinemachineVirtualCameraBase/TransitionParams::m_BlendHint
	int32_t ___m_BlendHint_0;
	// System.Boolean Cinemachine.CinemachineVirtualCameraBase/TransitionParams::m_InheritPosition
	bool ___m_InheritPosition_1;
	// Cinemachine.CinemachineBrain/VcamActivatedEvent Cinemachine.CinemachineVirtualCameraBase/TransitionParams::m_OnCameraLive
	VcamActivatedEvent_tBE585CFE82663479F5588F34F5039F7CCAE50154* ___m_OnCameraLive_2;
};
// Native definition for P/Invoke marshalling of Cinemachine.CinemachineVirtualCameraBase/TransitionParams
struct TransitionParams_tB597191957C5719625DEDBA130A4C3437346CDCA_marshaled_pinvoke
{
	int32_t ___m_BlendHint_0;
	int32_t ___m_InheritPosition_1;
	VcamActivatedEvent_tBE585CFE82663479F5588F34F5039F7CCAE50154* ___m_OnCameraLive_2;
};
// Native definition for COM marshalling of Cinemachine.CinemachineVirtualCameraBase/TransitionParams
struct TransitionParams_tB597191957C5719625DEDBA130A4C3437346CDCA_marshaled_com
{
	int32_t ___m_BlendHint_0;
	int32_t ___m_InheritPosition_1;
	VcamActivatedEvent_tBE585CFE82663479F5588F34F5039F7CCAE50154* ___m_OnCameraLive_2;
};

// UnityEngine.AnimationCurve
struct AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354  : public RuntimeObject
{
	// System.IntPtr UnityEngine.AnimationCurve::m_Ptr
	intptr_t ___m_Ptr_0;
};
// Native definition for P/Invoke marshalling of UnityEngine.AnimationCurve
struct AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshaled_pinvoke
{
	intptr_t ___m_Ptr_0;
};
// Native definition for COM marshalling of UnityEngine.AnimationCurve
struct AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshaled_com
{
	intptr_t ___m_Ptr_0;
};

// Cinemachine.AxisState
struct AxisState_t6996FE8143104E02683986C908C18B0F62595736 
{
	// System.Single Cinemachine.AxisState::Value
	float ___Value_0;
	// Cinemachine.AxisState/SpeedMode Cinemachine.AxisState::m_SpeedMode
	int32_t ___m_SpeedMode_1;
	// System.Single Cinemachine.AxisState::m_MaxSpeed
	float ___m_MaxSpeed_2;
	// System.Single Cinemachine.AxisState::m_AccelTime
	float ___m_AccelTime_3;
	// System.Single Cinemachine.AxisState::m_DecelTime
	float ___m_DecelTime_4;
	// System.String Cinemachine.AxisState::m_InputAxisName
	String_t* ___m_InputAxisName_5;
	// System.Single Cinemachine.AxisState::m_InputAxisValue
	float ___m_InputAxisValue_6;
	// System.Boolean Cinemachine.AxisState::m_InvertInput
	bool ___m_InvertInput_7;
	// System.Single Cinemachine.AxisState::m_MinValue
	float ___m_MinValue_8;
	// System.Single Cinemachine.AxisState::m_MaxValue
	float ___m_MaxValue_9;
	// System.Boolean Cinemachine.AxisState::m_Wrap
	bool ___m_Wrap_10;
	// Cinemachine.AxisState/Recentering Cinemachine.AxisState::m_Recentering
	Recentering_tB00B86249E96CFC65822315C710253B1E02459EF ___m_Recentering_11;
	// System.Single Cinemachine.AxisState::m_CurrentSpeed
	float ___m_CurrentSpeed_12;
	// System.Single Cinemachine.AxisState::m_LastUpdateTime
	float ___m_LastUpdateTime_13;
	// System.Int32 Cinemachine.AxisState::m_LastUpdateFrame
	int32_t ___m_LastUpdateFrame_14;
	// Cinemachine.AxisState/IInputAxisProvider Cinemachine.AxisState::m_InputAxisProvider
	RuntimeObject* ___m_InputAxisProvider_16;
	// System.Int32 Cinemachine.AxisState::m_InputAxisIndex
	int32_t ___m_InputAxisIndex_17;
	// System.Boolean Cinemachine.AxisState::<ValueRangeLocked>k__BackingField
	bool ___U3CValueRangeLockedU3Ek__BackingField_18;
	// System.Boolean Cinemachine.AxisState::<HasRecentering>k__BackingField
	bool ___U3CHasRecenteringU3Ek__BackingField_19;
};
// Native definition for P/Invoke marshalling of Cinemachine.AxisState
struct AxisState_t6996FE8143104E02683986C908C18B0F62595736_marshaled_pinvoke
{
	float ___Value_0;
	int32_t ___m_SpeedMode_1;
	float ___m_MaxSpeed_2;
	float ___m_AccelTime_3;
	float ___m_DecelTime_4;
	char* ___m_InputAxisName_5;
	float ___m_InputAxisValue_6;
	int32_t ___m_InvertInput_7;
	float ___m_MinValue_8;
	float ___m_MaxValue_9;
	int32_t ___m_Wrap_10;
	Recentering_tB00B86249E96CFC65822315C710253B1E02459EF_marshaled_pinvoke ___m_Recentering_11;
	float ___m_CurrentSpeed_12;
	float ___m_LastUpdateTime_13;
	int32_t ___m_LastUpdateFrame_14;
	RuntimeObject* ___m_InputAxisProvider_16;
	int32_t ___m_InputAxisIndex_17;
	int32_t ___U3CValueRangeLockedU3Ek__BackingField_18;
	int32_t ___U3CHasRecenteringU3Ek__BackingField_19;
};
// Native definition for COM marshalling of Cinemachine.AxisState
struct AxisState_t6996FE8143104E02683986C908C18B0F62595736_marshaled_com
{
	float ___Value_0;
	int32_t ___m_SpeedMode_1;
	float ___m_MaxSpeed_2;
	float ___m_AccelTime_3;
	float ___m_DecelTime_4;
	Il2CppChar* ___m_InputAxisName_5;
	float ___m_InputAxisValue_6;
	int32_t ___m_InvertInput_7;
	float ___m_MinValue_8;
	float ___m_MaxValue_9;
	int32_t ___m_Wrap_10;
	Recentering_tB00B86249E96CFC65822315C710253B1E02459EF_marshaled_com ___m_Recentering_11;
	float ___m_CurrentSpeed_12;
	float ___m_LastUpdateTime_13;
	int32_t ___m_LastUpdateFrame_14;
	RuntimeObject* ___m_InputAxisProvider_16;
	int32_t ___m_InputAxisIndex_17;
	int32_t ___U3CValueRangeLockedU3Ek__BackingField_18;
	int32_t ___U3CHasRecenteringU3Ek__BackingField_19;
};

// UnityEngine.Coroutine
struct Coroutine_t85EA685566A254C23F3FD77AB5BDFFFF8799596B  : public YieldInstruction_tFCE35FD0907950EFEE9BC2890AC664E41C53728D
{
	// System.IntPtr UnityEngine.Coroutine::m_Ptr
	intptr_t ___m_Ptr_0;
};
// Native definition for P/Invoke marshalling of UnityEngine.Coroutine
struct Coroutine_t85EA685566A254C23F3FD77AB5BDFFFF8799596B_marshaled_pinvoke : public YieldInstruction_tFCE35FD0907950EFEE9BC2890AC664E41C53728D_marshaled_pinvoke
{
	intptr_t ___m_Ptr_0;
};
// Native definition for COM marshalling of UnityEngine.Coroutine
struct Coroutine_t85EA685566A254C23F3FD77AB5BDFFFF8799596B_marshaled_com : public YieldInstruction_tFCE35FD0907950EFEE9BC2890AC664E41C53728D_marshaled_com
{
	intptr_t ___m_Ptr_0;
};

// System.Delegate
struct Delegate_t  : public RuntimeObject
{
	// System.IntPtr System.Delegate::method_ptr
	Il2CppMethodPointer ___method_ptr_0;
	// System.IntPtr System.Delegate::invoke_impl
	intptr_t ___invoke_impl_1;
	// System.Object System.Delegate::m_target
	RuntimeObject* ___m_target_2;
	// System.IntPtr System.Delegate::method
	intptr_t ___method_3;
	// System.IntPtr System.Delegate::delegate_trampoline
	intptr_t ___delegate_trampoline_4;
	// System.IntPtr System.Delegate::extra_arg
	intptr_t ___extra_arg_5;
	// System.IntPtr System.Delegate::method_code
	intptr_t ___method_code_6;
	// System.IntPtr System.Delegate::interp_method
	intptr_t ___interp_method_7;
	// System.IntPtr System.Delegate::interp_invoke_impl
	intptr_t ___interp_invoke_impl_8;
	// System.Reflection.MethodInfo System.Delegate::method_info
	MethodInfo_t* ___method_info_9;
	// System.Reflection.MethodInfo System.Delegate::original_method_info
	MethodInfo_t* ___original_method_info_10;
	// System.DelegateData System.Delegate::data
	DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E* ___data_11;
	// System.Boolean System.Delegate::method_is_virtual
	bool ___method_is_virtual_12;
};
// Native definition for P/Invoke marshalling of System.Delegate
struct Delegate_t_marshaled_pinvoke
{
	intptr_t ___method_ptr_0;
	intptr_t ___invoke_impl_1;
	Il2CppIUnknown* ___m_target_2;
	intptr_t ___method_3;
	intptr_t ___delegate_trampoline_4;
	intptr_t ___extra_arg_5;
	intptr_t ___method_code_6;
	intptr_t ___interp_method_7;
	intptr_t ___interp_invoke_impl_8;
	MethodInfo_t* ___method_info_9;
	MethodInfo_t* ___original_method_info_10;
	DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E* ___data_11;
	int32_t ___method_is_virtual_12;
};
// Native definition for COM marshalling of System.Delegate
struct Delegate_t_marshaled_com
{
	intptr_t ___method_ptr_0;
	intptr_t ___invoke_impl_1;
	Il2CppIUnknown* ___m_target_2;
	intptr_t ___method_3;
	intptr_t ___delegate_trampoline_4;
	intptr_t ___extra_arg_5;
	intptr_t ___method_code_6;
	intptr_t ___interp_method_7;
	intptr_t ___interp_invoke_impl_8;
	MethodInfo_t* ___method_info_9;
	MethodInfo_t* ___original_method_info_10;
	DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E* ___data_11;
	int32_t ___method_is_virtual_12;
};

// System.Exception
struct Exception_t  : public RuntimeObject
{
	// System.String System.Exception::_className
	String_t* ____className_1;
	// System.String System.Exception::_message
	String_t* ____message_2;
	// System.Collections.IDictionary System.Exception::_data
	RuntimeObject* ____data_3;
	// System.Exception System.Exception::_innerException
	Exception_t* ____innerException_4;
	// System.String System.Exception::_helpURL
	String_t* ____helpURL_5;
	// System.Object System.Exception::_stackTrace
	RuntimeObject* ____stackTrace_6;
	// System.String System.Exception::_stackTraceString
	String_t* ____stackTraceString_7;
	// System.String System.Exception::_remoteStackTraceString
	String_t* ____remoteStackTraceString_8;
	// System.Int32 System.Exception::_remoteStackIndex
	int32_t ____remoteStackIndex_9;
	// System.Object System.Exception::_dynamicMethods
	RuntimeObject* ____dynamicMethods_10;
	// System.Int32 System.Exception::_HResult
	int32_t ____HResult_11;
	// System.String System.Exception::_source
	String_t* ____source_12;
	// System.Runtime.Serialization.SafeSerializationManager System.Exception::_safeSerializationManager
	SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6* ____safeSerializationManager_13;
	// System.Diagnostics.StackTrace[] System.Exception::captured_traces
	StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF* ___captured_traces_14;
	// System.IntPtr[] System.Exception::native_trace_ips
	IntPtrU5BU5D_tFD177F8C806A6921AD7150264CCC62FA00CAD832* ___native_trace_ips_15;
	// System.Int32 System.Exception::caught_in_unmanaged
	int32_t ___caught_in_unmanaged_16;
};

struct Exception_t_StaticFields
{
	// System.Object System.Exception::s_EDILock
	RuntimeObject* ___s_EDILock_0;
};
// Native definition for P/Invoke marshalling of System.Exception
struct Exception_t_marshaled_pinvoke
{
	char* ____className_1;
	char* ____message_2;
	RuntimeObject* ____data_3;
	Exception_t_marshaled_pinvoke* ____innerException_4;
	char* ____helpURL_5;
	Il2CppIUnknown* ____stackTrace_6;
	char* ____stackTraceString_7;
	char* ____remoteStackTraceString_8;
	int32_t ____remoteStackIndex_9;
	Il2CppIUnknown* ____dynamicMethods_10;
	int32_t ____HResult_11;
	char* ____source_12;
	SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6* ____safeSerializationManager_13;
	StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF* ___captured_traces_14;
	Il2CppSafeArray/*NONE*/* ___native_trace_ips_15;
	int32_t ___caught_in_unmanaged_16;
};
// Native definition for COM marshalling of System.Exception
struct Exception_t_marshaled_com
{
	Il2CppChar* ____className_1;
	Il2CppChar* ____message_2;
	RuntimeObject* ____data_3;
	Exception_t_marshaled_com* ____innerException_4;
	Il2CppChar* ____helpURL_5;
	Il2CppIUnknown* ____stackTrace_6;
	Il2CppChar* ____stackTraceString_7;
	Il2CppChar* ____remoteStackTraceString_8;
	int32_t ____remoteStackIndex_9;
	Il2CppIUnknown* ____dynamicMethods_10;
	int32_t ____HResult_11;
	Il2CppChar* ____source_12;
	SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6* ____safeSerializationManager_13;
	StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF* ___captured_traces_14;
	Il2CppSafeArray/*NONE*/* ___native_trace_ips_15;
	int32_t ___caught_in_unmanaged_16;
};

// Cinemachine.LensSettings
struct LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE 
{
	// System.Single Cinemachine.LensSettings::FieldOfView
	float ___FieldOfView_1;
	// System.Single Cinemachine.LensSettings::OrthographicSize
	float ___OrthographicSize_2;
	// System.Single Cinemachine.LensSettings::NearClipPlane
	float ___NearClipPlane_3;
	// System.Single Cinemachine.LensSettings::FarClipPlane
	float ___FarClipPlane_4;
	// System.Single Cinemachine.LensSettings::Dutch
	float ___Dutch_5;
	// Cinemachine.LensSettings/OverrideModes Cinemachine.LensSettings::ModeOverride
	int32_t ___ModeOverride_6;
	// UnityEngine.Vector2 Cinemachine.LensSettings::LensShift
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___LensShift_7;
	// UnityEngine.Camera/GateFitMode Cinemachine.LensSettings::GateFit
	int32_t ___GateFit_8;
	// UnityEngine.Vector2 Cinemachine.LensSettings::m_SensorSize
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___m_SensorSize_9;
	// System.Boolean Cinemachine.LensSettings::m_OrthoFromCamera
	bool ___m_OrthoFromCamera_10;
	// System.Boolean Cinemachine.LensSettings::m_PhysicalFromCamera
	bool ___m_PhysicalFromCamera_11;
};

struct LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE_StaticFields
{
	// Cinemachine.LensSettings Cinemachine.LensSettings::Default
	LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE ___Default_0;
};
// Native definition for P/Invoke marshalling of Cinemachine.LensSettings
struct LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE_marshaled_pinvoke
{
	float ___FieldOfView_1;
	float ___OrthographicSize_2;
	float ___NearClipPlane_3;
	float ___FarClipPlane_4;
	float ___Dutch_5;
	int32_t ___ModeOverride_6;
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___LensShift_7;
	int32_t ___GateFit_8;
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___m_SensorSize_9;
	int32_t ___m_OrthoFromCamera_10;
	int32_t ___m_PhysicalFromCamera_11;
};
// Native definition for COM marshalling of Cinemachine.LensSettings
struct LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE_marshaled_com
{
	float ___FieldOfView_1;
	float ___OrthographicSize_2;
	float ___NearClipPlane_3;
	float ___FarClipPlane_4;
	float ___Dutch_5;
	int32_t ___ModeOverride_6;
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___LensShift_7;
	int32_t ___GateFit_8;
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___m_SensorSize_9;
	int32_t ___m_OrthoFromCamera_10;
	int32_t ___m_PhysicalFromCamera_11;
};

// MoreMountains.Feedbacks.MMF_Feedback
struct MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D  : public RuntimeObject
{
	// System.Boolean MoreMountains.Feedbacks.MMF_Feedback::Active
	bool ___Active_0;
	// System.Int32 MoreMountains.Feedbacks.MMF_Feedback::UniqueID
	int32_t ___UniqueID_1;
	// System.String MoreMountains.Feedbacks.MMF_Feedback::Label
	String_t* ___Label_2;
	// System.Int32 MoreMountains.Feedbacks.MMF_Feedback::Channel
	int32_t ___Channel_3;
	// System.Single MoreMountains.Feedbacks.MMF_Feedback::Chance
	float ___Chance_4;
	// UnityEngine.Color MoreMountains.Feedbacks.MMF_Feedback::DisplayColor
	Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___DisplayColor_5;
	// MoreMountains.Feedbacks.MMFeedbackTiming MoreMountains.Feedbacks.MMF_Feedback::Timing
	MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD* ___Timing_6;
	// MoreMountains.Feedbacks.MMF_Player MoreMountains.Feedbacks.MMF_Feedback::Owner
	MMF_Player_t93550CF1D39E682D9FF480A11FF0138923CBAE6C* ___Owner_7;
	// System.Boolean MoreMountains.Feedbacks.MMF_Feedback::DebugActive
	bool ___DebugActive_8;
	// System.Boolean MoreMountains.Feedbacks.MMF_Feedback::<ScriptDrivenPause>k__BackingField
	bool ___U3CScriptDrivenPauseU3Ek__BackingField_9;
	// System.Single MoreMountains.Feedbacks.MMF_Feedback::<ScriptDrivenPauseAutoResume>k__BackingField
	float ___U3CScriptDrivenPauseAutoResumeU3Ek__BackingField_10;
	// System.Boolean MoreMountains.Feedbacks.MMF_Feedback::<IsPlaying>k__BackingField
	bool ___U3CIsPlayingU3Ek__BackingField_11;
	// System.Single MoreMountains.Feedbacks.MMF_Feedback::_lastPlayTimestamp
	float ____lastPlayTimestamp_12;
	// System.Int32 MoreMountains.Feedbacks.MMF_Feedback::_playsLeft
	int32_t ____playsLeft_13;
	// System.Boolean MoreMountains.Feedbacks.MMF_Feedback::_initialized
	bool ____initialized_14;
	// UnityEngine.Coroutine MoreMountains.Feedbacks.MMF_Feedback::_playCoroutine
	Coroutine_t85EA685566A254C23F3FD77AB5BDFFFF8799596B* ____playCoroutine_15;
	// UnityEngine.Coroutine MoreMountains.Feedbacks.MMF_Feedback::_infinitePlayCoroutine
	Coroutine_t85EA685566A254C23F3FD77AB5BDFFFF8799596B* ____infinitePlayCoroutine_16;
	// UnityEngine.Coroutine MoreMountains.Feedbacks.MMF_Feedback::_sequenceCoroutine
	Coroutine_t85EA685566A254C23F3FD77AB5BDFFFF8799596B* ____sequenceCoroutine_17;
	// UnityEngine.Coroutine MoreMountains.Feedbacks.MMF_Feedback::_repeatedPlayCoroutine
	Coroutine_t85EA685566A254C23F3FD77AB5BDFFFF8799596B* ____repeatedPlayCoroutine_18;
	// System.Boolean MoreMountains.Feedbacks.MMF_Feedback::_requiresSetup
	bool ____requiresSetup_19;
	// System.String MoreMountains.Feedbacks.MMF_Feedback::_requiredTarget
	String_t* ____requiredTarget_20;
	// System.Int32 MoreMountains.Feedbacks.MMF_Feedback::_sequenceTrackID
	int32_t ____sequenceTrackID_21;
	// System.Single MoreMountains.Feedbacks.MMF_Feedback::_beatInterval
	float ____beatInterval_22;
	// System.Boolean MoreMountains.Feedbacks.MMF_Feedback::BeatThisFrame
	bool ___BeatThisFrame_23;
	// System.Int32 MoreMountains.Feedbacks.MMF_Feedback::LastBeatIndex
	int32_t ___LastBeatIndex_24;
	// System.Int32 MoreMountains.Feedbacks.MMF_Feedback::CurrentSequenceIndex
	int32_t ___CurrentSequenceIndex_25;
	// System.Single MoreMountains.Feedbacks.MMF_Feedback::LastBeatTimestamp
	float ___LastBeatTimestamp_26;
};

// UnityEngine.Object
struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C  : public RuntimeObject
{
	// System.IntPtr UnityEngine.Object::m_CachedPtr
	intptr_t ___m_CachedPtr_0;
};

struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_StaticFields
{
	// System.Int32 UnityEngine.Object::OffsetOfInstanceIDInCPlusPlusObject
	int32_t ___OffsetOfInstanceIDInCPlusPlusObject_1;
};
// Native definition for P/Invoke marshalling of UnityEngine.Object
struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_marshaled_pinvoke
{
	intptr_t ___m_CachedPtr_0;
};
// Native definition for COM marshalling of UnityEngine.Object
struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_marshaled_com
{
	intptr_t ___m_CachedPtr_0;
};

// Cinemachine.CameraState
struct CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 
{
	// Cinemachine.LensSettings Cinemachine.CameraState::Lens
	LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE ___Lens_0;
	// UnityEngine.Vector3 Cinemachine.CameraState::ReferenceUp
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___ReferenceUp_1;
	// UnityEngine.Vector3 Cinemachine.CameraState::ReferenceLookAt
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___ReferenceLookAt_2;
	// UnityEngine.Vector3 Cinemachine.CameraState::RawPosition
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___RawPosition_4;
	// UnityEngine.Quaternion Cinemachine.CameraState::RawOrientation
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___RawOrientation_5;
	// UnityEngine.Vector3 Cinemachine.CameraState::PositionDampingBypass
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___PositionDampingBypass_6;
	// System.Single Cinemachine.CameraState::ShotQuality
	float ___ShotQuality_7;
	// UnityEngine.Vector3 Cinemachine.CameraState::PositionCorrection
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___PositionCorrection_8;
	// UnityEngine.Quaternion Cinemachine.CameraState::OrientationCorrection
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___OrientationCorrection_9;
	// Cinemachine.CameraState/BlendHintValue Cinemachine.CameraState::BlendHint
	int32_t ___BlendHint_10;
	// Cinemachine.CameraState/CustomBlendable Cinemachine.CameraState::mCustom0
	CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB ___mCustom0_11;
	// Cinemachine.CameraState/CustomBlendable Cinemachine.CameraState::mCustom1
	CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB ___mCustom1_12;
	// Cinemachine.CameraState/CustomBlendable Cinemachine.CameraState::mCustom2
	CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB ___mCustom2_13;
	// Cinemachine.CameraState/CustomBlendable Cinemachine.CameraState::mCustom3
	CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB ___mCustom3_14;
	// System.Collections.Generic.List`1<Cinemachine.CameraState/CustomBlendable> Cinemachine.CameraState::m_CustomOverflow
	List_1_tECB13E82883EA864AEBA60A256302E1C8CFD6EF4* ___m_CustomOverflow_15;
	// System.Int32 Cinemachine.CameraState::<NumCustomBlendables>k__BackingField
	int32_t ___U3CNumCustomBlendablesU3Ek__BackingField_16;
};

struct CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156_StaticFields
{
	// UnityEngine.Vector3 Cinemachine.CameraState::kNoPoint
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___kNoPoint_3;
};
// Native definition for P/Invoke marshalling of Cinemachine.CameraState
struct CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156_marshaled_pinvoke
{
	LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE_marshaled_pinvoke ___Lens_0;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___ReferenceUp_1;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___ReferenceLookAt_2;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___RawPosition_4;
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___RawOrientation_5;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___PositionDampingBypass_6;
	float ___ShotQuality_7;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___PositionCorrection_8;
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___OrientationCorrection_9;
	int32_t ___BlendHint_10;
	CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB ___mCustom0_11;
	CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB ___mCustom1_12;
	CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB ___mCustom2_13;
	CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB ___mCustom3_14;
	List_1_tECB13E82883EA864AEBA60A256302E1C8CFD6EF4* ___m_CustomOverflow_15;
	int32_t ___U3CNumCustomBlendablesU3Ek__BackingField_16;
};
// Native definition for COM marshalling of Cinemachine.CameraState
struct CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156_marshaled_com
{
	LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE_marshaled_com ___Lens_0;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___ReferenceUp_1;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___ReferenceLookAt_2;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___RawPosition_4;
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___RawOrientation_5;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___PositionDampingBypass_6;
	float ___ShotQuality_7;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___PositionCorrection_8;
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___OrientationCorrection_9;
	int32_t ___BlendHint_10;
	CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB ___mCustom0_11;
	CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB ___mCustom1_12;
	CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB ___mCustom2_13;
	CustomBlendable_t99FF1C1C42F08A7265E2842451D5CB2F4BFF16CB ___mCustom3_14;
	List_1_tECB13E82883EA864AEBA60A256302E1C8CFD6EF4* ___m_CustomOverflow_15;
	int32_t ___U3CNumCustomBlendablesU3Ek__BackingField_16;
};

// UnityEngine.Component
struct Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3  : public Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C
{
};

// UnityEngine.GameObject
struct GameObject_t76FEDD663AB33C991A9C9A23129337651094216F  : public Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C
{
};

// MoreMountains.FeedbacksForThirdParty.MMF_CinemachineImpulse
struct MMF_CinemachineImpulse_t90A334FA345704DE6CAFD89E9F3B45D577717131  : public MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D
{
	// Cinemachine.CinemachineImpulseDefinition MoreMountains.FeedbacksForThirdParty.MMF_CinemachineImpulse::m_ImpulseDefinition
	CinemachineImpulseDefinition_t3F6992431B5EE7132783754081C473BABF2F4705* ___m_ImpulseDefinition_28;
	// UnityEngine.Vector3 MoreMountains.FeedbacksForThirdParty.MMF_CinemachineImpulse::Velocity
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___Velocity_29;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_CinemachineImpulse::ClearImpulseOnStop
	bool ___ClearImpulseOnStop_30;
};

struct MMF_CinemachineImpulse_t90A334FA345704DE6CAFD89E9F3B45D577717131_StaticFields
{
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_CinemachineImpulse::FeedbackTypeAuthorized
	bool ___FeedbackTypeAuthorized_27;
};

// MoreMountains.FeedbacksForThirdParty.MMF_CinemachineImpulseClear
struct MMF_CinemachineImpulseClear_t27C051FD2457C2ED6BF2929DD9603D9F4E3120A9  : public MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D
{
};

struct MMF_CinemachineImpulseClear_t27C051FD2457C2ED6BF2929DD9603D9F4E3120A9_StaticFields
{
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_CinemachineImpulseClear::FeedbackTypeAuthorized
	bool ___FeedbackTypeAuthorized_27;
};

// MoreMountains.FeedbacksForThirdParty.MMF_CinemachineImpulseSource
struct MMF_CinemachineImpulseSource_t9F058F7B40FDDD3C398BE92118D7F7BD2D861D49  : public MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D
{
	// UnityEngine.Vector3 MoreMountains.FeedbacksForThirdParty.MMF_CinemachineImpulseSource::Velocity
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___Velocity_28;
	// Cinemachine.CinemachineImpulseSource MoreMountains.FeedbacksForThirdParty.MMF_CinemachineImpulseSource::ImpulseSource
	CinemachineImpulseSource_t48D0DCECD3CD8432BF4442EB45399BBD383A1B83* ___ImpulseSource_29;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_CinemachineImpulseSource::ClearImpulseOnStop
	bool ___ClearImpulseOnStop_30;
};

struct MMF_CinemachineImpulseSource_t9F058F7B40FDDD3C398BE92118D7F7BD2D861D49_StaticFields
{
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_CinemachineImpulseSource::FeedbackTypeAuthorized
	bool ___FeedbackTypeAuthorized_27;
};

// MoreMountains.FeedbacksForThirdParty.MMF_CinemachineTransition
struct MMF_CinemachineTransition_t3F8513D5C3668F4DB53E0940D604A0D346CF24D8  : public MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D
{
	// MoreMountains.FeedbacksForThirdParty.MMF_CinemachineTransition/Modes MoreMountains.FeedbacksForThirdParty.MMF_CinemachineTransition::Mode
	int32_t ___Mode_28;
	// Cinemachine.CinemachineVirtualCamera MoreMountains.FeedbacksForThirdParty.MMF_CinemachineTransition::TargetVirtualCamera
	CinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50* ___TargetVirtualCamera_29;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_CinemachineTransition::ResetValuesAfterTransition
	bool ___ResetValuesAfterTransition_30;
	// System.Int32 MoreMountains.FeedbacksForThirdParty.MMF_CinemachineTransition::NewPriority
	int32_t ___NewPriority_31;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_CinemachineTransition::ForceMaxPriority
	bool ___ForceMaxPriority_32;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_CinemachineTransition::ForceTransition
	bool ___ForceTransition_33;
	// Cinemachine.CinemachineBlendDefinition MoreMountains.FeedbacksForThirdParty.MMF_CinemachineTransition::BlendDefintion
	CinemachineBlendDefinition_t6A16D5B51D440E317D413EC8612647EDA0A6580B ___BlendDefintion_34;
	// Cinemachine.CinemachineBlendDefinition MoreMountains.FeedbacksForThirdParty.MMF_CinemachineTransition::_tempBlend
	CinemachineBlendDefinition_t6A16D5B51D440E317D413EC8612647EDA0A6580B ____tempBlend_35;
};

struct MMF_CinemachineTransition_t3F8513D5C3668F4DB53E0940D604A0D346CF24D8_StaticFields
{
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_CinemachineTransition::FeedbackTypeAuthorized
	bool ___FeedbackTypeAuthorized_27;
};

// System.MulticastDelegate
struct MulticastDelegate_t  : public Delegate_t
{
	// System.Delegate[] System.MulticastDelegate::delegates
	DelegateU5BU5D_tC5AB7E8F745616680F337909D3A8E6C722CDF771* ___delegates_13;
};
// Native definition for P/Invoke marshalling of System.MulticastDelegate
struct MulticastDelegate_t_marshaled_pinvoke : public Delegate_t_marshaled_pinvoke
{
	Delegate_t_marshaled_pinvoke** ___delegates_13;
};
// Native definition for COM marshalling of System.MulticastDelegate
struct MulticastDelegate_t_marshaled_com : public Delegate_t_marshaled_com
{
	Delegate_t_marshaled_com** ___delegates_13;
};

// System.SystemException
struct SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295  : public Exception_t
{
};

// Cinemachine.CinemachineImpulseManager/EnvelopeDefinition
struct EnvelopeDefinition_tC875D919977CE4B1876A7CAAF64F9A087C86207E 
{
	// UnityEngine.AnimationCurve Cinemachine.CinemachineImpulseManager/EnvelopeDefinition::m_AttackShape
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___m_AttackShape_0;
	// UnityEngine.AnimationCurve Cinemachine.CinemachineImpulseManager/EnvelopeDefinition::m_DecayShape
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___m_DecayShape_1;
	// System.Single Cinemachine.CinemachineImpulseManager/EnvelopeDefinition::m_AttackTime
	float ___m_AttackTime_2;
	// System.Single Cinemachine.CinemachineImpulseManager/EnvelopeDefinition::m_SustainTime
	float ___m_SustainTime_3;
	// System.Single Cinemachine.CinemachineImpulseManager/EnvelopeDefinition::m_DecayTime
	float ___m_DecayTime_4;
	// System.Boolean Cinemachine.CinemachineImpulseManager/EnvelopeDefinition::m_ScaleWithImpact
	bool ___m_ScaleWithImpact_5;
	// System.Boolean Cinemachine.CinemachineImpulseManager/EnvelopeDefinition::m_HoldForever
	bool ___m_HoldForever_6;
};
// Native definition for P/Invoke marshalling of Cinemachine.CinemachineImpulseManager/EnvelopeDefinition
struct EnvelopeDefinition_tC875D919977CE4B1876A7CAAF64F9A087C86207E_marshaled_pinvoke
{
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshaled_pinvoke ___m_AttackShape_0;
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshaled_pinvoke ___m_DecayShape_1;
	float ___m_AttackTime_2;
	float ___m_SustainTime_3;
	float ___m_DecayTime_4;
	int32_t ___m_ScaleWithImpact_5;
	int32_t ___m_HoldForever_6;
};
// Native definition for COM marshalling of Cinemachine.CinemachineImpulseManager/EnvelopeDefinition
struct EnvelopeDefinition_tC875D919977CE4B1876A7CAAF64F9A087C86207E_marshaled_com
{
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshaled_com* ___m_AttackShape_0;
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshaled_com* ___m_DecayShape_1;
	float ___m_AttackTime_2;
	float ___m_SustainTime_3;
	float ___m_DecayTime_4;
	int32_t ___m_ScaleWithImpact_5;
	int32_t ___m_HoldForever_6;
};

// System.AsyncCallback
struct AsyncCallback_t7FEF460CBDCFB9C5FA2EF776984778B9A4145F4C  : public MulticastDelegate_t
{
};

// UnityEngine.Behaviour
struct Behaviour_t01970CFBBA658497AE30F311C447DB0440BAB7FA  : public Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3
{
};

// Cinemachine.CinemachineImpulseDefinition
struct CinemachineImpulseDefinition_t3F6992431B5EE7132783754081C473BABF2F4705  : public RuntimeObject
{
	// System.Int32 Cinemachine.CinemachineImpulseDefinition::m_ImpulseChannel
	int32_t ___m_ImpulseChannel_0;
	// Cinemachine.CinemachineImpulseDefinition/ImpulseShapes Cinemachine.CinemachineImpulseDefinition::m_ImpulseShape
	int32_t ___m_ImpulseShape_1;
	// UnityEngine.AnimationCurve Cinemachine.CinemachineImpulseDefinition::m_CustomImpulseShape
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___m_CustomImpulseShape_2;
	// System.Single Cinemachine.CinemachineImpulseDefinition::m_ImpulseDuration
	float ___m_ImpulseDuration_3;
	// Cinemachine.CinemachineImpulseDefinition/ImpulseTypes Cinemachine.CinemachineImpulseDefinition::m_ImpulseType
	int32_t ___m_ImpulseType_4;
	// System.Single Cinemachine.CinemachineImpulseDefinition::m_DissipationRate
	float ___m_DissipationRate_5;
	// Cinemachine.SignalSourceAsset Cinemachine.CinemachineImpulseDefinition::m_RawSignal
	SignalSourceAsset_t187094A020026D70B16096697802137226248D2B* ___m_RawSignal_6;
	// System.Single Cinemachine.CinemachineImpulseDefinition::m_AmplitudeGain
	float ___m_AmplitudeGain_7;
	// System.Single Cinemachine.CinemachineImpulseDefinition::m_FrequencyGain
	float ___m_FrequencyGain_8;
	// Cinemachine.CinemachineImpulseDefinition/RepeatMode Cinemachine.CinemachineImpulseDefinition::m_RepeatMode
	int32_t ___m_RepeatMode_9;
	// System.Boolean Cinemachine.CinemachineImpulseDefinition::m_Randomize
	bool ___m_Randomize_10;
	// Cinemachine.CinemachineImpulseManager/EnvelopeDefinition Cinemachine.CinemachineImpulseDefinition::m_TimeEnvelope
	EnvelopeDefinition_tC875D919977CE4B1876A7CAAF64F9A087C86207E ___m_TimeEnvelope_11;
	// System.Single Cinemachine.CinemachineImpulseDefinition::m_ImpactRadius
	float ___m_ImpactRadius_12;
	// Cinemachine.CinemachineImpulseManager/ImpulseEvent/DirectionMode Cinemachine.CinemachineImpulseDefinition::m_DirectionMode
	int32_t ___m_DirectionMode_13;
	// Cinemachine.CinemachineImpulseManager/ImpulseEvent/DissipationMode Cinemachine.CinemachineImpulseDefinition::m_DissipationMode
	int32_t ___m_DissipationMode_14;
	// System.Single Cinemachine.CinemachineImpulseDefinition::m_DissipationDistance
	float ___m_DissipationDistance_15;
	// System.Single Cinemachine.CinemachineImpulseDefinition::m_PropagationSpeed
	float ___m_PropagationSpeed_16;
};

struct CinemachineImpulseDefinition_t3F6992431B5EE7132783754081C473BABF2F4705_StaticFields
{
	// UnityEngine.AnimationCurve[] Cinemachine.CinemachineImpulseDefinition::sStandardShapes
	AnimationCurveU5BU5D_t2C4A38D7EFA8095F32316A4D9CE4CBB6840FB7EC* ___sStandardShapes_17;
};

// System.NotSupportedException
struct NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A  : public SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295
{
};

// MoreMountains.Feedbacks.MMCameraClippingPlanesShakeEvent/Delegate
struct Delegate_t9335CDEAFF0FB08FD5B9E989B907490B098870E3  : public MulticastDelegate_t
{
};

// MoreMountains.Feedbacks.MMCameraFieldOfViewShakeEvent/Delegate
struct Delegate_tB0BC9D7A574413E043B438F0A068AD7FB33AB277  : public MulticastDelegate_t
{
};

// MoreMountains.Feedbacks.MMCameraOrthographicSizeShakeEvent/Delegate
struct Delegate_tD173B266ED8EA45E3B0FEDA511537B9BCB52E868  : public MulticastDelegate_t
{
};

// MoreMountains.Feedbacks.MMCameraShakeEvent/Delegate
struct Delegate_t8F3069CFED90E34B40CF5BB68B095ACF9775E0CA  : public MulticastDelegate_t
{
};

// MoreMountains.Feedbacks.MMCameraShakeStopEvent/Delegate
struct Delegate_tB9EED8DE5A66B26FCB9ADEDD1A910A2862B48662  : public MulticastDelegate_t
{
};

// MoreMountains.Feedbacks.MMCameraZoomEvent/Delegate
struct Delegate_tA4CF453D6F49220E972ED8A4794892E9E1017260  : public MulticastDelegate_t
{
};

// MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityEvent/Delegate
struct Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D  : public MulticastDelegate_t
{
};

// UnityEngine.MonoBehaviour
struct MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71  : public Behaviour_t01970CFBBA658497AE30F311C447DB0440BAB7FA
{
};

// Cinemachine.CinemachineBrain
struct CinemachineBrain_tA44C6B1C4F0BD2B34EFCD06EE4C4AFE46685CBE9  : public MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71
{
	// System.Boolean Cinemachine.CinemachineBrain::m_ShowDebugText
	bool ___m_ShowDebugText_4;
	// System.Boolean Cinemachine.CinemachineBrain::m_ShowCameraFrustum
	bool ___m_ShowCameraFrustum_5;
	// System.Boolean Cinemachine.CinemachineBrain::m_IgnoreTimeScale
	bool ___m_IgnoreTimeScale_6;
	// UnityEngine.Transform Cinemachine.CinemachineBrain::m_WorldUpOverride
	Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* ___m_WorldUpOverride_7;
	// Cinemachine.CinemachineBrain/UpdateMethod Cinemachine.CinemachineBrain::m_UpdateMethod
	int32_t ___m_UpdateMethod_8;
	// Cinemachine.CinemachineBrain/BrainUpdateMethod Cinemachine.CinemachineBrain::m_BlendUpdateMethod
	int32_t ___m_BlendUpdateMethod_9;
	// Cinemachine.CinemachineBlendDefinition Cinemachine.CinemachineBrain::m_DefaultBlend
	CinemachineBlendDefinition_t6A16D5B51D440E317D413EC8612647EDA0A6580B ___m_DefaultBlend_10;
	// Cinemachine.CinemachineBlenderSettings Cinemachine.CinemachineBrain::m_CustomBlends
	CinemachineBlenderSettings_t55EA371578F7C0ADACF81ACF631C0838A459ED18* ___m_CustomBlends_11;
	// UnityEngine.Camera Cinemachine.CinemachineBrain::m_OutputCamera
	Camera_tA92CC927D7439999BC82DBEDC0AA45B470F9E184* ___m_OutputCamera_12;
	// Cinemachine.CinemachineBrain/BrainEvent Cinemachine.CinemachineBrain::m_CameraCutEvent
	BrainEvent_t849EB8BA11F9477DD4D1CCD463DF1C798A74B5E3* ___m_CameraCutEvent_13;
	// Cinemachine.CinemachineBrain/VcamActivatedEvent Cinemachine.CinemachineBrain::m_CameraActivatedEvent
	VcamActivatedEvent_tBE585CFE82663479F5588F34F5039F7CCAE50154* ___m_CameraActivatedEvent_14;
	// UnityEngine.Coroutine Cinemachine.CinemachineBrain::mPhysicsCoroutine
	Coroutine_t85EA685566A254C23F3FD77AB5BDFFFF8799596B* ___mPhysicsCoroutine_16;
	// System.Int32 Cinemachine.CinemachineBrain::m_LastFrameUpdated
	int32_t ___m_LastFrameUpdated_17;
	// UnityEngine.WaitForFixedUpdate Cinemachine.CinemachineBrain::mWaitForFixedUpdate
	WaitForFixedUpdate_t86F5BC0B6A668AEF2903DE9ADB52062E457BD1B7* ___mWaitForFixedUpdate_18;
	// System.Collections.Generic.List`1<Cinemachine.CinemachineBrain/BrainFrame> Cinemachine.CinemachineBrain::mFrameStack
	List_1_tC7A631B4A35E461A5E78F0D0C4D482812E731DEB* ___mFrameStack_19;
	// System.Int32 Cinemachine.CinemachineBrain::mNextFrameId
	int32_t ___mNextFrameId_20;
	// Cinemachine.CinemachineBlend Cinemachine.CinemachineBrain::mCurrentLiveCameras
	CinemachineBlend_t727AC6579F9C674EB8E01FC3ACB846B20786FF5E* ___mCurrentLiveCameras_21;
	// Cinemachine.ICinemachineCamera Cinemachine.CinemachineBrain::mActiveCameraPreviousFrame
	RuntimeObject* ___mActiveCameraPreviousFrame_23;
	// UnityEngine.GameObject Cinemachine.CinemachineBrain::mActiveCameraPreviousFrameGameObject
	GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* ___mActiveCameraPreviousFrameGameObject_24;
	// Cinemachine.CameraState Cinemachine.CinemachineBrain::<CurrentCameraState>k__BackingField
	CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 ___U3CCurrentCameraStateU3Ek__BackingField_25;
};

struct CinemachineBrain_tA44C6B1C4F0BD2B34EFCD06EE4C4AFE46685CBE9_StaticFields
{
	// Cinemachine.ICinemachineCamera Cinemachine.CinemachineBrain::mSoloCamera
	RuntimeObject* ___mSoloCamera_15;
	// UnityEngine.AnimationCurve Cinemachine.CinemachineBrain::mDefaultLinearAnimationCurve
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___mDefaultLinearAnimationCurve_22;
};

// Cinemachine.CinemachineComponentBase
struct CinemachineComponentBase_tDF1741220995A46FEA90E1FB7EA206D973D7428A  : public MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71
{
	// Cinemachine.CinemachineVirtualCameraBase Cinemachine.CinemachineComponentBase::m_vcamOwner
	CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* ___m_vcamOwner_5;
};

// Cinemachine.CinemachineImpulseSource
struct CinemachineImpulseSource_t48D0DCECD3CD8432BF4442EB45399BBD383A1B83  : public MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71
{
	// Cinemachine.CinemachineImpulseDefinition Cinemachine.CinemachineImpulseSource::m_ImpulseDefinition
	CinemachineImpulseDefinition_t3F6992431B5EE7132783754081C473BABF2F4705* ___m_ImpulseDefinition_4;
	// UnityEngine.Vector3 Cinemachine.CinemachineImpulseSource::m_DefaultVelocity
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___m_DefaultVelocity_5;
};

// Cinemachine.CinemachineVirtualCameraBase
struct CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE  : public MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71
{
	// System.String[] Cinemachine.CinemachineVirtualCameraBase::m_ExcludedPropertiesInInspector
	StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* ___m_ExcludedPropertiesInInspector_4;
	// Cinemachine.CinemachineCore/Stage[] Cinemachine.CinemachineVirtualCameraBase::m_LockStageInInspector
	StageU5BU5D_tF198CE3C6DE5C3D67552DAB4B9680F3BFF319981* ___m_LockStageInInspector_5;
	// System.Int32 Cinemachine.CinemachineVirtualCameraBase::m_ValidatingStreamVersion
	int32_t ___m_ValidatingStreamVersion_6;
	// System.Boolean Cinemachine.CinemachineVirtualCameraBase::m_OnValidateCalled
	bool ___m_OnValidateCalled_7;
	// System.Int32 Cinemachine.CinemachineVirtualCameraBase::m_StreamingVersion
	int32_t ___m_StreamingVersion_8;
	// System.Int32 Cinemachine.CinemachineVirtualCameraBase::m_Priority
	int32_t ___m_Priority_9;
	// System.Int32 Cinemachine.CinemachineVirtualCameraBase::m_ActivationId
	int32_t ___m_ActivationId_10;
	// System.Single Cinemachine.CinemachineVirtualCameraBase::FollowTargetAttachment
	float ___FollowTargetAttachment_11;
	// System.Single Cinemachine.CinemachineVirtualCameraBase::LookAtTargetAttachment
	float ___LookAtTargetAttachment_12;
	// Cinemachine.CinemachineVirtualCameraBase/StandbyUpdateMode Cinemachine.CinemachineVirtualCameraBase::m_StandbyUpdate
	int32_t ___m_StandbyUpdate_13;
	// System.Collections.Generic.List`1<Cinemachine.CinemachineExtension> Cinemachine.CinemachineVirtualCameraBase::<mExtensions>k__BackingField
	List_1_tF512ECCA426FF10471372F52B5C8784FC96A7EAC* ___U3CmExtensionsU3Ek__BackingField_14;
	// System.Boolean Cinemachine.CinemachineVirtualCameraBase::<PreviousStateIsValid>k__BackingField
	bool ___U3CPreviousStateIsValidU3Ek__BackingField_15;
	// System.Boolean Cinemachine.CinemachineVirtualCameraBase::m_WasStarted
	bool ___m_WasStarted_16;
	// System.Boolean Cinemachine.CinemachineVirtualCameraBase::mSlaveStatusUpdated
	bool ___mSlaveStatusUpdated_17;
	// Cinemachine.CinemachineVirtualCameraBase Cinemachine.CinemachineVirtualCameraBase::m_parentVcam
	CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* ___m_parentVcam_18;
	// System.Int32 Cinemachine.CinemachineVirtualCameraBase::m_QueuePriority
	int32_t ___m_QueuePriority_19;
	// UnityEngine.Transform Cinemachine.CinemachineVirtualCameraBase::m_CachedFollowTarget
	Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* ___m_CachedFollowTarget_20;
	// Cinemachine.CinemachineVirtualCameraBase Cinemachine.CinemachineVirtualCameraBase::m_CachedFollowTargetVcam
	CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* ___m_CachedFollowTargetVcam_21;
	// Cinemachine.ICinemachineTargetGroup Cinemachine.CinemachineVirtualCameraBase::m_CachedFollowTargetGroup
	RuntimeObject* ___m_CachedFollowTargetGroup_22;
	// UnityEngine.Transform Cinemachine.CinemachineVirtualCameraBase::m_CachedLookAtTarget
	Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* ___m_CachedLookAtTarget_23;
	// Cinemachine.CinemachineVirtualCameraBase Cinemachine.CinemachineVirtualCameraBase::m_CachedLookAtTargetVcam
	CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* ___m_CachedLookAtTargetVcam_24;
	// Cinemachine.ICinemachineTargetGroup Cinemachine.CinemachineVirtualCameraBase::m_CachedLookAtTargetGroup
	RuntimeObject* ___m_CachedLookAtTargetGroup_25;
	// System.Boolean Cinemachine.CinemachineVirtualCameraBase::<FollowTargetChanged>k__BackingField
	bool ___U3CFollowTargetChangedU3Ek__BackingField_26;
	// System.Boolean Cinemachine.CinemachineVirtualCameraBase::<LookAtTargetChanged>k__BackingField
	bool ___U3CLookAtTargetChangedU3Ek__BackingField_27;
};

// MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker
struct MMCinemachineCameraShaker_tFF3CD059083D1A332500FCCEEC5CBFD51EAFDAF5  : public MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71
{
	// System.Int32 MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker::Channel
	int32_t ___Channel_4;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker::DefaultShakeAmplitude
	float ___DefaultShakeAmplitude_5;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker::DefaultShakeFrequency
	float ___DefaultShakeFrequency_6;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker::IdleAmplitude
	float ___IdleAmplitude_7;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker::IdleFrequency
	float ___IdleFrequency_8;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker::LerpSpeed
	float ___LerpSpeed_9;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker::TestDuration
	float ___TestDuration_10;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker::TestAmplitude
	float ___TestAmplitude_11;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker::TestFrequency
	float ___TestFrequency_12;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker::TestShakeButton
	bool ___TestShakeButton_13;
	// MoreMountains.Feedbacks.TimescaleModes MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker::_timescaleMode
	int32_t ____timescaleMode_14;
	// UnityEngine.Vector3 MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker::_initialPosition
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ____initialPosition_15;
	// UnityEngine.Quaternion MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker::_initialRotation
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ____initialRotation_16;
	// Cinemachine.CinemachineBasicMultiChannelPerlin MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker::_perlin
	CinemachineBasicMultiChannelPerlin_tDAA09E3E93032C713228E84CA33B21293E9A9269* ____perlin_17;
	// Cinemachine.CinemachineVirtualCamera MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker::_virtualCamera
	CinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50* ____virtualCamera_18;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker::_targetAmplitude
	float ____targetAmplitude_19;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker::_targetFrequency
	float ____targetFrequency_20;
	// UnityEngine.Coroutine MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker::_shakeCoroutine
	Coroutine_t85EA685566A254C23F3FD77AB5BDFFFF8799596B* ____shakeCoroutine_21;
};

// MoreMountains.FeedbacksForThirdParty.MMCinemachineFreeLookZoom
struct MMCinemachineFreeLookZoom_t6535271BE733083A975D4068708827E4A05DEC1E  : public MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71
{
	// System.Int32 MoreMountains.FeedbacksForThirdParty.MMCinemachineFreeLookZoom::Channel
	int32_t ___Channel_4;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMCinemachineFreeLookZoom::ZoomCurve
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___ZoomCurve_5;
	// MoreMountains.Feedbacks.MMCameraZoomModes MoreMountains.FeedbacksForThirdParty.MMCinemachineFreeLookZoom::TestMode
	int32_t ___TestMode_6;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineFreeLookZoom::TestFieldOfView
	float ___TestFieldOfView_7;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineFreeLookZoom::TestTransitionDuration
	float ___TestTransitionDuration_8;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineFreeLookZoom::TestDuration
	float ___TestDuration_9;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMCinemachineFreeLookZoom::TestZoomButton
	bool ___TestZoomButton_10;
	// Cinemachine.CinemachineFreeLook MoreMountains.FeedbacksForThirdParty.MMCinemachineFreeLookZoom::_freeLookCamera
	CinemachineFreeLook_t397C813915C4BDC42D63DE82DF52897738FCBA1A* ____freeLookCamera_11;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineFreeLookZoom::_initialFieldOfView
	float ____initialFieldOfView_12;
	// MoreMountains.Feedbacks.MMCameraZoomModes MoreMountains.FeedbacksForThirdParty.MMCinemachineFreeLookZoom::_mode
	int32_t ____mode_13;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMCinemachineFreeLookZoom::_zooming
	bool ____zooming_14;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineFreeLookZoom::_startFieldOfView
	float ____startFieldOfView_15;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineFreeLookZoom::_transitionDuration
	float ____transitionDuration_16;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineFreeLookZoom::_duration
	float ____duration_17;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineFreeLookZoom::_targetFieldOfView
	float ____targetFieldOfView_18;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineFreeLookZoom::_delta
	float ____delta_19;
	// System.Int32 MoreMountains.FeedbacksForThirdParty.MMCinemachineFreeLookZoom::_direction
	int32_t ____direction_20;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineFreeLookZoom::_reachedDestinationTimestamp
	float ____reachedDestinationTimestamp_21;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMCinemachineFreeLookZoom::_destinationReached
	bool ____destinationReached_22;
};

// MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityBrainListener
struct MMCinemachinePriorityBrainListener_t1EAF821E7E0F7C672716F9DA1E639F23DF709D3A  : public MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71
{
	// MoreMountains.Feedbacks.TimescaleModes MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityBrainListener::TimescaleMode
	int32_t ___TimescaleMode_4;
	// Cinemachine.CinemachineBrain MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityBrainListener::_brain
	CinemachineBrain_tA44C6B1C4F0BD2B34EFCD06EE4C4AFE46685CBE9* ____brain_5;
	// Cinemachine.CinemachineBlendDefinition MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityBrainListener::_initialDefinition
	CinemachineBlendDefinition_t6A16D5B51D440E317D413EC8612647EDA0A6580B ____initialDefinition_6;
	// UnityEngine.Coroutine MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityBrainListener::_coroutine
	Coroutine_t85EA685566A254C23F3FD77AB5BDFFFF8799596B* ____coroutine_7;
};

// MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityListener
struct MMCinemachinePriorityListener_tEE3ED7BDA2BD945CC38862163B4A793F89E6158A  : public MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71
{
	// MoreMountains.Feedbacks.TimescaleModes MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityListener::TimescaleMode
	int32_t ___TimescaleMode_4;
	// System.Int32 MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityListener::Channel
	int32_t ___Channel_5;
	// Cinemachine.CinemachineVirtualCameraBase MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityListener::_camera
	CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* ____camera_6;
};

// MoreMountains.FeedbacksForThirdParty.MMCinemachineZoom
struct MMCinemachineZoom_t270C67D5C8B1AC74F711331A3953C83F4E27E61A  : public MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71
{
	// System.Int32 MoreMountains.FeedbacksForThirdParty.MMCinemachineZoom::Channel
	int32_t ___Channel_4;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMCinemachineZoom::ZoomCurve
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___ZoomCurve_5;
	// MoreMountains.Feedbacks.MMCameraZoomModes MoreMountains.FeedbacksForThirdParty.MMCinemachineZoom::TestMode
	int32_t ___TestMode_6;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineZoom::TestFieldOfView
	float ___TestFieldOfView_7;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineZoom::TestTransitionDuration
	float ___TestTransitionDuration_8;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineZoom::TestDuration
	float ___TestDuration_9;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMCinemachineZoom::TestZoomButton
	bool ___TestZoomButton_10;
	// MoreMountains.Feedbacks.TimescaleModes MoreMountains.FeedbacksForThirdParty.MMCinemachineZoom::<TimescaleMode>k__BackingField
	int32_t ___U3CTimescaleModeU3Ek__BackingField_11;
	// Cinemachine.CinemachineVirtualCamera MoreMountains.FeedbacksForThirdParty.MMCinemachineZoom::_virtualCamera
	CinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50* ____virtualCamera_12;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineZoom::_initialFieldOfView
	float ____initialFieldOfView_13;
	// MoreMountains.Feedbacks.MMCameraZoomModes MoreMountains.FeedbacksForThirdParty.MMCinemachineZoom::_mode
	int32_t ____mode_14;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMCinemachineZoom::_zooming
	bool ____zooming_15;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineZoom::_startFieldOfView
	float ____startFieldOfView_16;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineZoom::_transitionDuration
	float ____transitionDuration_17;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineZoom::_duration
	float ____duration_18;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineZoom::_targetFieldOfView
	float ____targetFieldOfView_19;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineZoom::_delta
	float ____delta_20;
	// System.Int32 MoreMountains.FeedbacksForThirdParty.MMCinemachineZoom::_direction
	int32_t ____direction_21;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineZoom::_reachedDestinationTimestamp
	float ____reachedDestinationTimestamp_22;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMCinemachineZoom::_destinationReached
	bool ____destinationReached_23;
};

// MoreMountains.Feedbacks.MMFeedback
struct MMFeedback_tE51A2F7A01B1E3BE46047E5A0D6BA5C79199FDCA  : public MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71
{
	// System.Boolean MoreMountains.Feedbacks.MMFeedback::Active
	bool ___Active_4;
	// System.String MoreMountains.Feedbacks.MMFeedback::Label
	String_t* ___Label_5;
	// System.Single MoreMountains.Feedbacks.MMFeedback::Chance
	float ___Chance_6;
	// MoreMountains.Feedbacks.MMFeedbackTiming MoreMountains.Feedbacks.MMFeedback::Timing
	MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD* ___Timing_7;
	// UnityEngine.GameObject MoreMountains.Feedbacks.MMFeedback::<Owner>k__BackingField
	GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* ___U3COwnerU3Ek__BackingField_8;
	// System.Boolean MoreMountains.Feedbacks.MMFeedback::DebugActive
	bool ___DebugActive_9;
	// System.Boolean MoreMountains.Feedbacks.MMFeedback::<ScriptDrivenPause>k__BackingField
	bool ___U3CScriptDrivenPauseU3Ek__BackingField_10;
	// System.Single MoreMountains.Feedbacks.MMFeedback::<ScriptDrivenPauseAutoResume>k__BackingField
	float ___U3CScriptDrivenPauseAutoResumeU3Ek__BackingField_11;
	// System.Boolean MoreMountains.Feedbacks.MMFeedback::<IsPlaying>k__BackingField
	bool ___U3CIsPlayingU3Ek__BackingField_12;
	// System.Single MoreMountains.Feedbacks.MMFeedback::_lastPlayTimestamp
	float ____lastPlayTimestamp_13;
	// System.Int32 MoreMountains.Feedbacks.MMFeedback::_playsLeft
	int32_t ____playsLeft_14;
	// System.Boolean MoreMountains.Feedbacks.MMFeedback::_initialized
	bool ____initialized_15;
	// UnityEngine.Coroutine MoreMountains.Feedbacks.MMFeedback::_playCoroutine
	Coroutine_t85EA685566A254C23F3FD77AB5BDFFFF8799596B* ____playCoroutine_16;
	// UnityEngine.Coroutine MoreMountains.Feedbacks.MMFeedback::_infinitePlayCoroutine
	Coroutine_t85EA685566A254C23F3FD77AB5BDFFFF8799596B* ____infinitePlayCoroutine_17;
	// UnityEngine.Coroutine MoreMountains.Feedbacks.MMFeedback::_sequenceCoroutine
	Coroutine_t85EA685566A254C23F3FD77AB5BDFFFF8799596B* ____sequenceCoroutine_18;
	// UnityEngine.Coroutine MoreMountains.Feedbacks.MMFeedback::_repeatedPlayCoroutine
	Coroutine_t85EA685566A254C23F3FD77AB5BDFFFF8799596B* ____repeatedPlayCoroutine_19;
	// System.Int32 MoreMountains.Feedbacks.MMFeedback::_sequenceTrackID
	int32_t ____sequenceTrackID_20;
	// MoreMountains.Feedbacks.MMFeedbacks MoreMountains.Feedbacks.MMFeedback::_hostMMFeedbacks
	MMFeedbacks_t38A4A1D812AE5F7C3C3033318C408D55AE462AD6* ____hostMMFeedbacks_21;
	// System.Single MoreMountains.Feedbacks.MMFeedback::_beatInterval
	float ____beatInterval_22;
	// System.Boolean MoreMountains.Feedbacks.MMFeedback::BeatThisFrame
	bool ___BeatThisFrame_23;
	// System.Int32 MoreMountains.Feedbacks.MMFeedback::LastBeatIndex
	int32_t ___LastBeatIndex_24;
	// System.Int32 MoreMountains.Feedbacks.MMFeedback::CurrentSequenceIndex
	int32_t ___CurrentSequenceIndex_25;
	// System.Single MoreMountains.Feedbacks.MMFeedback::LastBeatTimestamp
	float ___LastBeatTimestamp_26;
	// System.Boolean MoreMountains.Feedbacks.MMFeedback::_isHostMMFeedbacksNotNull
	bool ____isHostMMFeedbacksNotNull_27;
};

// MoreMountains.Tools.MMMonoBehaviour
struct MMMonoBehaviour_t983071B1C77C21CC3432DBBE41E3B288AC64FD15  : public MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71
{
};

// Cinemachine.CinemachineBasicMultiChannelPerlin
struct CinemachineBasicMultiChannelPerlin_tDAA09E3E93032C713228E84CA33B21293E9A9269  : public CinemachineComponentBase_tDF1741220995A46FEA90E1FB7EA206D973D7428A
{
	// Cinemachine.NoiseSettings Cinemachine.CinemachineBasicMultiChannelPerlin::m_NoiseProfile
	NoiseSettings_tFCB86EB3704D64D89D6D747BEAE83E1757EF68F1* ___m_NoiseProfile_6;
	// UnityEngine.Vector3 Cinemachine.CinemachineBasicMultiChannelPerlin::m_PivotOffset
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___m_PivotOffset_7;
	// System.Single Cinemachine.CinemachineBasicMultiChannelPerlin::m_AmplitudeGain
	float ___m_AmplitudeGain_8;
	// System.Single Cinemachine.CinemachineBasicMultiChannelPerlin::m_FrequencyGain
	float ___m_FrequencyGain_9;
	// System.Boolean Cinemachine.CinemachineBasicMultiChannelPerlin::mInitialized
	bool ___mInitialized_10;
	// System.Single Cinemachine.CinemachineBasicMultiChannelPerlin::mNoiseTime
	float ___mNoiseTime_11;
	// UnityEngine.Vector3 Cinemachine.CinemachineBasicMultiChannelPerlin::mNoiseOffsets
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___mNoiseOffsets_12;
};

// Cinemachine.CinemachineFreeLook
struct CinemachineFreeLook_t397C813915C4BDC42D63DE82DF52897738FCBA1A  : public CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE
{
	// UnityEngine.Transform Cinemachine.CinemachineFreeLook::m_LookAt
	Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* ___m_LookAt_28;
	// UnityEngine.Transform Cinemachine.CinemachineFreeLook::m_Follow
	Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* ___m_Follow_29;
	// System.Boolean Cinemachine.CinemachineFreeLook::m_CommonLens
	bool ___m_CommonLens_30;
	// Cinemachine.LensSettings Cinemachine.CinemachineFreeLook::m_Lens
	LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE ___m_Lens_31;
	// Cinemachine.CinemachineVirtualCameraBase/TransitionParams Cinemachine.CinemachineFreeLook::m_Transitions
	TransitionParams_tB597191957C5719625DEDBA130A4C3437346CDCA ___m_Transitions_32;
	// Cinemachine.CinemachineVirtualCameraBase/BlendHint Cinemachine.CinemachineFreeLook::m_LegacyBlendHint
	int32_t ___m_LegacyBlendHint_33;
	// Cinemachine.AxisState Cinemachine.CinemachineFreeLook::m_YAxis
	AxisState_t6996FE8143104E02683986C908C18B0F62595736 ___m_YAxis_34;
	// Cinemachine.AxisState/Recentering Cinemachine.CinemachineFreeLook::m_YAxisRecentering
	Recentering_tB00B86249E96CFC65822315C710253B1E02459EF ___m_YAxisRecentering_35;
	// Cinemachine.AxisState Cinemachine.CinemachineFreeLook::m_XAxis
	AxisState_t6996FE8143104E02683986C908C18B0F62595736 ___m_XAxis_36;
	// Cinemachine.CinemachineOrbitalTransposer/Heading Cinemachine.CinemachineFreeLook::m_Heading
	Heading_t2A3E10FE1156F914633F9E348691BC649C373B6E ___m_Heading_37;
	// Cinemachine.AxisState/Recentering Cinemachine.CinemachineFreeLook::m_RecenterToTargetHeading
	Recentering_tB00B86249E96CFC65822315C710253B1E02459EF ___m_RecenterToTargetHeading_38;
	// Cinemachine.CinemachineTransposer/BindingMode Cinemachine.CinemachineFreeLook::m_BindingMode
	int32_t ___m_BindingMode_39;
	// System.Single Cinemachine.CinemachineFreeLook::m_SplineCurvature
	float ___m_SplineCurvature_40;
	// Cinemachine.CinemachineFreeLook/Orbit[] Cinemachine.CinemachineFreeLook::m_Orbits
	OrbitU5BU5D_t1525789A40884DD43BBE283E26E989EC19733A28* ___m_Orbits_41;
	// System.Single Cinemachine.CinemachineFreeLook::m_LegacyHeadingBias
	float ___m_LegacyHeadingBias_42;
	// System.Boolean Cinemachine.CinemachineFreeLook::mUseLegacyRigDefinitions
	bool ___mUseLegacyRigDefinitions_43;
	// System.Boolean Cinemachine.CinemachineFreeLook::mIsDestroyed
	bool ___mIsDestroyed_44;
	// Cinemachine.CameraState Cinemachine.CinemachineFreeLook::m_State
	CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 ___m_State_45;
	// Cinemachine.CinemachineVirtualCamera[] Cinemachine.CinemachineFreeLook::m_Rigs
	CinemachineVirtualCameraU5BU5D_tC79623529FA0FC8916013356D0E0CB81EC16CFE7* ___m_Rigs_46;
	// Cinemachine.CinemachineOrbitalTransposer[] Cinemachine.CinemachineFreeLook::mOrbitals
	CinemachineOrbitalTransposerU5BU5D_tFB9047628E48134B27783E21772FA8EAD7CA791F* ___mOrbitals_47;
	// Cinemachine.CinemachineBlend Cinemachine.CinemachineFreeLook::mBlendA
	CinemachineBlend_t727AC6579F9C674EB8E01FC3ACB846B20786FF5E* ___mBlendA_48;
	// Cinemachine.CinemachineBlend Cinemachine.CinemachineFreeLook::mBlendB
	CinemachineBlend_t727AC6579F9C674EB8E01FC3ACB846B20786FF5E* ___mBlendB_49;
	// System.Single Cinemachine.CinemachineFreeLook::m_CachedXAxisHeading
	float ___m_CachedXAxisHeading_52;
	// System.Single Cinemachine.CinemachineFreeLook::m_LastHeadingUpdateFrame
	float ___m_LastHeadingUpdateFrame_53;
	// Cinemachine.CinemachineFreeLook/Orbit[] Cinemachine.CinemachineFreeLook::m_CachedOrbits
	OrbitU5BU5D_t1525789A40884DD43BBE283E26E989EC19733A28* ___m_CachedOrbits_54;
	// System.Single Cinemachine.CinemachineFreeLook::m_CachedTension
	float ___m_CachedTension_55;
	// UnityEngine.Vector4[] Cinemachine.CinemachineFreeLook::m_CachedKnots
	Vector4U5BU5D_tC0F3A7115F85007510F6D173968200CD31BCF7AD* ___m_CachedKnots_56;
	// UnityEngine.Vector4[] Cinemachine.CinemachineFreeLook::m_CachedCtrl1
	Vector4U5BU5D_tC0F3A7115F85007510F6D173968200CD31BCF7AD* ___m_CachedCtrl1_57;
	// UnityEngine.Vector4[] Cinemachine.CinemachineFreeLook::m_CachedCtrl2
	Vector4U5BU5D_tC0F3A7115F85007510F6D173968200CD31BCF7AD* ___m_CachedCtrl2_58;
};

struct CinemachineFreeLook_t397C813915C4BDC42D63DE82DF52897738FCBA1A_StaticFields
{
	// Cinemachine.CinemachineFreeLook/CreateRigDelegate Cinemachine.CinemachineFreeLook::CreateRigOverride
	CreateRigDelegate_tD6770756AD0D0BCB403556417C56015FBFB8343B* ___CreateRigOverride_50;
	// Cinemachine.CinemachineFreeLook/DestroyRigDelegate Cinemachine.CinemachineFreeLook::DestroyRigOverride
	DestroyRigDelegate_t28E835CF0AF2A9C3FE1C77889839F4B7A6D761B6* ___DestroyRigOverride_51;
};

// Cinemachine.CinemachineVirtualCamera
struct CinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50  : public CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE
{
	// UnityEngine.Transform Cinemachine.CinemachineVirtualCamera::m_LookAt
	Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* ___m_LookAt_28;
	// UnityEngine.Transform Cinemachine.CinemachineVirtualCamera::m_Follow
	Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* ___m_Follow_29;
	// Cinemachine.LensSettings Cinemachine.CinemachineVirtualCamera::m_Lens
	LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE ___m_Lens_30;
	// Cinemachine.CinemachineVirtualCameraBase/TransitionParams Cinemachine.CinemachineVirtualCamera::m_Transitions
	TransitionParams_tB597191957C5719625DEDBA130A4C3437346CDCA ___m_Transitions_31;
	// Cinemachine.CinemachineVirtualCameraBase/BlendHint Cinemachine.CinemachineVirtualCamera::m_LegacyBlendHint
	int32_t ___m_LegacyBlendHint_32;
	// System.Boolean Cinemachine.CinemachineVirtualCamera::m_UserIsDragging
	bool ___m_UserIsDragging_36;
	// Cinemachine.CameraState Cinemachine.CinemachineVirtualCamera::m_State
	CameraState_tBC57F8D313D0D19718B24CFBD690C089C2140156 ___m_State_37;
	// Cinemachine.CinemachineComponentBase[] Cinemachine.CinemachineVirtualCamera::m_ComponentPipeline
	CinemachineComponentBaseU5BU5D_t479D9A9F2F2C4AB6F50F6C64FAC4BC8EC602C077* ___m_ComponentPipeline_38;
	// UnityEngine.Transform Cinemachine.CinemachineVirtualCamera::m_ComponentOwner
	Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* ___m_ComponentOwner_39;
	// UnityEngine.Transform Cinemachine.CinemachineVirtualCamera::mCachedLookAtTarget
	Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* ___mCachedLookAtTarget_40;
	// Cinemachine.CinemachineVirtualCameraBase Cinemachine.CinemachineVirtualCamera::mCachedLookAtTargetVcam
	CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* ___mCachedLookAtTargetVcam_41;
};

struct CinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50_StaticFields
{
	// Cinemachine.CinemachineVirtualCamera/CreatePipelineDelegate Cinemachine.CinemachineVirtualCamera::CreatePipelineOverride
	CreatePipelineDelegate_tC9ED5364DE6A2A753E8C9FF767C2C37C5CBB6BFC* ___CreatePipelineOverride_34;
	// Cinemachine.CinemachineVirtualCamera/DestroyPipelineDelegate Cinemachine.CinemachineVirtualCamera::DestroyPipelineOverride
	DestroyPipelineDelegate_tDBA135A8B9ACD670F6144200C281F32F728BB842* ___DestroyPipelineOverride_35;
};

// MoreMountains.FeedbacksForThirdParty.MMFeedbackCinemachineImpulse
struct MMFeedbackCinemachineImpulse_tDA995C9877C6AC10EA0176B19A8F0E526467E55D  : public MMFeedback_tE51A2F7A01B1E3BE46047E5A0D6BA5C79199FDCA
{
	// Cinemachine.CinemachineImpulseDefinition MoreMountains.FeedbacksForThirdParty.MMFeedbackCinemachineImpulse::m_ImpulseDefinition
	CinemachineImpulseDefinition_t3F6992431B5EE7132783754081C473BABF2F4705* ___m_ImpulseDefinition_29;
	// UnityEngine.Vector3 MoreMountains.FeedbacksForThirdParty.MMFeedbackCinemachineImpulse::Velocity
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___Velocity_30;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMFeedbackCinemachineImpulse::ClearImpulseOnStop
	bool ___ClearImpulseOnStop_31;
};

struct MMFeedbackCinemachineImpulse_tDA995C9877C6AC10EA0176B19A8F0E526467E55D_StaticFields
{
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMFeedbackCinemachineImpulse::FeedbackTypeAuthorized
	bool ___FeedbackTypeAuthorized_28;
};

// MoreMountains.FeedbacksForThirdParty.MMFeedbackCinemachineImpulseClear
struct MMFeedbackCinemachineImpulseClear_t593754874A893902A94F35E475262D9F5E410CBF  : public MMFeedback_tE51A2F7A01B1E3BE46047E5A0D6BA5C79199FDCA
{
};

struct MMFeedbackCinemachineImpulseClear_t593754874A893902A94F35E475262D9F5E410CBF_StaticFields
{
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMFeedbackCinemachineImpulseClear::FeedbackTypeAuthorized
	bool ___FeedbackTypeAuthorized_28;
};

// MoreMountains.FeedbacksForThirdParty.MMFeedbackCinemachineTransition
struct MMFeedbackCinemachineTransition_t66579D56518B0A6FEC7B8EF5936D080172E93109  : public MMFeedback_tE51A2F7A01B1E3BE46047E5A0D6BA5C79199FDCA
{
	// MoreMountains.FeedbacksForThirdParty.MMFeedbackCinemachineTransition/Modes MoreMountains.FeedbacksForThirdParty.MMFeedbackCinemachineTransition::Mode
	int32_t ___Mode_29;
	// System.Int32 MoreMountains.FeedbacksForThirdParty.MMFeedbackCinemachineTransition::Channel
	int32_t ___Channel_30;
	// Cinemachine.CinemachineVirtualCamera MoreMountains.FeedbacksForThirdParty.MMFeedbackCinemachineTransition::TargetVirtualCamera
	CinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50* ___TargetVirtualCamera_31;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMFeedbackCinemachineTransition::ResetValuesAfterTransition
	bool ___ResetValuesAfterTransition_32;
	// System.Int32 MoreMountains.FeedbacksForThirdParty.MMFeedbackCinemachineTransition::NewPriority
	int32_t ___NewPriority_33;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMFeedbackCinemachineTransition::ForceMaxPriority
	bool ___ForceMaxPriority_34;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMFeedbackCinemachineTransition::ForceTransition
	bool ___ForceTransition_35;
	// Cinemachine.CinemachineBlendDefinition MoreMountains.FeedbacksForThirdParty.MMFeedbackCinemachineTransition::BlendDefintion
	CinemachineBlendDefinition_t6A16D5B51D440E317D413EC8612647EDA0A6580B ___BlendDefintion_36;
	// Cinemachine.CinemachineBlendDefinition MoreMountains.FeedbacksForThirdParty.MMFeedbackCinemachineTransition::_tempBlend
	CinemachineBlendDefinition_t6A16D5B51D440E317D413EC8612647EDA0A6580B ____tempBlend_37;
};

struct MMFeedbackCinemachineTransition_t66579D56518B0A6FEC7B8EF5936D080172E93109_StaticFields
{
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMFeedbackCinemachineTransition::FeedbackTypeAuthorized
	bool ___FeedbackTypeAuthorized_28;
};

// MoreMountains.Feedbacks.MMShaker
struct MMShaker_t48AAF716B7D3FC0C6FB15A32772D7DF0D57FCC31  : public MMMonoBehaviour_t983071B1C77C21CC3432DBBE41E3B288AC64FD15
{
	// System.Int32 MoreMountains.Feedbacks.MMShaker::Channel
	int32_t ___Channel_4;
	// System.Single MoreMountains.Feedbacks.MMShaker::ShakeDuration
	float ___ShakeDuration_5;
	// System.Boolean MoreMountains.Feedbacks.MMShaker::PlayOnAwake
	bool ___PlayOnAwake_6;
	// System.Boolean MoreMountains.Feedbacks.MMShaker::PermanentShake
	bool ___PermanentShake_7;
	// System.Boolean MoreMountains.Feedbacks.MMShaker::Interruptible
	bool ___Interruptible_8;
	// System.Boolean MoreMountains.Feedbacks.MMShaker::AlwaysResetTargetValuesAfterShake
	bool ___AlwaysResetTargetValuesAfterShake_9;
	// System.Single MoreMountains.Feedbacks.MMShaker::CooldownBetweenShakes
	float ___CooldownBetweenShakes_10;
	// System.Boolean MoreMountains.Feedbacks.MMShaker::Shaking
	bool ___Shaking_11;
	// System.Boolean MoreMountains.Feedbacks.MMShaker::ForwardDirection
	bool ___ForwardDirection_12;
	// MoreMountains.Feedbacks.TimescaleModes MoreMountains.Feedbacks.MMShaker::TimescaleMode
	int32_t ___TimescaleMode_13;
	// System.Boolean MoreMountains.Feedbacks.MMShaker::_listeningToEvents
	bool ____listeningToEvents_14;
	// System.Single MoreMountains.Feedbacks.MMShaker::_shakeStartedTimestamp
	float ____shakeStartedTimestamp_15;
	// System.Single MoreMountains.Feedbacks.MMShaker::_remappedTimeSinceStart
	float ____remappedTimeSinceStart_16;
	// System.Boolean MoreMountains.Feedbacks.MMShaker::_resetShakerValuesAfterShake
	bool ____resetShakerValuesAfterShake_17;
	// System.Boolean MoreMountains.Feedbacks.MMShaker::_resetTargetValuesAfterShake
	bool ____resetTargetValuesAfterShake_18;
	// System.Single MoreMountains.Feedbacks.MMShaker::_journey
	float ____journey_19;
};

// MoreMountains.FeedbacksForThirdParty.MMCinemachineClippingPlanesShaker
struct MMCinemachineClippingPlanesShaker_t7851747D89A493856A718862B75850B59C99DB3D  : public MMShaker_t48AAF716B7D3FC0C6FB15A32772D7DF0D57FCC31
{
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMCinemachineClippingPlanesShaker::RelativeClippingPlanes
	bool ___RelativeClippingPlanes_20;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMCinemachineClippingPlanesShaker::ShakeNear
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___ShakeNear_21;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineClippingPlanesShaker::RemapNearZero
	float ___RemapNearZero_22;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineClippingPlanesShaker::RemapNearOne
	float ___RemapNearOne_23;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMCinemachineClippingPlanesShaker::ShakeFar
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___ShakeFar_24;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineClippingPlanesShaker::RemapFarZero
	float ___RemapFarZero_25;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineClippingPlanesShaker::RemapFarOne
	float ___RemapFarOne_26;
	// Cinemachine.CinemachineVirtualCamera MoreMountains.FeedbacksForThirdParty.MMCinemachineClippingPlanesShaker::_targetCamera
	CinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50* ____targetCamera_27;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineClippingPlanesShaker::_initialNear
	float ____initialNear_28;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineClippingPlanesShaker::_initialFar
	float ____initialFar_29;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineClippingPlanesShaker::_originalShakeDuration
	float ____originalShakeDuration_30;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMCinemachineClippingPlanesShaker::_originalRelativeClippingPlanes
	bool ____originalRelativeClippingPlanes_31;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMCinemachineClippingPlanesShaker::_originalShakeNear
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ____originalShakeNear_32;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineClippingPlanesShaker::_originalRemapNearZero
	float ____originalRemapNearZero_33;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineClippingPlanesShaker::_originalRemapNearOne
	float ____originalRemapNearOne_34;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMCinemachineClippingPlanesShaker::_originalShakeFar
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ____originalShakeFar_35;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineClippingPlanesShaker::_originalRemapFarZero
	float ____originalRemapFarZero_36;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineClippingPlanesShaker::_originalRemapFarOne
	float ____originalRemapFarOne_37;
};

// MoreMountains.FeedbacksForThirdParty.MMCinemachineFieldOfViewShaker
struct MMCinemachineFieldOfViewShaker_t1BCC979BAE60EE46A3082B43C9024218559403C5  : public MMShaker_t48AAF716B7D3FC0C6FB15A32772D7DF0D57FCC31
{
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMCinemachineFieldOfViewShaker::RelativeFieldOfView
	bool ___RelativeFieldOfView_20;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMCinemachineFieldOfViewShaker::ShakeFieldOfView
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___ShakeFieldOfView_21;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineFieldOfViewShaker::RemapFieldOfViewZero
	float ___RemapFieldOfViewZero_22;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineFieldOfViewShaker::RemapFieldOfViewOne
	float ___RemapFieldOfViewOne_23;
	// Cinemachine.CinemachineVirtualCamera MoreMountains.FeedbacksForThirdParty.MMCinemachineFieldOfViewShaker::_targetCamera
	CinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50* ____targetCamera_24;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineFieldOfViewShaker::_initialFieldOfView
	float ____initialFieldOfView_25;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineFieldOfViewShaker::_originalShakeDuration
	float ____originalShakeDuration_26;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMCinemachineFieldOfViewShaker::_originalRelativeFieldOfView
	bool ____originalRelativeFieldOfView_27;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMCinemachineFieldOfViewShaker::_originalShakeFieldOfView
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ____originalShakeFieldOfView_28;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineFieldOfViewShaker::_originalRemapFieldOfViewZero
	float ____originalRemapFieldOfViewZero_29;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineFieldOfViewShaker::_originalRemapFieldOfViewOne
	float ____originalRemapFieldOfViewOne_30;
};

// MoreMountains.FeedbacksForThirdParty.MMCinemachineOrthographicSizeShaker
struct MMCinemachineOrthographicSizeShaker_t094C6772F057FE073685EB9E6AB0B65C7EAE909C  : public MMShaker_t48AAF716B7D3FC0C6FB15A32772D7DF0D57FCC31
{
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMCinemachineOrthographicSizeShaker::RelativeOrthographicSize
	bool ___RelativeOrthographicSize_20;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMCinemachineOrthographicSizeShaker::ShakeOrthographicSize
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___ShakeOrthographicSize_21;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineOrthographicSizeShaker::RemapOrthographicSizeZero
	float ___RemapOrthographicSizeZero_22;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineOrthographicSizeShaker::RemapOrthographicSizeOne
	float ___RemapOrthographicSizeOne_23;
	// Cinemachine.CinemachineVirtualCamera MoreMountains.FeedbacksForThirdParty.MMCinemachineOrthographicSizeShaker::_targetCamera
	CinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50* ____targetCamera_24;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineOrthographicSizeShaker::_initialOrthographicSize
	float ____initialOrthographicSize_25;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineOrthographicSizeShaker::_originalShakeDuration
	float ____originalShakeDuration_26;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMCinemachineOrthographicSizeShaker::_originalRelativeOrthographicSize
	bool ____originalRelativeOrthographicSize_27;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMCinemachineOrthographicSizeShaker::_originalShakeOrthographicSize
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ____originalShakeOrthographicSize_28;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineOrthographicSizeShaker::_originalRemapOrthographicSizeZero
	float ____originalRemapOrthographicSizeZero_29;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineOrthographicSizeShaker::_originalRemapOrthographicSizeOne
	float ____originalRemapOrthographicSizeOne_30;
};
#ifdef __clang__
#pragma clang diagnostic pop
#endif
// UnityEngine.Keyframe[]
struct KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3  : public RuntimeArray
{
	ALIGN_FIELD (8) Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 m_Items[1];

	inline Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0* GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0* GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 value)
	{
		m_Items[index] = value;
	}
};
// System.Delegate[]
struct DelegateU5BU5D_tC5AB7E8F745616680F337909D3A8E6C722CDF771  : public RuntimeArray
{
	ALIGN_FIELD (8) Delegate_t* m_Items[1];

	inline Delegate_t* GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline Delegate_t** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, Delegate_t* value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
	inline Delegate_t* GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline Delegate_t** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, Delegate_t* value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
};


// T UnityEngine.GameObject::GetComponent<System.Object>()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* GameObject_GetComponent_TisRuntimeObject_m6EAED4AA356F0F48288F67899E5958792395563B_gshared (GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* __this, const RuntimeMethod* method) ;
// T Cinemachine.CinemachineVirtualCamera::GetCinemachineComponent<System.Object>()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* CinemachineVirtualCamera_GetCinemachineComponent_TisRuntimeObject_m70B9E2B45173016F7928E3F968524E521FABFD34_gshared (CinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50* __this, const RuntimeMethod* method) ;

// System.Single Cinemachine.CinemachineImpulseManager/EnvelopeDefinition::get_Duration()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float EnvelopeDefinition_get_Duration_m3CF863DC6B71344BE096AD9CBFC6C86AD2FF634C (EnvelopeDefinition_tC875D919977CE4B1876A7CAAF64F9A087C86207E* __this, const RuntimeMethod* method) ;
// Cinemachine.CinemachineImpulseManager Cinemachine.CinemachineImpulseManager::get_Instance()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR CinemachineImpulseManager_t19F063379BE6FCCBDB8F5D04F1ABAD447FACBA8F* CinemachineImpulseManager_get_Instance_mCBBB7EE190D29704E4F44241A50BC2F6F23EB179 (const RuntimeMethod* method) ;
// UnityEngine.Vector3 UnityEngine.Vector3::op_Multiply(UnityEngine.Vector3,System.Single)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_op_Multiply_m87BA7C578F96C8E49BB07088DAAC4649F83B0353_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___a0, float ___d1, const RuntimeMethod* method) ;
// System.Void Cinemachine.CinemachineImpulseDefinition::CreateEvent(UnityEngine.Vector3,UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineImpulseDefinition_CreateEvent_m12158346403D3428D6DBC0D3D22DDDCF551E5B41 (CinemachineImpulseDefinition_t3F6992431B5EE7132783754081C473BABF2F4705* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___velocity1, const RuntimeMethod* method) ;
// System.Void MoreMountains.Feedbacks.MMFeedback::CustomStopFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedback_CustomStopFeedback_m812755E219AA8EF519A2D89F6C91AB793AE27EDD (MMFeedback_tE51A2F7A01B1E3BE46047E5A0D6BA5C79199FDCA* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) ;
// System.Void Cinemachine.CinemachineImpulseManager::Clear()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineImpulseManager_Clear_mA6DC571A238EB0C4C7B07C06D2263B5743FB82BA (CinemachineImpulseManager_t19F063379BE6FCCBDB8F5D04F1ABAD447FACBA8F* __this, const RuntimeMethod* method) ;
// System.Void MoreMountains.Feedbacks.MMFeedback::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedback__ctor_mCD506F8FC949D7574B8EB30A5C0CC117C19BD647 (MMFeedback_tE51A2F7A01B1E3BE46047E5A0D6BA5C79199FDCA* __this, const RuntimeMethod* method) ;
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityEvent::Trigger(System.Int32,System.Boolean,System.Int32,System.Boolean,Cinemachine.CinemachineBlendDefinition,System.Boolean,MoreMountains.Feedbacks.TimescaleModes)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachinePriorityEvent_Trigger_mB101FF6CE1A5AA8C81FDAAE93FF075CAF7C34581 (int32_t ___channel0, bool ___forceMaxPriority1, int32_t ___newPriority2, bool ___forceTransition3, CinemachineBlendDefinition_t6A16D5B51D440E317D413EC8612647EDA0A6580B ___blendDefinition4, bool ___resetValuesAfterTransition5, int32_t ___timescaleMode6, const RuntimeMethod* method) ;
// System.Void Cinemachine.CinemachineVirtualCameraBase::set_Priority(System.Int32)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void CinemachineVirtualCameraBase_set_Priority_m233ED0376CE0BD1244CCA52DF4532C8988DC05AC_inline (CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* __this, int32_t ___value0, const RuntimeMethod* method) ;
// System.Void MoreMountains.Feedbacks.MMF_Feedback::CustomStopFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_Feedback_CustomStopFeedback_m9388036D957D90AD8C6BC3C4B17AC9A7B3B49A30 (MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) ;
// System.Void MoreMountains.Feedbacks.MMF_Feedback::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_Feedback__ctor_mCD413701DAEE304A0840C520FF3EB470EE324AC5 (MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D* __this, const RuntimeMethod* method) ;
// System.Boolean UnityEngine.Object::op_Inequality(UnityEngine.Object,UnityEngine.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Object_op_Inequality_mD0BE578448EAA61948F25C32F8DD55AB1F778602 (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* ___x0, Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* ___y1, const RuntimeMethod* method) ;
// System.Void Cinemachine.CinemachineImpulseSource::GenerateImpulse(UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CinemachineImpulseSource_GenerateImpulse_m700534622EE72CDDAFEBEFAB2E60F88654660B6A (CinemachineImpulseSource_t48D0DCECD3CD8432BF4442EB45399BBD383A1B83* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___velocity0, const RuntimeMethod* method) ;
// System.Void UnityEngine.Vector3::.ctor(System.Single,System.Single,System.Single)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Vector3__ctor_m376936E6B999EF1ECBE57D990A386303E2283DE0_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* __this, float ___x0, float ___y1, float ___z2, const RuntimeMethod* method) ;
// System.Single UnityEngine.Time::get_unscaledTime()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Time_get_unscaledTime_mAF4040B858903E1325D1C65B8BF1AC61460B2503 (const RuntimeMethod* method) ;
// System.Single UnityEngine.Time::get_time()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Time_get_time_m3A271BB1B20041144AC5B7863B71AB1F0150374B (const RuntimeMethod* method) ;
// System.Single UnityEngine.Time::get_unscaledDeltaTime()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Time_get_unscaledDeltaTime_mF057EECA857E5C0F90A3F910D26D3EE59F27C4B5 (const RuntimeMethod* method) ;
// System.Single UnityEngine.Time::get_deltaTime()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Time_get_deltaTime_mC3195000401F0FD167DD2F948FD2BC58330D0865 (const RuntimeMethod* method) ;
// UnityEngine.GameObject UnityEngine.Component::get_gameObject()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* Component_get_gameObject_m57AEFBB14DB39EC476F740BA000E170355DE691B (Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3* __this, const RuntimeMethod* method) ;
// T UnityEngine.GameObject::GetComponent<Cinemachine.CinemachineVirtualCamera>()
inline CinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50* GameObject_GetComponent_TisCinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50_m1A2DDA6B545C821D4E79E784051FDF79464CAD2D (GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* __this, const RuntimeMethod* method)
{
	return ((  CinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50* (*) (GameObject_t76FEDD663AB33C991A9C9A23129337651094216F*, const RuntimeMethod*))GameObject_GetComponent_TisRuntimeObject_m6EAED4AA356F0F48288F67899E5958792395563B_gshared)(__this, method);
}
// T Cinemachine.CinemachineVirtualCamera::GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>()
inline CinemachineBasicMultiChannelPerlin_tDAA09E3E93032C713228E84CA33B21293E9A9269* CinemachineVirtualCamera_GetCinemachineComponent_TisCinemachineBasicMultiChannelPerlin_tDAA09E3E93032C713228E84CA33B21293E9A9269_m63C03133A16FCEF5C276CB88AD2FB3EB89DD2AD1 (CinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50* __this, const RuntimeMethod* method)
{
	return ((  CinemachineBasicMultiChannelPerlin_tDAA09E3E93032C713228E84CA33B21293E9A9269* (*) (CinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50*, const RuntimeMethod*))CinemachineVirtualCamera_GetCinemachineComponent_TisRuntimeObject_m70B9E2B45173016F7928E3F968524E521FABFD34_gshared)(__this, method);
}
// System.Single UnityEngine.Mathf::Lerp(System.Single,System.Single,System.Single)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Mathf_Lerp_m47EF2FFB7647BD0A1FDC26DC03E28B19812139B5_inline (float ___a0, float ___b1, float ___t2, const RuntimeMethod* method) ;
// UnityEngine.Coroutine UnityEngine.MonoBehaviour::StartCoroutine(System.Collections.IEnumerator)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Coroutine_t85EA685566A254C23F3FD77AB5BDFFFF8799596B* MonoBehaviour_StartCoroutine_m4CAFF732AA28CD3BDC5363B44A863575530EC812 (MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71* __this, RuntimeObject* ___routine0, const RuntimeMethod* method) ;
// System.Void UnityEngine.MonoBehaviour::StopCoroutine(UnityEngine.Coroutine)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MonoBehaviour_StopCoroutine_mB0FC91BE84203BD8E360B3FBAE5B958B4C5ED22A (MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71* __this, Coroutine_t85EA685566A254C23F3FD77AB5BDFFFF8799596B* ___routine0, const RuntimeMethod* method) ;
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker/<ShakeCameraCo>d__25::.ctor(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void U3CShakeCameraCoU3Ed__25__ctor_m30CC3D3C436592D75E79900DF9754427453F6813 (U3CShakeCameraCoU3Ed__25_t0B875CE45C13DC2DE65A0CFE1DD74167BC71FF6D* __this, int32_t ___U3CU3E1__state0, const RuntimeMethod* method) ;
// System.Void MoreMountains.Feedbacks.MMCameraShakeEvent/Delegate::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Delegate__ctor_m7CB5FEB96E25CDBD63C7E0A579CA8143E9BA8AFF (Delegate_t8F3069CFED90E34B40CF5BB68B095ACF9775E0CA* __this, RuntimeObject* ___object0, intptr_t ___method1, const RuntimeMethod* method) ;
// System.Void MoreMountains.Feedbacks.MMCameraShakeEvent::Register(MoreMountains.Feedbacks.MMCameraShakeEvent/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCameraShakeEvent_Register_m7BFC0967C829FBBEEE5DCD07ADF255BE5507D91D (Delegate_t8F3069CFED90E34B40CF5BB68B095ACF9775E0CA* ___callback0, const RuntimeMethod* method) ;
// System.Void MoreMountains.Feedbacks.MMCameraShakeStopEvent/Delegate::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Delegate__ctor_m63C01375264F2FE4B307E18D29F117B3F23B73B2 (Delegate_tB9EED8DE5A66B26FCB9ADEDD1A910A2862B48662* __this, RuntimeObject* ___object0, intptr_t ___method1, const RuntimeMethod* method) ;
// System.Void MoreMountains.Feedbacks.MMCameraShakeStopEvent::Register(MoreMountains.Feedbacks.MMCameraShakeStopEvent/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCameraShakeStopEvent_Register_m318BD840460216E7221EFCE171AA62BDEB82BCEE (Delegate_tB9EED8DE5A66B26FCB9ADEDD1A910A2862B48662* ___callback0, const RuntimeMethod* method) ;
// System.Void MoreMountains.Feedbacks.MMCameraShakeEvent::Unregister(MoreMountains.Feedbacks.MMCameraShakeEvent/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCameraShakeEvent_Unregister_m8ED0BB2E7A7CCEA4B2E35156AB22E65F3FF3A29A (Delegate_t8F3069CFED90E34B40CF5BB68B095ACF9775E0CA* ___callback0, const RuntimeMethod* method) ;
// System.Void MoreMountains.Feedbacks.MMCameraShakeStopEvent::Unregister(MoreMountains.Feedbacks.MMCameraShakeStopEvent/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCameraShakeStopEvent_Unregister_mE69EA56078B4ABA74367F9C073BB02FFC27BF0EE (Delegate_tB9EED8DE5A66B26FCB9ADEDD1A910A2862B48662* ___callback0, const RuntimeMethod* method) ;
// System.Void MoreMountains.Feedbacks.MMCameraShakeEvent::Trigger(System.Single,System.Single,System.Single,System.Single,System.Single,System.Single,System.Boolean,System.Int32,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCameraShakeEvent_Trigger_m71E4F28DF8D86A80F8C48EB2F985FC776230559F (float ___duration0, float ___amplitude1, float ___frequency2, float ___amplitudeX3, float ___amplitudeY4, float ___amplitudeZ5, bool ___infinite6, int32_t ___channel7, bool ___useUnscaledTime8, const RuntimeMethod* method) ;
// System.Void UnityEngine.MonoBehaviour::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MonoBehaviour__ctor_m592DB0105CA0BC97AA1C5F4AD27B12D68A3B7C1E (MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71* __this, const RuntimeMethod* method) ;
// System.Void System.Object::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2 (RuntimeObject* __this, const RuntimeMethod* method) ;
// System.Void UnityEngine.WaitForSeconds::.ctor(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void WaitForSeconds__ctor_m579F95BADEDBAB4B3A7E302C6EE3995926EF2EFC (WaitForSeconds_tF179DF251655B8DF044952E70A60DF4B358A3DD3* __this, float ___seconds0, const RuntimeMethod* method) ;
// System.Void System.NotSupportedException::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NotSupportedException__ctor_m1398D0CDE19B36AA3DE9392879738C1EA2439CDF (NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A* __this, const RuntimeMethod* method) ;
// System.Void MoreMountains.Feedbacks.MMShaker::Initialization()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMShaker_Initialization_mF435F195C4DE0AB245013FE4AC5C49DAF00EA29A (MMShaker_t48AAF716B7D3FC0C6FB15A32772D7DF0D57FCC31* __this, const RuntimeMethod* method) ;
// System.Void MoreMountains.Feedbacks.MMShaker::ResetTargetValues()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMShaker_ResetTargetValues_mD7E138483910DEE0DEF4276FF39F07A6AE80AE59 (MMShaker_t48AAF716B7D3FC0C6FB15A32772D7DF0D57FCC31* __this, const RuntimeMethod* method) ;
// System.Void MoreMountains.Feedbacks.MMShaker::ResetShakerValues()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMShaker_ResetShakerValues_mF597524D875B4EA6053014C7E9F63177D123C490 (MMShaker_t48AAF716B7D3FC0C6FB15A32772D7DF0D57FCC31* __this, const RuntimeMethod* method) ;
// System.Void MoreMountains.Feedbacks.MMShaker::StartListening()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMShaker_StartListening_m36823EC65926E79570BE8564A9C7F90DCEA8B7AD (MMShaker_t48AAF716B7D3FC0C6FB15A32772D7DF0D57FCC31* __this, const RuntimeMethod* method) ;
// System.Void MoreMountains.Feedbacks.MMCameraClippingPlanesShakeEvent/Delegate::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Delegate__ctor_mFF2CF1BA610BC049B43CDE70406E4C28B45EA7FA (Delegate_t9335CDEAFF0FB08FD5B9E989B907490B098870E3* __this, RuntimeObject* ___object0, intptr_t ___method1, const RuntimeMethod* method) ;
// System.Void MoreMountains.Feedbacks.MMCameraClippingPlanesShakeEvent::Register(MoreMountains.Feedbacks.MMCameraClippingPlanesShakeEvent/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCameraClippingPlanesShakeEvent_Register_mF87E62B189E26C561BCA3A40E297DA17E9AA7FF3 (Delegate_t9335CDEAFF0FB08FD5B9E989B907490B098870E3* ___callback0, const RuntimeMethod* method) ;
// System.Void MoreMountains.Feedbacks.MMShaker::StopListening()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMShaker_StopListening_m7F583AAD3037B2610ADB4BA3BBF63847EF3EDE1C (MMShaker_t48AAF716B7D3FC0C6FB15A32772D7DF0D57FCC31* __this, const RuntimeMethod* method) ;
// System.Void MoreMountains.Feedbacks.MMCameraClippingPlanesShakeEvent::Unregister(MoreMountains.Feedbacks.MMCameraClippingPlanesShakeEvent/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCameraClippingPlanesShakeEvent_Unregister_mF4002BB9EC90EC4D0C3362819546B37DCCACFCD1 (Delegate_t9335CDEAFF0FB08FD5B9E989B907490B098870E3* ___callback0, const RuntimeMethod* method) ;
// System.Void UnityEngine.Keyframe::.ctor(System.Single,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34 (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0* __this, float ___time0, float ___value1, const RuntimeMethod* method) ;
// System.Void UnityEngine.AnimationCurve::.ctor(UnityEngine.Keyframe[])
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AnimationCurve__ctor_mEABC98C03805713354D61E50D9340766BD5B717E (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* __this, KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* ___keys0, const RuntimeMethod* method) ;
// System.Void MoreMountains.Feedbacks.MMShaker::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMShaker__ctor_mF8C6BFF676BA0F272791D3B64B0E5EB2E598A709 (MMShaker_t48AAF716B7D3FC0C6FB15A32772D7DF0D57FCC31* __this, const RuntimeMethod* method) ;
// System.Void MoreMountains.Feedbacks.MMCameraFieldOfViewShakeEvent/Delegate::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Delegate__ctor_m321FFD3E054C53C801D96CC148892FA3E3A55ECB (Delegate_tB0BC9D7A574413E043B438F0A068AD7FB33AB277* __this, RuntimeObject* ___object0, intptr_t ___method1, const RuntimeMethod* method) ;
// System.Void MoreMountains.Feedbacks.MMCameraFieldOfViewShakeEvent::Register(MoreMountains.Feedbacks.MMCameraFieldOfViewShakeEvent/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCameraFieldOfViewShakeEvent_Register_mC79F1A4954A1AFE8872758F1BF3BC9A7D20454C9 (Delegate_tB0BC9D7A574413E043B438F0A068AD7FB33AB277* ___callback0, const RuntimeMethod* method) ;
// System.Void MoreMountains.Feedbacks.MMCameraFieldOfViewShakeEvent::Unregister(MoreMountains.Feedbacks.MMCameraFieldOfViewShakeEvent/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCameraFieldOfViewShakeEvent_Unregister_m5790F78661BF6DF619379F690D7336A5D860A3F2 (Delegate_tB0BC9D7A574413E043B438F0A068AD7FB33AB277* ___callback0, const RuntimeMethod* method) ;
// T UnityEngine.GameObject::GetComponent<Cinemachine.CinemachineFreeLook>()
inline CinemachineFreeLook_t397C813915C4BDC42D63DE82DF52897738FCBA1A* GameObject_GetComponent_TisCinemachineFreeLook_t397C813915C4BDC42D63DE82DF52897738FCBA1A_m55FDBF088D5B4E935514B4B81F63DE1044B0101D (GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* __this, const RuntimeMethod* method)
{
	return ((  CinemachineFreeLook_t397C813915C4BDC42D63DE82DF52897738FCBA1A* (*) (GameObject_t76FEDD663AB33C991A9C9A23129337651094216F*, const RuntimeMethod*))GameObject_GetComponent_TisRuntimeObject_m6EAED4AA356F0F48288F67899E5958792395563B_gshared)(__this, method);
}
// System.Single UnityEngine.AnimationCurve::Evaluate(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float AnimationCurve_Evaluate_m50B857043DE251A186032ADBCBB4CEF817F4EE3C (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* __this, float ___time0, const RuntimeMethod* method) ;
// System.Single UnityEngine.Mathf::LerpUnclamped(System.Single,System.Single,System.Single)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Mathf_LerpUnclamped_mF35042F9D25A221BDD4B3FD6251224610AFC1F35_inline (float ___a0, float ___b1, float ___t2, const RuntimeMethod* method) ;
// System.Void MoreMountains.Feedbacks.MMCameraZoomEvent/Delegate::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Delegate__ctor_m8D1004BCEFC6D845CBCB8EA17EF4FDBB819D808C (Delegate_tA4CF453D6F49220E972ED8A4794892E9E1017260* __this, RuntimeObject* ___object0, intptr_t ___method1, const RuntimeMethod* method) ;
// System.Void MoreMountains.Feedbacks.MMCameraZoomEvent::Register(MoreMountains.Feedbacks.MMCameraZoomEvent/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCameraZoomEvent_Register_m3BA025FD8AB4CDCE718D0FEEAB365B0E49EE94A0 (Delegate_tA4CF453D6F49220E972ED8A4794892E9E1017260* ___callback0, const RuntimeMethod* method) ;
// System.Void MoreMountains.Feedbacks.MMCameraZoomEvent::Unregister(MoreMountains.Feedbacks.MMCameraZoomEvent/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCameraZoomEvent_Unregister_m4A7B1DFA4E416AE9FEFD017466C03E5B18B1EF45 (Delegate_tA4CF453D6F49220E972ED8A4794892E9E1017260* ___callback0, const RuntimeMethod* method) ;
// System.Void MoreMountains.Feedbacks.MMCameraOrthographicSizeShakeEvent/Delegate::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Delegate__ctor_m4440EC7CB1C0F0B9EDEAAFA64173B9B8B2181BEC (Delegate_tD173B266ED8EA45E3B0FEDA511537B9BCB52E868* __this, RuntimeObject* ___object0, intptr_t ___method1, const RuntimeMethod* method) ;
// System.Void MoreMountains.Feedbacks.MMCameraOrthographicSizeShakeEvent::Register(MoreMountains.Feedbacks.MMCameraOrthographicSizeShakeEvent/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCameraOrthographicSizeShakeEvent_Register_mE4E6BA4E14CB2B31D7DA710C379DDEF6BDA02DCC (Delegate_tD173B266ED8EA45E3B0FEDA511537B9BCB52E868* ___callback0, const RuntimeMethod* method) ;
// System.Void MoreMountains.Feedbacks.MMCameraOrthographicSizeShakeEvent::Unregister(MoreMountains.Feedbacks.MMCameraOrthographicSizeShakeEvent/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCameraOrthographicSizeShakeEvent_Unregister_m3C0C9011FFED801F04C1F9A2697331AF8F22E3CC (Delegate_tD173B266ED8EA45E3B0FEDA511537B9BCB52E868* ___callback0, const RuntimeMethod* method) ;
// T UnityEngine.GameObject::GetComponent<Cinemachine.CinemachineBrain>()
inline CinemachineBrain_tA44C6B1C4F0BD2B34EFCD06EE4C4AFE46685CBE9* GameObject_GetComponent_TisCinemachineBrain_tA44C6B1C4F0BD2B34EFCD06EE4C4AFE46685CBE9_mC1162BCB892B08F7E1B985427405E11FA407A3CE (GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* __this, const RuntimeMethod* method)
{
	return ((  CinemachineBrain_tA44C6B1C4F0BD2B34EFCD06EE4C4AFE46685CBE9* (*) (GameObject_t76FEDD663AB33C991A9C9A23129337651094216F*, const RuntimeMethod*))GameObject_GetComponent_TisRuntimeObject_m6EAED4AA356F0F48288F67899E5958792395563B_gshared)(__this, method);
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityBrainListener/<ResetBlendDefinition>d__8::.ctor(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void U3CResetBlendDefinitionU3Ed__8__ctor_mCD7D7BDADF94634CC7BB73B670390E1F290CC99D (U3CResetBlendDefinitionU3Ed__8_t970EC43B233ACC0456765A17D202202B7079A1DC* __this, int32_t ___U3CU3E1__state0, const RuntimeMethod* method) ;
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityEvent/Delegate::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Delegate__ctor_m102966351BDF3F711589A2E9A2E52F8C9EABE54E (Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* __this, RuntimeObject* ___object0, intptr_t ___method1, const RuntimeMethod* method) ;
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityEvent::Register(MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityEvent/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachinePriorityEvent_Register_mA41B0E167E2ED763E8E1BA74E316A99CE097C582 (Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* ___callback0, const RuntimeMethod* method) ;
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityEvent::Unregister(MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityEvent/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachinePriorityEvent_Unregister_mF6CDB945CAAFC6C09F0296A156D4FA1608FD761D (Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* ___callback0, const RuntimeMethod* method) ;
// T UnityEngine.GameObject::GetComponent<Cinemachine.CinemachineVirtualCameraBase>()
inline CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* GameObject_GetComponent_TisCinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE_m24E4FA934917769BC3E78C1CE434B56A2B0346C5 (GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* __this, const RuntimeMethod* method)
{
	return ((  CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* (*) (GameObject_t76FEDD663AB33C991A9C9A23129337651094216F*, const RuntimeMethod*))GameObject_GetComponent_TisRuntimeObject_m6EAED4AA356F0F48288F67899E5958792395563B_gshared)(__this, method);
}
// System.Delegate System.Delegate::Combine(System.Delegate,System.Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Delegate_t* Delegate_Combine_m1F725AEF318BE6F0426863490691A6F4606E7D00 (Delegate_t* ___a0, Delegate_t* ___b1, const RuntimeMethod* method) ;
// System.Delegate System.Delegate::Remove(System.Delegate,System.Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Delegate_t* Delegate_Remove_m8B7DD5661308FA972E23CA1CC3FC9CEB355504E3 (Delegate_t* ___source0, Delegate_t* ___value1, const RuntimeMethod* method) ;
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityEvent::add_OnEvent(MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityEvent/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachinePriorityEvent_add_OnEvent_mC495EF756CD4D57D51DDBD60DF005DB2A7995769 (Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* ___value0, const RuntimeMethod* method) ;
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityEvent::remove_OnEvent(MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityEvent/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachinePriorityEvent_remove_OnEvent_m7125AA477BD05BA55997BAA712E5171318487ED7 (Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* ___value0, const RuntimeMethod* method) ;
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityEvent/Delegate::Invoke(System.Int32,System.Boolean,System.Int32,System.Boolean,Cinemachine.CinemachineBlendDefinition,System.Boolean,MoreMountains.Feedbacks.TimescaleModes)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Delegate_Invoke_m522A97EE33632F1AA72205CB61AB7258FE91C19D_inline (Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* __this, int32_t ___channel0, bool ___forceMaxPriority1, int32_t ___newPriority2, bool ___forceTransition3, CinemachineBlendDefinition_t6A16D5B51D440E317D413EC8612647EDA0A6580B ___blendDefinition4, bool ___resetValuesAfterTransition5, int32_t ___timescaleMode6, const RuntimeMethod* method) ;
// MoreMountains.Feedbacks.TimescaleModes MoreMountains.FeedbacksForThirdParty.MMCinemachineZoom::get_TimescaleMode()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t MMCinemachineZoom_get_TimescaleMode_m011368B7AAC7340E11480854F9FCF8DF02DCDF14_inline (MMCinemachineZoom_t270C67D5C8B1AC74F711331A3953C83F4E27E61A* __this, const RuntimeMethod* method) ;
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineZoom::set_TimescaleMode(MoreMountains.Feedbacks.TimescaleModes)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void MMCinemachineZoom_set_TimescaleMode_m31C347EEC2E268FA9BC4824C78891EED9796E08F_inline (MMCinemachineZoom_t270C67D5C8B1AC74F711331A3953C83F4E27E61A* __this, int32_t ___value0, const RuntimeMethod* method) ;
// System.Single UnityEngine.Mathf::Clamp01(System.Single)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Mathf_Clamp01_mA7E048DBDA832D399A581BE4D6DED9FA44CE0F14_inline (float ___value0, const RuntimeMethod* method) ;
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackCinemachineImpulse::get_FeedbackDuration()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float MMFeedbackCinemachineImpulse_get_FeedbackDuration_m8FDEC225A8870B93481898C3131FDF245D57E906 (MMFeedbackCinemachineImpulse_tDA995C9877C6AC10EA0176B19A8F0E526467E55D* __this, const RuntimeMethod* method) 
{
	{
		// public override float FeedbackDuration { get { return m_ImpulseDefinition.m_TimeEnvelope.Duration; } }
		CinemachineImpulseDefinition_t3F6992431B5EE7132783754081C473BABF2F4705* L_0 = __this->___m_ImpulseDefinition_29;
		NullCheck(L_0);
		EnvelopeDefinition_tC875D919977CE4B1876A7CAAF64F9A087C86207E* L_1 = (&L_0->___m_TimeEnvelope_11);
		float L_2;
		L_2 = EnvelopeDefinition_get_Duration_m3CF863DC6B71344BE096AD9CBFC6C86AD2FF634C(L_1, NULL);
		return L_2;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackCinemachineImpulse::CustomPlayFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackCinemachineImpulse_CustomPlayFeedback_mC388912092663F3A8F196EDFD1AA8784D782C9A4 (MMFeedbackCinemachineImpulse_tDA995C9877C6AC10EA0176B19A8F0E526467E55D* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMFeedbackCinemachineImpulse_tDA995C9877C6AC10EA0176B19A8F0E526467E55D_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	float V_0 = 0.0f;
	float G_B6_0 = 0.0f;
	{
		// if (!Active || !FeedbackTypeAuthorized)
		bool L_0 = ((MMFeedback_tE51A2F7A01B1E3BE46047E5A0D6BA5C79199FDCA*)__this)->___Active_4;
		if (!L_0)
		{
			goto IL_000f;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(MMFeedbackCinemachineImpulse_tDA995C9877C6AC10EA0176B19A8F0E526467E55D_il2cpp_TypeInfo_var);
		bool L_1 = ((MMFeedbackCinemachineImpulse_tDA995C9877C6AC10EA0176B19A8F0E526467E55D_StaticFields*)il2cpp_codegen_static_fields_for(MMFeedbackCinemachineImpulse_tDA995C9877C6AC10EA0176B19A8F0E526467E55D_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_28;
		if (L_1)
		{
			goto IL_0010;
		}
	}

IL_000f:
	{
		// return;
		return;
	}

IL_0010:
	{
		// CinemachineImpulseManager.Instance.IgnoreTimeScale = (Timing.TimescaleMode == TimescaleModes.Unscaled);
		CinemachineImpulseManager_t19F063379BE6FCCBDB8F5D04F1ABAD447FACBA8F* L_2;
		L_2 = CinemachineImpulseManager_get_Instance_mCBBB7EE190D29704E4F44241A50BC2F6F23EB179(NULL);
		MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD* L_3 = ((MMFeedback_tE51A2F7A01B1E3BE46047E5A0D6BA5C79199FDCA*)__this)->___Timing_7;
		NullCheck(L_3);
		int32_t L_4 = L_3->___TimescaleMode_0;
		NullCheck(L_2);
		L_2->___IgnoreTimeScale_4 = (bool)((((int32_t)L_4) == ((int32_t)1))? 1 : 0);
		// float intensityMultiplier = Timing.ConstantIntensity ? 1f : feedbacksIntensity;
		MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD* L_5 = ((MMFeedback_tE51A2F7A01B1E3BE46047E5A0D6BA5C79199FDCA*)__this)->___Timing_7;
		NullCheck(L_5);
		bool L_6 = L_5->___ConstantIntensity_11;
		if (L_6)
		{
			goto IL_0038;
		}
	}
	{
		float L_7 = ___feedbacksIntensity1;
		G_B6_0 = L_7;
		goto IL_003d;
	}

IL_0038:
	{
		G_B6_0 = (1.0f);
	}

IL_003d:
	{
		V_0 = G_B6_0;
		// m_ImpulseDefinition.CreateEvent(position, Velocity * intensityMultiplier);
		CinemachineImpulseDefinition_t3F6992431B5EE7132783754081C473BABF2F4705* L_8 = __this->___m_ImpulseDefinition_29;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_9 = ___position0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_10 = __this->___Velocity_30;
		float L_11 = V_0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_12;
		L_12 = Vector3_op_Multiply_m87BA7C578F96C8E49BB07088DAAC4649F83B0353_inline(L_10, L_11, NULL);
		NullCheck(L_8);
		CinemachineImpulseDefinition_CreateEvent_m12158346403D3428D6DBC0D3D22DDDCF551E5B41(L_8, L_9, L_12, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackCinemachineImpulse::CustomStopFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackCinemachineImpulse_CustomStopFeedback_m7366BE8B560B4DA98133D3CEAB83116EDF6A3C36 (MMFeedbackCinemachineImpulse_tDA995C9877C6AC10EA0176B19A8F0E526467E55D* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMFeedbackCinemachineImpulse_tDA995C9877C6AC10EA0176B19A8F0E526467E55D_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// if (!Active || !FeedbackTypeAuthorized || !ClearImpulseOnStop)
		bool L_0 = ((MMFeedback_tE51A2F7A01B1E3BE46047E5A0D6BA5C79199FDCA*)__this)->___Active_4;
		if (!L_0)
		{
			goto IL_0017;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(MMFeedbackCinemachineImpulse_tDA995C9877C6AC10EA0176B19A8F0E526467E55D_il2cpp_TypeInfo_var);
		bool L_1 = ((MMFeedbackCinemachineImpulse_tDA995C9877C6AC10EA0176B19A8F0E526467E55D_StaticFields*)il2cpp_codegen_static_fields_for(MMFeedbackCinemachineImpulse_tDA995C9877C6AC10EA0176B19A8F0E526467E55D_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_28;
		if (!L_1)
		{
			goto IL_0017;
		}
	}
	{
		bool L_2 = __this->___ClearImpulseOnStop_31;
		if (L_2)
		{
			goto IL_0018;
		}
	}

IL_0017:
	{
		// return;
		return;
	}

IL_0018:
	{
		// base.CustomStopFeedback(position, feedbacksIntensity);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_3 = ___position0;
		float L_4 = ___feedbacksIntensity1;
		MMFeedback_CustomStopFeedback_m812755E219AA8EF519A2D89F6C91AB793AE27EDD(__this, L_3, L_4, NULL);
		// CinemachineImpulseManager.Instance.Clear();
		CinemachineImpulseManager_t19F063379BE6FCCBDB8F5D04F1ABAD447FACBA8F* L_5;
		L_5 = CinemachineImpulseManager_get_Instance_mCBBB7EE190D29704E4F44241A50BC2F6F23EB179(NULL);
		NullCheck(L_5);
		CinemachineImpulseManager_Clear_mA6DC571A238EB0C4C7B07C06D2263B5743FB82BA(L_5, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackCinemachineImpulse::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackCinemachineImpulse__ctor_mF0C1C34831E745FA19F86D7ED81711B3A23811D7 (MMFeedbackCinemachineImpulse_tDA995C9877C6AC10EA0176B19A8F0E526467E55D* __this, const RuntimeMethod* method) 
{
	{
		MMFeedback__ctor_mCD506F8FC949D7574B8EB30A5C0CC117C19BD647(__this, NULL);
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackCinemachineImpulse::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackCinemachineImpulse__cctor_m750F6A64B873A1B6CF710A875769B805D8917FF5 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMFeedbackCinemachineImpulse_tDA995C9877C6AC10EA0176B19A8F0E526467E55D_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public static bool FeedbackTypeAuthorized = true;
		((MMFeedbackCinemachineImpulse_tDA995C9877C6AC10EA0176B19A8F0E526467E55D_StaticFields*)il2cpp_codegen_static_fields_for(MMFeedbackCinemachineImpulse_tDA995C9877C6AC10EA0176B19A8F0E526467E55D_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_28 = (bool)1;
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackCinemachineImpulseClear::CustomPlayFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackCinemachineImpulseClear_CustomPlayFeedback_mB4C76D5D20D2F9C8603D979ABB66E165D491B404 (MMFeedbackCinemachineImpulseClear_t593754874A893902A94F35E475262D9F5E410CBF* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMFeedbackCinemachineImpulseClear_t593754874A893902A94F35E475262D9F5E410CBF_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// if (!Active || !FeedbackTypeAuthorized)
		bool L_0 = ((MMFeedback_tE51A2F7A01B1E3BE46047E5A0D6BA5C79199FDCA*)__this)->___Active_4;
		if (!L_0)
		{
			goto IL_000f;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(MMFeedbackCinemachineImpulseClear_t593754874A893902A94F35E475262D9F5E410CBF_il2cpp_TypeInfo_var);
		bool L_1 = ((MMFeedbackCinemachineImpulseClear_t593754874A893902A94F35E475262D9F5E410CBF_StaticFields*)il2cpp_codegen_static_fields_for(MMFeedbackCinemachineImpulseClear_t593754874A893902A94F35E475262D9F5E410CBF_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_28;
		if (L_1)
		{
			goto IL_0010;
		}
	}

IL_000f:
	{
		// return;
		return;
	}

IL_0010:
	{
		// CinemachineImpulseManager.Instance.Clear();
		CinemachineImpulseManager_t19F063379BE6FCCBDB8F5D04F1ABAD447FACBA8F* L_2;
		L_2 = CinemachineImpulseManager_get_Instance_mCBBB7EE190D29704E4F44241A50BC2F6F23EB179(NULL);
		NullCheck(L_2);
		CinemachineImpulseManager_Clear_mA6DC571A238EB0C4C7B07C06D2263B5743FB82BA(L_2, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackCinemachineImpulseClear::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackCinemachineImpulseClear__ctor_m508AF9C769E38565BCF2CB49953C21651E69A317 (MMFeedbackCinemachineImpulseClear_t593754874A893902A94F35E475262D9F5E410CBF* __this, const RuntimeMethod* method) 
{
	{
		MMFeedback__ctor_mCD506F8FC949D7574B8EB30A5C0CC117C19BD647(__this, NULL);
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackCinemachineImpulseClear::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackCinemachineImpulseClear__cctor_mC575F066130F49D92B73E8F9EECA48D7796FDF80 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMFeedbackCinemachineImpulseClear_t593754874A893902A94F35E475262D9F5E410CBF_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public static bool FeedbackTypeAuthorized = true;
		((MMFeedbackCinemachineImpulseClear_t593754874A893902A94F35E475262D9F5E410CBF_StaticFields*)il2cpp_codegen_static_fields_for(MMFeedbackCinemachineImpulseClear_t593754874A893902A94F35E475262D9F5E410CBF_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_28 = (bool)1;
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackCinemachineTransition::get_FeedbackDuration()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float MMFeedbackCinemachineTransition_get_FeedbackDuration_mCC54A3DA3D84D6766255CFDBA6816DECFDD8AB85 (MMFeedbackCinemachineTransition_t66579D56518B0A6FEC7B8EF5936D080172E93109* __this, const RuntimeMethod* method) 
{
	{
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(BlendDefintion.m_Time); } set { BlendDefintion.m_Time = value; } }
		CinemachineBlendDefinition_t6A16D5B51D440E317D413EC8612647EDA0A6580B* L_0 = (&__this->___BlendDefintion_36);
		float L_1 = L_0->___m_Time_1;
		float L_2;
		L_2 = VirtualFuncInvoker1< float, float >::Invoke(36 /* System.Single MoreMountains.Feedbacks.MMFeedback::ApplyTimeMultiplier(System.Single) */, __this, L_1);
		return L_2;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackCinemachineTransition::set_FeedbackDuration(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackCinemachineTransition_set_FeedbackDuration_mD612803A6A2D98AB4C6ECD8CB3770D35B55D36A7 (MMFeedbackCinemachineTransition_t66579D56518B0A6FEC7B8EF5936D080172E93109* __this, float ___value0, const RuntimeMethod* method) 
{
	{
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(BlendDefintion.m_Time); } set { BlendDefintion.m_Time = value; } }
		CinemachineBlendDefinition_t6A16D5B51D440E317D413EC8612647EDA0A6580B* L_0 = (&__this->___BlendDefintion_36);
		float L_1 = ___value0;
		L_0->___m_Time_1 = L_1;
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(BlendDefintion.m_Time); } set { BlendDefintion.m_Time = value; } }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackCinemachineTransition::CustomPlayFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackCinemachineTransition_CustomPlayFeedback_m5161365984117A0453F2F2AF42E2871CE3F4363E (MMFeedbackCinemachineTransition_t66579D56518B0A6FEC7B8EF5936D080172E93109* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMFeedbackCinemachineTransition_t66579D56518B0A6FEC7B8EF5936D080172E93109_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// if (!Active || !FeedbackTypeAuthorized)
		bool L_0 = ((MMFeedback_tE51A2F7A01B1E3BE46047E5A0D6BA5C79199FDCA*)__this)->___Active_4;
		if (!L_0)
		{
			goto IL_000f;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(MMFeedbackCinemachineTransition_t66579D56518B0A6FEC7B8EF5936D080172E93109_il2cpp_TypeInfo_var);
		bool L_1 = ((MMFeedbackCinemachineTransition_t66579D56518B0A6FEC7B8EF5936D080172E93109_StaticFields*)il2cpp_codegen_static_fields_for(MMFeedbackCinemachineTransition_t66579D56518B0A6FEC7B8EF5936D080172E93109_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_28;
		if (L_1)
		{
			goto IL_0010;
		}
	}

IL_000f:
	{
		// return;
		return;
	}

IL_0010:
	{
		// _tempBlend = BlendDefintion;
		CinemachineBlendDefinition_t6A16D5B51D440E317D413EC8612647EDA0A6580B L_2 = __this->___BlendDefintion_36;
		__this->____tempBlend_37 = L_2;
		Il2CppCodeGenWriteBarrier((void**)&(((&__this->____tempBlend_37))->___m_CustomCurve_2), (void*)NULL);
		// _tempBlend.m_Time = FeedbackDuration;
		CinemachineBlendDefinition_t6A16D5B51D440E317D413EC8612647EDA0A6580B* L_3 = (&__this->____tempBlend_37);
		float L_4;
		L_4 = VirtualFuncInvoker0< float >::Invoke(16 /* System.Single MoreMountains.Feedbacks.MMFeedback::get_FeedbackDuration() */, __this);
		L_3->___m_Time_1 = L_4;
		// if (Mode == Modes.Event)
		int32_t L_5 = __this->___Mode_29;
		if (L_5)
		{
			goto IL_006a;
		}
	}
	{
		// MMCinemachinePriorityEvent.Trigger(Channel, ForceMaxPriority, NewPriority, ForceTransition, _tempBlend, ResetValuesAfterTransition, Timing.TimescaleMode);
		int32_t L_6 = __this->___Channel_30;
		bool L_7 = __this->___ForceMaxPriority_34;
		int32_t L_8 = __this->___NewPriority_33;
		bool L_9 = __this->___ForceTransition_35;
		CinemachineBlendDefinition_t6A16D5B51D440E317D413EC8612647EDA0A6580B L_10 = __this->____tempBlend_37;
		bool L_11 = __this->___ResetValuesAfterTransition_32;
		MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD* L_12 = ((MMFeedback_tE51A2F7A01B1E3BE46047E5A0D6BA5C79199FDCA*)__this)->___Timing_7;
		NullCheck(L_12);
		int32_t L_13 = L_12->___TimescaleMode_0;
		MMCinemachinePriorityEvent_Trigger_mB101FF6CE1A5AA8C81FDAAE93FF075CAF7C34581(L_6, L_7, L_8, L_9, L_10, L_11, L_13, NULL);
		return;
	}

IL_006a:
	{
		// MMCinemachinePriorityEvent.Trigger(Channel, ForceMaxPriority, 0, ForceTransition, _tempBlend, ResetValuesAfterTransition, Timing.TimescaleMode);
		int32_t L_14 = __this->___Channel_30;
		bool L_15 = __this->___ForceMaxPriority_34;
		bool L_16 = __this->___ForceTransition_35;
		CinemachineBlendDefinition_t6A16D5B51D440E317D413EC8612647EDA0A6580B L_17 = __this->____tempBlend_37;
		bool L_18 = __this->___ResetValuesAfterTransition_32;
		MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD* L_19 = ((MMFeedback_tE51A2F7A01B1E3BE46047E5A0D6BA5C79199FDCA*)__this)->___Timing_7;
		NullCheck(L_19);
		int32_t L_20 = L_19->___TimescaleMode_0;
		MMCinemachinePriorityEvent_Trigger_mB101FF6CE1A5AA8C81FDAAE93FF075CAF7C34581(L_14, L_15, 0, L_16, L_17, L_18, L_20, NULL);
		// TargetVirtualCamera.Priority = NewPriority;
		CinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50* L_21 = __this->___TargetVirtualCamera_31;
		int32_t L_22 = __this->___NewPriority_33;
		NullCheck(L_21);
		CinemachineVirtualCameraBase_set_Priority_m233ED0376CE0BD1244CCA52DF4532C8988DC05AC_inline(L_21, L_22, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackCinemachineTransition::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackCinemachineTransition__ctor_mE197459336F90D968C079F460997BC9B07B3D3A1 (MMFeedbackCinemachineTransition_t66579D56518B0A6FEC7B8EF5936D080172E93109* __this, const RuntimeMethod* method) 
{
	{
		// public bool ResetValuesAfterTransition = true;
		__this->___ResetValuesAfterTransition_32 = (bool)1;
		// public int NewPriority = 10;
		__this->___NewPriority_33 = ((int32_t)10);
		// public bool ForceMaxPriority = true;
		__this->___ForceMaxPriority_34 = (bool)1;
		MMFeedback__ctor_mCD506F8FC949D7574B8EB30A5C0CC117C19BD647(__this, NULL);
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackCinemachineTransition::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackCinemachineTransition__cctor_mE03B086D44259D9E1631530C612512656836A460 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMFeedbackCinemachineTransition_t66579D56518B0A6FEC7B8EF5936D080172E93109_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public static bool FeedbackTypeAuthorized = true;
		((MMFeedbackCinemachineTransition_t66579D56518B0A6FEC7B8EF5936D080172E93109_StaticFields*)il2cpp_codegen_static_fields_for(MMFeedbackCinemachineTransition_t66579D56518B0A6FEC7B8EF5936D080172E93109_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_28 = (bool)1;
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Single MoreMountains.FeedbacksForThirdParty.MMF_CinemachineImpulse::get_FeedbackDuration()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float MMF_CinemachineImpulse_get_FeedbackDuration_m7DF82922006A07FF9C3CB02EA1E2D85422F3FE55 (MMF_CinemachineImpulse_t90A334FA345704DE6CAFD89E9F3B45D577717131* __this, const RuntimeMethod* method) 
{
	{
		// public override float FeedbackDuration { get { return m_ImpulseDefinition.m_TimeEnvelope.Duration; } }
		CinemachineImpulseDefinition_t3F6992431B5EE7132783754081C473BABF2F4705* L_0 = __this->___m_ImpulseDefinition_28;
		NullCheck(L_0);
		EnvelopeDefinition_tC875D919977CE4B1876A7CAAF64F9A087C86207E* L_1 = (&L_0->___m_TimeEnvelope_11);
		float L_2;
		L_2 = EnvelopeDefinition_get_Duration_m3CF863DC6B71344BE096AD9CBFC6C86AD2FF634C(L_1, NULL);
		return L_2;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_CinemachineImpulse::CustomPlayFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_CinemachineImpulse_CustomPlayFeedback_m327933AFC8064FB14C29D3036B926DC1739939AC (MMF_CinemachineImpulse_t90A334FA345704DE6CAFD89E9F3B45D577717131* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMF_CinemachineImpulse_t90A334FA345704DE6CAFD89E9F3B45D577717131_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	float V_0 = 0.0f;
	float G_B6_0 = 0.0f;
	{
		// if (!Active || !FeedbackTypeAuthorized)
		bool L_0 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Active_0;
		if (!L_0)
		{
			goto IL_000f;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(MMF_CinemachineImpulse_t90A334FA345704DE6CAFD89E9F3B45D577717131_il2cpp_TypeInfo_var);
		bool L_1 = ((MMF_CinemachineImpulse_t90A334FA345704DE6CAFD89E9F3B45D577717131_StaticFields*)il2cpp_codegen_static_fields_for(MMF_CinemachineImpulse_t90A334FA345704DE6CAFD89E9F3B45D577717131_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_27;
		if (L_1)
		{
			goto IL_0010;
		}
	}

IL_000f:
	{
		// return;
		return;
	}

IL_0010:
	{
		// CinemachineImpulseManager.Instance.IgnoreTimeScale = (Timing.TimescaleMode == TimescaleModes.Unscaled);
		CinemachineImpulseManager_t19F063379BE6FCCBDB8F5D04F1ABAD447FACBA8F* L_2;
		L_2 = CinemachineImpulseManager_get_Instance_mCBBB7EE190D29704E4F44241A50BC2F6F23EB179(NULL);
		MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD* L_3 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Timing_6;
		NullCheck(L_3);
		int32_t L_4 = L_3->___TimescaleMode_0;
		NullCheck(L_2);
		L_2->___IgnoreTimeScale_4 = (bool)((((int32_t)L_4) == ((int32_t)1))? 1 : 0);
		// float intensityMultiplier = Timing.ConstantIntensity ? 1f : feedbacksIntensity;
		MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD* L_5 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Timing_6;
		NullCheck(L_5);
		bool L_6 = L_5->___ConstantIntensity_11;
		if (L_6)
		{
			goto IL_0038;
		}
	}
	{
		float L_7 = ___feedbacksIntensity1;
		G_B6_0 = L_7;
		goto IL_003d;
	}

IL_0038:
	{
		G_B6_0 = (1.0f);
	}

IL_003d:
	{
		V_0 = G_B6_0;
		// m_ImpulseDefinition.CreateEvent(position, Velocity * intensityMultiplier);
		CinemachineImpulseDefinition_t3F6992431B5EE7132783754081C473BABF2F4705* L_8 = __this->___m_ImpulseDefinition_28;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_9 = ___position0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_10 = __this->___Velocity_29;
		float L_11 = V_0;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_12;
		L_12 = Vector3_op_Multiply_m87BA7C578F96C8E49BB07088DAAC4649F83B0353_inline(L_10, L_11, NULL);
		NullCheck(L_8);
		CinemachineImpulseDefinition_CreateEvent_m12158346403D3428D6DBC0D3D22DDDCF551E5B41(L_8, L_9, L_12, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_CinemachineImpulse::CustomStopFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_CinemachineImpulse_CustomStopFeedback_m2D53260C94A5B5F6052D238128BCEA4E15E0B35A (MMF_CinemachineImpulse_t90A334FA345704DE6CAFD89E9F3B45D577717131* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMF_CinemachineImpulse_t90A334FA345704DE6CAFD89E9F3B45D577717131_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// if (!Active || !FeedbackTypeAuthorized || !ClearImpulseOnStop)
		bool L_0 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Active_0;
		if (!L_0)
		{
			goto IL_0017;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(MMF_CinemachineImpulse_t90A334FA345704DE6CAFD89E9F3B45D577717131_il2cpp_TypeInfo_var);
		bool L_1 = ((MMF_CinemachineImpulse_t90A334FA345704DE6CAFD89E9F3B45D577717131_StaticFields*)il2cpp_codegen_static_fields_for(MMF_CinemachineImpulse_t90A334FA345704DE6CAFD89E9F3B45D577717131_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_27;
		if (!L_1)
		{
			goto IL_0017;
		}
	}
	{
		bool L_2 = __this->___ClearImpulseOnStop_30;
		if (L_2)
		{
			goto IL_0018;
		}
	}

IL_0017:
	{
		// return;
		return;
	}

IL_0018:
	{
		// base.CustomStopFeedback(position, feedbacksIntensity);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_3 = ___position0;
		float L_4 = ___feedbacksIntensity1;
		MMF_Feedback_CustomStopFeedback_m9388036D957D90AD8C6BC3C4B17AC9A7B3B49A30(__this, L_3, L_4, NULL);
		// CinemachineImpulseManager.Instance.Clear();
		CinemachineImpulseManager_t19F063379BE6FCCBDB8F5D04F1ABAD447FACBA8F* L_5;
		L_5 = CinemachineImpulseManager_get_Instance_mCBBB7EE190D29704E4F44241A50BC2F6F23EB179(NULL);
		NullCheck(L_5);
		CinemachineImpulseManager_Clear_mA6DC571A238EB0C4C7B07C06D2263B5743FB82BA(L_5, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_CinemachineImpulse::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_CinemachineImpulse__ctor_m047E6E68528C063C6058D4E36E4ABF70E845E28C (MMF_CinemachineImpulse_t90A334FA345704DE6CAFD89E9F3B45D577717131* __this, const RuntimeMethod* method) 
{
	{
		MMF_Feedback__ctor_mCD413701DAEE304A0840C520FF3EB470EE324AC5(__this, NULL);
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_CinemachineImpulse::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_CinemachineImpulse__cctor_mDF56927E5865698501F5C494B8242445491AC8FD (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMF_CinemachineImpulse_t90A334FA345704DE6CAFD89E9F3B45D577717131_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public static bool FeedbackTypeAuthorized = true;
		((MMF_CinemachineImpulse_t90A334FA345704DE6CAFD89E9F3B45D577717131_StaticFields*)il2cpp_codegen_static_fields_for(MMF_CinemachineImpulse_t90A334FA345704DE6CAFD89E9F3B45D577717131_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_27 = (bool)1;
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_CinemachineImpulseClear::CustomPlayFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_CinemachineImpulseClear_CustomPlayFeedback_m622D190B08335B8640FC7D9CF907CE4BF96A3C9A (MMF_CinemachineImpulseClear_t27C051FD2457C2ED6BF2929DD9603D9F4E3120A9* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMF_CinemachineImpulseClear_t27C051FD2457C2ED6BF2929DD9603D9F4E3120A9_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// if (!Active || !FeedbackTypeAuthorized)
		bool L_0 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Active_0;
		if (!L_0)
		{
			goto IL_000f;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(MMF_CinemachineImpulseClear_t27C051FD2457C2ED6BF2929DD9603D9F4E3120A9_il2cpp_TypeInfo_var);
		bool L_1 = ((MMF_CinemachineImpulseClear_t27C051FD2457C2ED6BF2929DD9603D9F4E3120A9_StaticFields*)il2cpp_codegen_static_fields_for(MMF_CinemachineImpulseClear_t27C051FD2457C2ED6BF2929DD9603D9F4E3120A9_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_27;
		if (L_1)
		{
			goto IL_0010;
		}
	}

IL_000f:
	{
		// return;
		return;
	}

IL_0010:
	{
		// CinemachineImpulseManager.Instance.Clear();
		CinemachineImpulseManager_t19F063379BE6FCCBDB8F5D04F1ABAD447FACBA8F* L_2;
		L_2 = CinemachineImpulseManager_get_Instance_mCBBB7EE190D29704E4F44241A50BC2F6F23EB179(NULL);
		NullCheck(L_2);
		CinemachineImpulseManager_Clear_mA6DC571A238EB0C4C7B07C06D2263B5743FB82BA(L_2, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_CinemachineImpulseClear::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_CinemachineImpulseClear__ctor_m15A600DA1716D5B0408182987F3496A05CB92ED7 (MMF_CinemachineImpulseClear_t27C051FD2457C2ED6BF2929DD9603D9F4E3120A9* __this, const RuntimeMethod* method) 
{
	{
		MMF_Feedback__ctor_mCD413701DAEE304A0840C520FF3EB470EE324AC5(__this, NULL);
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_CinemachineImpulseClear::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_CinemachineImpulseClear__cctor_mBDC1C2D393378F011EB5D1A3E20856D1BDAB99ED (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMF_CinemachineImpulseClear_t27C051FD2457C2ED6BF2929DD9603D9F4E3120A9_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public static bool FeedbackTypeAuthorized = true;
		((MMF_CinemachineImpulseClear_t27C051FD2457C2ED6BF2929DD9603D9F4E3120A9_StaticFields*)il2cpp_codegen_static_fields_for(MMF_CinemachineImpulseClear_t27C051FD2457C2ED6BF2929DD9603D9F4E3120A9_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_27 = (bool)1;
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_CinemachineImpulseSource::CustomPlayFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_CinemachineImpulseSource_CustomPlayFeedback_mC8AFF403882BCFDDBF8D119A26F3EC4FF8CF0EE6 (MMF_CinemachineImpulseSource_t9F058F7B40FDDD3C398BE92118D7F7BD2D861D49* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMF_CinemachineImpulseSource_t9F058F7B40FDDD3C398BE92118D7F7BD2D861D49_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// if (!Active || !FeedbackTypeAuthorized)
		bool L_0 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Active_0;
		if (!L_0)
		{
			goto IL_000f;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(MMF_CinemachineImpulseSource_t9F058F7B40FDDD3C398BE92118D7F7BD2D861D49_il2cpp_TypeInfo_var);
		bool L_1 = ((MMF_CinemachineImpulseSource_t9F058F7B40FDDD3C398BE92118D7F7BD2D861D49_StaticFields*)il2cpp_codegen_static_fields_for(MMF_CinemachineImpulseSource_t9F058F7B40FDDD3C398BE92118D7F7BD2D861D49_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_27;
		if (L_1)
		{
			goto IL_0010;
		}
	}

IL_000f:
	{
		// return;
		return;
	}

IL_0010:
	{
		// if (ImpulseSource != null)
		CinemachineImpulseSource_t48D0DCECD3CD8432BF4442EB45399BBD383A1B83* L_2 = __this->___ImpulseSource_29;
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_3;
		L_3 = Object_op_Inequality_mD0BE578448EAA61948F25C32F8DD55AB1F778602(L_2, (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C*)NULL, NULL);
		if (!L_3)
		{
			goto IL_002f;
		}
	}
	{
		// ImpulseSource.GenerateImpulse(Velocity);
		CinemachineImpulseSource_t48D0DCECD3CD8432BF4442EB45399BBD383A1B83* L_4 = __this->___ImpulseSource_29;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_5 = __this->___Velocity_28;
		NullCheck(L_4);
		CinemachineImpulseSource_GenerateImpulse_m700534622EE72CDDAFEBEFAB2E60F88654660B6A(L_4, L_5, NULL);
	}

IL_002f:
	{
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_CinemachineImpulseSource::CustomStopFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_CinemachineImpulseSource_CustomStopFeedback_m192BEBEFD3FE17E3F9EDDA06F0169C2AF48D4EB2 (MMF_CinemachineImpulseSource_t9F058F7B40FDDD3C398BE92118D7F7BD2D861D49* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMF_CinemachineImpulseSource_t9F058F7B40FDDD3C398BE92118D7F7BD2D861D49_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// if (!Active || !FeedbackTypeAuthorized || !ClearImpulseOnStop)
		bool L_0 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Active_0;
		if (!L_0)
		{
			goto IL_0017;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(MMF_CinemachineImpulseSource_t9F058F7B40FDDD3C398BE92118D7F7BD2D861D49_il2cpp_TypeInfo_var);
		bool L_1 = ((MMF_CinemachineImpulseSource_t9F058F7B40FDDD3C398BE92118D7F7BD2D861D49_StaticFields*)il2cpp_codegen_static_fields_for(MMF_CinemachineImpulseSource_t9F058F7B40FDDD3C398BE92118D7F7BD2D861D49_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_27;
		if (!L_1)
		{
			goto IL_0017;
		}
	}
	{
		bool L_2 = __this->___ClearImpulseOnStop_30;
		if (L_2)
		{
			goto IL_0018;
		}
	}

IL_0017:
	{
		// return;
		return;
	}

IL_0018:
	{
		// base.CustomStopFeedback(position, feedbacksIntensity);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_3 = ___position0;
		float L_4 = ___feedbacksIntensity1;
		MMF_Feedback_CustomStopFeedback_m9388036D957D90AD8C6BC3C4B17AC9A7B3B49A30(__this, L_3, L_4, NULL);
		// CinemachineImpulseManager.Instance.Clear();
		CinemachineImpulseManager_t19F063379BE6FCCBDB8F5D04F1ABAD447FACBA8F* L_5;
		L_5 = CinemachineImpulseManager_get_Instance_mCBBB7EE190D29704E4F44241A50BC2F6F23EB179(NULL);
		NullCheck(L_5);
		CinemachineImpulseManager_Clear_mA6DC571A238EB0C4C7B07C06D2263B5743FB82BA(L_5, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_CinemachineImpulseSource::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_CinemachineImpulseSource__ctor_m78C274900B84ABA7D4A221658400645C1F34EE18 (MMF_CinemachineImpulseSource_t9F058F7B40FDDD3C398BE92118D7F7BD2D861D49* __this, const RuntimeMethod* method) 
{
	{
		// public Vector3 Velocity = new Vector3(1f,1f,1f);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0;
		memset((&L_0), 0, sizeof(L_0));
		Vector3__ctor_m376936E6B999EF1ECBE57D990A386303E2283DE0_inline((&L_0), (1.0f), (1.0f), (1.0f), /*hidden argument*/NULL);
		__this->___Velocity_28 = L_0;
		MMF_Feedback__ctor_mCD413701DAEE304A0840C520FF3EB470EE324AC5(__this, NULL);
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_CinemachineImpulseSource::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_CinemachineImpulseSource__cctor_mDB44B980BDBEADF59B066E3A527F23DDE89B36C6 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMF_CinemachineImpulseSource_t9F058F7B40FDDD3C398BE92118D7F7BD2D861D49_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public static bool FeedbackTypeAuthorized = true;
		((MMF_CinemachineImpulseSource_t9F058F7B40FDDD3C398BE92118D7F7BD2D861D49_StaticFields*)il2cpp_codegen_static_fields_for(MMF_CinemachineImpulseSource_t9F058F7B40FDDD3C398BE92118D7F7BD2D861D49_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_27 = (bool)1;
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Single MoreMountains.FeedbacksForThirdParty.MMF_CinemachineTransition::get_FeedbackDuration()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float MMF_CinemachineTransition_get_FeedbackDuration_mE4AB9695C200504382AE6505797224924930CC97 (MMF_CinemachineTransition_t3F8513D5C3668F4DB53E0940D604A0D346CF24D8* __this, const RuntimeMethod* method) 
{
	{
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(BlendDefintion.m_Time); } set { BlendDefintion.m_Time = value; } }
		CinemachineBlendDefinition_t6A16D5B51D440E317D413EC8612647EDA0A6580B* L_0 = (&__this->___BlendDefintion_34);
		float L_1 = L_0->___m_Time_1;
		float L_2;
		L_2 = VirtualFuncInvoker1< float, float >::Invoke(43 /* System.Single MoreMountains.Feedbacks.MMF_Feedback::ApplyTimeMultiplier(System.Single) */, __this, L_1);
		return L_2;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_CinemachineTransition::set_FeedbackDuration(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_CinemachineTransition_set_FeedbackDuration_mF9347FCEDD53470118097014F9ADB90CC9B44127 (MMF_CinemachineTransition_t3F8513D5C3668F4DB53E0940D604A0D346CF24D8* __this, float ___value0, const RuntimeMethod* method) 
{
	{
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(BlendDefintion.m_Time); } set { BlendDefintion.m_Time = value; } }
		CinemachineBlendDefinition_t6A16D5B51D440E317D413EC8612647EDA0A6580B* L_0 = (&__this->___BlendDefintion_34);
		float L_1 = ___value0;
		L_0->___m_Time_1 = L_1;
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(BlendDefintion.m_Time); } set { BlendDefintion.m_Time = value; } }
		return;
	}
}
// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_CinemachineTransition::get_HasChannel()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool MMF_CinemachineTransition_get_HasChannel_mADF2C9C6758A7C6794F0CDC65420CF55078B64C9 (MMF_CinemachineTransition_t3F8513D5C3668F4DB53E0940D604A0D346CF24D8* __this, const RuntimeMethod* method) 
{
	{
		// public override bool HasChannel => true;
		return (bool)1;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_CinemachineTransition::CustomPlayFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_CinemachineTransition_CustomPlayFeedback_m3DFD4590423FEBE0F356EA26452B05546CE92BF0 (MMF_CinemachineTransition_t3F8513D5C3668F4DB53E0940D604A0D346CF24D8* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMF_CinemachineTransition_t3F8513D5C3668F4DB53E0940D604A0D346CF24D8_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// if (!Active || !FeedbackTypeAuthorized)
		bool L_0 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Active_0;
		if (!L_0)
		{
			goto IL_000f;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(MMF_CinemachineTransition_t3F8513D5C3668F4DB53E0940D604A0D346CF24D8_il2cpp_TypeInfo_var);
		bool L_1 = ((MMF_CinemachineTransition_t3F8513D5C3668F4DB53E0940D604A0D346CF24D8_StaticFields*)il2cpp_codegen_static_fields_for(MMF_CinemachineTransition_t3F8513D5C3668F4DB53E0940D604A0D346CF24D8_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_27;
		if (L_1)
		{
			goto IL_0010;
		}
	}

IL_000f:
	{
		// return;
		return;
	}

IL_0010:
	{
		// _tempBlend = BlendDefintion;
		CinemachineBlendDefinition_t6A16D5B51D440E317D413EC8612647EDA0A6580B L_2 = __this->___BlendDefintion_34;
		__this->____tempBlend_35 = L_2;
		Il2CppCodeGenWriteBarrier((void**)&(((&__this->____tempBlend_35))->___m_CustomCurve_2), (void*)NULL);
		// _tempBlend.m_Time = FeedbackDuration;
		CinemachineBlendDefinition_t6A16D5B51D440E317D413EC8612647EDA0A6580B* L_3 = (&__this->____tempBlend_35);
		float L_4;
		L_4 = VirtualFuncInvoker0< float >::Invoke(26 /* System.Single MoreMountains.Feedbacks.MMF_Feedback::get_FeedbackDuration() */, __this);
		L_3->___m_Time_1 = L_4;
		// if (Mode == Modes.Event)
		int32_t L_5 = __this->___Mode_28;
		if (L_5)
		{
			goto IL_006a;
		}
	}
	{
		// MMCinemachinePriorityEvent.Trigger(Channel, ForceMaxPriority, NewPriority, ForceTransition, _tempBlend, ResetValuesAfterTransition, Timing.TimescaleMode);
		int32_t L_6 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Channel_3;
		bool L_7 = __this->___ForceMaxPriority_32;
		int32_t L_8 = __this->___NewPriority_31;
		bool L_9 = __this->___ForceTransition_33;
		CinemachineBlendDefinition_t6A16D5B51D440E317D413EC8612647EDA0A6580B L_10 = __this->____tempBlend_35;
		bool L_11 = __this->___ResetValuesAfterTransition_30;
		MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD* L_12 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Timing_6;
		NullCheck(L_12);
		int32_t L_13 = L_12->___TimescaleMode_0;
		MMCinemachinePriorityEvent_Trigger_mB101FF6CE1A5AA8C81FDAAE93FF075CAF7C34581(L_6, L_7, L_8, L_9, L_10, L_11, L_13, NULL);
		return;
	}

IL_006a:
	{
		// MMCinemachinePriorityEvent.Trigger(Channel, ForceMaxPriority, 0, ForceTransition, _tempBlend, ResetValuesAfterTransition, Timing.TimescaleMode);
		int32_t L_14 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Channel_3;
		bool L_15 = __this->___ForceMaxPriority_32;
		bool L_16 = __this->___ForceTransition_33;
		CinemachineBlendDefinition_t6A16D5B51D440E317D413EC8612647EDA0A6580B L_17 = __this->____tempBlend_35;
		bool L_18 = __this->___ResetValuesAfterTransition_30;
		MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD* L_19 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Timing_6;
		NullCheck(L_19);
		int32_t L_20 = L_19->___TimescaleMode_0;
		MMCinemachinePriorityEvent_Trigger_mB101FF6CE1A5AA8C81FDAAE93FF075CAF7C34581(L_14, L_15, 0, L_16, L_17, L_18, L_20, NULL);
		// TargetVirtualCamera.Priority = NewPriority;
		CinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50* L_21 = __this->___TargetVirtualCamera_29;
		int32_t L_22 = __this->___NewPriority_31;
		NullCheck(L_21);
		CinemachineVirtualCameraBase_set_Priority_m233ED0376CE0BD1244CCA52DF4532C8988DC05AC_inline(L_21, L_22, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_CinemachineTransition::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_CinemachineTransition__ctor_m13697265EA0477E2BCEB077C9783B96C3B8CCF78 (MMF_CinemachineTransition_t3F8513D5C3668F4DB53E0940D604A0D346CF24D8* __this, const RuntimeMethod* method) 
{
	{
		// public bool ResetValuesAfterTransition = true;
		__this->___ResetValuesAfterTransition_30 = (bool)1;
		// public int NewPriority = 10;
		__this->___NewPriority_31 = ((int32_t)10);
		// public bool ForceMaxPriority = true;
		__this->___ForceMaxPriority_32 = (bool)1;
		MMF_Feedback__ctor_mCD413701DAEE304A0840C520FF3EB470EE324AC5(__this, NULL);
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_CinemachineTransition::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_CinemachineTransition__cctor_m2E6AA23362091CE633C16319BE319F887ABC8DA4 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMF_CinemachineTransition_t3F8513D5C3668F4DB53E0940D604A0D346CF24D8_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public static bool FeedbackTypeAuthorized = true;
		((MMF_CinemachineTransition_t3F8513D5C3668F4DB53E0940D604A0D346CF24D8_StaticFields*)il2cpp_codegen_static_fields_for(MMF_CinemachineTransition_t3F8513D5C3668F4DB53E0940D604A0D346CF24D8_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_27 = (bool)1;
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker::GetTime()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float MMCinemachineCameraShaker_GetTime_m5FA41F37498C0EFDCCBABA66C26491A0E3D6FD95 (MMCinemachineCameraShaker_tFF3CD059083D1A332500FCCEEC5CBFD51EAFDAF5* __this, const RuntimeMethod* method) 
{
	{
		// public virtual float GetTime() { return (_timescaleMode == TimescaleModes.Scaled) ? Time.time : Time.unscaledTime; }
		int32_t L_0 = __this->____timescaleMode_14;
		if (!L_0)
		{
			goto IL_000e;
		}
	}
	{
		float L_1;
		L_1 = Time_get_unscaledTime_mAF4040B858903E1325D1C65B8BF1AC61460B2503(NULL);
		return L_1;
	}

IL_000e:
	{
		float L_2;
		L_2 = Time_get_time_m3A271BB1B20041144AC5B7863B71AB1F0150374B(NULL);
		return L_2;
	}
}
// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker::GetDeltaTime()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float MMCinemachineCameraShaker_GetDeltaTime_m8C172518E7DEC953162B2DECBDF7436DBA962F83 (MMCinemachineCameraShaker_tFF3CD059083D1A332500FCCEEC5CBFD51EAFDAF5* __this, const RuntimeMethod* method) 
{
	{
		// public virtual float GetDeltaTime() { return (_timescaleMode == TimescaleModes.Scaled) ? Time.deltaTime : Time.unscaledDeltaTime; }
		int32_t L_0 = __this->____timescaleMode_14;
		if (!L_0)
		{
			goto IL_000e;
		}
	}
	{
		float L_1;
		L_1 = Time_get_unscaledDeltaTime_mF057EECA857E5C0F90A3F910D26D3EE59F27C4B5(NULL);
		return L_1;
	}

IL_000e:
	{
		float L_2;
		L_2 = Time_get_deltaTime_mC3195000401F0FD167DD2F948FD2BC58330D0865(NULL);
		return L_2;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker::Awake()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineCameraShaker_Awake_m3C05C3365913AAE198D61DA9C59A12DABFEF23A4 (MMCinemachineCameraShaker_tFF3CD059083D1A332500FCCEEC5CBFD51EAFDAF5* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&CinemachineVirtualCamera_GetCinemachineComponent_TisCinemachineBasicMultiChannelPerlin_tDAA09E3E93032C713228E84CA33B21293E9A9269_m63C03133A16FCEF5C276CB88AD2FB3EB89DD2AD1_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&GameObject_GetComponent_TisCinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50_m1A2DDA6B545C821D4E79E784051FDF79464CAD2D_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// _virtualCamera = this.gameObject.GetComponent<CinemachineVirtualCamera>();
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_0;
		L_0 = Component_get_gameObject_m57AEFBB14DB39EC476F740BA000E170355DE691B(__this, NULL);
		NullCheck(L_0);
		CinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50* L_1;
		L_1 = GameObject_GetComponent_TisCinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50_m1A2DDA6B545C821D4E79E784051FDF79464CAD2D(L_0, GameObject_GetComponent_TisCinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50_m1A2DDA6B545C821D4E79E784051FDF79464CAD2D_RuntimeMethod_var);
		__this->____virtualCamera_18 = L_1;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____virtualCamera_18), (void*)L_1);
		// _perlin = _virtualCamera.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
		CinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50* L_2 = __this->____virtualCamera_18;
		NullCheck(L_2);
		CinemachineBasicMultiChannelPerlin_tDAA09E3E93032C713228E84CA33B21293E9A9269* L_3;
		L_3 = CinemachineVirtualCamera_GetCinemachineComponent_TisCinemachineBasicMultiChannelPerlin_tDAA09E3E93032C713228E84CA33B21293E9A9269_m63C03133A16FCEF5C276CB88AD2FB3EB89DD2AD1(L_2, CinemachineVirtualCamera_GetCinemachineComponent_TisCinemachineBasicMultiChannelPerlin_tDAA09E3E93032C713228E84CA33B21293E9A9269_m63C03133A16FCEF5C276CB88AD2FB3EB89DD2AD1_RuntimeMethod_var);
		__this->____perlin_17 = L_3;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____perlin_17), (void*)L_3);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker::Start()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineCameraShaker_Start_m73F83A8B0222D9174CF7512E7B5633E5D08B979A (MMCinemachineCameraShaker_tFF3CD059083D1A332500FCCEEC5CBFD51EAFDAF5* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// if (_perlin != null)
		CinemachineBasicMultiChannelPerlin_tDAA09E3E93032C713228E84CA33B21293E9A9269* L_0 = __this->____perlin_17;
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_1;
		L_1 = Object_op_Inequality_mD0BE578448EAA61948F25C32F8DD55AB1F778602(L_0, (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C*)NULL, NULL);
		if (!L_1)
		{
			goto IL_0030;
		}
	}
	{
		// IdleAmplitude = _perlin.m_AmplitudeGain;
		CinemachineBasicMultiChannelPerlin_tDAA09E3E93032C713228E84CA33B21293E9A9269* L_2 = __this->____perlin_17;
		NullCheck(L_2);
		float L_3 = L_2->___m_AmplitudeGain_8;
		__this->___IdleAmplitude_7 = L_3;
		// IdleFrequency = _perlin.m_FrequencyGain;
		CinemachineBasicMultiChannelPerlin_tDAA09E3E93032C713228E84CA33B21293E9A9269* L_4 = __this->____perlin_17;
		NullCheck(L_4);
		float L_5 = L_4->___m_FrequencyGain_9;
		__this->___IdleFrequency_8 = L_5;
	}

IL_0030:
	{
		// _targetAmplitude = IdleAmplitude;
		float L_6 = __this->___IdleAmplitude_7;
		__this->____targetAmplitude_19 = L_6;
		// _targetFrequency = IdleFrequency;
		float L_7 = __this->___IdleFrequency_8;
		__this->____targetFrequency_20 = L_7;
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker::Update()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineCameraShaker_Update_m964CC72366F5D257FEAE0B31DE64EE99E126C8D0 (MMCinemachineCameraShaker_tFF3CD059083D1A332500FCCEEC5CBFD51EAFDAF5* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// if (_perlin != null)
		CinemachineBasicMultiChannelPerlin_tDAA09E3E93032C713228E84CA33B21293E9A9269* L_0 = __this->____perlin_17;
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_1;
		L_1 = Object_op_Inequality_mD0BE578448EAA61948F25C32F8DD55AB1F778602(L_0, (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C*)NULL, NULL);
		if (!L_1)
		{
			goto IL_004d;
		}
	}
	{
		// _perlin.m_AmplitudeGain = _targetAmplitude;
		CinemachineBasicMultiChannelPerlin_tDAA09E3E93032C713228E84CA33B21293E9A9269* L_2 = __this->____perlin_17;
		float L_3 = __this->____targetAmplitude_19;
		NullCheck(L_2);
		L_2->___m_AmplitudeGain_8 = L_3;
		// _perlin.m_FrequencyGain = Mathf.Lerp(_perlin.m_FrequencyGain, _targetFrequency, GetDeltaTime() * LerpSpeed);
		CinemachineBasicMultiChannelPerlin_tDAA09E3E93032C713228E84CA33B21293E9A9269* L_4 = __this->____perlin_17;
		CinemachineBasicMultiChannelPerlin_tDAA09E3E93032C713228E84CA33B21293E9A9269* L_5 = __this->____perlin_17;
		NullCheck(L_5);
		float L_6 = L_5->___m_FrequencyGain_9;
		float L_7 = __this->____targetFrequency_20;
		float L_8;
		L_8 = VirtualFuncInvoker0< float >::Invoke(5 /* System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker::GetDeltaTime() */, __this);
		float L_9 = __this->___LerpSpeed_9;
		float L_10;
		L_10 = Mathf_Lerp_m47EF2FFB7647BD0A1FDC26DC03E28B19812139B5_inline(L_6, L_7, ((float)il2cpp_codegen_multiply(L_8, L_9)), NULL);
		NullCheck(L_4);
		L_4->___m_FrequencyGain_9 = L_10;
	}

IL_004d:
	{
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker::ShakeCamera(System.Single,System.Boolean,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineCameraShaker_ShakeCamera_m205B1DA42B57384B9E6099A659A2D7A72222C367 (MMCinemachineCameraShaker_tFF3CD059083D1A332500FCCEEC5CBFD51EAFDAF5* __this, float ___duration0, bool ___infinite1, bool ___useUnscaledTime2, const RuntimeMethod* method) 
{
	{
		// StartCoroutine(ShakeCameraCo(duration, DefaultShakeAmplitude, DefaultShakeFrequency, infinite, useUnscaledTime));
		float L_0 = ___duration0;
		float L_1 = __this->___DefaultShakeAmplitude_5;
		float L_2 = __this->___DefaultShakeFrequency_6;
		bool L_3 = ___infinite1;
		bool L_4 = ___useUnscaledTime2;
		RuntimeObject* L_5;
		L_5 = VirtualFuncInvoker5< RuntimeObject*, float, float, float, bool, bool >::Invoke(11 /* System.Collections.IEnumerator MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker::ShakeCameraCo(System.Single,System.Single,System.Single,System.Boolean,System.Boolean) */, __this, L_0, L_1, L_2, L_3, L_4);
		Coroutine_t85EA685566A254C23F3FD77AB5BDFFFF8799596B* L_6;
		L_6 = MonoBehaviour_StartCoroutine_m4CAFF732AA28CD3BDC5363B44A863575530EC812(__this, L_5, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker::ShakeCamera(System.Single,System.Single,System.Single,System.Boolean,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineCameraShaker_ShakeCamera_mE23F478E58F52F68AA6B93CCE1C6E6404017CBBA (MMCinemachineCameraShaker_tFF3CD059083D1A332500FCCEEC5CBFD51EAFDAF5* __this, float ___duration0, float ___amplitude1, float ___frequency2, bool ___infinite3, bool ___useUnscaledTime4, const RuntimeMethod* method) 
{
	{
		// if (_shakeCoroutine != null)
		Coroutine_t85EA685566A254C23F3FD77AB5BDFFFF8799596B* L_0 = __this->____shakeCoroutine_21;
		if (!L_0)
		{
			goto IL_0014;
		}
	}
	{
		// StopCoroutine(_shakeCoroutine);
		Coroutine_t85EA685566A254C23F3FD77AB5BDFFFF8799596B* L_1 = __this->____shakeCoroutine_21;
		MonoBehaviour_StopCoroutine_mB0FC91BE84203BD8E360B3FBAE5B958B4C5ED22A(__this, L_1, NULL);
	}

IL_0014:
	{
		// _shakeCoroutine = StartCoroutine(ShakeCameraCo(duration, amplitude, frequency, infinite, useUnscaledTime));
		float L_2 = ___duration0;
		float L_3 = ___amplitude1;
		float L_4 = ___frequency2;
		bool L_5 = ___infinite3;
		bool L_6 = ___useUnscaledTime4;
		RuntimeObject* L_7;
		L_7 = VirtualFuncInvoker5< RuntimeObject*, float, float, float, bool, bool >::Invoke(11 /* System.Collections.IEnumerator MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker::ShakeCameraCo(System.Single,System.Single,System.Single,System.Boolean,System.Boolean) */, __this, L_2, L_3, L_4, L_5, L_6);
		Coroutine_t85EA685566A254C23F3FD77AB5BDFFFF8799596B* L_8;
		L_8 = MonoBehaviour_StartCoroutine_m4CAFF732AA28CD3BDC5363B44A863575530EC812(__this, L_7, NULL);
		__this->____shakeCoroutine_21 = L_8;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____shakeCoroutine_21), (void*)L_8);
		// }
		return;
	}
}
// System.Collections.IEnumerator MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker::ShakeCameraCo(System.Single,System.Single,System.Single,System.Boolean,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* MMCinemachineCameraShaker_ShakeCameraCo_m0B57179ACBEA3CF98767E5EC4E1357CBC80CECB7 (MMCinemachineCameraShaker_tFF3CD059083D1A332500FCCEEC5CBFD51EAFDAF5* __this, float ___duration0, float ___amplitude1, float ___frequency2, bool ___infinite3, bool ___useUnscaledTime4, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&U3CShakeCameraCoU3Ed__25_t0B875CE45C13DC2DE65A0CFE1DD74167BC71FF6D_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		U3CShakeCameraCoU3Ed__25_t0B875CE45C13DC2DE65A0CFE1DD74167BC71FF6D* L_0 = (U3CShakeCameraCoU3Ed__25_t0B875CE45C13DC2DE65A0CFE1DD74167BC71FF6D*)il2cpp_codegen_object_new(U3CShakeCameraCoU3Ed__25_t0B875CE45C13DC2DE65A0CFE1DD74167BC71FF6D_il2cpp_TypeInfo_var);
		NullCheck(L_0);
		U3CShakeCameraCoU3Ed__25__ctor_m30CC3D3C436592D75E79900DF9754427453F6813(L_0, 0, NULL);
		U3CShakeCameraCoU3Ed__25_t0B875CE45C13DC2DE65A0CFE1DD74167BC71FF6D* L_1 = L_0;
		NullCheck(L_1);
		L_1->___U3CU3E4__this_2 = __this;
		Il2CppCodeGenWriteBarrier((void**)(&L_1->___U3CU3E4__this_2), (void*)__this);
		U3CShakeCameraCoU3Ed__25_t0B875CE45C13DC2DE65A0CFE1DD74167BC71FF6D* L_2 = L_1;
		float L_3 = ___duration0;
		NullCheck(L_2);
		L_2->___duration_7 = L_3;
		U3CShakeCameraCoU3Ed__25_t0B875CE45C13DC2DE65A0CFE1DD74167BC71FF6D* L_4 = L_2;
		float L_5 = ___amplitude1;
		NullCheck(L_4);
		L_4->___amplitude_3 = L_5;
		U3CShakeCameraCoU3Ed__25_t0B875CE45C13DC2DE65A0CFE1DD74167BC71FF6D* L_6 = L_4;
		float L_7 = ___frequency2;
		NullCheck(L_6);
		L_6->___frequency_4 = L_7;
		U3CShakeCameraCoU3Ed__25_t0B875CE45C13DC2DE65A0CFE1DD74167BC71FF6D* L_8 = L_6;
		bool L_9 = ___infinite3;
		NullCheck(L_8);
		L_8->___infinite_6 = L_9;
		U3CShakeCameraCoU3Ed__25_t0B875CE45C13DC2DE65A0CFE1DD74167BC71FF6D* L_10 = L_8;
		bool L_11 = ___useUnscaledTime4;
		NullCheck(L_10);
		L_10->___useUnscaledTime_5 = L_11;
		return L_10;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker::CameraReset()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineCameraShaker_CameraReset_m777562FE20253349BDA90034444853E7CBF76B35 (MMCinemachineCameraShaker_tFF3CD059083D1A332500FCCEEC5CBFD51EAFDAF5* __this, const RuntimeMethod* method) 
{
	{
		// _targetAmplitude = IdleAmplitude;
		float L_0 = __this->___IdleAmplitude_7;
		__this->____targetAmplitude_19 = L_0;
		// _targetFrequency = IdleFrequency;
		float L_1 = __this->___IdleFrequency_8;
		__this->____targetFrequency_20 = L_1;
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker::OnCameraShakeEvent(System.Single,System.Single,System.Single,System.Single,System.Single,System.Single,System.Boolean,System.Int32,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineCameraShaker_OnCameraShakeEvent_mCF1A537CBEECA69FBB4697B6DFFA73A2553BC4C1 (MMCinemachineCameraShaker_tFF3CD059083D1A332500FCCEEC5CBFD51EAFDAF5* __this, float ___duration0, float ___amplitude1, float ___frequency2, float ___amplitudeX3, float ___amplitudeY4, float ___amplitudeZ5, bool ___infinite6, int32_t ___channel7, bool ___useUnscaledTime8, const RuntimeMethod* method) 
{
	{
		// if ((channel != Channel) && (channel != -1) && (Channel != -1))
		int32_t L_0 = ___channel7;
		int32_t L_1 = __this->___Channel_4;
		if ((((int32_t)L_0) == ((int32_t)L_1)))
		{
			goto IL_0019;
		}
	}
	{
		int32_t L_2 = ___channel7;
		if ((((int32_t)L_2) == ((int32_t)(-1))))
		{
			goto IL_0019;
		}
	}
	{
		int32_t L_3 = __this->___Channel_4;
		if ((((int32_t)L_3) == ((int32_t)(-1))))
		{
			goto IL_0019;
		}
	}
	{
		// return;
		return;
	}

IL_0019:
	{
		// this.ShakeCamera(duration, amplitude, frequency, infinite, useUnscaledTime);
		float L_4 = ___duration0;
		float L_5 = ___amplitude1;
		float L_6 = ___frequency2;
		bool L_7 = ___infinite6;
		bool L_8 = ___useUnscaledTime8;
		VirtualActionInvoker5< float, float, float, bool, bool >::Invoke(10 /* System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker::ShakeCamera(System.Single,System.Single,System.Single,System.Boolean,System.Boolean) */, __this, L_4, L_5, L_6, L_7, L_8);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker::OnCameraShakeStopEvent(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineCameraShaker_OnCameraShakeStopEvent_mF5C03F0C41A2D6DE19DDDA48F31DD2290DB76E23 (MMCinemachineCameraShaker_tFF3CD059083D1A332500FCCEEC5CBFD51EAFDAF5* __this, int32_t ___channel0, const RuntimeMethod* method) 
{
	{
		// if ((channel != Channel) && (channel != -1) && (Channel != -1))
		int32_t L_0 = ___channel0;
		int32_t L_1 = __this->___Channel_4;
		if ((((int32_t)L_0) == ((int32_t)L_1)))
		{
			goto IL_0017;
		}
	}
	{
		int32_t L_2 = ___channel0;
		if ((((int32_t)L_2) == ((int32_t)(-1))))
		{
			goto IL_0017;
		}
	}
	{
		int32_t L_3 = __this->___Channel_4;
		if ((((int32_t)L_3) == ((int32_t)(-1))))
		{
			goto IL_0017;
		}
	}
	{
		// return;
		return;
	}

IL_0017:
	{
		// if (_shakeCoroutine != null)
		Coroutine_t85EA685566A254C23F3FD77AB5BDFFFF8799596B* L_4 = __this->____shakeCoroutine_21;
		if (!L_4)
		{
			goto IL_002b;
		}
	}
	{
		// StopCoroutine(_shakeCoroutine);
		Coroutine_t85EA685566A254C23F3FD77AB5BDFFFF8799596B* L_5 = __this->____shakeCoroutine_21;
		MonoBehaviour_StopCoroutine_mB0FC91BE84203BD8E360B3FBAE5B958B4C5ED22A(__this, L_5, NULL);
	}

IL_002b:
	{
		// CameraReset();
		VirtualActionInvoker0::Invoke(12 /* System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker::CameraReset() */, __this);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker::OnEnable()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineCameraShaker_OnEnable_mD97234C840B048487BE7146E8B8F49C32E9BAF18 (MMCinemachineCameraShaker_tFF3CD059083D1A332500FCCEEC5CBFD51EAFDAF5* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Delegate_t8F3069CFED90E34B40CF5BB68B095ACF9775E0CA_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Delegate_tB9EED8DE5A66B26FCB9ADEDD1A910A2862B48662_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// MMCameraShakeEvent.Register(OnCameraShakeEvent);
		Delegate_t8F3069CFED90E34B40CF5BB68B095ACF9775E0CA* L_0 = (Delegate_t8F3069CFED90E34B40CF5BB68B095ACF9775E0CA*)il2cpp_codegen_object_new(Delegate_t8F3069CFED90E34B40CF5BB68B095ACF9775E0CA_il2cpp_TypeInfo_var);
		NullCheck(L_0);
		Delegate__ctor_m7CB5FEB96E25CDBD63C7E0A579CA8143E9BA8AFF(L_0, __this, (intptr_t)((void*)GetVirtualMethodInfo(__this, 13)), NULL);
		MMCameraShakeEvent_Register_m7BFC0967C829FBBEEE5DCD07ADF255BE5507D91D(L_0, NULL);
		// MMCameraShakeStopEvent.Register(OnCameraShakeStopEvent);
		Delegate_tB9EED8DE5A66B26FCB9ADEDD1A910A2862B48662* L_1 = (Delegate_tB9EED8DE5A66B26FCB9ADEDD1A910A2862B48662*)il2cpp_codegen_object_new(Delegate_tB9EED8DE5A66B26FCB9ADEDD1A910A2862B48662_il2cpp_TypeInfo_var);
		NullCheck(L_1);
		Delegate__ctor_m63C01375264F2FE4B307E18D29F117B3F23B73B2(L_1, __this, (intptr_t)((void*)GetVirtualMethodInfo(__this, 14)), NULL);
		MMCameraShakeStopEvent_Register_m318BD840460216E7221EFCE171AA62BDEB82BCEE(L_1, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker::OnDisable()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineCameraShaker_OnDisable_mCCFED102B1D3DF2B1A9EB093363B5C2AC9357E89 (MMCinemachineCameraShaker_tFF3CD059083D1A332500FCCEEC5CBFD51EAFDAF5* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Delegate_t8F3069CFED90E34B40CF5BB68B095ACF9775E0CA_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Delegate_tB9EED8DE5A66B26FCB9ADEDD1A910A2862B48662_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// MMCameraShakeEvent.Unregister(OnCameraShakeEvent);
		Delegate_t8F3069CFED90E34B40CF5BB68B095ACF9775E0CA* L_0 = (Delegate_t8F3069CFED90E34B40CF5BB68B095ACF9775E0CA*)il2cpp_codegen_object_new(Delegate_t8F3069CFED90E34B40CF5BB68B095ACF9775E0CA_il2cpp_TypeInfo_var);
		NullCheck(L_0);
		Delegate__ctor_m7CB5FEB96E25CDBD63C7E0A579CA8143E9BA8AFF(L_0, __this, (intptr_t)((void*)GetVirtualMethodInfo(__this, 13)), NULL);
		MMCameraShakeEvent_Unregister_m8ED0BB2E7A7CCEA4B2E35156AB22E65F3FF3A29A(L_0, NULL);
		// MMCameraShakeStopEvent.Unregister(OnCameraShakeStopEvent);
		Delegate_tB9EED8DE5A66B26FCB9ADEDD1A910A2862B48662* L_1 = (Delegate_tB9EED8DE5A66B26FCB9ADEDD1A910A2862B48662*)il2cpp_codegen_object_new(Delegate_tB9EED8DE5A66B26FCB9ADEDD1A910A2862B48662_il2cpp_TypeInfo_var);
		NullCheck(L_1);
		Delegate__ctor_m63C01375264F2FE4B307E18D29F117B3F23B73B2(L_1, __this, (intptr_t)((void*)GetVirtualMethodInfo(__this, 14)), NULL);
		MMCameraShakeStopEvent_Unregister_mE69EA56078B4ABA74367F9C073BB02FFC27BF0EE(L_1, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker::TestShake()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineCameraShaker_TestShake_m88E644DAB400000396A3ED6B5FD998E49FE225BC (MMCinemachineCameraShaker_tFF3CD059083D1A332500FCCEEC5CBFD51EAFDAF5* __this, const RuntimeMethod* method) 
{
	{
		// MMCameraShakeEvent.Trigger(TestDuration, TestAmplitude, TestFrequency, 0f, 0f, 0f, false, 0);
		float L_0 = __this->___TestDuration_10;
		float L_1 = __this->___TestAmplitude_11;
		float L_2 = __this->___TestFrequency_12;
		MMCameraShakeEvent_Trigger_m71E4F28DF8D86A80F8C48EB2F985FC776230559F(L_0, L_1, L_2, (0.0f), (0.0f), (0.0f), (bool)0, 0, (bool)0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineCameraShaker__ctor_m3041D9ECA821BF013877FDD10182B0FFA66AC034 (MMCinemachineCameraShaker_tFF3CD059083D1A332500FCCEEC5CBFD51EAFDAF5* __this, const RuntimeMethod* method) 
{
	{
		// public float DefaultShakeAmplitude = .5f;
		__this->___DefaultShakeAmplitude_5 = (0.5f);
		// public float DefaultShakeFrequency = 10f;
		__this->___DefaultShakeFrequency_6 = (10.0f);
		// public float IdleFrequency = 1f;
		__this->___IdleFrequency_8 = (1.0f);
		// public float LerpSpeed = 5f;
		__this->___LerpSpeed_9 = (5.0f);
		// public float TestDuration = 0.3f;
		__this->___TestDuration_10 = (0.300000012f);
		// public float TestAmplitude = 2f;
		__this->___TestAmplitude_11 = (2.0f);
		// public float TestFrequency = 20f;
		__this->___TestFrequency_12 = (20.0f);
		MonoBehaviour__ctor_m592DB0105CA0BC97AA1C5F4AD27B12D68A3B7C1E(__this, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker/<ShakeCameraCo>d__25::.ctor(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void U3CShakeCameraCoU3Ed__25__ctor_m30CC3D3C436592D75E79900DF9754427453F6813 (U3CShakeCameraCoU3Ed__25_t0B875CE45C13DC2DE65A0CFE1DD74167BC71FF6D* __this, int32_t ___U3CU3E1__state0, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		int32_t L_0 = ___U3CU3E1__state0;
		__this->___U3CU3E1__state_0 = L_0;
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker/<ShakeCameraCo>d__25::System.IDisposable.Dispose()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void U3CShakeCameraCoU3Ed__25_System_IDisposable_Dispose_mCB9D24CAD4F35E2C6C09DFC905CCA9F6341C9121 (U3CShakeCameraCoU3Ed__25_t0B875CE45C13DC2DE65A0CFE1DD74167BC71FF6D* __this, const RuntimeMethod* method) 
{
	{
		return;
	}
}
// System.Boolean MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker/<ShakeCameraCo>d__25::MoveNext()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool U3CShakeCameraCoU3Ed__25_MoveNext_m708ABB8B0DA3980359EC067786A3F75F1699EFFE (U3CShakeCameraCoU3Ed__25_t0B875CE45C13DC2DE65A0CFE1DD74167BC71FF6D* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&WaitForSeconds_tF179DF251655B8DF044952E70A60DF4B358A3DD3_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	MMCinemachineCameraShaker_tFF3CD059083D1A332500FCCEEC5CBFD51EAFDAF5* V_1 = NULL;
	MMCinemachineCameraShaker_tFF3CD059083D1A332500FCCEEC5CBFD51EAFDAF5* G_B5_0 = NULL;
	MMCinemachineCameraShaker_tFF3CD059083D1A332500FCCEEC5CBFD51EAFDAF5* G_B4_0 = NULL;
	int32_t G_B6_0 = 0;
	MMCinemachineCameraShaker_tFF3CD059083D1A332500FCCEEC5CBFD51EAFDAF5* G_B6_1 = NULL;
	{
		int32_t L_0 = __this->___U3CU3E1__state_0;
		V_0 = L_0;
		MMCinemachineCameraShaker_tFF3CD059083D1A332500FCCEEC5CBFD51EAFDAF5* L_1 = __this->___U3CU3E4__this_2;
		V_1 = L_1;
		int32_t L_2 = V_0;
		if (!L_2)
		{
			goto IL_0017;
		}
	}
	{
		int32_t L_3 = V_0;
		if ((((int32_t)L_3) == ((int32_t)1)))
		{
			goto IL_006a;
		}
	}
	{
		return (bool)0;
	}

IL_0017:
	{
		__this->___U3CU3E1__state_0 = (-1);
		// _targetAmplitude  = amplitude;
		MMCinemachineCameraShaker_tFF3CD059083D1A332500FCCEEC5CBFD51EAFDAF5* L_4 = V_1;
		float L_5 = __this->___amplitude_3;
		NullCheck(L_4);
		L_4->____targetAmplitude_19 = L_5;
		// _targetFrequency = frequency;
		MMCinemachineCameraShaker_tFF3CD059083D1A332500FCCEEC5CBFD51EAFDAF5* L_6 = V_1;
		float L_7 = __this->___frequency_4;
		NullCheck(L_6);
		L_6->____targetFrequency_20 = L_7;
		// _timescaleMode = useUnscaledTime ? TimescaleModes.Unscaled : TimescaleModes.Scaled;
		MMCinemachineCameraShaker_tFF3CD059083D1A332500FCCEEC5CBFD51EAFDAF5* L_8 = V_1;
		bool L_9 = __this->___useUnscaledTime_5;
		G_B4_0 = L_8;
		if (L_9)
		{
			G_B5_0 = L_8;
			goto IL_0042;
		}
	}
	{
		G_B6_0 = 0;
		G_B6_1 = G_B4_0;
		goto IL_0043;
	}

IL_0042:
	{
		G_B6_0 = 1;
		G_B6_1 = G_B5_0;
	}

IL_0043:
	{
		NullCheck(G_B6_1);
		G_B6_1->____timescaleMode_14 = G_B6_0;
		// if (!infinite)
		bool L_10 = __this->___infinite_6;
		if (L_10)
		{
			goto IL_0077;
		}
	}
	{
		// yield return new WaitForSeconds(duration);
		float L_11 = __this->___duration_7;
		WaitForSeconds_tF179DF251655B8DF044952E70A60DF4B358A3DD3* L_12 = (WaitForSeconds_tF179DF251655B8DF044952E70A60DF4B358A3DD3*)il2cpp_codegen_object_new(WaitForSeconds_tF179DF251655B8DF044952E70A60DF4B358A3DD3_il2cpp_TypeInfo_var);
		NullCheck(L_12);
		WaitForSeconds__ctor_m579F95BADEDBAB4B3A7E302C6EE3995926EF2EFC(L_12, L_11, NULL);
		__this->___U3CU3E2__current_1 = L_12;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___U3CU3E2__current_1), (void*)L_12);
		__this->___U3CU3E1__state_0 = 1;
		return (bool)1;
	}

IL_006a:
	{
		__this->___U3CU3E1__state_0 = (-1);
		// CameraReset();
		MMCinemachineCameraShaker_tFF3CD059083D1A332500FCCEEC5CBFD51EAFDAF5* L_13 = V_1;
		NullCheck(L_13);
		VirtualActionInvoker0::Invoke(12 /* System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker::CameraReset() */, L_13);
	}

IL_0077:
	{
		// }
		return (bool)0;
	}
}
// System.Object MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker/<ShakeCameraCo>d__25::System.Collections.Generic.IEnumerator<System.Object>.get_Current()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* U3CShakeCameraCoU3Ed__25_System_Collections_Generic_IEnumeratorU3CSystem_ObjectU3E_get_Current_mB4ED006CC4CFABAA00DAD8EADC7672DF2945B243 (U3CShakeCameraCoU3Ed__25_t0B875CE45C13DC2DE65A0CFE1DD74167BC71FF6D* __this, const RuntimeMethod* method) 
{
	{
		RuntimeObject* L_0 = __this->___U3CU3E2__current_1;
		return L_0;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker/<ShakeCameraCo>d__25::System.Collections.IEnumerator.Reset()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void U3CShakeCameraCoU3Ed__25_System_Collections_IEnumerator_Reset_m4ADC8BB3251C00B25EAFD66E20DFC4F9367A02EA (U3CShakeCameraCoU3Ed__25_t0B875CE45C13DC2DE65A0CFE1DD74167BC71FF6D* __this, const RuntimeMethod* method) 
{
	{
		NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A* L_0 = (NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A_il2cpp_TypeInfo_var)));
		NullCheck(L_0);
		NotSupportedException__ctor_m1398D0CDE19B36AA3DE9392879738C1EA2439CDF(L_0, NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_0, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&U3CShakeCameraCoU3Ed__25_System_Collections_IEnumerator_Reset_m4ADC8BB3251C00B25EAFD66E20DFC4F9367A02EA_RuntimeMethod_var)));
	}
}
// System.Object MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker/<ShakeCameraCo>d__25::System.Collections.IEnumerator.get_Current()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* U3CShakeCameraCoU3Ed__25_System_Collections_IEnumerator_get_Current_m524E7CA8D5E54D040A5CB60D777A8607ACD0C389 (U3CShakeCameraCoU3Ed__25_t0B875CE45C13DC2DE65A0CFE1DD74167BC71FF6D* __this, const RuntimeMethod* method) 
{
	{
		RuntimeObject* L_0 = __this->___U3CU3E2__current_1;
		return L_0;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineClippingPlanesShaker::Initialization()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineClippingPlanesShaker_Initialization_m605D3A3D5E192592B530584FE0E779380371223C (MMCinemachineClippingPlanesShaker_t7851747D89A493856A718862B75850B59C99DB3D* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&GameObject_GetComponent_TisCinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50_m1A2DDA6B545C821D4E79E784051FDF79464CAD2D_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// base.Initialization();
		MMShaker_Initialization_mF435F195C4DE0AB245013FE4AC5C49DAF00EA29A(__this, NULL);
		// _targetCamera = this.gameObject.GetComponent<CinemachineVirtualCamera>();
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_0;
		L_0 = Component_get_gameObject_m57AEFBB14DB39EC476F740BA000E170355DE691B(__this, NULL);
		NullCheck(L_0);
		CinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50* L_1;
		L_1 = GameObject_GetComponent_TisCinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50_m1A2DDA6B545C821D4E79E784051FDF79464CAD2D(L_0, GameObject_GetComponent_TisCinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50_m1A2DDA6B545C821D4E79E784051FDF79464CAD2D_RuntimeMethod_var);
		__this->____targetCamera_27 = L_1;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____targetCamera_27), (void*)L_1);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineClippingPlanesShaker::Reset()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineClippingPlanesShaker_Reset_mE9A4C7B81616469D1898B8BB7C23874EFFC0FF61 (MMCinemachineClippingPlanesShaker_t7851747D89A493856A718862B75850B59C99DB3D* __this, const RuntimeMethod* method) 
{
	{
		// ShakeDuration = 0.5f;
		((MMShaker_t48AAF716B7D3FC0C6FB15A32772D7DF0D57FCC31*)__this)->___ShakeDuration_5 = (0.5f);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineClippingPlanesShaker::Shake()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineClippingPlanesShaker_Shake_mBE6B5179C7EFCE9A56008C641880B11436E2EDDD (MMCinemachineClippingPlanesShaker_t7851747D89A493856A718862B75850B59C99DB3D* __this, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	float V_1 = 0.0f;
	{
		// float newNear = ShakeFloat(ShakeNear, RemapNearZero, RemapNearOne, RelativeClippingPlanes, _initialNear);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_0 = __this->___ShakeNear_21;
		float L_1 = __this->___RemapNearZero_22;
		float L_2 = __this->___RemapNearOne_23;
		bool L_3 = __this->___RelativeClippingPlanes_20;
		float L_4 = __this->____initialNear_28;
		float L_5;
		L_5 = VirtualFuncInvoker5< float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, bool, float >::Invoke(13 /* System.Single MoreMountains.Feedbacks.MMShaker::ShakeFloat(UnityEngine.AnimationCurve,System.Single,System.Single,System.Boolean,System.Single) */, __this, L_0, L_1, L_2, L_3, L_4);
		V_0 = L_5;
		// _targetCamera.m_Lens.NearClipPlane = newNear;
		CinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50* L_6 = __this->____targetCamera_27;
		NullCheck(L_6);
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE* L_7 = (&L_6->___m_Lens_30);
		float L_8 = V_0;
		L_7->___NearClipPlane_3 = L_8;
		// float newFar = ShakeFloat(ShakeFar, RemapFarZero, RemapFarOne, RelativeClippingPlanes, _initialFar);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_9 = __this->___ShakeFar_24;
		float L_10 = __this->___RemapFarZero_25;
		float L_11 = __this->___RemapFarOne_26;
		bool L_12 = __this->___RelativeClippingPlanes_20;
		float L_13 = __this->____initialFar_29;
		float L_14;
		L_14 = VirtualFuncInvoker5< float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, bool, float >::Invoke(13 /* System.Single MoreMountains.Feedbacks.MMShaker::ShakeFloat(UnityEngine.AnimationCurve,System.Single,System.Single,System.Boolean,System.Single) */, __this, L_9, L_10, L_11, L_12, L_13);
		V_1 = L_14;
		// _targetCamera.m_Lens.FarClipPlane = newFar;
		CinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50* L_15 = __this->____targetCamera_27;
		NullCheck(L_15);
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE* L_16 = (&L_15->___m_Lens_30);
		float L_17 = V_1;
		L_16->___FarClipPlane_4 = L_17;
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineClippingPlanesShaker::GrabInitialValues()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineClippingPlanesShaker_GrabInitialValues_mEA6A3C163EC251DB3376C955DB2B55F5D62DAEA1 (MMCinemachineClippingPlanesShaker_t7851747D89A493856A718862B75850B59C99DB3D* __this, const RuntimeMethod* method) 
{
	{
		// _initialNear = _targetCamera.m_Lens.NearClipPlane;
		CinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50* L_0 = __this->____targetCamera_27;
		NullCheck(L_0);
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE* L_1 = (&L_0->___m_Lens_30);
		float L_2 = L_1->___NearClipPlane_3;
		__this->____initialNear_28 = L_2;
		// _initialFar = _targetCamera.m_Lens.FarClipPlane;
		CinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50* L_3 = __this->____targetCamera_27;
		NullCheck(L_3);
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE* L_4 = (&L_3->___m_Lens_30);
		float L_5 = L_4->___FarClipPlane_4;
		__this->____initialFar_29 = L_5;
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineClippingPlanesShaker::OnMMCameraClippingPlanesShakeEvent(UnityEngine.AnimationCurve,System.Single,System.Single,System.Single,UnityEngine.AnimationCurve,System.Single,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineClippingPlanesShaker_OnMMCameraClippingPlanesShakeEvent_m0F0D9D3A2D2ED0F18CD98B13B8457BCA6DDB4D95 (MMCinemachineClippingPlanesShaker_t7851747D89A493856A718862B75850B59C99DB3D* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___animNearCurve0, float ___duration1, float ___remapNearMin2, float ___remapNearMax3, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___animFarCurve4, float ___remapFarMin5, float ___remapFarMax6, bool ___relativeValues7, float ___feedbacksIntensity8, int32_t ___channel9, bool ___resetShakerValuesAfterShake10, bool ___resetTargetValuesAfterShake11, bool ___forwardDirection12, int32_t ___timescaleMode13, bool ___stop14, const RuntimeMethod* method) 
{
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		// if (!CheckEventAllowed(channel))
		int32_t L_0 = ___channel9;
		il2cpp_codegen_initobj((&V_0), sizeof(Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2));
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_1 = V_0;
		bool L_2;
		L_2 = VirtualFuncInvoker4< bool, int32_t, bool, float, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 >::Invoke(24 /* System.Boolean MoreMountains.Feedbacks.MMShaker::CheckEventAllowed(System.Int32,System.Boolean,System.Single,UnityEngine.Vector3) */, __this, L_0, (bool)0, (0.0f), L_1);
		if (L_2)
		{
			goto IL_001a;
		}
	}
	{
		// return;
		return;
	}

IL_001a:
	{
		// if (stop)
		bool L_3 = ___stop14;
		if (!L_3)
		{
			goto IL_0025;
		}
	}
	{
		// Stop();
		VirtualActionInvoker0::Invoke(21 /* System.Void MoreMountains.Feedbacks.MMShaker::Stop() */, __this);
		// return;
		return;
	}

IL_0025:
	{
		// if (!Interruptible && Shaking)
		bool L_4 = ((MMShaker_t48AAF716B7D3FC0C6FB15A32772D7DF0D57FCC31*)__this)->___Interruptible_8;
		if (L_4)
		{
			goto IL_0036;
		}
	}
	{
		bool L_5 = ((MMShaker_t48AAF716B7D3FC0C6FB15A32772D7DF0D57FCC31*)__this)->___Shaking_11;
		if (!L_5)
		{
			goto IL_0036;
		}
	}
	{
		// return;
		return;
	}

IL_0036:
	{
		// _resetShakerValuesAfterShake = resetShakerValuesAfterShake;
		bool L_6 = ___resetShakerValuesAfterShake10;
		((MMShaker_t48AAF716B7D3FC0C6FB15A32772D7DF0D57FCC31*)__this)->____resetShakerValuesAfterShake_17 = L_6;
		// _resetTargetValuesAfterShake = resetTargetValuesAfterShake;
		bool L_7 = ___resetTargetValuesAfterShake11;
		((MMShaker_t48AAF716B7D3FC0C6FB15A32772D7DF0D57FCC31*)__this)->____resetTargetValuesAfterShake_18 = L_7;
		// if (resetShakerValuesAfterShake)
		bool L_8 = ___resetShakerValuesAfterShake10;
		if (!L_8)
		{
			goto IL_00aa;
		}
	}
	{
		// _originalShakeDuration = ShakeDuration;
		float L_9 = ((MMShaker_t48AAF716B7D3FC0C6FB15A32772D7DF0D57FCC31*)__this)->___ShakeDuration_5;
		__this->____originalShakeDuration_30 = L_9;
		// _originalShakeNear = ShakeNear;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_10 = __this->___ShakeNear_21;
		__this->____originalShakeNear_32 = L_10;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____originalShakeNear_32), (void*)L_10);
		// _originalShakeFar = ShakeFar;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_11 = __this->___ShakeFar_24;
		__this->____originalShakeFar_35 = L_11;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____originalShakeFar_35), (void*)L_11);
		// _originalRemapNearZero = RemapNearZero;
		float L_12 = __this->___RemapNearZero_22;
		__this->____originalRemapNearZero_33 = L_12;
		// _originalRemapNearOne = RemapNearOne;
		float L_13 = __this->___RemapNearOne_23;
		__this->____originalRemapNearOne_34 = L_13;
		// _originalRemapFarZero = RemapFarZero;
		float L_14 = __this->___RemapFarZero_25;
		__this->____originalRemapFarZero_36 = L_14;
		// _originalRemapFarOne = RemapFarOne;
		float L_15 = __this->___RemapFarOne_26;
		__this->____originalRemapFarOne_37 = L_15;
		// _originalRelativeClippingPlanes = RelativeClippingPlanes;
		bool L_16 = __this->___RelativeClippingPlanes_20;
		__this->____originalRelativeClippingPlanes_31 = L_16;
	}

IL_00aa:
	{
		// TimescaleMode = timescaleMode;
		int32_t L_17 = ___timescaleMode13;
		((MMShaker_t48AAF716B7D3FC0C6FB15A32772D7DF0D57FCC31*)__this)->___TimescaleMode_13 = L_17;
		// ShakeDuration = duration;
		float L_18 = ___duration1;
		((MMShaker_t48AAF716B7D3FC0C6FB15A32772D7DF0D57FCC31*)__this)->___ShakeDuration_5 = L_18;
		// ShakeNear = animNearCurve;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_19 = ___animNearCurve0;
		__this->___ShakeNear_21 = L_19;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ShakeNear_21), (void*)L_19);
		// RemapNearZero = remapNearMin * feedbacksIntensity;
		float L_20 = ___remapNearMin2;
		float L_21 = ___feedbacksIntensity8;
		__this->___RemapNearZero_22 = ((float)il2cpp_codegen_multiply(L_20, L_21));
		// RemapNearOne = remapNearMax * feedbacksIntensity;
		float L_22 = ___remapNearMax3;
		float L_23 = ___feedbacksIntensity8;
		__this->___RemapNearOne_23 = ((float)il2cpp_codegen_multiply(L_22, L_23));
		// ShakeFar = animFarCurve;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_24 = ___animFarCurve4;
		__this->___ShakeFar_24 = L_24;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ShakeFar_24), (void*)L_24);
		// RemapFarZero = remapFarMin * feedbacksIntensity;
		float L_25 = ___remapFarMin5;
		float L_26 = ___feedbacksIntensity8;
		__this->___RemapFarZero_25 = ((float)il2cpp_codegen_multiply(L_25, L_26));
		// RemapFarOne = remapFarMax * feedbacksIntensity;
		float L_27 = ___remapFarMax6;
		float L_28 = ___feedbacksIntensity8;
		__this->___RemapFarOne_26 = ((float)il2cpp_codegen_multiply(L_27, L_28));
		// RelativeClippingPlanes = relativeValues;
		bool L_29 = ___relativeValues7;
		__this->___RelativeClippingPlanes_20 = L_29;
		// ForwardDirection = forwardDirection;
		bool L_30 = ___forwardDirection12;
		((MMShaker_t48AAF716B7D3FC0C6FB15A32772D7DF0D57FCC31*)__this)->___ForwardDirection_12 = L_30;
		// Play();
		VirtualActionInvoker0::Invoke(20 /* System.Void MoreMountains.Feedbacks.MMShaker::Play() */, __this);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineClippingPlanesShaker::ResetTargetValues()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineClippingPlanesShaker_ResetTargetValues_mDA2C536D84A8348CB74FC9AE25B0ABDB6A747250 (MMCinemachineClippingPlanesShaker_t7851747D89A493856A718862B75850B59C99DB3D* __this, const RuntimeMethod* method) 
{
	{
		// base.ResetTargetValues();
		MMShaker_ResetTargetValues_mD7E138483910DEE0DEF4276FF39F07A6AE80AE59(__this, NULL);
		// _targetCamera.m_Lens.NearClipPlane = _initialNear;
		CinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50* L_0 = __this->____targetCamera_27;
		NullCheck(L_0);
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE* L_1 = (&L_0->___m_Lens_30);
		float L_2 = __this->____initialNear_28;
		L_1->___NearClipPlane_3 = L_2;
		// _targetCamera.m_Lens.FarClipPlane = _initialFar;
		CinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50* L_3 = __this->____targetCamera_27;
		NullCheck(L_3);
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE* L_4 = (&L_3->___m_Lens_30);
		float L_5 = __this->____initialFar_29;
		L_4->___FarClipPlane_4 = L_5;
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineClippingPlanesShaker::ResetShakerValues()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineClippingPlanesShaker_ResetShakerValues_mAD1967572FEBC1B1C727BAD2EF8C9DEF401483EB (MMCinemachineClippingPlanesShaker_t7851747D89A493856A718862B75850B59C99DB3D* __this, const RuntimeMethod* method) 
{
	{
		// base.ResetShakerValues();
		MMShaker_ResetShakerValues_mF597524D875B4EA6053014C7E9F63177D123C490(__this, NULL);
		// ShakeDuration = _originalShakeDuration;
		float L_0 = __this->____originalShakeDuration_30;
		((MMShaker_t48AAF716B7D3FC0C6FB15A32772D7DF0D57FCC31*)__this)->___ShakeDuration_5 = L_0;
		// ShakeNear = _originalShakeNear;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_1 = __this->____originalShakeNear_32;
		__this->___ShakeNear_21 = L_1;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ShakeNear_21), (void*)L_1);
		// ShakeFar = _originalShakeFar;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_2 = __this->____originalShakeFar_35;
		__this->___ShakeFar_24 = L_2;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ShakeFar_24), (void*)L_2);
		// RemapNearZero = _originalRemapNearZero;
		float L_3 = __this->____originalRemapNearZero_33;
		__this->___RemapNearZero_22 = L_3;
		// RemapNearOne = _originalRemapNearOne;
		float L_4 = __this->____originalRemapNearOne_34;
		__this->___RemapNearOne_23 = L_4;
		// RemapFarZero = _originalRemapFarZero;
		float L_5 = __this->____originalRemapFarZero_36;
		__this->___RemapFarZero_25 = L_5;
		// RemapFarOne = _originalRemapFarOne;
		float L_6 = __this->____originalRemapFarOne_37;
		__this->___RemapFarOne_26 = L_6;
		// RelativeClippingPlanes = _originalRelativeClippingPlanes;
		bool L_7 = __this->____originalRelativeClippingPlanes_31;
		__this->___RelativeClippingPlanes_20 = L_7;
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineClippingPlanesShaker::StartListening()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineClippingPlanesShaker_StartListening_m382C6B6493E634AF2A6D1F37B32F422C2B0F7558 (MMCinemachineClippingPlanesShaker_t7851747D89A493856A718862B75850B59C99DB3D* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Delegate_t9335CDEAFF0FB08FD5B9E989B907490B098870E3_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// base.StartListening();
		MMShaker_StartListening_m36823EC65926E79570BE8564A9C7F90DCEA8B7AD(__this, NULL);
		// MMCameraClippingPlanesShakeEvent.Register(OnMMCameraClippingPlanesShakeEvent);
		Delegate_t9335CDEAFF0FB08FD5B9E989B907490B098870E3* L_0 = (Delegate_t9335CDEAFF0FB08FD5B9E989B907490B098870E3*)il2cpp_codegen_object_new(Delegate_t9335CDEAFF0FB08FD5B9E989B907490B098870E3_il2cpp_TypeInfo_var);
		NullCheck(L_0);
		Delegate__ctor_mFF2CF1BA610BC049B43CDE70406E4C28B45EA7FA(L_0, __this, (intptr_t)((void*)GetVirtualMethodInfo(__this, 26)), NULL);
		MMCameraClippingPlanesShakeEvent_Register_mF87E62B189E26C561BCA3A40E297DA17E9AA7FF3(L_0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineClippingPlanesShaker::StopListening()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineClippingPlanesShaker_StopListening_m663CB34D33F8086FBAC5F6C90E2FD4EA70F4B06C (MMCinemachineClippingPlanesShaker_t7851747D89A493856A718862B75850B59C99DB3D* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Delegate_t9335CDEAFF0FB08FD5B9E989B907490B098870E3_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// base.StopListening();
		MMShaker_StopListening_m7F583AAD3037B2610ADB4BA3BBF63847EF3EDE1C(__this, NULL);
		// MMCameraClippingPlanesShakeEvent.Unregister(OnMMCameraClippingPlanesShakeEvent);
		Delegate_t9335CDEAFF0FB08FD5B9E989B907490B098870E3* L_0 = (Delegate_t9335CDEAFF0FB08FD5B9E989B907490B098870E3*)il2cpp_codegen_object_new(Delegate_t9335CDEAFF0FB08FD5B9E989B907490B098870E3_il2cpp_TypeInfo_var);
		NullCheck(L_0);
		Delegate__ctor_mFF2CF1BA610BC049B43CDE70406E4C28B45EA7FA(L_0, __this, (intptr_t)((void*)GetVirtualMethodInfo(__this, 26)), NULL);
		MMCameraClippingPlanesShakeEvent_Unregister_mF4002BB9EC90EC4D0C3362819546B37DCCACFCD1(L_0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineClippingPlanesShaker::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineClippingPlanesShaker__ctor_mDBD3DBC91E44ED7CC9295FC99EF3D416932D3329 (MMCinemachineClippingPlanesShaker_t7851747D89A493856A718862B75850B59C99DB3D* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public AnimationCurve ShakeNear = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_0 = (KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3*)(KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3*)SZArrayNew(KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var, (uint32_t)3);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_1 = L_0;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_2;
		memset((&L_2), 0, sizeof(L_2));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_2), (0.0f), (0.0f), /*hidden argument*/NULL);
		NullCheck(L_1);
		(L_1)->SetAt(static_cast<il2cpp_array_size_t>(0), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_2);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_3 = L_1;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_4;
		memset((&L_4), 0, sizeof(L_4));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_4), (0.5f), (1.0f), /*hidden argument*/NULL);
		NullCheck(L_3);
		(L_3)->SetAt(static_cast<il2cpp_array_size_t>(1), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_4);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_5 = L_3;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_6;
		memset((&L_6), 0, sizeof(L_6));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_6), (1.0f), (0.0f), /*hidden argument*/NULL);
		NullCheck(L_5);
		(L_5)->SetAt(static_cast<il2cpp_array_size_t>(2), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_6);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_7 = (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*)il2cpp_codegen_object_new(AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		NullCheck(L_7);
		AnimationCurve__ctor_mEABC98C03805713354D61E50D9340766BD5B717E(L_7, L_5, NULL);
		__this->___ShakeNear_21 = L_7;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ShakeNear_21), (void*)L_7);
		// public float RemapNearZero = 0.3f;
		__this->___RemapNearZero_22 = (0.300000012f);
		// public float RemapNearOne = 100f;
		__this->___RemapNearOne_23 = (100.0f);
		// public AnimationCurve ShakeFar = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_8 = (KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3*)(KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3*)SZArrayNew(KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var, (uint32_t)3);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_9 = L_8;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_10;
		memset((&L_10), 0, sizeof(L_10));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_10), (0.0f), (0.0f), /*hidden argument*/NULL);
		NullCheck(L_9);
		(L_9)->SetAt(static_cast<il2cpp_array_size_t>(0), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_10);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_11 = L_9;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_12;
		memset((&L_12), 0, sizeof(L_12));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_12), (0.5f), (1.0f), /*hidden argument*/NULL);
		NullCheck(L_11);
		(L_11)->SetAt(static_cast<il2cpp_array_size_t>(1), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_12);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_13 = L_11;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_14;
		memset((&L_14), 0, sizeof(L_14));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_14), (1.0f), (0.0f), /*hidden argument*/NULL);
		NullCheck(L_13);
		(L_13)->SetAt(static_cast<il2cpp_array_size_t>(2), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_14);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_15 = (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*)il2cpp_codegen_object_new(AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		NullCheck(L_15);
		AnimationCurve__ctor_mEABC98C03805713354D61E50D9340766BD5B717E(L_15, L_13, NULL);
		__this->___ShakeFar_24 = L_15;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ShakeFar_24), (void*)L_15);
		// public float RemapFarZero = 1000f;
		__this->___RemapFarZero_25 = (1000.0f);
		// public float RemapFarOne = 1000f;
		__this->___RemapFarOne_26 = (1000.0f);
		MMShaker__ctor_mF8C6BFF676BA0F272791D3B64B0E5EB2E598A709(__this, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineFieldOfViewShaker::Initialization()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineFieldOfViewShaker_Initialization_mF437E0F15248EEB909C4A064D2316C713DE33FF3 (MMCinemachineFieldOfViewShaker_t1BCC979BAE60EE46A3082B43C9024218559403C5* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&GameObject_GetComponent_TisCinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50_m1A2DDA6B545C821D4E79E784051FDF79464CAD2D_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// base.Initialization();
		MMShaker_Initialization_mF435F195C4DE0AB245013FE4AC5C49DAF00EA29A(__this, NULL);
		// _targetCamera = this.gameObject.GetComponent<CinemachineVirtualCamera>();
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_0;
		L_0 = Component_get_gameObject_m57AEFBB14DB39EC476F740BA000E170355DE691B(__this, NULL);
		NullCheck(L_0);
		CinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50* L_1;
		L_1 = GameObject_GetComponent_TisCinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50_m1A2DDA6B545C821D4E79E784051FDF79464CAD2D(L_0, GameObject_GetComponent_TisCinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50_m1A2DDA6B545C821D4E79E784051FDF79464CAD2D_RuntimeMethod_var);
		__this->____targetCamera_24 = L_1;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____targetCamera_24), (void*)L_1);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineFieldOfViewShaker::Reset()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineFieldOfViewShaker_Reset_m6E547CF7A6BC6FE34A8AEA3E10660A3921ECD408 (MMCinemachineFieldOfViewShaker_t1BCC979BAE60EE46A3082B43C9024218559403C5* __this, const RuntimeMethod* method) 
{
	{
		// ShakeDuration = 0.5f;
		((MMShaker_t48AAF716B7D3FC0C6FB15A32772D7DF0D57FCC31*)__this)->___ShakeDuration_5 = (0.5f);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineFieldOfViewShaker::Shake()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineFieldOfViewShaker_Shake_m4BBB3C251DF7D5737F0E4C5B982431CDCE3F891D (MMCinemachineFieldOfViewShaker_t1BCC979BAE60EE46A3082B43C9024218559403C5* __this, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	{
		// float newFieldOfView = ShakeFloat(ShakeFieldOfView, RemapFieldOfViewZero, RemapFieldOfViewOne, RelativeFieldOfView, _initialFieldOfView);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_0 = __this->___ShakeFieldOfView_21;
		float L_1 = __this->___RemapFieldOfViewZero_22;
		float L_2 = __this->___RemapFieldOfViewOne_23;
		bool L_3 = __this->___RelativeFieldOfView_20;
		float L_4 = __this->____initialFieldOfView_25;
		float L_5;
		L_5 = VirtualFuncInvoker5< float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, bool, float >::Invoke(13 /* System.Single MoreMountains.Feedbacks.MMShaker::ShakeFloat(UnityEngine.AnimationCurve,System.Single,System.Single,System.Boolean,System.Single) */, __this, L_0, L_1, L_2, L_3, L_4);
		V_0 = L_5;
		// _targetCamera.m_Lens.FieldOfView = newFieldOfView;
		CinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50* L_6 = __this->____targetCamera_24;
		NullCheck(L_6);
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE* L_7 = (&L_6->___m_Lens_30);
		float L_8 = V_0;
		L_7->___FieldOfView_1 = L_8;
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineFieldOfViewShaker::GrabInitialValues()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineFieldOfViewShaker_GrabInitialValues_mC442989521060FCC04209A9C593D0F8A61F56A7E (MMCinemachineFieldOfViewShaker_t1BCC979BAE60EE46A3082B43C9024218559403C5* __this, const RuntimeMethod* method) 
{
	{
		// _initialFieldOfView = _targetCamera.m_Lens.FieldOfView;
		CinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50* L_0 = __this->____targetCamera_24;
		NullCheck(L_0);
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE* L_1 = (&L_0->___m_Lens_30);
		float L_2 = L_1->___FieldOfView_1;
		__this->____initialFieldOfView_25 = L_2;
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineFieldOfViewShaker::OnMMCameraFieldOfViewShakeEvent(UnityEngine.AnimationCurve,System.Single,System.Single,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineFieldOfViewShaker_OnMMCameraFieldOfViewShakeEvent_m256A825036B262A35BF721AB36CCB30A30BD0F36 (MMCinemachineFieldOfViewShaker_t1BCC979BAE60EE46A3082B43C9024218559403C5* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___distortionCurve0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeDistortion4, float ___feedbacksIntensity5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method) 
{
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		// if (!CheckEventAllowed(channel))
		int32_t L_0 = ___channel6;
		il2cpp_codegen_initobj((&V_0), sizeof(Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2));
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_1 = V_0;
		bool L_2;
		L_2 = VirtualFuncInvoker4< bool, int32_t, bool, float, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 >::Invoke(24 /* System.Boolean MoreMountains.Feedbacks.MMShaker::CheckEventAllowed(System.Int32,System.Boolean,System.Single,UnityEngine.Vector3) */, __this, L_0, (bool)0, (0.0f), L_1);
		if (L_2)
		{
			goto IL_001a;
		}
	}
	{
		// return;
		return;
	}

IL_001a:
	{
		// if (stop)
		bool L_3 = ___stop11;
		if (!L_3)
		{
			goto IL_0025;
		}
	}
	{
		// Stop();
		VirtualActionInvoker0::Invoke(21 /* System.Void MoreMountains.Feedbacks.MMShaker::Stop() */, __this);
		// return;
		return;
	}

IL_0025:
	{
		// if (!Interruptible && Shaking)
		bool L_4 = ((MMShaker_t48AAF716B7D3FC0C6FB15A32772D7DF0D57FCC31*)__this)->___Interruptible_8;
		if (L_4)
		{
			goto IL_0036;
		}
	}
	{
		bool L_5 = ((MMShaker_t48AAF716B7D3FC0C6FB15A32772D7DF0D57FCC31*)__this)->___Shaking_11;
		if (!L_5)
		{
			goto IL_0036;
		}
	}
	{
		// return;
		return;
	}

IL_0036:
	{
		// _resetShakerValuesAfterShake = resetShakerValuesAfterShake;
		bool L_6 = ___resetShakerValuesAfterShake7;
		((MMShaker_t48AAF716B7D3FC0C6FB15A32772D7DF0D57FCC31*)__this)->____resetShakerValuesAfterShake_17 = L_6;
		// _resetTargetValuesAfterShake = resetTargetValuesAfterShake;
		bool L_7 = ___resetTargetValuesAfterShake8;
		((MMShaker_t48AAF716B7D3FC0C6FB15A32772D7DF0D57FCC31*)__this)->____resetTargetValuesAfterShake_18 = L_7;
		// if (resetShakerValuesAfterShake)
		bool L_8 = ___resetShakerValuesAfterShake7;
		if (!L_8)
		{
			goto IL_0086;
		}
	}
	{
		// _originalShakeDuration = ShakeDuration;
		float L_9 = ((MMShaker_t48AAF716B7D3FC0C6FB15A32772D7DF0D57FCC31*)__this)->___ShakeDuration_5;
		__this->____originalShakeDuration_26 = L_9;
		// _originalShakeFieldOfView = ShakeFieldOfView;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_10 = __this->___ShakeFieldOfView_21;
		__this->____originalShakeFieldOfView_28 = L_10;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____originalShakeFieldOfView_28), (void*)L_10);
		// _originalRemapFieldOfViewZero = RemapFieldOfViewZero;
		float L_11 = __this->___RemapFieldOfViewZero_22;
		__this->____originalRemapFieldOfViewZero_29 = L_11;
		// _originalRemapFieldOfViewOne = RemapFieldOfViewOne;
		float L_12 = __this->___RemapFieldOfViewOne_23;
		__this->____originalRemapFieldOfViewOne_30 = L_12;
		// _originalRelativeFieldOfView = RelativeFieldOfView;
		bool L_13 = __this->___RelativeFieldOfView_20;
		__this->____originalRelativeFieldOfView_27 = L_13;
	}

IL_0086:
	{
		// TimescaleMode = timescaleMode;
		int32_t L_14 = ___timescaleMode10;
		((MMShaker_t48AAF716B7D3FC0C6FB15A32772D7DF0D57FCC31*)__this)->___TimescaleMode_13 = L_14;
		// ShakeDuration = duration;
		float L_15 = ___duration1;
		((MMShaker_t48AAF716B7D3FC0C6FB15A32772D7DF0D57FCC31*)__this)->___ShakeDuration_5 = L_15;
		// ShakeFieldOfView = distortionCurve;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_16 = ___distortionCurve0;
		__this->___ShakeFieldOfView_21 = L_16;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ShakeFieldOfView_21), (void*)L_16);
		// RemapFieldOfViewZero = remapMin * feedbacksIntensity;
		float L_17 = ___remapMin2;
		float L_18 = ___feedbacksIntensity5;
		__this->___RemapFieldOfViewZero_22 = ((float)il2cpp_codegen_multiply(L_17, L_18));
		// RemapFieldOfViewOne = remapMax * feedbacksIntensity;
		float L_19 = ___remapMax3;
		float L_20 = ___feedbacksIntensity5;
		__this->___RemapFieldOfViewOne_23 = ((float)il2cpp_codegen_multiply(L_19, L_20));
		// RelativeFieldOfView = relativeDistortion;
		bool L_21 = ___relativeDistortion4;
		__this->___RelativeFieldOfView_20 = L_21;
		// ForwardDirection = forwardDirection;
		bool L_22 = ___forwardDirection9;
		((MMShaker_t48AAF716B7D3FC0C6FB15A32772D7DF0D57FCC31*)__this)->___ForwardDirection_12 = L_22;
		// Play();
		VirtualActionInvoker0::Invoke(20 /* System.Void MoreMountains.Feedbacks.MMShaker::Play() */, __this);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineFieldOfViewShaker::ResetTargetValues()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineFieldOfViewShaker_ResetTargetValues_m18AB5A6F6529FD69DE410DB32F516C46E25EA30C (MMCinemachineFieldOfViewShaker_t1BCC979BAE60EE46A3082B43C9024218559403C5* __this, const RuntimeMethod* method) 
{
	{
		// base.ResetTargetValues();
		MMShaker_ResetTargetValues_mD7E138483910DEE0DEF4276FF39F07A6AE80AE59(__this, NULL);
		// _targetCamera.m_Lens.FieldOfView = _initialFieldOfView;
		CinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50* L_0 = __this->____targetCamera_24;
		NullCheck(L_0);
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE* L_1 = (&L_0->___m_Lens_30);
		float L_2 = __this->____initialFieldOfView_25;
		L_1->___FieldOfView_1 = L_2;
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineFieldOfViewShaker::ResetShakerValues()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineFieldOfViewShaker_ResetShakerValues_m16600E4B007436BA20DC0B30A249B7B4B23051E1 (MMCinemachineFieldOfViewShaker_t1BCC979BAE60EE46A3082B43C9024218559403C5* __this, const RuntimeMethod* method) 
{
	{
		// base.ResetShakerValues();
		MMShaker_ResetShakerValues_mF597524D875B4EA6053014C7E9F63177D123C490(__this, NULL);
		// ShakeDuration = _originalShakeDuration;
		float L_0 = __this->____originalShakeDuration_26;
		((MMShaker_t48AAF716B7D3FC0C6FB15A32772D7DF0D57FCC31*)__this)->___ShakeDuration_5 = L_0;
		// ShakeFieldOfView = _originalShakeFieldOfView;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_1 = __this->____originalShakeFieldOfView_28;
		__this->___ShakeFieldOfView_21 = L_1;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ShakeFieldOfView_21), (void*)L_1);
		// RemapFieldOfViewZero = _originalRemapFieldOfViewZero;
		float L_2 = __this->____originalRemapFieldOfViewZero_29;
		__this->___RemapFieldOfViewZero_22 = L_2;
		// RemapFieldOfViewOne = _originalRemapFieldOfViewOne;
		float L_3 = __this->____originalRemapFieldOfViewOne_30;
		__this->___RemapFieldOfViewOne_23 = L_3;
		// RelativeFieldOfView = _originalRelativeFieldOfView;
		bool L_4 = __this->____originalRelativeFieldOfView_27;
		__this->___RelativeFieldOfView_20 = L_4;
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineFieldOfViewShaker::StartListening()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineFieldOfViewShaker_StartListening_mB0D3DC90103F0C1B6CC10BCCCDF8F831CF6036F4 (MMCinemachineFieldOfViewShaker_t1BCC979BAE60EE46A3082B43C9024218559403C5* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Delegate_tB0BC9D7A574413E043B438F0A068AD7FB33AB277_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// base.StartListening();
		MMShaker_StartListening_m36823EC65926E79570BE8564A9C7F90DCEA8B7AD(__this, NULL);
		// MMCameraFieldOfViewShakeEvent.Register(OnMMCameraFieldOfViewShakeEvent);
		Delegate_tB0BC9D7A574413E043B438F0A068AD7FB33AB277* L_0 = (Delegate_tB0BC9D7A574413E043B438F0A068AD7FB33AB277*)il2cpp_codegen_object_new(Delegate_tB0BC9D7A574413E043B438F0A068AD7FB33AB277_il2cpp_TypeInfo_var);
		NullCheck(L_0);
		Delegate__ctor_m321FFD3E054C53C801D96CC148892FA3E3A55ECB(L_0, __this, (intptr_t)((void*)GetVirtualMethodInfo(__this, 26)), NULL);
		MMCameraFieldOfViewShakeEvent_Register_mC79F1A4954A1AFE8872758F1BF3BC9A7D20454C9(L_0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineFieldOfViewShaker::StopListening()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineFieldOfViewShaker_StopListening_m28FC30250B795704CF7AC3539BDA5826F0DE7664 (MMCinemachineFieldOfViewShaker_t1BCC979BAE60EE46A3082B43C9024218559403C5* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Delegate_tB0BC9D7A574413E043B438F0A068AD7FB33AB277_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// base.StopListening();
		MMShaker_StopListening_m7F583AAD3037B2610ADB4BA3BBF63847EF3EDE1C(__this, NULL);
		// MMCameraFieldOfViewShakeEvent.Unregister(OnMMCameraFieldOfViewShakeEvent);
		Delegate_tB0BC9D7A574413E043B438F0A068AD7FB33AB277* L_0 = (Delegate_tB0BC9D7A574413E043B438F0A068AD7FB33AB277*)il2cpp_codegen_object_new(Delegate_tB0BC9D7A574413E043B438F0A068AD7FB33AB277_il2cpp_TypeInfo_var);
		NullCheck(L_0);
		Delegate__ctor_m321FFD3E054C53C801D96CC148892FA3E3A55ECB(L_0, __this, (intptr_t)((void*)GetVirtualMethodInfo(__this, 26)), NULL);
		MMCameraFieldOfViewShakeEvent_Unregister_m5790F78661BF6DF619379F690D7336A5D860A3F2(L_0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineFieldOfViewShaker::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineFieldOfViewShaker__ctor_mEA5FCC82DBDD22D784634986E5E216A265770351 (MMCinemachineFieldOfViewShaker_t1BCC979BAE60EE46A3082B43C9024218559403C5* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public AnimationCurve ShakeFieldOfView = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_0 = (KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3*)(KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3*)SZArrayNew(KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var, (uint32_t)3);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_1 = L_0;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_2;
		memset((&L_2), 0, sizeof(L_2));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_2), (0.0f), (0.0f), /*hidden argument*/NULL);
		NullCheck(L_1);
		(L_1)->SetAt(static_cast<il2cpp_array_size_t>(0), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_2);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_3 = L_1;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_4;
		memset((&L_4), 0, sizeof(L_4));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_4), (0.5f), (1.0f), /*hidden argument*/NULL);
		NullCheck(L_3);
		(L_3)->SetAt(static_cast<il2cpp_array_size_t>(1), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_4);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_5 = L_3;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_6;
		memset((&L_6), 0, sizeof(L_6));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_6), (1.0f), (0.0f), /*hidden argument*/NULL);
		NullCheck(L_5);
		(L_5)->SetAt(static_cast<il2cpp_array_size_t>(2), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_6);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_7 = (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*)il2cpp_codegen_object_new(AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		NullCheck(L_7);
		AnimationCurve__ctor_mEABC98C03805713354D61E50D9340766BD5B717E(L_7, L_5, NULL);
		__this->___ShakeFieldOfView_21 = L_7;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ShakeFieldOfView_21), (void*)L_7);
		// public float RemapFieldOfViewZero = 60f;
		__this->___RemapFieldOfViewZero_22 = (60.0f);
		// public float RemapFieldOfViewOne = 120f;
		__this->___RemapFieldOfViewOne_23 = (120.0f);
		MMShaker__ctor_mF8C6BFF676BA0F272791D3B64B0E5EB2E598A709(__this, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineFreeLookZoom::Awake()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineFreeLookZoom_Awake_m9CB69056CB21B0F94EF1F68594187263031F4BD9 (MMCinemachineFreeLookZoom_t6535271BE733083A975D4068708827E4A05DEC1E* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&GameObject_GetComponent_TisCinemachineFreeLook_t397C813915C4BDC42D63DE82DF52897738FCBA1A_m55FDBF088D5B4E935514B4B81F63DE1044B0101D_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// _freeLookCamera = this.gameObject.GetComponent<Cinemachine.CinemachineFreeLook>();
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_0;
		L_0 = Component_get_gameObject_m57AEFBB14DB39EC476F740BA000E170355DE691B(__this, NULL);
		NullCheck(L_0);
		CinemachineFreeLook_t397C813915C4BDC42D63DE82DF52897738FCBA1A* L_1;
		L_1 = GameObject_GetComponent_TisCinemachineFreeLook_t397C813915C4BDC42D63DE82DF52897738FCBA1A_m55FDBF088D5B4E935514B4B81F63DE1044B0101D(L_0, GameObject_GetComponent_TisCinemachineFreeLook_t397C813915C4BDC42D63DE82DF52897738FCBA1A_m55FDBF088D5B4E935514B4B81F63DE1044B0101D_RuntimeMethod_var);
		__this->____freeLookCamera_11 = L_1;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____freeLookCamera_11), (void*)L_1);
		// _initialFieldOfView = _freeLookCamera.m_Lens.FieldOfView;
		CinemachineFreeLook_t397C813915C4BDC42D63DE82DF52897738FCBA1A* L_2 = __this->____freeLookCamera_11;
		NullCheck(L_2);
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE* L_3 = (&L_2->___m_Lens_31);
		float L_4 = L_3->___FieldOfView_1;
		__this->____initialFieldOfView_12 = L_4;
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineFreeLookZoom::Update()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineFreeLookZoom_Update_m74875FB2D88BCE2506BBCB410073C2088233DDAA (MMCinemachineFreeLookZoom_t6535271BE733083A975D4068708827E4A05DEC1E* __this, const RuntimeMethod* method) 
{
	{
		// if (!_zooming)
		bool L_0 = __this->____zooming_14;
		if (L_0)
		{
			goto IL_0009;
		}
	}
	{
		// return;
		return;
	}

IL_0009:
	{
		// if (_freeLookCamera.m_Lens.FieldOfView != _targetFieldOfView)
		CinemachineFreeLook_t397C813915C4BDC42D63DE82DF52897738FCBA1A* L_1 = __this->____freeLookCamera_11;
		NullCheck(L_1);
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE* L_2 = (&L_1->___m_Lens_31);
		float L_3 = L_2->___FieldOfView_1;
		float L_4 = __this->____targetFieldOfView_18;
		if ((((float)L_3) == ((float)L_4)))
		{
			goto IL_006d;
		}
	}
	{
		// _delta += Time.deltaTime / _transitionDuration;
		float L_5 = __this->____delta_19;
		float L_6;
		L_6 = Time_get_deltaTime_mC3195000401F0FD167DD2F948FD2BC58330D0865(NULL);
		float L_7 = __this->____transitionDuration_16;
		__this->____delta_19 = ((float)il2cpp_codegen_add(L_5, ((float)(L_6/L_7))));
		// _freeLookCamera.m_Lens.FieldOfView = Mathf.LerpUnclamped(_startFieldOfView, _targetFieldOfView, ZoomCurve.Evaluate(_delta));
		CinemachineFreeLook_t397C813915C4BDC42D63DE82DF52897738FCBA1A* L_8 = __this->____freeLookCamera_11;
		NullCheck(L_8);
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE* L_9 = (&L_8->___m_Lens_31);
		float L_10 = __this->____startFieldOfView_15;
		float L_11 = __this->____targetFieldOfView_18;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_12 = __this->___ZoomCurve_5;
		float L_13 = __this->____delta_19;
		NullCheck(L_12);
		float L_14;
		L_14 = AnimationCurve_Evaluate_m50B857043DE251A186032ADBCBB4CEF817F4EE3C(L_12, L_13, NULL);
		float L_15;
		L_15 = Mathf_LerpUnclamped_mF35042F9D25A221BDD4B3FD6251224610AFC1F35_inline(L_10, L_11, L_14, NULL);
		L_9->___FieldOfView_1 = L_15;
		return;
	}

IL_006d:
	{
		// if (!_destinationReached)
		bool L_16 = __this->____destinationReached_22;
		if (L_16)
		{
			goto IL_0087;
		}
	}
	{
		// _reachedDestinationTimestamp = Time.time;
		float L_17;
		L_17 = Time_get_time_m3A271BB1B20041144AC5B7863B71AB1F0150374B(NULL);
		__this->____reachedDestinationTimestamp_21 = L_17;
		// _destinationReached = true;
		__this->____destinationReached_22 = (bool)1;
	}

IL_0087:
	{
		// if ((_mode == MMCameraZoomModes.For) && (_direction == 1))
		int32_t L_18 = __this->____mode_13;
		if (L_18)
		{
			goto IL_00d7;
		}
	}
	{
		int32_t L_19 = __this->____direction_20;
		if ((!(((uint32_t)L_19) == ((uint32_t)1))))
		{
			goto IL_00d7;
		}
	}
	{
		// if (Time.time - _reachedDestinationTimestamp > _duration)
		float L_20;
		L_20 = Time_get_time_m3A271BB1B20041144AC5B7863B71AB1F0150374B(NULL);
		float L_21 = __this->____reachedDestinationTimestamp_21;
		float L_22 = __this->____duration_17;
		if ((!(((float)((float)il2cpp_codegen_subtract(L_20, L_21))) > ((float)L_22))))
		{
			goto IL_00de;
		}
	}
	{
		// _direction = -1;
		__this->____direction_20 = (-1);
		// _startFieldOfView = _targetFieldOfView;
		float L_23 = __this->____targetFieldOfView_18;
		__this->____startFieldOfView_15 = L_23;
		// _targetFieldOfView = _initialFieldOfView;
		float L_24 = __this->____initialFieldOfView_12;
		__this->____targetFieldOfView_18 = L_24;
		// _delta = 0f;
		__this->____delta_19 = (0.0f);
		return;
	}

IL_00d7:
	{
		// _zooming = false;
		__this->____zooming_14 = (bool)0;
	}

IL_00de:
	{
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineFreeLookZoom::Zoom(MoreMountains.Feedbacks.MMCameraZoomModes,System.Single,System.Single,System.Single,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineFreeLookZoom_Zoom_m3832EE0E3F88C915C6C716238B1263D1926D77AE (MMCinemachineFreeLookZoom_t6535271BE733083A975D4068708827E4A05DEC1E* __this, int32_t ___mode0, float ___newFieldOfView1, float ___transitionDuration2, float ___duration3, bool ___relative4, const RuntimeMethod* method) 
{
	{
		// if (_zooming)
		bool L_0 = __this->____zooming_14;
		if (!L_0)
		{
			goto IL_0009;
		}
	}
	{
		// return;
		return;
	}

IL_0009:
	{
		// _zooming = true;
		__this->____zooming_14 = (bool)1;
		// _delta = 0f;
		__this->____delta_19 = (0.0f);
		// _mode = mode;
		int32_t L_1 = ___mode0;
		__this->____mode_13 = L_1;
		// _startFieldOfView = _freeLookCamera.m_Lens.FieldOfView;
		CinemachineFreeLook_t397C813915C4BDC42D63DE82DF52897738FCBA1A* L_2 = __this->____freeLookCamera_11;
		NullCheck(L_2);
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE* L_3 = (&L_2->___m_Lens_31);
		float L_4 = L_3->___FieldOfView_1;
		__this->____startFieldOfView_15 = L_4;
		// _transitionDuration = transitionDuration;
		float L_5 = ___transitionDuration2;
		__this->____transitionDuration_16 = L_5;
		// _duration = duration;
		float L_6 = ___duration3;
		__this->____duration_17 = L_6;
		// _transitionDuration = transitionDuration;
		float L_7 = ___transitionDuration2;
		__this->____transitionDuration_16 = L_7;
		// _direction = 1;
		__this->____direction_20 = 1;
		// _destinationReached = false;
		__this->____destinationReached_22 = (bool)0;
		int32_t L_8 = ___mode0;
		switch (L_8)
		{
			case 0:
			{
				goto IL_0070;
			}
			case 1:
			{
				goto IL_0079;
			}
			case 2:
			{
				goto IL_0082;
			}
		}
	}
	{
		goto IL_008e;
	}

IL_0070:
	{
		// _targetFieldOfView = newFieldOfView;
		float L_9 = ___newFieldOfView1;
		__this->____targetFieldOfView_18 = L_9;
		// break;
		goto IL_008e;
	}

IL_0079:
	{
		// _targetFieldOfView = newFieldOfView;
		float L_10 = ___newFieldOfView1;
		__this->____targetFieldOfView_18 = L_10;
		// break;
		goto IL_008e;
	}

IL_0082:
	{
		// _targetFieldOfView = _initialFieldOfView;
		float L_11 = __this->____initialFieldOfView_12;
		__this->____targetFieldOfView_18 = L_11;
	}

IL_008e:
	{
		// if (relative)
		bool L_12 = ___relative4;
		if (!L_12)
		{
			goto IL_00a5;
		}
	}
	{
		// _targetFieldOfView += _initialFieldOfView;
		float L_13 = __this->____targetFieldOfView_18;
		float L_14 = __this->____initialFieldOfView_12;
		__this->____targetFieldOfView_18 = ((float)il2cpp_codegen_add(L_13, L_14));
	}

IL_00a5:
	{
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineFreeLookZoom::TestZoom()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineFreeLookZoom_TestZoom_m9552AFAE3871D313D7309B69D33E28F052E65BFA (MMCinemachineFreeLookZoom_t6535271BE733083A975D4068708827E4A05DEC1E* __this, const RuntimeMethod* method) 
{
	{
		// Zoom(TestMode, TestFieldOfView, TestTransitionDuration, TestDuration);
		int32_t L_0 = __this->___TestMode_6;
		float L_1 = __this->___TestFieldOfView_7;
		float L_2 = __this->___TestTransitionDuration_8;
		float L_3 = __this->___TestDuration_9;
		VirtualActionInvoker5< int32_t, float, float, float, bool >::Invoke(6 /* System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineFreeLookZoom::Zoom(MoreMountains.Feedbacks.MMCameraZoomModes,System.Single,System.Single,System.Single,System.Boolean) */, __this, L_0, L_1, L_2, L_3, (bool)0);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineFreeLookZoom::OnCameraZoomEvent(MoreMountains.Feedbacks.MMCameraZoomModes,System.Single,System.Single,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineFreeLookZoom_OnCameraZoomEvent_m803FCE477BBCB3DB6E97EC4F3C6BA0DD4C7B2CD8 (MMCinemachineFreeLookZoom_t6535271BE733083A975D4068708827E4A05DEC1E* __this, int32_t ___mode0, float ___newFieldOfView1, float ___transitionDuration2, float ___duration3, int32_t ___channel4, bool ___useUnscaledTime5, bool ___stop6, bool ___relative7, const RuntimeMethod* method) 
{
	{
		// if ((channel != Channel) && (channel != -1) && (Channel != -1))
		int32_t L_0 = ___channel4;
		int32_t L_1 = __this->___Channel_4;
		if ((((int32_t)L_0) == ((int32_t)L_1)))
		{
			goto IL_0019;
		}
	}
	{
		int32_t L_2 = ___channel4;
		if ((((int32_t)L_2) == ((int32_t)(-1))))
		{
			goto IL_0019;
		}
	}
	{
		int32_t L_3 = __this->___Channel_4;
		if ((((int32_t)L_3) == ((int32_t)(-1))))
		{
			goto IL_0019;
		}
	}
	{
		// return;
		return;
	}

IL_0019:
	{
		// if (stop)
		bool L_4 = ___stop6;
		if (!L_4)
		{
			goto IL_0025;
		}
	}
	{
		// _zooming = false;
		__this->____zooming_14 = (bool)0;
		// return;
		return;
	}

IL_0025:
	{
		// this.Zoom(mode, newFieldOfView, transitionDuration, duration, relative);
		int32_t L_5 = ___mode0;
		float L_6 = ___newFieldOfView1;
		float L_7 = ___transitionDuration2;
		float L_8 = ___duration3;
		bool L_9 = ___relative7;
		VirtualActionInvoker5< int32_t, float, float, float, bool >::Invoke(6 /* System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineFreeLookZoom::Zoom(MoreMountains.Feedbacks.MMCameraZoomModes,System.Single,System.Single,System.Single,System.Boolean) */, __this, L_5, L_6, L_7, L_8, L_9);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineFreeLookZoom::OnEnable()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineFreeLookZoom_OnEnable_m31C6EDEEFF51A24DC77551AB7CDD8AB253FF2F47 (MMCinemachineFreeLookZoom_t6535271BE733083A975D4068708827E4A05DEC1E* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Delegate_tA4CF453D6F49220E972ED8A4794892E9E1017260_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// MMCameraZoomEvent.Register(OnCameraZoomEvent);
		Delegate_tA4CF453D6F49220E972ED8A4794892E9E1017260* L_0 = (Delegate_tA4CF453D6F49220E972ED8A4794892E9E1017260*)il2cpp_codegen_object_new(Delegate_tA4CF453D6F49220E972ED8A4794892E9E1017260_il2cpp_TypeInfo_var);
		NullCheck(L_0);
		Delegate__ctor_m8D1004BCEFC6D845CBCB8EA17EF4FDBB819D808C(L_0, __this, (intptr_t)((void*)GetVirtualMethodInfo(__this, 8)), NULL);
		MMCameraZoomEvent_Register_m3BA025FD8AB4CDCE718D0FEEAB365B0E49EE94A0(L_0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineFreeLookZoom::OnDisable()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineFreeLookZoom_OnDisable_mEADA1FC245E253B0E2CDC09CA178F49A011332F7 (MMCinemachineFreeLookZoom_t6535271BE733083A975D4068708827E4A05DEC1E* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Delegate_tA4CF453D6F49220E972ED8A4794892E9E1017260_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// MMCameraZoomEvent.Unregister(OnCameraZoomEvent);
		Delegate_tA4CF453D6F49220E972ED8A4794892E9E1017260* L_0 = (Delegate_tA4CF453D6F49220E972ED8A4794892E9E1017260*)il2cpp_codegen_object_new(Delegate_tA4CF453D6F49220E972ED8A4794892E9E1017260_il2cpp_TypeInfo_var);
		NullCheck(L_0);
		Delegate__ctor_m8D1004BCEFC6D845CBCB8EA17EF4FDBB819D808C(L_0, __this, (intptr_t)((void*)GetVirtualMethodInfo(__this, 8)), NULL);
		MMCameraZoomEvent_Unregister_m4A7B1DFA4E416AE9FEFD017466C03E5B18B1EF45(L_0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineFreeLookZoom::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineFreeLookZoom__ctor_m269CE8779DEE61F205F6DF5143FBC9A17F199E51 (MMCinemachineFreeLookZoom_t6535271BE733083A975D4068708827E4A05DEC1E* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public AnimationCurve ZoomCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f));
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_0 = (KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3*)(KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3*)SZArrayNew(KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var, (uint32_t)2);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_1 = L_0;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_2;
		memset((&L_2), 0, sizeof(L_2));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_2), (0.0f), (0.0f), /*hidden argument*/NULL);
		NullCheck(L_1);
		(L_1)->SetAt(static_cast<il2cpp_array_size_t>(0), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_2);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_3 = L_1;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_4;
		memset((&L_4), 0, sizeof(L_4));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_4), (1.0f), (1.0f), /*hidden argument*/NULL);
		NullCheck(L_3);
		(L_3)->SetAt(static_cast<il2cpp_array_size_t>(1), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_4);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_5 = (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*)il2cpp_codegen_object_new(AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		NullCheck(L_5);
		AnimationCurve__ctor_mEABC98C03805713354D61E50D9340766BD5B717E(L_5, L_3, NULL);
		__this->___ZoomCurve_5 = L_5;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ZoomCurve_5), (void*)L_5);
		// public float TestFieldOfView = 30f;
		__this->___TestFieldOfView_7 = (30.0f);
		// public float TestTransitionDuration = 0.1f;
		__this->___TestTransitionDuration_8 = (0.100000001f);
		// public float TestDuration = 0.05f;
		__this->___TestDuration_9 = (0.0500000007f);
		// protected int _direction = 1;
		__this->____direction_20 = 1;
		MonoBehaviour__ctor_m592DB0105CA0BC97AA1C5F4AD27B12D68A3B7C1E(__this, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineOrthographicSizeShaker::Initialization()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineOrthographicSizeShaker_Initialization_m6EAAEC2A573176C7329DD993E1E4C44BD879C9E0 (MMCinemachineOrthographicSizeShaker_t094C6772F057FE073685EB9E6AB0B65C7EAE909C* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&GameObject_GetComponent_TisCinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50_m1A2DDA6B545C821D4E79E784051FDF79464CAD2D_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// base.Initialization();
		MMShaker_Initialization_mF435F195C4DE0AB245013FE4AC5C49DAF00EA29A(__this, NULL);
		// _targetCamera = this.gameObject.GetComponent<CinemachineVirtualCamera>();
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_0;
		L_0 = Component_get_gameObject_m57AEFBB14DB39EC476F740BA000E170355DE691B(__this, NULL);
		NullCheck(L_0);
		CinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50* L_1;
		L_1 = GameObject_GetComponent_TisCinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50_m1A2DDA6B545C821D4E79E784051FDF79464CAD2D(L_0, GameObject_GetComponent_TisCinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50_m1A2DDA6B545C821D4E79E784051FDF79464CAD2D_RuntimeMethod_var);
		__this->____targetCamera_24 = L_1;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____targetCamera_24), (void*)L_1);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineOrthographicSizeShaker::Reset()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineOrthographicSizeShaker_Reset_m5AD5A152203F4D6F8C4C79B5A9222B3B3D352BB9 (MMCinemachineOrthographicSizeShaker_t094C6772F057FE073685EB9E6AB0B65C7EAE909C* __this, const RuntimeMethod* method) 
{
	{
		// ShakeDuration = 0.5f;
		((MMShaker_t48AAF716B7D3FC0C6FB15A32772D7DF0D57FCC31*)__this)->___ShakeDuration_5 = (0.5f);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineOrthographicSizeShaker::Shake()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineOrthographicSizeShaker_Shake_m08AAAF91B1B37620603722075702957FE0BB987B (MMCinemachineOrthographicSizeShaker_t094C6772F057FE073685EB9E6AB0B65C7EAE909C* __this, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	{
		// float newOrthographicSize = ShakeFloat(ShakeOrthographicSize, RemapOrthographicSizeZero, RemapOrthographicSizeOne, RelativeOrthographicSize, _initialOrthographicSize);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_0 = __this->___ShakeOrthographicSize_21;
		float L_1 = __this->___RemapOrthographicSizeZero_22;
		float L_2 = __this->___RemapOrthographicSizeOne_23;
		bool L_3 = __this->___RelativeOrthographicSize_20;
		float L_4 = __this->____initialOrthographicSize_25;
		float L_5;
		L_5 = VirtualFuncInvoker5< float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, bool, float >::Invoke(13 /* System.Single MoreMountains.Feedbacks.MMShaker::ShakeFloat(UnityEngine.AnimationCurve,System.Single,System.Single,System.Boolean,System.Single) */, __this, L_0, L_1, L_2, L_3, L_4);
		V_0 = L_5;
		// _targetCamera.m_Lens.OrthographicSize = newOrthographicSize;
		CinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50* L_6 = __this->____targetCamera_24;
		NullCheck(L_6);
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE* L_7 = (&L_6->___m_Lens_30);
		float L_8 = V_0;
		L_7->___OrthographicSize_2 = L_8;
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineOrthographicSizeShaker::GrabInitialValues()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineOrthographicSizeShaker_GrabInitialValues_m80963B0B0CA4EBAD3345047A89C70BEBFDB7D961 (MMCinemachineOrthographicSizeShaker_t094C6772F057FE073685EB9E6AB0B65C7EAE909C* __this, const RuntimeMethod* method) 
{
	{
		// _initialOrthographicSize = _targetCamera.m_Lens.OrthographicSize;
		CinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50* L_0 = __this->____targetCamera_24;
		NullCheck(L_0);
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE* L_1 = (&L_0->___m_Lens_30);
		float L_2 = L_1->___OrthographicSize_2;
		__this->____initialOrthographicSize_25 = L_2;
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineOrthographicSizeShaker::OnMMCameraOrthographicSizeShakeEvent(UnityEngine.AnimationCurve,System.Single,System.Single,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineOrthographicSizeShaker_OnMMCameraOrthographicSizeShakeEvent_mB603EC111111F0FDA1520B3769965218A8797A8D (MMCinemachineOrthographicSizeShaker_t094C6772F057FE073685EB9E6AB0B65C7EAE909C* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___distortionCurve0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeDistortion4, float ___feedbacksIntensity5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, bool ___stop10, const RuntimeMethod* method) 
{
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		// if (!CheckEventAllowed(channel))
		int32_t L_0 = ___channel6;
		il2cpp_codegen_initobj((&V_0), sizeof(Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2));
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_1 = V_0;
		bool L_2;
		L_2 = VirtualFuncInvoker4< bool, int32_t, bool, float, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 >::Invoke(24 /* System.Boolean MoreMountains.Feedbacks.MMShaker::CheckEventAllowed(System.Int32,System.Boolean,System.Single,UnityEngine.Vector3) */, __this, L_0, (bool)0, (0.0f), L_1);
		if (L_2)
		{
			goto IL_001a;
		}
	}
	{
		// return;
		return;
	}

IL_001a:
	{
		// if (stop)
		bool L_3 = ___stop10;
		if (!L_3)
		{
			goto IL_0025;
		}
	}
	{
		// Stop();
		VirtualActionInvoker0::Invoke(21 /* System.Void MoreMountains.Feedbacks.MMShaker::Stop() */, __this);
		// return;
		return;
	}

IL_0025:
	{
		// if (!Interruptible && Shaking)
		bool L_4 = ((MMShaker_t48AAF716B7D3FC0C6FB15A32772D7DF0D57FCC31*)__this)->___Interruptible_8;
		if (L_4)
		{
			goto IL_0036;
		}
	}
	{
		bool L_5 = ((MMShaker_t48AAF716B7D3FC0C6FB15A32772D7DF0D57FCC31*)__this)->___Shaking_11;
		if (!L_5)
		{
			goto IL_0036;
		}
	}
	{
		// return;
		return;
	}

IL_0036:
	{
		// _resetShakerValuesAfterShake = resetShakerValuesAfterShake;
		bool L_6 = ___resetShakerValuesAfterShake7;
		((MMShaker_t48AAF716B7D3FC0C6FB15A32772D7DF0D57FCC31*)__this)->____resetShakerValuesAfterShake_17 = L_6;
		// _resetTargetValuesAfterShake = resetTargetValuesAfterShake;
		bool L_7 = ___resetTargetValuesAfterShake8;
		((MMShaker_t48AAF716B7D3FC0C6FB15A32772D7DF0D57FCC31*)__this)->____resetTargetValuesAfterShake_18 = L_7;
		// if (resetShakerValuesAfterShake)
		bool L_8 = ___resetShakerValuesAfterShake7;
		if (!L_8)
		{
			goto IL_0086;
		}
	}
	{
		// _originalShakeDuration = ShakeDuration;
		float L_9 = ((MMShaker_t48AAF716B7D3FC0C6FB15A32772D7DF0D57FCC31*)__this)->___ShakeDuration_5;
		__this->____originalShakeDuration_26 = L_9;
		// _originalShakeOrthographicSize = ShakeOrthographicSize;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_10 = __this->___ShakeOrthographicSize_21;
		__this->____originalShakeOrthographicSize_28 = L_10;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____originalShakeOrthographicSize_28), (void*)L_10);
		// _originalRemapOrthographicSizeZero = RemapOrthographicSizeZero;
		float L_11 = __this->___RemapOrthographicSizeZero_22;
		__this->____originalRemapOrthographicSizeZero_29 = L_11;
		// _originalRemapOrthographicSizeOne = RemapOrthographicSizeOne;
		float L_12 = __this->___RemapOrthographicSizeOne_23;
		__this->____originalRemapOrthographicSizeOne_30 = L_12;
		// _originalRelativeOrthographicSize = RelativeOrthographicSize;
		bool L_13 = __this->___RelativeOrthographicSize_20;
		__this->____originalRelativeOrthographicSize_27 = L_13;
	}

IL_0086:
	{
		// ShakeDuration = duration;
		float L_14 = ___duration1;
		((MMShaker_t48AAF716B7D3FC0C6FB15A32772D7DF0D57FCC31*)__this)->___ShakeDuration_5 = L_14;
		// ShakeOrthographicSize = distortionCurve;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_15 = ___distortionCurve0;
		__this->___ShakeOrthographicSize_21 = L_15;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ShakeOrthographicSize_21), (void*)L_15);
		// RemapOrthographicSizeZero = remapMin * feedbacksIntensity;
		float L_16 = ___remapMin2;
		float L_17 = ___feedbacksIntensity5;
		__this->___RemapOrthographicSizeZero_22 = ((float)il2cpp_codegen_multiply(L_16, L_17));
		// RemapOrthographicSizeOne = remapMax * feedbacksIntensity;
		float L_18 = ___remapMax3;
		float L_19 = ___feedbacksIntensity5;
		__this->___RemapOrthographicSizeOne_23 = ((float)il2cpp_codegen_multiply(L_18, L_19));
		// RelativeOrthographicSize = relativeDistortion;
		bool L_20 = ___relativeDistortion4;
		__this->___RelativeOrthographicSize_20 = L_20;
		// ForwardDirection = forwardDirection;
		bool L_21 = ___forwardDirection9;
		((MMShaker_t48AAF716B7D3FC0C6FB15A32772D7DF0D57FCC31*)__this)->___ForwardDirection_12 = L_21;
		// Play();
		VirtualActionInvoker0::Invoke(20 /* System.Void MoreMountains.Feedbacks.MMShaker::Play() */, __this);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineOrthographicSizeShaker::ResetTargetValues()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineOrthographicSizeShaker_ResetTargetValues_m70FEFDB87E9B96DEA5B6BA9A100F26AFC009162E (MMCinemachineOrthographicSizeShaker_t094C6772F057FE073685EB9E6AB0B65C7EAE909C* __this, const RuntimeMethod* method) 
{
	{
		// base.ResetTargetValues();
		MMShaker_ResetTargetValues_mD7E138483910DEE0DEF4276FF39F07A6AE80AE59(__this, NULL);
		// _targetCamera.m_Lens.OrthographicSize = _initialOrthographicSize;
		CinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50* L_0 = __this->____targetCamera_24;
		NullCheck(L_0);
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE* L_1 = (&L_0->___m_Lens_30);
		float L_2 = __this->____initialOrthographicSize_25;
		L_1->___OrthographicSize_2 = L_2;
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineOrthographicSizeShaker::ResetShakerValues()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineOrthographicSizeShaker_ResetShakerValues_mDE8222E2118C320A8872DF6D780E38A15D7DFEFD (MMCinemachineOrthographicSizeShaker_t094C6772F057FE073685EB9E6AB0B65C7EAE909C* __this, const RuntimeMethod* method) 
{
	{
		// base.ResetShakerValues();
		MMShaker_ResetShakerValues_mF597524D875B4EA6053014C7E9F63177D123C490(__this, NULL);
		// ShakeDuration = _originalShakeDuration;
		float L_0 = __this->____originalShakeDuration_26;
		((MMShaker_t48AAF716B7D3FC0C6FB15A32772D7DF0D57FCC31*)__this)->___ShakeDuration_5 = L_0;
		// ShakeOrthographicSize = _originalShakeOrthographicSize;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_1 = __this->____originalShakeOrthographicSize_28;
		__this->___ShakeOrthographicSize_21 = L_1;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ShakeOrthographicSize_21), (void*)L_1);
		// RemapOrthographicSizeZero = _originalRemapOrthographicSizeZero;
		float L_2 = __this->____originalRemapOrthographicSizeZero_29;
		__this->___RemapOrthographicSizeZero_22 = L_2;
		// RemapOrthographicSizeOne = _originalRemapOrthographicSizeOne;
		float L_3 = __this->____originalRemapOrthographicSizeOne_30;
		__this->___RemapOrthographicSizeOne_23 = L_3;
		// RelativeOrthographicSize = _originalRelativeOrthographicSize;
		bool L_4 = __this->____originalRelativeOrthographicSize_27;
		__this->___RelativeOrthographicSize_20 = L_4;
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineOrthographicSizeShaker::StartListening()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineOrthographicSizeShaker_StartListening_m4328E94835F4B0193B1F264D7B28A09F9D74A9E4 (MMCinemachineOrthographicSizeShaker_t094C6772F057FE073685EB9E6AB0B65C7EAE909C* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Delegate_tD173B266ED8EA45E3B0FEDA511537B9BCB52E868_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// base.StartListening();
		MMShaker_StartListening_m36823EC65926E79570BE8564A9C7F90DCEA8B7AD(__this, NULL);
		// MMCameraOrthographicSizeShakeEvent.Register(OnMMCameraOrthographicSizeShakeEvent);
		Delegate_tD173B266ED8EA45E3B0FEDA511537B9BCB52E868* L_0 = (Delegate_tD173B266ED8EA45E3B0FEDA511537B9BCB52E868*)il2cpp_codegen_object_new(Delegate_tD173B266ED8EA45E3B0FEDA511537B9BCB52E868_il2cpp_TypeInfo_var);
		NullCheck(L_0);
		Delegate__ctor_m4440EC7CB1C0F0B9EDEAAFA64173B9B8B2181BEC(L_0, __this, (intptr_t)((void*)GetVirtualMethodInfo(__this, 26)), NULL);
		MMCameraOrthographicSizeShakeEvent_Register_mE4E6BA4E14CB2B31D7DA710C379DDEF6BDA02DCC(L_0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineOrthographicSizeShaker::StopListening()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineOrthographicSizeShaker_StopListening_mD34AF14C738E321DB75BA50A9BC853F11D26E506 (MMCinemachineOrthographicSizeShaker_t094C6772F057FE073685EB9E6AB0B65C7EAE909C* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Delegate_tD173B266ED8EA45E3B0FEDA511537B9BCB52E868_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// base.StopListening();
		MMShaker_StopListening_m7F583AAD3037B2610ADB4BA3BBF63847EF3EDE1C(__this, NULL);
		// MMCameraOrthographicSizeShakeEvent.Unregister(OnMMCameraOrthographicSizeShakeEvent);
		Delegate_tD173B266ED8EA45E3B0FEDA511537B9BCB52E868* L_0 = (Delegate_tD173B266ED8EA45E3B0FEDA511537B9BCB52E868*)il2cpp_codegen_object_new(Delegate_tD173B266ED8EA45E3B0FEDA511537B9BCB52E868_il2cpp_TypeInfo_var);
		NullCheck(L_0);
		Delegate__ctor_m4440EC7CB1C0F0B9EDEAAFA64173B9B8B2181BEC(L_0, __this, (intptr_t)((void*)GetVirtualMethodInfo(__this, 26)), NULL);
		MMCameraOrthographicSizeShakeEvent_Unregister_m3C0C9011FFED801F04C1F9A2697331AF8F22E3CC(L_0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineOrthographicSizeShaker::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineOrthographicSizeShaker__ctor_m38AF23D7D724E0F9CF4C6DE6C07B9FB3B75B2883 (MMCinemachineOrthographicSizeShaker_t094C6772F057FE073685EB9E6AB0B65C7EAE909C* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public AnimationCurve ShakeOrthographicSize = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_0 = (KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3*)(KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3*)SZArrayNew(KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var, (uint32_t)3);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_1 = L_0;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_2;
		memset((&L_2), 0, sizeof(L_2));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_2), (0.0f), (0.0f), /*hidden argument*/NULL);
		NullCheck(L_1);
		(L_1)->SetAt(static_cast<il2cpp_array_size_t>(0), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_2);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_3 = L_1;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_4;
		memset((&L_4), 0, sizeof(L_4));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_4), (0.5f), (1.0f), /*hidden argument*/NULL);
		NullCheck(L_3);
		(L_3)->SetAt(static_cast<il2cpp_array_size_t>(1), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_4);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_5 = L_3;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_6;
		memset((&L_6), 0, sizeof(L_6));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_6), (1.0f), (0.0f), /*hidden argument*/NULL);
		NullCheck(L_5);
		(L_5)->SetAt(static_cast<il2cpp_array_size_t>(2), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_6);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_7 = (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*)il2cpp_codegen_object_new(AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		NullCheck(L_7);
		AnimationCurve__ctor_mEABC98C03805713354D61E50D9340766BD5B717E(L_7, L_5, NULL);
		__this->___ShakeOrthographicSize_21 = L_7;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ShakeOrthographicSize_21), (void*)L_7);
		// public float RemapOrthographicSizeZero = 5f;
		__this->___RemapOrthographicSizeZero_22 = (5.0f);
		// public float RemapOrthographicSizeOne = 10f;
		__this->___RemapOrthographicSizeOne_23 = (10.0f);
		MMShaker__ctor_mF8C6BFF676BA0F272791D3B64B0E5EB2E598A709(__this, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityBrainListener::GetTime()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float MMCinemachinePriorityBrainListener_GetTime_mA27B7A8759E39A4F324918EDDCB469922BBE2795 (MMCinemachinePriorityBrainListener_t1EAF821E7E0F7C672716F9DA1E639F23DF709D3A* __this, const RuntimeMethod* method) 
{
	{
		// public virtual float GetTime() { return (TimescaleMode == TimescaleModes.Scaled) ? Time.time : Time.unscaledTime; }
		int32_t L_0 = __this->___TimescaleMode_4;
		if (!L_0)
		{
			goto IL_000e;
		}
	}
	{
		float L_1;
		L_1 = Time_get_unscaledTime_mAF4040B858903E1325D1C65B8BF1AC61460B2503(NULL);
		return L_1;
	}

IL_000e:
	{
		float L_2;
		L_2 = Time_get_time_m3A271BB1B20041144AC5B7863B71AB1F0150374B(NULL);
		return L_2;
	}
}
// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityBrainListener::GetDeltaTime()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float MMCinemachinePriorityBrainListener_GetDeltaTime_m8ED920CFF126036A6F04D4ABA7C35243B7736914 (MMCinemachinePriorityBrainListener_t1EAF821E7E0F7C672716F9DA1E639F23DF709D3A* __this, const RuntimeMethod* method) 
{
	{
		// public virtual float GetDeltaTime() { return (TimescaleMode == TimescaleModes.Scaled) ? Time.deltaTime : Time.unscaledDeltaTime; }
		int32_t L_0 = __this->___TimescaleMode_4;
		if (!L_0)
		{
			goto IL_000e;
		}
	}
	{
		float L_1;
		L_1 = Time_get_unscaledDeltaTime_mF057EECA857E5C0F90A3F910D26D3EE59F27C4B5(NULL);
		return L_1;
	}

IL_000e:
	{
		float L_2;
		L_2 = Time_get_deltaTime_mC3195000401F0FD167DD2F948FD2BC58330D0865(NULL);
		return L_2;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityBrainListener::Awake()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachinePriorityBrainListener_Awake_m6E8DD8FCFC75E6EE08E2B21019F4DB645D17BD6F (MMCinemachinePriorityBrainListener_t1EAF821E7E0F7C672716F9DA1E639F23DF709D3A* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&GameObject_GetComponent_TisCinemachineBrain_tA44C6B1C4F0BD2B34EFCD06EE4C4AFE46685CBE9_mC1162BCB892B08F7E1B985427405E11FA407A3CE_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// _brain = this.gameObject.GetComponent<CinemachineBrain>();
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_0;
		L_0 = Component_get_gameObject_m57AEFBB14DB39EC476F740BA000E170355DE691B(__this, NULL);
		NullCheck(L_0);
		CinemachineBrain_tA44C6B1C4F0BD2B34EFCD06EE4C4AFE46685CBE9* L_1;
		L_1 = GameObject_GetComponent_TisCinemachineBrain_tA44C6B1C4F0BD2B34EFCD06EE4C4AFE46685CBE9_mC1162BCB892B08F7E1B985427405E11FA407A3CE(L_0, GameObject_GetComponent_TisCinemachineBrain_tA44C6B1C4F0BD2B34EFCD06EE4C4AFE46685CBE9_mC1162BCB892B08F7E1B985427405E11FA407A3CE_RuntimeMethod_var);
		__this->____brain_5 = L_1;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____brain_5), (void*)L_1);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityBrainListener::OnMMCinemachinePriorityEvent(System.Int32,System.Boolean,System.Int32,System.Boolean,Cinemachine.CinemachineBlendDefinition,System.Boolean,MoreMountains.Feedbacks.TimescaleModes)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachinePriorityBrainListener_OnMMCinemachinePriorityEvent_mFC292BB161F28521D047024ACDE913092156EA92 (MMCinemachinePriorityBrainListener_t1EAF821E7E0F7C672716F9DA1E639F23DF709D3A* __this, int32_t ___channel0, bool ___forceMaxPriority1, int32_t ___newPriority2, bool ___forceTransition3, CinemachineBlendDefinition_t6A16D5B51D440E317D413EC8612647EDA0A6580B ___blendDefinition4, bool ___resetValuesAfterTransition5, int32_t ___timescaleMode6, const RuntimeMethod* method) 
{
	{
		// if (forceTransition)
		bool L_0 = ___forceTransition3;
		if (!L_0)
		{
			goto IL_0059;
		}
	}
	{
		// if (_coroutine != null)
		Coroutine_t85EA685566A254C23F3FD77AB5BDFFFF8799596B* L_1 = __this->____coroutine_7;
		if (!L_1)
		{
			goto IL_001a;
		}
	}
	{
		// StopCoroutine(_coroutine);
		Coroutine_t85EA685566A254C23F3FD77AB5BDFFFF8799596B* L_2 = __this->____coroutine_7;
		MonoBehaviour_StopCoroutine_mB0FC91BE84203BD8E360B3FBAE5B958B4C5ED22A(__this, L_2, NULL);
		goto IL_002b;
	}

IL_001a:
	{
		// _initialDefinition = _brain.m_DefaultBlend;
		CinemachineBrain_tA44C6B1C4F0BD2B34EFCD06EE4C4AFE46685CBE9* L_3 = __this->____brain_5;
		NullCheck(L_3);
		CinemachineBlendDefinition_t6A16D5B51D440E317D413EC8612647EDA0A6580B L_4 = L_3->___m_DefaultBlend_10;
		__this->____initialDefinition_6 = L_4;
		Il2CppCodeGenWriteBarrier((void**)&(((&__this->____initialDefinition_6))->___m_CustomCurve_2), (void*)NULL);
	}

IL_002b:
	{
		// _brain.m_DefaultBlend = blendDefinition;
		CinemachineBrain_tA44C6B1C4F0BD2B34EFCD06EE4C4AFE46685CBE9* L_5 = __this->____brain_5;
		CinemachineBlendDefinition_t6A16D5B51D440E317D413EC8612647EDA0A6580B L_6 = ___blendDefinition4;
		NullCheck(L_5);
		L_5->___m_DefaultBlend_10 = L_6;
		Il2CppCodeGenWriteBarrier((void**)&(((&L_5->___m_DefaultBlend_10))->___m_CustomCurve_2), (void*)NULL);
		// TimescaleMode = timescaleMode;
		int32_t L_7 = ___timescaleMode6;
		__this->___TimescaleMode_4 = L_7;
		// _coroutine = StartCoroutine(ResetBlendDefinition(blendDefinition.m_Time));
		CinemachineBlendDefinition_t6A16D5B51D440E317D413EC8612647EDA0A6580B L_8 = ___blendDefinition4;
		float L_9 = L_8.___m_Time_1;
		RuntimeObject* L_10;
		L_10 = VirtualFuncInvoker1< RuntimeObject*, float >::Invoke(8 /* System.Collections.IEnumerator MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityBrainListener::ResetBlendDefinition(System.Single) */, __this, L_9);
		Coroutine_t85EA685566A254C23F3FD77AB5BDFFFF8799596B* L_11;
		L_11 = MonoBehaviour_StartCoroutine_m4CAFF732AA28CD3BDC5363B44A863575530EC812(__this, L_10, NULL);
		__this->____coroutine_7 = L_11;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____coroutine_7), (void*)L_11);
	}

IL_0059:
	{
		// }
		return;
	}
}
// System.Collections.IEnumerator MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityBrainListener::ResetBlendDefinition(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* MMCinemachinePriorityBrainListener_ResetBlendDefinition_mA150DCC540BD1CBE33751A41C20BB280E1C7AD51 (MMCinemachinePriorityBrainListener_t1EAF821E7E0F7C672716F9DA1E639F23DF709D3A* __this, float ___delay0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&U3CResetBlendDefinitionU3Ed__8_t970EC43B233ACC0456765A17D202202B7079A1DC_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		U3CResetBlendDefinitionU3Ed__8_t970EC43B233ACC0456765A17D202202B7079A1DC* L_0 = (U3CResetBlendDefinitionU3Ed__8_t970EC43B233ACC0456765A17D202202B7079A1DC*)il2cpp_codegen_object_new(U3CResetBlendDefinitionU3Ed__8_t970EC43B233ACC0456765A17D202202B7079A1DC_il2cpp_TypeInfo_var);
		NullCheck(L_0);
		U3CResetBlendDefinitionU3Ed__8__ctor_mCD7D7BDADF94634CC7BB73B670390E1F290CC99D(L_0, 0, NULL);
		U3CResetBlendDefinitionU3Ed__8_t970EC43B233ACC0456765A17D202202B7079A1DC* L_1 = L_0;
		NullCheck(L_1);
		L_1->___U3CU3E4__this_2 = __this;
		Il2CppCodeGenWriteBarrier((void**)(&L_1->___U3CU3E4__this_2), (void*)__this);
		U3CResetBlendDefinitionU3Ed__8_t970EC43B233ACC0456765A17D202202B7079A1DC* L_2 = L_1;
		float L_3 = ___delay0;
		NullCheck(L_2);
		L_2->___delay_3 = L_3;
		return L_2;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityBrainListener::OnEnable()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachinePriorityBrainListener_OnEnable_m7653F212F57EEEEB836B227EAF3DE36D27C1A2CA (MMCinemachinePriorityBrainListener_t1EAF821E7E0F7C672716F9DA1E639F23DF709D3A* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// _coroutine = null;
		__this->____coroutine_7 = (Coroutine_t85EA685566A254C23F3FD77AB5BDFFFF8799596B*)NULL;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____coroutine_7), (void*)(Coroutine_t85EA685566A254C23F3FD77AB5BDFFFF8799596B*)NULL);
		// MMCinemachinePriorityEvent.Register(OnMMCinemachinePriorityEvent);
		Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* L_0 = (Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D*)il2cpp_codegen_object_new(Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D_il2cpp_TypeInfo_var);
		NullCheck(L_0);
		Delegate__ctor_m102966351BDF3F711589A2E9A2E52F8C9EABE54E(L_0, __this, (intptr_t)((void*)GetVirtualMethodInfo(__this, 7)), NULL);
		MMCinemachinePriorityEvent_Register_mA41B0E167E2ED763E8E1BA74E316A99CE097C582(L_0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityBrainListener::OnDisable()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachinePriorityBrainListener_OnDisable_m0C27D69DE368DF573F54828B6B7D45FC8DDC0BBE (MMCinemachinePriorityBrainListener_t1EAF821E7E0F7C672716F9DA1E639F23DF709D3A* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// if (_coroutine != null)
		Coroutine_t85EA685566A254C23F3FD77AB5BDFFFF8799596B* L_0 = __this->____coroutine_7;
		if (!L_0)
		{
			goto IL_0014;
		}
	}
	{
		// StopCoroutine(_coroutine);
		Coroutine_t85EA685566A254C23F3FD77AB5BDFFFF8799596B* L_1 = __this->____coroutine_7;
		MonoBehaviour_StopCoroutine_mB0FC91BE84203BD8E360B3FBAE5B958B4C5ED22A(__this, L_1, NULL);
	}

IL_0014:
	{
		// _coroutine = null;
		__this->____coroutine_7 = (Coroutine_t85EA685566A254C23F3FD77AB5BDFFFF8799596B*)NULL;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____coroutine_7), (void*)(Coroutine_t85EA685566A254C23F3FD77AB5BDFFFF8799596B*)NULL);
		// MMCinemachinePriorityEvent.Unregister(OnMMCinemachinePriorityEvent);
		Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* L_2 = (Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D*)il2cpp_codegen_object_new(Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D_il2cpp_TypeInfo_var);
		NullCheck(L_2);
		Delegate__ctor_m102966351BDF3F711589A2E9A2E52F8C9EABE54E(L_2, __this, (intptr_t)((void*)GetVirtualMethodInfo(__this, 7)), NULL);
		MMCinemachinePriorityEvent_Unregister_mF6CDB945CAAFC6C09F0296A156D4FA1608FD761D(L_2, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityBrainListener::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachinePriorityBrainListener__ctor_mECC2F85F880C4BE7665BCABC3B1BB4BB2537B473 (MMCinemachinePriorityBrainListener_t1EAF821E7E0F7C672716F9DA1E639F23DF709D3A* __this, const RuntimeMethod* method) 
{
	{
		MonoBehaviour__ctor_m592DB0105CA0BC97AA1C5F4AD27B12D68A3B7C1E(__this, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityBrainListener/<ResetBlendDefinition>d__8::.ctor(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void U3CResetBlendDefinitionU3Ed__8__ctor_mCD7D7BDADF94634CC7BB73B670390E1F290CC99D (U3CResetBlendDefinitionU3Ed__8_t970EC43B233ACC0456765A17D202202B7079A1DC* __this, int32_t ___U3CU3E1__state0, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		int32_t L_0 = ___U3CU3E1__state0;
		__this->___U3CU3E1__state_0 = L_0;
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityBrainListener/<ResetBlendDefinition>d__8::System.IDisposable.Dispose()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void U3CResetBlendDefinitionU3Ed__8_System_IDisposable_Dispose_m0B871ACFEB503085AEC099A1FDACF1309DB188E1 (U3CResetBlendDefinitionU3Ed__8_t970EC43B233ACC0456765A17D202202B7079A1DC* __this, const RuntimeMethod* method) 
{
	{
		return;
	}
}
// System.Boolean MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityBrainListener/<ResetBlendDefinition>d__8::MoveNext()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool U3CResetBlendDefinitionU3Ed__8_MoveNext_m7082239513487DE0B2A432F5E07FFF74010DAD42 (U3CResetBlendDefinitionU3Ed__8_t970EC43B233ACC0456765A17D202202B7079A1DC* __this, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	MMCinemachinePriorityBrainListener_t1EAF821E7E0F7C672716F9DA1E639F23DF709D3A* V_1 = NULL;
	{
		int32_t L_0 = __this->___U3CU3E1__state_0;
		V_0 = L_0;
		MMCinemachinePriorityBrainListener_t1EAF821E7E0F7C672716F9DA1E639F23DF709D3A* L_1 = __this->___U3CU3E4__this_2;
		V_1 = L_1;
		int32_t L_2 = V_0;
		if (!L_2)
		{
			goto IL_0017;
		}
	}
	{
		int32_t L_3 = V_0;
		if ((((int32_t)L_3) == ((int32_t)1)))
		{
			goto IL_003b;
		}
	}
	{
		return (bool)0;
	}

IL_0017:
	{
		__this->___U3CU3E1__state_0 = (-1);
		// for (float timer = 0; timer < delay; timer += GetDeltaTime())
		__this->___U3CtimerU3E5__2_4 = (0.0f);
		goto IL_0055;
	}

IL_002b:
	{
		// yield return null;
		__this->___U3CU3E2__current_1 = NULL;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___U3CU3E2__current_1), (void*)NULL);
		__this->___U3CU3E1__state_0 = 1;
		return (bool)1;
	}

IL_003b:
	{
		__this->___U3CU3E1__state_0 = (-1);
		// for (float timer = 0; timer < delay; timer += GetDeltaTime())
		float L_4 = __this->___U3CtimerU3E5__2_4;
		MMCinemachinePriorityBrainListener_t1EAF821E7E0F7C672716F9DA1E639F23DF709D3A* L_5 = V_1;
		NullCheck(L_5);
		float L_6;
		L_6 = VirtualFuncInvoker0< float >::Invoke(5 /* System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityBrainListener::GetDeltaTime() */, L_5);
		__this->___U3CtimerU3E5__2_4 = ((float)il2cpp_codegen_add(L_4, L_6));
	}

IL_0055:
	{
		// for (float timer = 0; timer < delay; timer += GetDeltaTime())
		float L_7 = __this->___U3CtimerU3E5__2_4;
		float L_8 = __this->___delay_3;
		if ((((float)L_7) < ((float)L_8)))
		{
			goto IL_002b;
		}
	}
	{
		// _brain.m_DefaultBlend = _initialDefinition;
		MMCinemachinePriorityBrainListener_t1EAF821E7E0F7C672716F9DA1E639F23DF709D3A* L_9 = V_1;
		NullCheck(L_9);
		CinemachineBrain_tA44C6B1C4F0BD2B34EFCD06EE4C4AFE46685CBE9* L_10 = L_9->____brain_5;
		MMCinemachinePriorityBrainListener_t1EAF821E7E0F7C672716F9DA1E639F23DF709D3A* L_11 = V_1;
		NullCheck(L_11);
		CinemachineBlendDefinition_t6A16D5B51D440E317D413EC8612647EDA0A6580B L_12 = L_11->____initialDefinition_6;
		NullCheck(L_10);
		L_10->___m_DefaultBlend_10 = L_12;
		Il2CppCodeGenWriteBarrier((void**)&(((&L_10->___m_DefaultBlend_10))->___m_CustomCurve_2), (void*)NULL);
		// _coroutine = null;
		MMCinemachinePriorityBrainListener_t1EAF821E7E0F7C672716F9DA1E639F23DF709D3A* L_13 = V_1;
		NullCheck(L_13);
		L_13->____coroutine_7 = (Coroutine_t85EA685566A254C23F3FD77AB5BDFFFF8799596B*)NULL;
		Il2CppCodeGenWriteBarrier((void**)(&L_13->____coroutine_7), (void*)(Coroutine_t85EA685566A254C23F3FD77AB5BDFFFF8799596B*)NULL);
		// }
		return (bool)0;
	}
}
// System.Object MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityBrainListener/<ResetBlendDefinition>d__8::System.Collections.Generic.IEnumerator<System.Object>.get_Current()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* U3CResetBlendDefinitionU3Ed__8_System_Collections_Generic_IEnumeratorU3CSystem_ObjectU3E_get_Current_m6C38DC491690604C54EB4C6F5D93F29184244958 (U3CResetBlendDefinitionU3Ed__8_t970EC43B233ACC0456765A17D202202B7079A1DC* __this, const RuntimeMethod* method) 
{
	{
		RuntimeObject* L_0 = __this->___U3CU3E2__current_1;
		return L_0;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityBrainListener/<ResetBlendDefinition>d__8::System.Collections.IEnumerator.Reset()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void U3CResetBlendDefinitionU3Ed__8_System_Collections_IEnumerator_Reset_m643CB5C475512A99ABB6530903238B2DABB0BC10 (U3CResetBlendDefinitionU3Ed__8_t970EC43B233ACC0456765A17D202202B7079A1DC* __this, const RuntimeMethod* method) 
{
	{
		NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A* L_0 = (NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A_il2cpp_TypeInfo_var)));
		NullCheck(L_0);
		NotSupportedException__ctor_m1398D0CDE19B36AA3DE9392879738C1EA2439CDF(L_0, NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_0, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&U3CResetBlendDefinitionU3Ed__8_System_Collections_IEnumerator_Reset_m643CB5C475512A99ABB6530903238B2DABB0BC10_RuntimeMethod_var)));
	}
}
// System.Object MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityBrainListener/<ResetBlendDefinition>d__8::System.Collections.IEnumerator.get_Current()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* U3CResetBlendDefinitionU3Ed__8_System_Collections_IEnumerator_get_Current_mE078A4F3FA4740A0D50C5050B2635AA209E24C75 (U3CResetBlendDefinitionU3Ed__8_t970EC43B233ACC0456765A17D202202B7079A1DC* __this, const RuntimeMethod* method) 
{
	{
		RuntimeObject* L_0 = __this->___U3CU3E2__current_1;
		return L_0;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityListener::GetTime()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float MMCinemachinePriorityListener_GetTime_m6FFB449E6B4503BAB1CE782A663EEAE8B531F21E (MMCinemachinePriorityListener_tEE3ED7BDA2BD945CC38862163B4A793F89E6158A* __this, const RuntimeMethod* method) 
{
	{
		// public virtual float GetTime() { return (TimescaleMode == TimescaleModes.Scaled) ? Time.time : Time.unscaledTime; }
		int32_t L_0 = __this->___TimescaleMode_4;
		if (!L_0)
		{
			goto IL_000e;
		}
	}
	{
		float L_1;
		L_1 = Time_get_unscaledTime_mAF4040B858903E1325D1C65B8BF1AC61460B2503(NULL);
		return L_1;
	}

IL_000e:
	{
		float L_2;
		L_2 = Time_get_time_m3A271BB1B20041144AC5B7863B71AB1F0150374B(NULL);
		return L_2;
	}
}
// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityListener::GetDeltaTime()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float MMCinemachinePriorityListener_GetDeltaTime_m843F571A7D3E510FF2B343414A2038C43D018EE5 (MMCinemachinePriorityListener_tEE3ED7BDA2BD945CC38862163B4A793F89E6158A* __this, const RuntimeMethod* method) 
{
	{
		// public virtual float GetDeltaTime() { return (TimescaleMode == TimescaleModes.Scaled) ? Time.deltaTime : Time.unscaledDeltaTime; }
		int32_t L_0 = __this->___TimescaleMode_4;
		if (!L_0)
		{
			goto IL_000e;
		}
	}
	{
		float L_1;
		L_1 = Time_get_unscaledDeltaTime_mF057EECA857E5C0F90A3F910D26D3EE59F27C4B5(NULL);
		return L_1;
	}

IL_000e:
	{
		float L_2;
		L_2 = Time_get_deltaTime_mC3195000401F0FD167DD2F948FD2BC58330D0865(NULL);
		return L_2;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityListener::Awake()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachinePriorityListener_Awake_m2EF780FFAE46F97617DA497793B32FBA64A17B14 (MMCinemachinePriorityListener_tEE3ED7BDA2BD945CC38862163B4A793F89E6158A* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&GameObject_GetComponent_TisCinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE_m24E4FA934917769BC3E78C1CE434B56A2B0346C5_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// _camera = this.gameObject.GetComponent<CinemachineVirtualCameraBase>();
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_0;
		L_0 = Component_get_gameObject_m57AEFBB14DB39EC476F740BA000E170355DE691B(__this, NULL);
		NullCheck(L_0);
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_1;
		L_1 = GameObject_GetComponent_TisCinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE_m24E4FA934917769BC3E78C1CE434B56A2B0346C5(L_0, GameObject_GetComponent_TisCinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE_m24E4FA934917769BC3E78C1CE434B56A2B0346C5_RuntimeMethod_var);
		__this->____camera_6 = L_1;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____camera_6), (void*)L_1);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityListener::OnMMCinemachinePriorityEvent(System.Int32,System.Boolean,System.Int32,System.Boolean,Cinemachine.CinemachineBlendDefinition,System.Boolean,MoreMountains.Feedbacks.TimescaleModes)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachinePriorityListener_OnMMCinemachinePriorityEvent_mBCA877FEA7C6BAE7B43C5BBE0A33396AB6F0EE38 (MMCinemachinePriorityListener_tEE3ED7BDA2BD945CC38862163B4A793F89E6158A* __this, int32_t ___channel0, bool ___forceMaxPriority1, int32_t ___newPriority2, bool ___forceTransition3, CinemachineBlendDefinition_t6A16D5B51D440E317D413EC8612647EDA0A6580B ___blendDefinition4, bool ___resetValuesAfterTransition5, int32_t ___timescaleMode6, const RuntimeMethod* method) 
{
	{
		// TimescaleMode = timescaleMode;
		int32_t L_0 = ___timescaleMode6;
		__this->___TimescaleMode_4 = L_0;
		// if (channel == Channel)
		int32_t L_1 = ___channel0;
		int32_t L_2 = __this->___Channel_5;
		if ((!(((uint32_t)L_1) == ((uint32_t)L_2))))
		{
			goto IL_001e;
		}
	}
	{
		// _camera.Priority = newPriority;
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_3 = __this->____camera_6;
		int32_t L_4 = ___newPriority2;
		NullCheck(L_3);
		CinemachineVirtualCameraBase_set_Priority_m233ED0376CE0BD1244CCA52DF4532C8988DC05AC_inline(L_3, L_4, NULL);
		return;
	}

IL_001e:
	{
		// if (forceMaxPriority)
		bool L_5 = ___forceMaxPriority1;
		if (!L_5)
		{
			goto IL_002d;
		}
	}
	{
		// _camera.Priority = 0;
		CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* L_6 = __this->____camera_6;
		NullCheck(L_6);
		CinemachineVirtualCameraBase_set_Priority_m233ED0376CE0BD1244CCA52DF4532C8988DC05AC_inline(L_6, 0, NULL);
	}

IL_002d:
	{
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityListener::OnEnable()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachinePriorityListener_OnEnable_m4A933A7ABC71769D48FB2FC4BE3043051FB498B9 (MMCinemachinePriorityListener_tEE3ED7BDA2BD945CC38862163B4A793F89E6158A* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// MMCinemachinePriorityEvent.Register(OnMMCinemachinePriorityEvent);
		Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* L_0 = (Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D*)il2cpp_codegen_object_new(Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D_il2cpp_TypeInfo_var);
		NullCheck(L_0);
		Delegate__ctor_m102966351BDF3F711589A2E9A2E52F8C9EABE54E(L_0, __this, (intptr_t)((void*)GetVirtualMethodInfo(__this, 7)), NULL);
		MMCinemachinePriorityEvent_Register_mA41B0E167E2ED763E8E1BA74E316A99CE097C582(L_0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityListener::OnDisable()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachinePriorityListener_OnDisable_m577A6680866BF8B7E30CC652D08638171DE8AD58 (MMCinemachinePriorityListener_tEE3ED7BDA2BD945CC38862163B4A793F89E6158A* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// MMCinemachinePriorityEvent.Unregister(OnMMCinemachinePriorityEvent);
		Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* L_0 = (Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D*)il2cpp_codegen_object_new(Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D_il2cpp_TypeInfo_var);
		NullCheck(L_0);
		Delegate__ctor_m102966351BDF3F711589A2E9A2E52F8C9EABE54E(L_0, __this, (intptr_t)((void*)GetVirtualMethodInfo(__this, 7)), NULL);
		MMCinemachinePriorityEvent_Unregister_mF6CDB945CAAFC6C09F0296A156D4FA1608FD761D(L_0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityListener::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachinePriorityListener__ctor_m49D8A8A09506A9B819E9E54D958FE7C26E1B62F5 (MMCinemachinePriorityListener_tEE3ED7BDA2BD945CC38862163B4A793F89E6158A* __this, const RuntimeMethod* method) 
{
	{
		MonoBehaviour__ctor_m592DB0105CA0BC97AA1C5F4AD27B12D68A3B7C1E(__this, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityEvent::add_OnEvent(MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityEvent/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachinePriorityEvent_add_OnEvent_mC495EF756CD4D57D51DDBD60DF005DB2A7995769 (Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* ___value0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMCinemachinePriorityEvent_t171D76AEBB1D62D1F95FA9594669EA08940AA0E9_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* V_0 = NULL;
	Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* V_1 = NULL;
	Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* V_2 = NULL;
	{
		Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* L_0 = ((MMCinemachinePriorityEvent_t171D76AEBB1D62D1F95FA9594669EA08940AA0E9_StaticFields*)il2cpp_codegen_static_fields_for(MMCinemachinePriorityEvent_t171D76AEBB1D62D1F95FA9594669EA08940AA0E9_il2cpp_TypeInfo_var))->___OnEvent_0;
		V_0 = L_0;
	}

IL_0006:
	{
		Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* L_1 = V_0;
		V_1 = L_1;
		Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* L_2 = V_1;
		Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* L_3 = ___value0;
		Delegate_t* L_4;
		L_4 = Delegate_Combine_m1F725AEF318BE6F0426863490691A6F4606E7D00(L_2, L_3, NULL);
		V_2 = ((Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D*)CastclassSealed((RuntimeObject*)L_4, Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D_il2cpp_TypeInfo_var));
		Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* L_5 = V_2;
		Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* L_6 = V_1;
		Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* L_7;
		L_7 = InterlockedCompareExchangeImpl<Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D*>((&((MMCinemachinePriorityEvent_t171D76AEBB1D62D1F95FA9594669EA08940AA0E9_StaticFields*)il2cpp_codegen_static_fields_for(MMCinemachinePriorityEvent_t171D76AEBB1D62D1F95FA9594669EA08940AA0E9_il2cpp_TypeInfo_var))->___OnEvent_0), L_5, L_6);
		V_0 = L_7;
		Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* L_8 = V_0;
		Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* L_9 = V_1;
		if ((!(((RuntimeObject*)(Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D*)L_8) == ((RuntimeObject*)(Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D*)L_9))))
		{
			goto IL_0006;
		}
	}
	{
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityEvent::remove_OnEvent(MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityEvent/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachinePriorityEvent_remove_OnEvent_m7125AA477BD05BA55997BAA712E5171318487ED7 (Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* ___value0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMCinemachinePriorityEvent_t171D76AEBB1D62D1F95FA9594669EA08940AA0E9_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* V_0 = NULL;
	Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* V_1 = NULL;
	Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* V_2 = NULL;
	{
		Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* L_0 = ((MMCinemachinePriorityEvent_t171D76AEBB1D62D1F95FA9594669EA08940AA0E9_StaticFields*)il2cpp_codegen_static_fields_for(MMCinemachinePriorityEvent_t171D76AEBB1D62D1F95FA9594669EA08940AA0E9_il2cpp_TypeInfo_var))->___OnEvent_0;
		V_0 = L_0;
	}

IL_0006:
	{
		Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* L_1 = V_0;
		V_1 = L_1;
		Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* L_2 = V_1;
		Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* L_3 = ___value0;
		Delegate_t* L_4;
		L_4 = Delegate_Remove_m8B7DD5661308FA972E23CA1CC3FC9CEB355504E3(L_2, L_3, NULL);
		V_2 = ((Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D*)CastclassSealed((RuntimeObject*)L_4, Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D_il2cpp_TypeInfo_var));
		Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* L_5 = V_2;
		Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* L_6 = V_1;
		Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* L_7;
		L_7 = InterlockedCompareExchangeImpl<Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D*>((&((MMCinemachinePriorityEvent_t171D76AEBB1D62D1F95FA9594669EA08940AA0E9_StaticFields*)il2cpp_codegen_static_fields_for(MMCinemachinePriorityEvent_t171D76AEBB1D62D1F95FA9594669EA08940AA0E9_il2cpp_TypeInfo_var))->___OnEvent_0), L_5, L_6);
		V_0 = L_7;
		Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* L_8 = V_0;
		Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* L_9 = V_1;
		if ((!(((RuntimeObject*)(Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D*)L_8) == ((RuntimeObject*)(Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D*)L_9))))
		{
			goto IL_0006;
		}
	}
	{
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityEvent::Register(MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityEvent/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachinePriorityEvent_Register_mA41B0E167E2ED763E8E1BA74E316A99CE097C582 (Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* ___callback0, const RuntimeMethod* method) 
{
	{
		// OnEvent += callback;
		Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* L_0 = ___callback0;
		MMCinemachinePriorityEvent_add_OnEvent_mC495EF756CD4D57D51DDBD60DF005DB2A7995769(L_0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityEvent::Unregister(MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityEvent/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachinePriorityEvent_Unregister_mF6CDB945CAAFC6C09F0296A156D4FA1608FD761D (Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* ___callback0, const RuntimeMethod* method) 
{
	{
		// OnEvent -= callback;
		Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* L_0 = ___callback0;
		MMCinemachinePriorityEvent_remove_OnEvent_m7125AA477BD05BA55997BAA712E5171318487ED7(L_0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityEvent::Trigger(System.Int32,System.Boolean,System.Int32,System.Boolean,Cinemachine.CinemachineBlendDefinition,System.Boolean,MoreMountains.Feedbacks.TimescaleModes)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachinePriorityEvent_Trigger_mB101FF6CE1A5AA8C81FDAAE93FF075CAF7C34581 (int32_t ___channel0, bool ___forceMaxPriority1, int32_t ___newPriority2, bool ___forceTransition3, CinemachineBlendDefinition_t6A16D5B51D440E317D413EC8612647EDA0A6580B ___blendDefinition4, bool ___resetValuesAfterTransition5, int32_t ___timescaleMode6, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMCinemachinePriorityEvent_t171D76AEBB1D62D1F95FA9594669EA08940AA0E9_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* G_B2_0 = NULL;
	Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* G_B1_0 = NULL;
	{
		// OnEvent?.Invoke(channel, forceMaxPriority, newPriority, forceTransition, blendDefinition, resetValuesAfterTransition, timescaleMode);
		Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* L_0 = ((MMCinemachinePriorityEvent_t171D76AEBB1D62D1F95FA9594669EA08940AA0E9_StaticFields*)il2cpp_codegen_static_fields_for(MMCinemachinePriorityEvent_t171D76AEBB1D62D1F95FA9594669EA08940AA0E9_il2cpp_TypeInfo_var))->___OnEvent_0;
		Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* L_1 = L_0;
		G_B1_0 = L_1;
		if (L_1)
		{
			G_B2_0 = L_1;
			goto IL_000a;
		}
	}
	{
		return;
	}

IL_000a:
	{
		int32_t L_2 = ___channel0;
		bool L_3 = ___forceMaxPriority1;
		int32_t L_4 = ___newPriority2;
		bool L_5 = ___forceTransition3;
		CinemachineBlendDefinition_t6A16D5B51D440E317D413EC8612647EDA0A6580B L_6 = ___blendDefinition4;
		bool L_7 = ___resetValuesAfterTransition5;
		int32_t L_8 = ___timescaleMode6;
		NullCheck(G_B2_0);
		Delegate_Invoke_m522A97EE33632F1AA72205CB61AB7258FE91C19D_inline(G_B2_0, L_2, L_3, L_4, L_5, L_6, L_7, L_8, NULL);
		// }
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
void Delegate_Invoke_m522A97EE33632F1AA72205CB61AB7258FE91C19D_Multicast(Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* __this, int32_t ___channel0, bool ___forceMaxPriority1, int32_t ___newPriority2, bool ___forceTransition3, CinemachineBlendDefinition_t6A16D5B51D440E317D413EC8612647EDA0A6580B ___blendDefinition4, bool ___resetValuesAfterTransition5, int32_t ___timescaleMode6, const RuntimeMethod* method)
{
	il2cpp_array_size_t length = __this->___delegates_13->max_length;
	Delegate_t** delegatesToInvoke = reinterpret_cast<Delegate_t**>(__this->___delegates_13->GetAddressAtUnchecked(0));
	for (il2cpp_array_size_t i = 0; i < length; i++)
	{
		Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* currentDelegate = reinterpret_cast<Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D*>(delegatesToInvoke[i]);
		typedef void (*FunctionPointerType) (RuntimeObject*, int32_t, bool, int32_t, bool, CinemachineBlendDefinition_t6A16D5B51D440E317D413EC8612647EDA0A6580B, bool, int32_t, const RuntimeMethod*);
		((FunctionPointerType)currentDelegate->___invoke_impl_1)((Il2CppObject*)currentDelegate->___method_code_6, ___channel0, ___forceMaxPriority1, ___newPriority2, ___forceTransition3, ___blendDefinition4, ___resetValuesAfterTransition5, ___timescaleMode6, reinterpret_cast<RuntimeMethod*>(currentDelegate->___method_3));
	}
}
void Delegate_Invoke_m522A97EE33632F1AA72205CB61AB7258FE91C19D_OpenInst(Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* __this, int32_t ___channel0, bool ___forceMaxPriority1, int32_t ___newPriority2, bool ___forceTransition3, CinemachineBlendDefinition_t6A16D5B51D440E317D413EC8612647EDA0A6580B ___blendDefinition4, bool ___resetValuesAfterTransition5, int32_t ___timescaleMode6, const RuntimeMethod* method)
{
	typedef void (*FunctionPointerType) (int32_t, bool, int32_t, bool, CinemachineBlendDefinition_t6A16D5B51D440E317D413EC8612647EDA0A6580B, bool, int32_t, const RuntimeMethod*);
	((FunctionPointerType)__this->___method_ptr_0)(___channel0, ___forceMaxPriority1, ___newPriority2, ___forceTransition3, ___blendDefinition4, ___resetValuesAfterTransition5, ___timescaleMode6, method);
}
void Delegate_Invoke_m522A97EE33632F1AA72205CB61AB7258FE91C19D_OpenStatic(Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* __this, int32_t ___channel0, bool ___forceMaxPriority1, int32_t ___newPriority2, bool ___forceTransition3, CinemachineBlendDefinition_t6A16D5B51D440E317D413EC8612647EDA0A6580B ___blendDefinition4, bool ___resetValuesAfterTransition5, int32_t ___timescaleMode6, const RuntimeMethod* method)
{
	typedef void (*FunctionPointerType) (int32_t, bool, int32_t, bool, CinemachineBlendDefinition_t6A16D5B51D440E317D413EC8612647EDA0A6580B, bool, int32_t, const RuntimeMethod*);
	((FunctionPointerType)__this->___method_ptr_0)(___channel0, ___forceMaxPriority1, ___newPriority2, ___forceTransition3, ___blendDefinition4, ___resetValuesAfterTransition5, ___timescaleMode6, method);
}
void Delegate_Invoke_m522A97EE33632F1AA72205CB61AB7258FE91C19D_OpenStaticInvoker(Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* __this, int32_t ___channel0, bool ___forceMaxPriority1, int32_t ___newPriority2, bool ___forceTransition3, CinemachineBlendDefinition_t6A16D5B51D440E317D413EC8612647EDA0A6580B ___blendDefinition4, bool ___resetValuesAfterTransition5, int32_t ___timescaleMode6, const RuntimeMethod* method)
{
	InvokerActionInvoker7< int32_t, bool, int32_t, bool, CinemachineBlendDefinition_t6A16D5B51D440E317D413EC8612647EDA0A6580B, bool, int32_t >::Invoke(__this->___method_ptr_0, method, NULL, ___channel0, ___forceMaxPriority1, ___newPriority2, ___forceTransition3, ___blendDefinition4, ___resetValuesAfterTransition5, ___timescaleMode6);
}
void Delegate_Invoke_m522A97EE33632F1AA72205CB61AB7258FE91C19D_ClosedStaticInvoker(Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* __this, int32_t ___channel0, bool ___forceMaxPriority1, int32_t ___newPriority2, bool ___forceTransition3, CinemachineBlendDefinition_t6A16D5B51D440E317D413EC8612647EDA0A6580B ___blendDefinition4, bool ___resetValuesAfterTransition5, int32_t ___timescaleMode6, const RuntimeMethod* method)
{
	InvokerActionInvoker8< RuntimeObject*, int32_t, bool, int32_t, bool, CinemachineBlendDefinition_t6A16D5B51D440E317D413EC8612647EDA0A6580B, bool, int32_t >::Invoke(__this->___method_ptr_0, method, NULL, __this->___m_target_2, ___channel0, ___forceMaxPriority1, ___newPriority2, ___forceTransition3, ___blendDefinition4, ___resetValuesAfterTransition5, ___timescaleMode6);
}
IL2CPP_EXTERN_C  void DelegatePInvokeWrapper_Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D (Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* __this, int32_t ___channel0, bool ___forceMaxPriority1, int32_t ___newPriority2, bool ___forceTransition3, CinemachineBlendDefinition_t6A16D5B51D440E317D413EC8612647EDA0A6580B ___blendDefinition4, bool ___resetValuesAfterTransition5, int32_t ___timescaleMode6, const RuntimeMethod* method)
{
	typedef void (DEFAULT_CALL *PInvokeFunc)(int32_t, int32_t, int32_t, int32_t, CinemachineBlendDefinition_t6A16D5B51D440E317D413EC8612647EDA0A6580B, int32_t, int32_t);
	PInvokeFunc il2cppPInvokeFunc = reinterpret_cast<PInvokeFunc>(il2cpp_codegen_get_reverse_pinvoke_function_ptr(__this));
	// Native function invocation
	il2cppPInvokeFunc(___channel0, static_cast<int32_t>(___forceMaxPriority1), ___newPriority2, static_cast<int32_t>(___forceTransition3), ___blendDefinition4, static_cast<int32_t>(___resetValuesAfterTransition5), ___timescaleMode6);

}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityEvent/Delegate::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Delegate__ctor_m102966351BDF3F711589A2E9A2E52F8C9EABE54E (Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* __this, RuntimeObject* ___object0, intptr_t ___method1, const RuntimeMethod* method) 
{
	__this->___method_ptr_0 = il2cpp_codegen_get_virtual_call_method_pointer((RuntimeMethod*)___method1);
	__this->___method_3 = ___method1;
	__this->___m_target_2 = ___object0;
	Il2CppCodeGenWriteBarrier((void**)(&__this->___m_target_2), (void*)___object0);
	int parameterCount = il2cpp_codegen_method_parameter_count((RuntimeMethod*)___method1);
	__this->___method_code_6 = (intptr_t)__this;
	if (MethodIsStatic((RuntimeMethod*)___method1))
	{
		bool isOpen = parameterCount == 7;
		if (il2cpp_codegen_call_method_via_invoker((RuntimeMethod*)___method1))
			if (isOpen)
				__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_m522A97EE33632F1AA72205CB61AB7258FE91C19D_OpenStaticInvoker;
			else
				__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_m522A97EE33632F1AA72205CB61AB7258FE91C19D_ClosedStaticInvoker;
		else
			if (isOpen)
				__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_m522A97EE33632F1AA72205CB61AB7258FE91C19D_OpenStatic;
			else
				{
					__this->___invoke_impl_1 = (intptr_t)__this->___method_ptr_0;
					__this->___method_code_6 = (intptr_t)__this->___m_target_2;
				}
	}
	else
	{
		if (___object0 == NULL)
			il2cpp_codegen_raise_exception(il2cpp_codegen_get_argument_exception(NULL, "Delegate to an instance method cannot have null 'this'."), NULL);
		__this->___invoke_impl_1 = (intptr_t)__this->___method_ptr_0;
		__this->___method_code_6 = (intptr_t)__this->___m_target_2;
	}
	__this->___extra_arg_5 = (intptr_t)&Delegate_Invoke_m522A97EE33632F1AA72205CB61AB7258FE91C19D_Multicast;
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityEvent/Delegate::Invoke(System.Int32,System.Boolean,System.Int32,System.Boolean,Cinemachine.CinemachineBlendDefinition,System.Boolean,MoreMountains.Feedbacks.TimescaleModes)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Delegate_Invoke_m522A97EE33632F1AA72205CB61AB7258FE91C19D (Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* __this, int32_t ___channel0, bool ___forceMaxPriority1, int32_t ___newPriority2, bool ___forceTransition3, CinemachineBlendDefinition_t6A16D5B51D440E317D413EC8612647EDA0A6580B ___blendDefinition4, bool ___resetValuesAfterTransition5, int32_t ___timescaleMode6, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, int32_t, bool, int32_t, bool, CinemachineBlendDefinition_t6A16D5B51D440E317D413EC8612647EDA0A6580B, bool, int32_t, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___channel0, ___forceMaxPriority1, ___newPriority2, ___forceTransition3, ___blendDefinition4, ___resetValuesAfterTransition5, ___timescaleMode6, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
// System.IAsyncResult MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityEvent/Delegate::BeginInvoke(System.Int32,System.Boolean,System.Int32,System.Boolean,Cinemachine.CinemachineBlendDefinition,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.AsyncCallback,System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* Delegate_BeginInvoke_m34C3261395B235B1D48563F0A2A9398829E8477A (Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* __this, int32_t ___channel0, bool ___forceMaxPriority1, int32_t ___newPriority2, bool ___forceTransition3, CinemachineBlendDefinition_t6A16D5B51D440E317D413EC8612647EDA0A6580B ___blendDefinition4, bool ___resetValuesAfterTransition5, int32_t ___timescaleMode6, AsyncCallback_t7FEF460CBDCFB9C5FA2EF776984778B9A4145F4C* ___callback7, RuntimeObject* ___object8, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&CinemachineBlendDefinition_t6A16D5B51D440E317D413EC8612647EDA0A6580B_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TimescaleModes_t567213DC39EEE1AA073F8E8473E19F2B71FC9A68_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	void *__d_args[8] = {0};
	__d_args[0] = Box(Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var, &___channel0);
	__d_args[1] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___forceMaxPriority1);
	__d_args[2] = Box(Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var, &___newPriority2);
	__d_args[3] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___forceTransition3);
	__d_args[4] = Box(CinemachineBlendDefinition_t6A16D5B51D440E317D413EC8612647EDA0A6580B_il2cpp_TypeInfo_var, &___blendDefinition4);
	__d_args[5] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___resetValuesAfterTransition5);
	__d_args[6] = Box(TimescaleModes_t567213DC39EEE1AA073F8E8473E19F2B71FC9A68_il2cpp_TypeInfo_var, &___timescaleMode6);
	return (RuntimeObject*)il2cpp_codegen_delegate_begin_invoke((RuntimeDelegate*)__this, __d_args, (RuntimeDelegate*)___callback7, (RuntimeObject*)___object8);
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachinePriorityEvent/Delegate::EndInvoke(System.IAsyncResult)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Delegate_EndInvoke_m6D1DEA66CE92232CBD0B438837DD170B8112A488 (Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* __this, RuntimeObject* ___result0, const RuntimeMethod* method) 
{
	il2cpp_codegen_delegate_end_invoke((Il2CppAsyncResult*) ___result0, 0);
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineZoom::GetTime()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float MMCinemachineZoom_GetTime_m13D43F45B941D2EFACB89D0FAFFC18E618384F79 (MMCinemachineZoom_t270C67D5C8B1AC74F711331A3953C83F4E27E61A* __this, const RuntimeMethod* method) 
{
	{
		// public virtual float GetTime() { return (TimescaleMode == TimescaleModes.Scaled) ? Time.time : Time.unscaledTime; }
		int32_t L_0;
		L_0 = MMCinemachineZoom_get_TimescaleMode_m011368B7AAC7340E11480854F9FCF8DF02DCDF14_inline(__this, NULL);
		if (!L_0)
		{
			goto IL_000e;
		}
	}
	{
		float L_1;
		L_1 = Time_get_unscaledTime_mAF4040B858903E1325D1C65B8BF1AC61460B2503(NULL);
		return L_1;
	}

IL_000e:
	{
		float L_2;
		L_2 = Time_get_time_m3A271BB1B20041144AC5B7863B71AB1F0150374B(NULL);
		return L_2;
	}
}
// System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineZoom::GetDeltaTime()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float MMCinemachineZoom_GetDeltaTime_m144C0593548EE27DF3E4AEEF092BDD4910987BFC (MMCinemachineZoom_t270C67D5C8B1AC74F711331A3953C83F4E27E61A* __this, const RuntimeMethod* method) 
{
	{
		// public virtual float GetDeltaTime() { return (TimescaleMode == TimescaleModes.Scaled) ? Time.deltaTime : Time.unscaledDeltaTime; }
		int32_t L_0;
		L_0 = MMCinemachineZoom_get_TimescaleMode_m011368B7AAC7340E11480854F9FCF8DF02DCDF14_inline(__this, NULL);
		if (!L_0)
		{
			goto IL_000e;
		}
	}
	{
		float L_1;
		L_1 = Time_get_unscaledDeltaTime_mF057EECA857E5C0F90A3F910D26D3EE59F27C4B5(NULL);
		return L_1;
	}

IL_000e:
	{
		float L_2;
		L_2 = Time_get_deltaTime_mC3195000401F0FD167DD2F948FD2BC58330D0865(NULL);
		return L_2;
	}
}
// MoreMountains.Feedbacks.TimescaleModes MoreMountains.FeedbacksForThirdParty.MMCinemachineZoom::get_TimescaleMode()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t MMCinemachineZoom_get_TimescaleMode_m011368B7AAC7340E11480854F9FCF8DF02DCDF14 (MMCinemachineZoom_t270C67D5C8B1AC74F711331A3953C83F4E27E61A* __this, const RuntimeMethod* method) 
{
	{
		// public TimescaleModes TimescaleMode { get; set; }
		int32_t L_0 = __this->___U3CTimescaleModeU3Ek__BackingField_11;
		return L_0;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineZoom::set_TimescaleMode(MoreMountains.Feedbacks.TimescaleModes)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineZoom_set_TimescaleMode_m31C347EEC2E268FA9BC4824C78891EED9796E08F (MMCinemachineZoom_t270C67D5C8B1AC74F711331A3953C83F4E27E61A* __this, int32_t ___value0, const RuntimeMethod* method) 
{
	{
		// public TimescaleModes TimescaleMode { get; set; }
		int32_t L_0 = ___value0;
		__this->___U3CTimescaleModeU3Ek__BackingField_11 = L_0;
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineZoom::Awake()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineZoom_Awake_mCA12A9B756478507042A2371EFA1F5B573C5B5F0 (MMCinemachineZoom_t270C67D5C8B1AC74F711331A3953C83F4E27E61A* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&GameObject_GetComponent_TisCinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50_m1A2DDA6B545C821D4E79E784051FDF79464CAD2D_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// _virtualCamera = this.gameObject.GetComponent<Cinemachine.CinemachineVirtualCamera>();
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_0;
		L_0 = Component_get_gameObject_m57AEFBB14DB39EC476F740BA000E170355DE691B(__this, NULL);
		NullCheck(L_0);
		CinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50* L_1;
		L_1 = GameObject_GetComponent_TisCinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50_m1A2DDA6B545C821D4E79E784051FDF79464CAD2D(L_0, GameObject_GetComponent_TisCinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50_m1A2DDA6B545C821D4E79E784051FDF79464CAD2D_RuntimeMethod_var);
		__this->____virtualCamera_12 = L_1;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____virtualCamera_12), (void*)L_1);
		// _initialFieldOfView = _virtualCamera.m_Lens.FieldOfView;
		CinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50* L_2 = __this->____virtualCamera_12;
		NullCheck(L_2);
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE* L_3 = (&L_2->___m_Lens_30);
		float L_4 = L_3->___FieldOfView_1;
		__this->____initialFieldOfView_13 = L_4;
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineZoom::Update()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineZoom_Update_mB2499E263B8FDC4CBB4124978320CCF6F1C54774 (MMCinemachineZoom_t270C67D5C8B1AC74F711331A3953C83F4E27E61A* __this, const RuntimeMethod* method) 
{
	{
		// if (!_zooming)
		bool L_0 = __this->____zooming_15;
		if (L_0)
		{
			goto IL_0009;
		}
	}
	{
		// return;
		return;
	}

IL_0009:
	{
		// if (_virtualCamera.m_Lens.FieldOfView != _targetFieldOfView)
		CinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50* L_1 = __this->____virtualCamera_12;
		NullCheck(L_1);
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE* L_2 = (&L_1->___m_Lens_30);
		float L_3 = L_2->___FieldOfView_1;
		float L_4 = __this->____targetFieldOfView_19;
		if ((((float)L_3) == ((float)L_4)))
		{
			goto IL_006e;
		}
	}
	{
		// _delta += GetDeltaTime() / _transitionDuration;
		float L_5 = __this->____delta_20;
		float L_6;
		L_6 = VirtualFuncInvoker0< float >::Invoke(5 /* System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineZoom::GetDeltaTime() */, __this);
		float L_7 = __this->____transitionDuration_17;
		__this->____delta_20 = ((float)il2cpp_codegen_add(L_5, ((float)(L_6/L_7))));
		// _virtualCamera.m_Lens.FieldOfView = Mathf.LerpUnclamped(_startFieldOfView, _targetFieldOfView, ZoomCurve.Evaluate(_delta));
		CinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50* L_8 = __this->____virtualCamera_12;
		NullCheck(L_8);
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE* L_9 = (&L_8->___m_Lens_30);
		float L_10 = __this->____startFieldOfView_16;
		float L_11 = __this->____targetFieldOfView_19;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_12 = __this->___ZoomCurve_5;
		float L_13 = __this->____delta_20;
		NullCheck(L_12);
		float L_14;
		L_14 = AnimationCurve_Evaluate_m50B857043DE251A186032ADBCBB4CEF817F4EE3C(L_12, L_13, NULL);
		float L_15;
		L_15 = Mathf_LerpUnclamped_mF35042F9D25A221BDD4B3FD6251224610AFC1F35_inline(L_10, L_11, L_14, NULL);
		L_9->___FieldOfView_1 = L_15;
		return;
	}

IL_006e:
	{
		// if (!_destinationReached)
		bool L_16 = __this->____destinationReached_23;
		if (L_16)
		{
			goto IL_0089;
		}
	}
	{
		// _reachedDestinationTimestamp = GetTime();
		float L_17;
		L_17 = VirtualFuncInvoker0< float >::Invoke(4 /* System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineZoom::GetTime() */, __this);
		__this->____reachedDestinationTimestamp_22 = L_17;
		// _destinationReached = true;
		__this->____destinationReached_23 = (bool)1;
	}

IL_0089:
	{
		// if ((_mode == MMCameraZoomModes.For) && (_direction == 1))
		int32_t L_18 = __this->____mode_14;
		if (L_18)
		{
			goto IL_00da;
		}
	}
	{
		int32_t L_19 = __this->____direction_21;
		if ((!(((uint32_t)L_19) == ((uint32_t)1))))
		{
			goto IL_00da;
		}
	}
	{
		// if (GetTime() - _reachedDestinationTimestamp > _duration)
		float L_20;
		L_20 = VirtualFuncInvoker0< float >::Invoke(4 /* System.Single MoreMountains.FeedbacksForThirdParty.MMCinemachineZoom::GetTime() */, __this);
		float L_21 = __this->____reachedDestinationTimestamp_22;
		float L_22 = __this->____duration_18;
		if ((!(((float)((float)il2cpp_codegen_subtract(L_20, L_21))) > ((float)L_22))))
		{
			goto IL_00e1;
		}
	}
	{
		// _direction = -1;
		__this->____direction_21 = (-1);
		// _startFieldOfView = _targetFieldOfView;
		float L_23 = __this->____targetFieldOfView_19;
		__this->____startFieldOfView_16 = L_23;
		// _targetFieldOfView = _initialFieldOfView;
		float L_24 = __this->____initialFieldOfView_13;
		__this->____targetFieldOfView_19 = L_24;
		// _delta = 0f;
		__this->____delta_20 = (0.0f);
		return;
	}

IL_00da:
	{
		// _zooming = false;
		__this->____zooming_15 = (bool)0;
	}

IL_00e1:
	{
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineZoom::Zoom(MoreMountains.Feedbacks.MMCameraZoomModes,System.Single,System.Single,System.Single,System.Boolean,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineZoom_Zoom_m5A3A56975137A728278F68F7412757409A2F2140 (MMCinemachineZoom_t270C67D5C8B1AC74F711331A3953C83F4E27E61A* __this, int32_t ___mode0, float ___newFieldOfView1, float ___transitionDuration2, float ___duration3, bool ___useUnscaledTime4, bool ___relative5, const RuntimeMethod* method) 
{
	MMCinemachineZoom_t270C67D5C8B1AC74F711331A3953C83F4E27E61A* G_B4_0 = NULL;
	MMCinemachineZoom_t270C67D5C8B1AC74F711331A3953C83F4E27E61A* G_B3_0 = NULL;
	int32_t G_B5_0 = 0;
	MMCinemachineZoom_t270C67D5C8B1AC74F711331A3953C83F4E27E61A* G_B5_1 = NULL;
	{
		// if (_zooming)
		bool L_0 = __this->____zooming_15;
		if (!L_0)
		{
			goto IL_0009;
		}
	}
	{
		// return;
		return;
	}

IL_0009:
	{
		// _zooming = true;
		__this->____zooming_15 = (bool)1;
		// _delta = 0f;
		__this->____delta_20 = (0.0f);
		// _mode = mode;
		int32_t L_1 = ___mode0;
		__this->____mode_14 = L_1;
		// TimescaleMode = useUnscaledTime ? TimescaleModes.Unscaled : TimescaleModes.Scaled;
		bool L_2 = ___useUnscaledTime4;
		G_B3_0 = __this;
		if (L_2)
		{
			G_B4_0 = __this;
			goto IL_002a;
		}
	}
	{
		G_B5_0 = 0;
		G_B5_1 = G_B3_0;
		goto IL_002b;
	}

IL_002a:
	{
		G_B5_0 = 1;
		G_B5_1 = G_B4_0;
	}

IL_002b:
	{
		NullCheck(G_B5_1);
		MMCinemachineZoom_set_TimescaleMode_m31C347EEC2E268FA9BC4824C78891EED9796E08F_inline(G_B5_1, G_B5_0, NULL);
		// _startFieldOfView = _virtualCamera.m_Lens.FieldOfView;
		CinemachineVirtualCamera_t7BAD867E24FA315D28917EE318CE7D7258C4CD50* L_3 = __this->____virtualCamera_12;
		NullCheck(L_3);
		LensSettings_t6DAB2F204EC22686BF4397E0871B4875414A84FE* L_4 = (&L_3->___m_Lens_30);
		float L_5 = L_4->___FieldOfView_1;
		__this->____startFieldOfView_16 = L_5;
		// _transitionDuration = transitionDuration;
		float L_6 = ___transitionDuration2;
		__this->____transitionDuration_17 = L_6;
		// _duration = duration;
		float L_7 = ___duration3;
		__this->____duration_18 = L_7;
		// _transitionDuration = transitionDuration;
		float L_8 = ___transitionDuration2;
		__this->____transitionDuration_17 = L_8;
		// _direction = 1;
		__this->____direction_21 = 1;
		// _destinationReached = false;
		__this->____destinationReached_23 = (bool)0;
		int32_t L_9 = ___mode0;
		switch (L_9)
		{
			case 0:
			{
				goto IL_007e;
			}
			case 1:
			{
				goto IL_0087;
			}
			case 2:
			{
				goto IL_0090;
			}
		}
	}
	{
		goto IL_009c;
	}

IL_007e:
	{
		// _targetFieldOfView = newFieldOfView;
		float L_10 = ___newFieldOfView1;
		__this->____targetFieldOfView_19 = L_10;
		// break;
		goto IL_009c;
	}

IL_0087:
	{
		// _targetFieldOfView = newFieldOfView;
		float L_11 = ___newFieldOfView1;
		__this->____targetFieldOfView_19 = L_11;
		// break;
		goto IL_009c;
	}

IL_0090:
	{
		// _targetFieldOfView = _initialFieldOfView;
		float L_12 = __this->____initialFieldOfView_13;
		__this->____targetFieldOfView_19 = L_12;
	}

IL_009c:
	{
		// if (relative)
		bool L_13 = ___relative5;
		if (!L_13)
		{
			goto IL_00b3;
		}
	}
	{
		// _targetFieldOfView += _initialFieldOfView;
		float L_14 = __this->____targetFieldOfView_19;
		float L_15 = __this->____initialFieldOfView_13;
		__this->____targetFieldOfView_19 = ((float)il2cpp_codegen_add(L_14, L_15));
	}

IL_00b3:
	{
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineZoom::TestZoom()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineZoom_TestZoom_m61A06D4F072C05CE4B26C861E00476C64C062752 (MMCinemachineZoom_t270C67D5C8B1AC74F711331A3953C83F4E27E61A* __this, const RuntimeMethod* method) 
{
	{
		// Zoom(TestMode, TestFieldOfView, TestTransitionDuration, TestDuration, false);
		int32_t L_0 = __this->___TestMode_6;
		float L_1 = __this->___TestFieldOfView_7;
		float L_2 = __this->___TestTransitionDuration_8;
		float L_3 = __this->___TestDuration_9;
		VirtualActionInvoker6< int32_t, float, float, float, bool, bool >::Invoke(8 /* System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineZoom::Zoom(MoreMountains.Feedbacks.MMCameraZoomModes,System.Single,System.Single,System.Single,System.Boolean,System.Boolean) */, __this, L_0, L_1, L_2, L_3, (bool)0, (bool)0);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineZoom::OnCameraZoomEvent(MoreMountains.Feedbacks.MMCameraZoomModes,System.Single,System.Single,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineZoom_OnCameraZoomEvent_m2EE19263DC93D53BC51FBE37A39E1F52BAEFF964 (MMCinemachineZoom_t270C67D5C8B1AC74F711331A3953C83F4E27E61A* __this, int32_t ___mode0, float ___newFieldOfView1, float ___transitionDuration2, float ___duration3, int32_t ___channel4, bool ___useUnscaledTime5, bool ___stop6, bool ___relative7, const RuntimeMethod* method) 
{
	{
		// if ((channel != Channel) && (channel != -1) && (Channel != -1))
		int32_t L_0 = ___channel4;
		int32_t L_1 = __this->___Channel_4;
		if ((((int32_t)L_0) == ((int32_t)L_1)))
		{
			goto IL_0019;
		}
	}
	{
		int32_t L_2 = ___channel4;
		if ((((int32_t)L_2) == ((int32_t)(-1))))
		{
			goto IL_0019;
		}
	}
	{
		int32_t L_3 = __this->___Channel_4;
		if ((((int32_t)L_3) == ((int32_t)(-1))))
		{
			goto IL_0019;
		}
	}
	{
		// return;
		return;
	}

IL_0019:
	{
		// if (stop)
		bool L_4 = ___stop6;
		if (!L_4)
		{
			goto IL_0025;
		}
	}
	{
		// _zooming = false;
		__this->____zooming_15 = (bool)0;
		// return;
		return;
	}

IL_0025:
	{
		// this.Zoom(mode, newFieldOfView, transitionDuration, duration, useUnscaledTime, relative);
		int32_t L_5 = ___mode0;
		float L_6 = ___newFieldOfView1;
		float L_7 = ___transitionDuration2;
		float L_8 = ___duration3;
		bool L_9 = ___useUnscaledTime5;
		bool L_10 = ___relative7;
		VirtualActionInvoker6< int32_t, float, float, float, bool, bool >::Invoke(8 /* System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineZoom::Zoom(MoreMountains.Feedbacks.MMCameraZoomModes,System.Single,System.Single,System.Single,System.Boolean,System.Boolean) */, __this, L_5, L_6, L_7, L_8, L_9, L_10);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineZoom::OnEnable()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineZoom_OnEnable_m3E204719867DD4CA406653C044C2B243495FE778 (MMCinemachineZoom_t270C67D5C8B1AC74F711331A3953C83F4E27E61A* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Delegate_tA4CF453D6F49220E972ED8A4794892E9E1017260_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// MMCameraZoomEvent.Register(OnCameraZoomEvent);
		Delegate_tA4CF453D6F49220E972ED8A4794892E9E1017260* L_0 = (Delegate_tA4CF453D6F49220E972ED8A4794892E9E1017260*)il2cpp_codegen_object_new(Delegate_tA4CF453D6F49220E972ED8A4794892E9E1017260_il2cpp_TypeInfo_var);
		NullCheck(L_0);
		Delegate__ctor_m8D1004BCEFC6D845CBCB8EA17EF4FDBB819D808C(L_0, __this, (intptr_t)((void*)GetVirtualMethodInfo(__this, 10)), NULL);
		MMCameraZoomEvent_Register_m3BA025FD8AB4CDCE718D0FEEAB365B0E49EE94A0(L_0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineZoom::OnDisable()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineZoom_OnDisable_m61F1170B65770EA68D258283A4B3E3682638F3A3 (MMCinemachineZoom_t270C67D5C8B1AC74F711331A3953C83F4E27E61A* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Delegate_tA4CF453D6F49220E972ED8A4794892E9E1017260_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// MMCameraZoomEvent.Unregister(OnCameraZoomEvent);
		Delegate_tA4CF453D6F49220E972ED8A4794892E9E1017260* L_0 = (Delegate_tA4CF453D6F49220E972ED8A4794892E9E1017260*)il2cpp_codegen_object_new(Delegate_tA4CF453D6F49220E972ED8A4794892E9E1017260_il2cpp_TypeInfo_var);
		NullCheck(L_0);
		Delegate__ctor_m8D1004BCEFC6D845CBCB8EA17EF4FDBB819D808C(L_0, __this, (intptr_t)((void*)GetVirtualMethodInfo(__this, 10)), NULL);
		MMCameraZoomEvent_Unregister_m4A7B1DFA4E416AE9FEFD017466C03E5B18B1EF45(L_0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMCinemachineZoom::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMCinemachineZoom__ctor_mCD282CB742CD8C0EEB795BDB354D7AEBDA89C946 (MMCinemachineZoom_t270C67D5C8B1AC74F711331A3953C83F4E27E61A* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public AnimationCurve ZoomCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f));
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_0 = (KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3*)(KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3*)SZArrayNew(KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var, (uint32_t)2);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_1 = L_0;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_2;
		memset((&L_2), 0, sizeof(L_2));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_2), (0.0f), (0.0f), /*hidden argument*/NULL);
		NullCheck(L_1);
		(L_1)->SetAt(static_cast<il2cpp_array_size_t>(0), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_2);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_3 = L_1;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_4;
		memset((&L_4), 0, sizeof(L_4));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_4), (1.0f), (1.0f), /*hidden argument*/NULL);
		NullCheck(L_3);
		(L_3)->SetAt(static_cast<il2cpp_array_size_t>(1), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_4);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_5 = (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*)il2cpp_codegen_object_new(AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		NullCheck(L_5);
		AnimationCurve__ctor_mEABC98C03805713354D61E50D9340766BD5B717E(L_5, L_3, NULL);
		__this->___ZoomCurve_5 = L_5;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ZoomCurve_5), (void*)L_5);
		// public float TestFieldOfView = 30f;
		__this->___TestFieldOfView_7 = (30.0f);
		// public float TestTransitionDuration = 0.1f;
		__this->___TestTransitionDuration_8 = (0.100000001f);
		// public float TestDuration = 0.05f;
		__this->___TestDuration_9 = (0.0500000007f);
		// protected int _direction = 1;
		__this->____direction_21 = 1;
		MonoBehaviour__ctor_m592DB0105CA0BC97AA1C5F4AD27B12D68A3B7C1E(__this, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_op_Multiply_m87BA7C578F96C8E49BB07088DAAC4649F83B0353_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___a0, float ___d1, const RuntimeMethod* method) 
{
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = ___a0;
		float L_1 = L_0.___x_2;
		float L_2 = ___d1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_3 = ___a0;
		float L_4 = L_3.___y_3;
		float L_5 = ___d1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_6 = ___a0;
		float L_7 = L_6.___z_4;
		float L_8 = ___d1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_9;
		memset((&L_9), 0, sizeof(L_9));
		Vector3__ctor_m376936E6B999EF1ECBE57D990A386303E2283DE0_inline((&L_9), ((float)il2cpp_codegen_multiply(L_1, L_2)), ((float)il2cpp_codegen_multiply(L_4, L_5)), ((float)il2cpp_codegen_multiply(L_7, L_8)), /*hidden argument*/NULL);
		V_0 = L_9;
		goto IL_0021;
	}

IL_0021:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_10 = V_0;
		return L_10;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void CinemachineVirtualCameraBase_set_Priority_m233ED0376CE0BD1244CCA52DF4532C8988DC05AC_inline (CinemachineVirtualCameraBase_tAD070AA799E9D3990F0B2DA9AC5889CF138261DE* __this, int32_t ___value0, const RuntimeMethod* method) 
{
	{
		// set => m_Priority = value;
		int32_t L_0 = ___value0;
		__this->___m_Priority_9 = L_0;
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Vector3__ctor_m376936E6B999EF1ECBE57D990A386303E2283DE0_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* __this, float ___x0, float ___y1, float ___z2, const RuntimeMethod* method) 
{
	{
		float L_0 = ___x0;
		__this->___x_2 = L_0;
		float L_1 = ___y1;
		__this->___y_3 = L_1;
		float L_2 = ___z2;
		__this->___z_4 = L_2;
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Mathf_Lerp_m47EF2FFB7647BD0A1FDC26DC03E28B19812139B5_inline (float ___a0, float ___b1, float ___t2, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	{
		float L_0 = ___a0;
		float L_1 = ___b1;
		float L_2 = ___a0;
		float L_3 = ___t2;
		float L_4;
		L_4 = Mathf_Clamp01_mA7E048DBDA832D399A581BE4D6DED9FA44CE0F14_inline(L_3, NULL);
		V_0 = ((float)il2cpp_codegen_add(L_0, ((float)il2cpp_codegen_multiply(((float)il2cpp_codegen_subtract(L_1, L_2)), L_4))));
		goto IL_0010;
	}

IL_0010:
	{
		float L_5 = V_0;
		return L_5;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Mathf_LerpUnclamped_mF35042F9D25A221BDD4B3FD6251224610AFC1F35_inline (float ___a0, float ___b1, float ___t2, const RuntimeMethod* method) 
{
	float V_0 = 0.0f;
	{
		float L_0 = ___a0;
		float L_1 = ___b1;
		float L_2 = ___a0;
		float L_3 = ___t2;
		V_0 = ((float)il2cpp_codegen_add(L_0, ((float)il2cpp_codegen_multiply(((float)il2cpp_codegen_subtract(L_1, L_2)), L_3))));
		goto IL_000b;
	}

IL_000b:
	{
		float L_4 = V_0;
		return L_4;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Delegate_Invoke_m522A97EE33632F1AA72205CB61AB7258FE91C19D_inline (Delegate_tCFB2DEC2BDD896115C5E195E37FA1C71102C549D* __this, int32_t ___channel0, bool ___forceMaxPriority1, int32_t ___newPriority2, bool ___forceTransition3, CinemachineBlendDefinition_t6A16D5B51D440E317D413EC8612647EDA0A6580B ___blendDefinition4, bool ___resetValuesAfterTransition5, int32_t ___timescaleMode6, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, int32_t, bool, int32_t, bool, CinemachineBlendDefinition_t6A16D5B51D440E317D413EC8612647EDA0A6580B, bool, int32_t, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___channel0, ___forceMaxPriority1, ___newPriority2, ___forceTransition3, ___blendDefinition4, ___resetValuesAfterTransition5, ___timescaleMode6, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t MMCinemachineZoom_get_TimescaleMode_m011368B7AAC7340E11480854F9FCF8DF02DCDF14_inline (MMCinemachineZoom_t270C67D5C8B1AC74F711331A3953C83F4E27E61A* __this, const RuntimeMethod* method) 
{
	{
		// public TimescaleModes TimescaleMode { get; set; }
		int32_t L_0 = __this->___U3CTimescaleModeU3Ek__BackingField_11;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void MMCinemachineZoom_set_TimescaleMode_m31C347EEC2E268FA9BC4824C78891EED9796E08F_inline (MMCinemachineZoom_t270C67D5C8B1AC74F711331A3953C83F4E27E61A* __this, int32_t ___value0, const RuntimeMethod* method) 
{
	{
		// public TimescaleModes TimescaleMode { get; set; }
		int32_t L_0 = ___value0;
		__this->___U3CTimescaleModeU3Ek__BackingField_11 = L_0;
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float Mathf_Clamp01_mA7E048DBDA832D399A581BE4D6DED9FA44CE0F14_inline (float ___value0, const RuntimeMethod* method) 
{
	bool V_0 = false;
	float V_1 = 0.0f;
	bool V_2 = false;
	{
		float L_0 = ___value0;
		V_0 = (bool)((((float)L_0) < ((float)(0.0f)))? 1 : 0);
		bool L_1 = V_0;
		if (!L_1)
		{
			goto IL_0015;
		}
	}
	{
		V_1 = (0.0f);
		goto IL_002d;
	}

IL_0015:
	{
		float L_2 = ___value0;
		V_2 = (bool)((((float)L_2) > ((float)(1.0f)))? 1 : 0);
		bool L_3 = V_2;
		if (!L_3)
		{
			goto IL_0029;
		}
	}
	{
		V_1 = (1.0f);
		goto IL_002d;
	}

IL_0029:
	{
		float L_4 = ___value0;
		V_1 = L_4;
		goto IL_002d;
	}

IL_002d:
	{
		float L_5 = V_1;
		return L_5;
	}
}
