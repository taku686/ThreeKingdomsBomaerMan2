#include "pch-cpp.hpp"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <limits>
#include <stdint.h>


template <typename T1, typename T2, typename T3, typename T4, typename T5, typename T6, typename T7, typename T8, typename T9, typename T10, typename T11>
struct VirtualActionInvoker11
{
	typedef void (*Action)(void*, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		((Action)invokeData.methodPtr)(obj, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, invokeData.method);
	}
};
template <typename T1, typename T2, typename T3, typename T4, typename T5, typename T6, typename T7, typename T8, typename T9, typename T10, typename T11, typename T12, typename T13, typename T14>
struct VirtualActionInvoker14
{
	typedef void (*Action)(void*, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		((Action)invokeData.methodPtr)(obj, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, invokeData.method);
	}
};
template <typename T1, typename T2, typename T3, typename T4, typename T5, typename T6, typename T7, typename T8, typename T9, typename T10, typename T11, typename T12, typename T13, typename T14, typename T15, typename T16, typename T17>
struct VirtualActionInvoker17
{
	typedef void (*Action)(void*, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15, T16 p16, T17 p17)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		((Action)invokeData.methodPtr)(obj, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, invokeData.method);
	}
};
template <typename T1, typename T2, typename T3, typename T4, typename T5, typename T6, typename T7, typename T8, typename T9, typename T10, typename T11, typename T12, typename T13, typename T14, typename T15, typename T16, typename T17, typename T18, typename T19, typename T20, typename T21, typename T22, typename T23, typename T24>
struct VirtualActionInvoker24
{
	typedef void (*Action)(void*, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15, T16 p16, T17 p17, T18 p18, T19 p19, T20 p20, T21 p21, T22 p22, T23 p23, T24 p24)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		((Action)invokeData.methodPtr)(obj, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, p18, p19, p20, p21, p22, p23, p24, invokeData.method);
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
template <typename T1, typename T2, typename T3, typename T4, typename T5, typename T6, typename T7, typename T8, typename T9, typename T10, typename T11>
struct GenericVirtualActionInvoker11
{
	typedef void (*Action)(void*, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, const RuntimeMethod*);

	static inline void Invoke (const RuntimeMethod* method, RuntimeObject* obj, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_virtual_invoke_data(method, obj, &invokeData);
		((Action)invokeData.methodPtr)(obj, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, invokeData.method);
	}
};
template <typename T1, typename T2, typename T3, typename T4, typename T5, typename T6, typename T7, typename T8, typename T9, typename T10, typename T11, typename T12, typename T13, typename T14>
struct GenericVirtualActionInvoker14
{
	typedef void (*Action)(void*, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, const RuntimeMethod*);

	static inline void Invoke (const RuntimeMethod* method, RuntimeObject* obj, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_virtual_invoke_data(method, obj, &invokeData);
		((Action)invokeData.methodPtr)(obj, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, invokeData.method);
	}
};
template <typename T1, typename T2, typename T3, typename T4, typename T5, typename T6, typename T7, typename T8, typename T9, typename T10, typename T11, typename T12, typename T13, typename T14, typename T15, typename T16, typename T17>
struct GenericVirtualActionInvoker17
{
	typedef void (*Action)(void*, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, const RuntimeMethod*);

	static inline void Invoke (const RuntimeMethod* method, RuntimeObject* obj, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15, T16 p16, T17 p17)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_virtual_invoke_data(method, obj, &invokeData);
		((Action)invokeData.methodPtr)(obj, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, invokeData.method);
	}
};
template <typename T1, typename T2, typename T3, typename T4, typename T5, typename T6, typename T7, typename T8, typename T9, typename T10, typename T11, typename T12, typename T13, typename T14, typename T15, typename T16, typename T17, typename T18, typename T19, typename T20, typename T21, typename T22, typename T23, typename T24>
struct GenericVirtualActionInvoker24
{
	typedef void (*Action)(void*, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, const RuntimeMethod*);

	static inline void Invoke (const RuntimeMethod* method, RuntimeObject* obj, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15, T16 p16, T17 p17, T18 p18, T19 p19, T20 p20, T21 p21, T22 p22, T23 p23, T24 p24)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_virtual_invoke_data(method, obj, &invokeData);
		((Action)invokeData.methodPtr)(obj, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, p18, p19, p20, p21, p22, p23, p24, invokeData.method);
	}
};
template <typename T1, typename T2, typename T3, typename T4, typename T5, typename T6, typename T7, typename T8, typename T9, typename T10, typename T11>
struct InterfaceActionInvoker11
{
	typedef void (*Action)(void*, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		((Action)invokeData.methodPtr)(obj, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, invokeData.method);
	}
};
template <typename T1, typename T2, typename T3, typename T4, typename T5, typename T6, typename T7, typename T8, typename T9, typename T10, typename T11, typename T12, typename T13, typename T14>
struct InterfaceActionInvoker14
{
	typedef void (*Action)(void*, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		((Action)invokeData.methodPtr)(obj, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, invokeData.method);
	}
};
template <typename T1, typename T2, typename T3, typename T4, typename T5, typename T6, typename T7, typename T8, typename T9, typename T10, typename T11, typename T12, typename T13, typename T14, typename T15, typename T16, typename T17>
struct InterfaceActionInvoker17
{
	typedef void (*Action)(void*, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15, T16 p16, T17 p17)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		((Action)invokeData.methodPtr)(obj, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, invokeData.method);
	}
};
template <typename T1, typename T2, typename T3, typename T4, typename T5, typename T6, typename T7, typename T8, typename T9, typename T10, typename T11, typename T12, typename T13, typename T14, typename T15, typename T16, typename T17, typename T18, typename T19, typename T20, typename T21, typename T22, typename T23, typename T24>
struct InterfaceActionInvoker24
{
	typedef void (*Action)(void*, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15, T16 p16, T17 p17, T18 p18, T19 p19, T20 p20, T21 p21, T22 p22, T23 p23, T24 p24)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		((Action)invokeData.methodPtr)(obj, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, p18, p19, p20, p21, p22, p23, p24, invokeData.method);
	}
};
template <typename T1, typename T2, typename T3, typename T4, typename T5, typename T6, typename T7, typename T8, typename T9, typename T10, typename T11>
struct GenericInterfaceActionInvoker11
{
	typedef void (*Action)(void*, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, const RuntimeMethod*);

	static inline void Invoke (const RuntimeMethod* method, RuntimeObject* obj, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_interface_invoke_data(method, obj, &invokeData);
		((Action)invokeData.methodPtr)(obj, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, invokeData.method);
	}
};
template <typename T1, typename T2, typename T3, typename T4, typename T5, typename T6, typename T7, typename T8, typename T9, typename T10, typename T11, typename T12, typename T13, typename T14>
struct GenericInterfaceActionInvoker14
{
	typedef void (*Action)(void*, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, const RuntimeMethod*);

	static inline void Invoke (const RuntimeMethod* method, RuntimeObject* obj, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_interface_invoke_data(method, obj, &invokeData);
		((Action)invokeData.methodPtr)(obj, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, invokeData.method);
	}
};
template <typename T1, typename T2, typename T3, typename T4, typename T5, typename T6, typename T7, typename T8, typename T9, typename T10, typename T11, typename T12, typename T13, typename T14, typename T15, typename T16, typename T17>
struct GenericInterfaceActionInvoker17
{
	typedef void (*Action)(void*, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, const RuntimeMethod*);

	static inline void Invoke (const RuntimeMethod* method, RuntimeObject* obj, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15, T16 p16, T17 p17)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_interface_invoke_data(method, obj, &invokeData);
		((Action)invokeData.methodPtr)(obj, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, invokeData.method);
	}
};
template <typename T1, typename T2, typename T3, typename T4, typename T5, typename T6, typename T7, typename T8, typename T9, typename T10, typename T11, typename T12, typename T13, typename T14, typename T15, typename T16, typename T17, typename T18, typename T19, typename T20, typename T21, typename T22, typename T23, typename T24>
struct GenericInterfaceActionInvoker24
{
	typedef void (*Action)(void*, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, const RuntimeMethod*);

	static inline void Invoke (const RuntimeMethod* method, RuntimeObject* obj, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15, T16 p16, T17 p17, T18 p18, T19 p19, T20 p20, T21 p21, T22 p22, T23 p23, T24 p24)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_interface_invoke_data(method, obj, &invokeData);
		((Action)invokeData.methodPtr)(obj, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, p18, p19, p20, p21, p22, p23, p24, invokeData.method);
	}
};
template <typename T1, typename T2, typename T3, typename T4, typename T5, typename T6, typename T7, typename T8, typename T9, typename T10, typename T11, typename T12>
struct InvokerActionInvoker12;
template <typename T1, typename T2, typename T3, typename T4, typename T5, typename T6, typename T7, typename T8, typename T9, typename T10, typename T11, typename T12>
struct InvokerActionInvoker12<T1*, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
{
	static inline void Invoke (Il2CppMethodPointer methodPtr, const RuntimeMethod* method, void* obj, T1* p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12)
	{
		void* params[12] = { p1, &p2, &p3, &p4, &p5, &p6, &p7, &p8, &p9, &p10, &p11, &p12 };
		method->invoker_method(methodPtr, method, obj, params, NULL);
	}
};
template <typename T1, typename T2, typename T3, typename T4, typename T5, typename T6, typename T7, typename T8, typename T9, typename T10, typename T11, typename T12, typename T13>
struct InvokerActionInvoker13;
template <typename T1, typename T2, typename T3, typename T4, typename T5, typename T6, typename T7, typename T8, typename T9, typename T10, typename T11, typename T12, typename T13>
struct InvokerActionInvoker13<T1*, T2*, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
{
	static inline void Invoke (Il2CppMethodPointer methodPtr, const RuntimeMethod* method, void* obj, T1* p1, T2* p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13)
	{
		void* params[13] = { p1, p2, &p3, &p4, &p5, &p6, &p7, &p8, &p9, &p10, &p11, &p12, &p13 };
		method->invoker_method(methodPtr, method, obj, params, NULL);
	}
};
template <typename T1, typename T2, typename T3, typename T4, typename T5, typename T6, typename T7, typename T8, typename T9, typename T10, typename T11, typename T12, typename T13, typename T14, typename T15>
struct InvokerActionInvoker15;
template <typename T1, typename T2, typename T3, typename T4, typename T5, typename T6, typename T7, typename T8, typename T9, typename T10, typename T11, typename T12, typename T13, typename T14, typename T15>
struct InvokerActionInvoker15<T1*, T2, T3, T4, T5*, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>
{
	static inline void Invoke (Il2CppMethodPointer methodPtr, const RuntimeMethod* method, void* obj, T1* p1, T2 p2, T3 p3, T4 p4, T5* p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15)
	{
		void* params[15] = { p1, &p2, &p3, &p4, p5, &p6, &p7, &p8, &p9, &p10, &p11, &p12, &p13, &p14, &p15 };
		method->invoker_method(methodPtr, method, obj, params, NULL);
	}
};
template <typename T1, typename T2, typename T3, typename T4, typename T5, typename T6, typename T7, typename T8, typename T9, typename T10, typename T11, typename T12, typename T13, typename T14, typename T15, typename T16>
struct InvokerActionInvoker16;
template <typename T1, typename T2, typename T3, typename T4, typename T5, typename T6, typename T7, typename T8, typename T9, typename T10, typename T11, typename T12, typename T13, typename T14, typename T15, typename T16>
struct InvokerActionInvoker16<T1*, T2*, T3, T4, T5, T6*, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
{
	static inline void Invoke (Il2CppMethodPointer methodPtr, const RuntimeMethod* method, void* obj, T1* p1, T2* p2, T3 p3, T4 p4, T5 p5, T6* p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15, T16 p16)
	{
		void* params[16] = { p1, p2, &p3, &p4, &p5, p6, &p7, &p8, &p9, &p10, &p11, &p12, &p13, &p14, &p15, &p16 };
		method->invoker_method(methodPtr, method, obj, params, NULL);
	}
};
template <typename T1, typename T2, typename T3, typename T4, typename T5, typename T6, typename T7, typename T8, typename T9, typename T10, typename T11, typename T12, typename T13, typename T14, typename T15, typename T16, typename T17, typename T18>
struct InvokerActionInvoker18;
template <typename T1, typename T2, typename T3, typename T4, typename T5, typename T6, typename T7, typename T8, typename T9, typename T10, typename T11, typename T12, typename T13, typename T14, typename T15, typename T16, typename T17, typename T18>
struct InvokerActionInvoker18<T1*, T2, T3, T4*, T5, T6, T7*, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>
{
	static inline void Invoke (Il2CppMethodPointer methodPtr, const RuntimeMethod* method, void* obj, T1* p1, T2 p2, T3 p3, T4* p4, T5 p5, T6 p6, T7* p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15, T16 p16, T17 p17, T18 p18)
	{
		void* params[18] = { p1, &p2, &p3, p4, &p5, &p6, p7, &p8, &p9, &p10, &p11, &p12, &p13, &p14, &p15, &p16, &p17, &p18 };
		method->invoker_method(methodPtr, method, obj, params, NULL);
	}
};
template <typename T1, typename T2, typename T3, typename T4, typename T5, typename T6, typename T7, typename T8, typename T9, typename T10, typename T11, typename T12, typename T13, typename T14, typename T15, typename T16, typename T17, typename T18, typename T19>
struct InvokerActionInvoker19;
template <typename T1, typename T2, typename T3, typename T4, typename T5, typename T6, typename T7, typename T8, typename T9, typename T10, typename T11, typename T12, typename T13, typename T14, typename T15, typename T16, typename T17, typename T18, typename T19>
struct InvokerActionInvoker19<T1*, T2*, T3, T4, T5*, T6, T7, T8*, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>
{
	static inline void Invoke (Il2CppMethodPointer methodPtr, const RuntimeMethod* method, void* obj, T1* p1, T2* p2, T3 p3, T4 p4, T5* p5, T6 p6, T7 p7, T8* p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15, T16 p16, T17 p17, T18 p18, T19 p19)
	{
		void* params[19] = { p1, p2, &p3, &p4, p5, &p6, &p7, p8, &p9, &p10, &p11, &p12, &p13, &p14, &p15, &p16, &p17, &p18, &p19 };
		method->invoker_method(methodPtr, method, obj, params, NULL);
	}
};
template <typename T1, typename T2, typename T3, typename T4, typename T5, typename T6, typename T7, typename T8, typename T9, typename T10, typename T11, typename T12, typename T13, typename T14, typename T15, typename T16, typename T17, typename T18, typename T19, typename T20, typename T21, typename T22, typename T23, typename T24, typename T25>
struct InvokerActionInvoker25;
template <typename T1, typename T2, typename T3, typename T4, typename T5, typename T6, typename T7, typename T8, typename T9, typename T10, typename T11, typename T12, typename T13, typename T14, typename T15, typename T16, typename T17, typename T18, typename T19, typename T20, typename T21, typename T22, typename T23, typename T24, typename T25>
struct InvokerActionInvoker25<T1*, T2, T3, T4*, T5, T6, T7*, T8, T9, T10*, T11, T12, T13, T14*, T15, T16*, T17, T18, T19, T20, T21, T22, T23, T24, T25>
{
	static inline void Invoke (Il2CppMethodPointer methodPtr, const RuntimeMethod* method, void* obj, T1* p1, T2 p2, T3 p3, T4* p4, T5 p5, T6 p6, T7* p7, T8 p8, T9 p9, T10* p10, T11 p11, T12 p12, T13 p13, T14* p14, T15 p15, T16* p16, T17 p17, T18 p18, T19 p19, T20 p20, T21 p21, T22 p22, T23 p23, T24 p24, T25 p25)
	{
		void* params[25] = { p1, &p2, &p3, p4, &p5, &p6, p7, &p8, &p9, p10, &p11, &p12, &p13, p14, &p15, p16, &p17, &p18, &p19, &p20, &p21, &p22, &p23, &p24, &p25 };
		method->invoker_method(methodPtr, method, obj, params, NULL);
	}
};
template <typename T1, typename T2, typename T3, typename T4, typename T5, typename T6, typename T7, typename T8, typename T9, typename T10, typename T11, typename T12, typename T13, typename T14, typename T15, typename T16, typename T17, typename T18, typename T19, typename T20, typename T21, typename T22, typename T23, typename T24, typename T25, typename T26>
struct InvokerActionInvoker26;
template <typename T1, typename T2, typename T3, typename T4, typename T5, typename T6, typename T7, typename T8, typename T9, typename T10, typename T11, typename T12, typename T13, typename T14, typename T15, typename T16, typename T17, typename T18, typename T19, typename T20, typename T21, typename T22, typename T23, typename T24, typename T25, typename T26>
struct InvokerActionInvoker26<T1*, T2*, T3, T4, T5*, T6, T7, T8*, T9, T10, T11*, T12, T13, T14, T15*, T16, T17*, T18, T19, T20, T21, T22, T23, T24, T25, T26>
{
	static inline void Invoke (Il2CppMethodPointer methodPtr, const RuntimeMethod* method, void* obj, T1* p1, T2* p2, T3 p3, T4 p4, T5* p5, T6 p6, T7 p7, T8* p8, T9 p9, T10 p10, T11* p11, T12 p12, T13 p13, T14 p14, T15* p15, T16 p16, T17* p17, T18 p18, T19 p19, T20 p20, T21 p21, T22 p22, T23 p23, T24 p24, T25 p25, T26 p26)
	{
		void* params[26] = { p1, p2, &p3, &p4, p5, &p6, &p7, p8, &p9, &p10, p11, &p12, &p13, &p14, p15, &p16, p17, &p18, &p19, &p20, &p21, &p22, &p23, &p24, &p25, &p26 };
		method->invoker_method(methodPtr, method, obj, params, NULL);
	}
};

// System.Delegate[]
struct DelegateU5BU5D_tC5AB7E8F745616680F337909D3A8E6C722CDF771;
// UnityEngine.Keyframe[]
struct KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3;
// UnityEngine.AnimationCurve
struct AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354;
// System.AsyncCallback
struct AsyncCallback_t7FEF460CBDCFB9C5FA2EF776984778B9A4145F4C;
// UnityEngine.Coroutine
struct Coroutine_t85EA685566A254C23F3FD77AB5BDFFFF8799596B;
// System.Delegate
struct Delegate_t;
// System.DelegateData
struct DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E;
// UnityEngine.GameObject
struct GameObject_t76FEDD663AB33C991A9C9A23129337651094216F;
// UnityEngine.Gradient
struct Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E;
// System.IAsyncResult
struct IAsyncResult_t7B9B5A0ECB35DCEC31B8A8122C37D687369253B5;
// MoreMountains.FeedbacksForThirdParty.MMBloomShaker_HDRP
struct MMBloomShaker_HDRP_tD2D9A71961AFE4E5FFFDAD5E37B7DB19DD990CA8;
// MoreMountains.FeedbacksForThirdParty.MMChannelMixerShaker_HDRP
struct MMChannelMixerShaker_HDRP_t78DBC564D348F7D72193C967D7866E87F57079FE;
// MoreMountains.FeedbacksForThirdParty.MMChromaticAberrationShaker_HDRP
struct MMChromaticAberrationShaker_HDRP_t472F090F0A238CD24FFB7783BEFAE79680D74ECD;
// MoreMountains.FeedbacksForThirdParty.MMColorAdjustmentsShaker_HDRP
struct MMColorAdjustmentsShaker_HDRP_t9171C6E1A7365800B6688933DC93F11BC338793A;
// MoreMountains.FeedbacksForThirdParty.MMExposureShaker_HDRP
struct MMExposureShaker_HDRP_t178AB71E45D967A121DFA78C5761DC7F02CC94BD;
// MoreMountains.FeedbacksForThirdParty.MMF_Bloom_HDRP
struct MMF_Bloom_HDRP_t583E4BC36988860792A3694FAAA4ACB4A61AEE8C;
// MoreMountains.FeedbacksForThirdParty.MMF_ChannelMixer_HDRP
struct MMF_ChannelMixer_HDRP_tC2DC756B34F42806D3167C44141414379772DB24;
// MoreMountains.FeedbacksForThirdParty.MMF_ChromaticAberration_HDRP
struct MMF_ChromaticAberration_HDRP_tD7D36DC2674B8207EBCFCFAEF6EAEF7D13520240;
// MoreMountains.FeedbacksForThirdParty.MMF_ColorAdjustments_HDRP
struct MMF_ColorAdjustments_HDRP_t70D2A2F27CA819A0F1E7CE7996B7A17AEFDB124B;
// MoreMountains.FeedbacksForThirdParty.MMF_Exposure_HDRP
struct MMF_Exposure_HDRP_tD40DE5A57861581BA0D7198465A6683F481AC412;
// MoreMountains.Feedbacks.MMF_Feedback
struct MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D;
// MoreMountains.FeedbacksForThirdParty.MMF_FilmGrain_HDRP
struct MMF_FilmGrain_HDRP_tD693F1E63ABEEF2285669284914A08CE5C6E06DC;
// MoreMountains.FeedbacksForThirdParty.MMF_LensDistortion_HDRP
struct MMF_LensDistortion_HDRP_t1CBCDEC25ED40B9644C9104EE2EF9E7F76EA0823;
// MoreMountains.FeedbacksForThirdParty.MMF_MotionBlur_HDRP
struct MMF_MotionBlur_HDRP_tF0EE4FD8B93630B1A5AFE3686B359264F68FB63F;
// MoreMountains.FeedbacksForThirdParty.MMF_PaniniProjection_HDRP
struct MMF_PaniniProjection_HDRP_tDDC11106E1AD99645085221E893B9A46C02C8B40;
// MoreMountains.Feedbacks.MMF_Player
struct MMF_Player_t93550CF1D39E682D9FF480A11FF0138923CBAE6C;
// MoreMountains.FeedbacksForThirdParty.MMF_Vignette_HDRP
struct MMF_Vignette_HDRP_t433C1F57FA003E5F6BFF1409F73E44528F35C229;
// MoreMountains.FeedbacksForThirdParty.MMF_WhiteBalance_HDRP
struct MMF_WhiteBalance_HDRP_t37FAFEF0B791B3E1EE7863DD1CAE220CC225606A;
// MoreMountains.Feedbacks.MMFeedback
struct MMFeedback_tE51A2F7A01B1E3BE46047E5A0D6BA5C79199FDCA;
// MoreMountains.FeedbacksForThirdParty.MMFeedbackBloom_HDRP
struct MMFeedbackBloom_HDRP_t0BF688EBD458BA2F7F0E5834DBC5E2011CD66174;
// MoreMountains.FeedbacksForThirdParty.MMFeedbackChannelMixer_HDRP
struct MMFeedbackChannelMixer_HDRP_tFC9637D2DBA8B0F6CE6D58226C992B5CD30B0680;
// MoreMountains.FeedbacksForThirdParty.MMFeedbackChromaticAberration_HDRP
struct MMFeedbackChromaticAberration_HDRP_t2F1C669FEDB2F3DD0732EF9B63569FB42EB25929;
// MoreMountains.FeedbacksForThirdParty.MMFeedbackColorAdjustments_HDRP
struct MMFeedbackColorAdjustments_HDRP_t99AF449C9842B06883E26C14553A117A6EA0D216;
// MoreMountains.FeedbacksForThirdParty.MMFeedbackExposure_HDRP
struct MMFeedbackExposure_HDRP_t7D28A8ECA50B6411205FF1E72D45E78055A36395;
// MoreMountains.FeedbacksForThirdParty.MMFeedbackFilmGrain_HDRP
struct MMFeedbackFilmGrain_HDRP_tA820A4A0D3AF519A8B4AF875A1CD16A7AC494503;
// MoreMountains.FeedbacksForThirdParty.MMFeedbackLensDistortion_HDRP
struct MMFeedbackLensDistortion_HDRP_tCC834E1D0D5B6F46A8F512F480B8A9952D662380;
// MoreMountains.FeedbacksForThirdParty.MMFeedbackMotionBlur_HDRP
struct MMFeedbackMotionBlur_HDRP_t726897213A8066AA7377F6281608B75D9E5B6410;
// MoreMountains.FeedbacksForThirdParty.MMFeedbackPaniniProjection_HDRP
struct MMFeedbackPaniniProjection_HDRP_tE2401287FF42E493F48B927B259C4A9EA85B2536;
// MoreMountains.Feedbacks.MMFeedbackTiming
struct MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD;
// MoreMountains.FeedbacksForThirdParty.MMFeedbackVignette_HDRP
struct MMFeedbackVignette_HDRP_tBB217D0E1DDEA10E932AB75E962FBB1EC382342A;
// MoreMountains.FeedbacksForThirdParty.MMFeedbackWhiteBalance_HDRP
struct MMFeedbackWhiteBalance_HDRP_t4D7756DFBD852A605B201C0F63F472455C03E48E;
// MoreMountains.Feedbacks.MMFeedbacks
struct MMFeedbacks_t38A4A1D812AE5F7C3C3033318C408D55AE462AD6;
// MoreMountains.FeedbacksForThirdParty.MMFilmGrainShaker_HDRP
struct MMFilmGrainShaker_HDRP_t642417F8C9001ECE6687F790C023D752011D9BC9;
// MoreMountains.FeedbacksForThirdParty.MMLensDistortionShaker_HDRP
struct MMLensDistortionShaker_HDRP_t0B49054863BD3B0C6DEBFDCD95FD027FC66E31A4;
// MoreMountains.FeedbacksForThirdParty.MMMotionBlurShaker_HDRP
struct MMMotionBlurShaker_HDRP_t2143D5FAF199B1BF22C56DC7A080A2A0BA6AEC3A;
// MoreMountains.FeedbacksForThirdParty.MMPaniniProjectionShaker_HDRP
struct MMPaniniProjectionShaker_HDRP_t8AD69F4068D255EDE69BA9597B9EAF1AB4641054;
// MoreMountains.Feedbacks.MMSequence
struct MMSequence_t10D0481DC725D195973AC5C741491AD1E69EA20C;
// MoreMountains.Feedbacks.MMShaker
struct MMShaker_t48AAF716B7D3FC0C6FB15A32772D7DF0D57FCC31;
// MoreMountains.FeedbacksForThirdParty.MMVignetteShaker_HDRP
struct MMVignetteShaker_HDRP_t210D4D7C056D8ECE4C934F3A13B817FA2EEDB376;
// MoreMountains.FeedbacksForThirdParty.MMWhiteBalanceShaker_HDRP
struct MMWhiteBalanceShaker_HDRP_t65113CD3FFAFC79CAE06093A6D758FB158F20A63;
// System.Reflection.MethodInfo
struct MethodInfo_t;
// System.String
struct String_t;
// System.Void
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915;
// MoreMountains.FeedbacksForThirdParty.MMBloomShakeEvent_HDRP/Delegate
struct Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8;
// MoreMountains.FeedbacksForThirdParty.MMChannelMixerShakeEvent_HDRP/Delegate
struct Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176;
// MoreMountains.FeedbacksForThirdParty.MMChromaticAberrationShakeEvent_HDRP/Delegate
struct Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2;
// MoreMountains.FeedbacksForThirdParty.MMColorAdjustmentsShakeEvent_HDRP/Delegate
struct Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19;
// MoreMountains.FeedbacksForThirdParty.MMExposureShakeEvent_HDRP/Delegate
struct Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0;
// MoreMountains.FeedbacksForThirdParty.MMFilmGrainShakeEvent_HDRP/Delegate
struct Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15;
// MoreMountains.FeedbacksForThirdParty.MMLensDistortionShakeEvent_HDRP/Delegate
struct Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994;
// MoreMountains.FeedbacksForThirdParty.MMMotionBlurShakeEvent_HDRP/Delegate
struct Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8;
// MoreMountains.FeedbacksForThirdParty.MMPaniniProjectionShakeEvent_HDRP/Delegate
struct Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79;
// MoreMountains.FeedbacksForThirdParty.MMVignetteShakeEvent_HDRP/Delegate
struct Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78;
// MoreMountains.FeedbacksForThirdParty.MMWhiteBalanceShakeEvent_HDRP/Delegate
struct Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7;

IL2CPP_EXTERN_C RuntimeClass* AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ColorFilterModes_t7B7A4B63C0D7B36E482FEC816A9A5B0BED8F79DA_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Color_tD001788D726C3A7F1379BEED0260B9591F440C1F_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* MMBloomShakeEvent_HDRP_t2A48F2352C66505C62C6A80DABF3D3F0DE3738B0_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* MMChannelMixerShakeEvent_HDRP_tBD77FF8BBEF92186F80603D199DBFC62DC4CE948_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* MMChromaticAberrationShakeEvent_HDRP_t3A6944A1AAA0BD111C74BBAAFB4D8D0278088CE3_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* MMColorAdjustmentsShakeEvent_HDRP_tD8B4F222BD3844D61BC606D3E8FFCF5D6B20B5FE_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* MMExposureShakeEvent_HDRP_t429034491DB8574CF83B64B4D3052EF37D8AE226_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* MMF_Bloom_HDRP_t583E4BC36988860792A3694FAAA4ACB4A61AEE8C_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* MMF_ChannelMixer_HDRP_tC2DC756B34F42806D3167C44141414379772DB24_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* MMF_ChromaticAberration_HDRP_tD7D36DC2674B8207EBCFCFAEF6EAEF7D13520240_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* MMF_ColorAdjustments_HDRP_t70D2A2F27CA819A0F1E7CE7996B7A17AEFDB124B_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* MMF_Exposure_HDRP_tD40DE5A57861581BA0D7198465A6683F481AC412_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* MMF_FilmGrain_HDRP_tD693F1E63ABEEF2285669284914A08CE5C6E06DC_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* MMF_LensDistortion_HDRP_t1CBCDEC25ED40B9644C9104EE2EF9E7F76EA0823_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* MMF_MotionBlur_HDRP_tF0EE4FD8B93630B1A5AFE3686B359264F68FB63F_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* MMF_PaniniProjection_HDRP_tDDC11106E1AD99645085221E893B9A46C02C8B40_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* MMF_Vignette_HDRP_t433C1F57FA003E5F6BFF1409F73E44528F35C229_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* MMF_WhiteBalance_HDRP_t37FAFEF0B791B3E1EE7863DD1CAE220CC225606A_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* MMFeedbackBloom_HDRP_t0BF688EBD458BA2F7F0E5834DBC5E2011CD66174_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* MMFeedbackChannelMixer_HDRP_tFC9637D2DBA8B0F6CE6D58226C992B5CD30B0680_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* MMFeedbackChromaticAberration_HDRP_t2F1C669FEDB2F3DD0732EF9B63569FB42EB25929_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* MMFeedbackColorAdjustments_HDRP_t99AF449C9842B06883E26C14553A117A6EA0D216_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* MMFeedbackExposure_HDRP_t7D28A8ECA50B6411205FF1E72D45E78055A36395_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* MMFeedbackFilmGrain_HDRP_tA820A4A0D3AF519A8B4AF875A1CD16A7AC494503_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* MMFeedbackLensDistortion_HDRP_tCC834E1D0D5B6F46A8F512F480B8A9952D662380_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* MMFeedbackMotionBlur_HDRP_t726897213A8066AA7377F6281608B75D9E5B6410_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* MMFeedbackPaniniProjection_HDRP_tE2401287FF42E493F48B927B259C4A9EA85B2536_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* MMFeedbackVignette_HDRP_tBB217D0E1DDEA10E932AB75E962FBB1EC382342A_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* MMFeedbackWhiteBalance_HDRP_t4D7756DFBD852A605B201C0F63F472455C03E48E_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* MMFilmGrainShakeEvent_HDRP_t6EE5990F0D1EFCAA1EEE776CFE548DA66CB1D52B_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* MMLensDistortionShakeEvent_HDRP_tB04E28FAD0419A5DD447624B6D4171E4660134C6_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* MMMotionBlurShakeEvent_HDRP_tA8E616DFF1071517A558A6C7CA356B15F8CFC3F9_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* MMPaniniProjectionShakeEvent_HDRP_tFA1A61153E3701522C4E4A3464D9F9F85C50B884_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* MMVignetteShakeEvent_HDRP_t34C7476BF07488DAEA4EC32082A29AC303604A21_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* MMWhiteBalanceShakeEvent_HDRP_t974BEF62F681D273DAD8418106D7C1E817696F90_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* TimescaleModes_t567213DC39EEE1AA073F8E8473E19F2B71FC9A68_il2cpp_TypeInfo_var;
struct AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354;;
struct AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshaled_pinvoke;
struct AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshaled_pinvoke;;
struct Delegate_t_marshaled_com;
struct Delegate_t_marshaled_pinvoke;
struct Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E;;
struct Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E_marshaled_pinvoke;
struct Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E_marshaled_pinvoke;;

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
struct U3CModuleU3E_t1FFD851D8E197C68AD7A46662E461D98B5058BFC 
{
};
struct Il2CppArrayBounds;

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

// MoreMountains.FeedbacksForThirdParty.MMBloomShakeEvent_HDRP
struct MMBloomShakeEvent_HDRP_t2A48F2352C66505C62C6A80DABF3D3F0DE3738B0 
{
	union
	{
		struct
		{
		};
		uint8_t MMBloomShakeEvent_HDRP_t2A48F2352C66505C62C6A80DABF3D3F0DE3738B0__padding[1];
	};
};

struct MMBloomShakeEvent_HDRP_t2A48F2352C66505C62C6A80DABF3D3F0DE3738B0_StaticFields
{
	// MoreMountains.FeedbacksForThirdParty.MMBloomShakeEvent_HDRP/Delegate MoreMountains.FeedbacksForThirdParty.MMBloomShakeEvent_HDRP::OnEvent
	Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8* ___OnEvent_0;
};

// MoreMountains.FeedbacksForThirdParty.MMChannelMixerShakeEvent_HDRP
struct MMChannelMixerShakeEvent_HDRP_tBD77FF8BBEF92186F80603D199DBFC62DC4CE948 
{
	union
	{
		struct
		{
		};
		uint8_t MMChannelMixerShakeEvent_HDRP_tBD77FF8BBEF92186F80603D199DBFC62DC4CE948__padding[1];
	};
};

struct MMChannelMixerShakeEvent_HDRP_tBD77FF8BBEF92186F80603D199DBFC62DC4CE948_StaticFields
{
	// MoreMountains.FeedbacksForThirdParty.MMChannelMixerShakeEvent_HDRP/Delegate MoreMountains.FeedbacksForThirdParty.MMChannelMixerShakeEvent_HDRP::OnEvent
	Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176* ___OnEvent_0;
};

// MoreMountains.FeedbacksForThirdParty.MMChromaticAberrationShakeEvent_HDRP
struct MMChromaticAberrationShakeEvent_HDRP_t3A6944A1AAA0BD111C74BBAAFB4D8D0278088CE3 
{
	union
	{
		struct
		{
		};
		uint8_t MMChromaticAberrationShakeEvent_HDRP_t3A6944A1AAA0BD111C74BBAAFB4D8D0278088CE3__padding[1];
	};
};

struct MMChromaticAberrationShakeEvent_HDRP_t3A6944A1AAA0BD111C74BBAAFB4D8D0278088CE3_StaticFields
{
	// MoreMountains.FeedbacksForThirdParty.MMChromaticAberrationShakeEvent_HDRP/Delegate MoreMountains.FeedbacksForThirdParty.MMChromaticAberrationShakeEvent_HDRP::OnEvent
	Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2* ___OnEvent_0;
};

// MoreMountains.FeedbacksForThirdParty.MMColorAdjustmentsShakeEvent_HDRP
struct MMColorAdjustmentsShakeEvent_HDRP_tD8B4F222BD3844D61BC606D3E8FFCF5D6B20B5FE 
{
	union
	{
		struct
		{
		};
		uint8_t MMColorAdjustmentsShakeEvent_HDRP_tD8B4F222BD3844D61BC606D3E8FFCF5D6B20B5FE__padding[1];
	};
};

struct MMColorAdjustmentsShakeEvent_HDRP_tD8B4F222BD3844D61BC606D3E8FFCF5D6B20B5FE_StaticFields
{
	// MoreMountains.FeedbacksForThirdParty.MMColorAdjustmentsShakeEvent_HDRP/Delegate MoreMountains.FeedbacksForThirdParty.MMColorAdjustmentsShakeEvent_HDRP::OnEvent
	Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19* ___OnEvent_0;
};

// MoreMountains.FeedbacksForThirdParty.MMExposureShakeEvent_HDRP
struct MMExposureShakeEvent_HDRP_t429034491DB8574CF83B64B4D3052EF37D8AE226 
{
	union
	{
		struct
		{
		};
		uint8_t MMExposureShakeEvent_HDRP_t429034491DB8574CF83B64B4D3052EF37D8AE226__padding[1];
	};
};

struct MMExposureShakeEvent_HDRP_t429034491DB8574CF83B64B4D3052EF37D8AE226_StaticFields
{
	// MoreMountains.FeedbacksForThirdParty.MMExposureShakeEvent_HDRP/Delegate MoreMountains.FeedbacksForThirdParty.MMExposureShakeEvent_HDRP::OnEvent
	Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0* ___OnEvent_0;
};

// MoreMountains.FeedbacksForThirdParty.MMFilmGrainShakeEvent_HDRP
struct MMFilmGrainShakeEvent_HDRP_t6EE5990F0D1EFCAA1EEE776CFE548DA66CB1D52B 
{
	union
	{
		struct
		{
		};
		uint8_t MMFilmGrainShakeEvent_HDRP_t6EE5990F0D1EFCAA1EEE776CFE548DA66CB1D52B__padding[1];
	};
};

struct MMFilmGrainShakeEvent_HDRP_t6EE5990F0D1EFCAA1EEE776CFE548DA66CB1D52B_StaticFields
{
	// MoreMountains.FeedbacksForThirdParty.MMFilmGrainShakeEvent_HDRP/Delegate MoreMountains.FeedbacksForThirdParty.MMFilmGrainShakeEvent_HDRP::OnEvent
	Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15* ___OnEvent_0;
};

// MoreMountains.FeedbacksForThirdParty.MMLensDistortionShakeEvent_HDRP
struct MMLensDistortionShakeEvent_HDRP_tB04E28FAD0419A5DD447624B6D4171E4660134C6 
{
	union
	{
		struct
		{
		};
		uint8_t MMLensDistortionShakeEvent_HDRP_tB04E28FAD0419A5DD447624B6D4171E4660134C6__padding[1];
	};
};

struct MMLensDistortionShakeEvent_HDRP_tB04E28FAD0419A5DD447624B6D4171E4660134C6_StaticFields
{
	// MoreMountains.FeedbacksForThirdParty.MMLensDistortionShakeEvent_HDRP/Delegate MoreMountains.FeedbacksForThirdParty.MMLensDistortionShakeEvent_HDRP::OnEvent
	Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994* ___OnEvent_0;
};

// MoreMountains.FeedbacksForThirdParty.MMMotionBlurShakeEvent_HDRP
struct MMMotionBlurShakeEvent_HDRP_tA8E616DFF1071517A558A6C7CA356B15F8CFC3F9 
{
	union
	{
		struct
		{
		};
		uint8_t MMMotionBlurShakeEvent_HDRP_tA8E616DFF1071517A558A6C7CA356B15F8CFC3F9__padding[1];
	};
};

struct MMMotionBlurShakeEvent_HDRP_tA8E616DFF1071517A558A6C7CA356B15F8CFC3F9_StaticFields
{
	// MoreMountains.FeedbacksForThirdParty.MMMotionBlurShakeEvent_HDRP/Delegate MoreMountains.FeedbacksForThirdParty.MMMotionBlurShakeEvent_HDRP::OnEvent
	Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8* ___OnEvent_0;
};

// MoreMountains.FeedbacksForThirdParty.MMPaniniProjectionShakeEvent_HDRP
struct MMPaniniProjectionShakeEvent_HDRP_tFA1A61153E3701522C4E4A3464D9F9F85C50B884 
{
	union
	{
		struct
		{
		};
		uint8_t MMPaniniProjectionShakeEvent_HDRP_tFA1A61153E3701522C4E4A3464D9F9F85C50B884__padding[1];
	};
};

struct MMPaniniProjectionShakeEvent_HDRP_tFA1A61153E3701522C4E4A3464D9F9F85C50B884_StaticFields
{
	// MoreMountains.FeedbacksForThirdParty.MMPaniniProjectionShakeEvent_HDRP/Delegate MoreMountains.FeedbacksForThirdParty.MMPaniniProjectionShakeEvent_HDRP::OnEvent
	Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79* ___OnEvent_0;
};

// MoreMountains.FeedbacksForThirdParty.MMVignetteShakeEvent_HDRP
struct MMVignetteShakeEvent_HDRP_t34C7476BF07488DAEA4EC32082A29AC303604A21 
{
	union
	{
		struct
		{
		};
		uint8_t MMVignetteShakeEvent_HDRP_t34C7476BF07488DAEA4EC32082A29AC303604A21__padding[1];
	};
};

struct MMVignetteShakeEvent_HDRP_t34C7476BF07488DAEA4EC32082A29AC303604A21_StaticFields
{
	// MoreMountains.FeedbacksForThirdParty.MMVignetteShakeEvent_HDRP/Delegate MoreMountains.FeedbacksForThirdParty.MMVignetteShakeEvent_HDRP::OnEvent
	Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78* ___OnEvent_0;
};

// MoreMountains.FeedbacksForThirdParty.MMWhiteBalanceShakeEvent_HDRP
struct MMWhiteBalanceShakeEvent_HDRP_t974BEF62F681D273DAD8418106D7C1E817696F90 
{
	union
	{
		struct
		{
		};
		uint8_t MMWhiteBalanceShakeEvent_HDRP_t974BEF62F681D273DAD8418106D7C1E817696F90__padding[1];
	};
};

struct MMWhiteBalanceShakeEvent_HDRP_t974BEF62F681D273DAD8418106D7C1E817696F90_StaticFields
{
	// MoreMountains.FeedbacksForThirdParty.MMWhiteBalanceShakeEvent_HDRP/Delegate MoreMountains.FeedbacksForThirdParty.MMWhiteBalanceShakeEvent_HDRP::OnEvent
	Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7* ___OnEvent_0;
};

// System.Single
struct Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C 
{
	// System.Single System.Single::m_value
	float ___m_value_0;
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

// UnityEngine.Gradient
struct Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E  : public RuntimeObject
{
	// System.IntPtr UnityEngine.Gradient::m_Ptr
	intptr_t ___m_Ptr_0;
};
// Native definition for P/Invoke marshalling of UnityEngine.Gradient
struct Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E_marshaled_pinvoke
{
	intptr_t ___m_Ptr_0;
};
// Native definition for COM marshalling of UnityEngine.Gradient
struct Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E_marshaled_com
{
	intptr_t ___m_Ptr_0;
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

// UnityEngine.Component
struct Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3  : public Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C
{
};

// MoreMountains.FeedbacksForThirdParty.MMF_Bloom_HDRP
struct MMF_Bloom_HDRP_t583E4BC36988860792A3694FAAA4ACB4A61AEE8C  : public MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D
{
	// System.Single MoreMountains.FeedbacksForThirdParty.MMF_Bloom_HDRP::ShakeDuration
	float ___ShakeDuration_28;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_Bloom_HDRP::ResetShakerValuesAfterShake
	bool ___ResetShakerValuesAfterShake_29;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_Bloom_HDRP::ResetTargetValuesAfterShake
	bool ___ResetTargetValuesAfterShake_30;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_Bloom_HDRP::RelativeValues
	bool ___RelativeValues_31;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMF_Bloom_HDRP::ShakeIntensity
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___ShakeIntensity_32;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMF_Bloom_HDRP::RemapIntensityZero
	float ___RemapIntensityZero_33;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMF_Bloom_HDRP::RemapIntensityOne
	float ___RemapIntensityOne_34;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMF_Bloom_HDRP::ShakeThreshold
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___ShakeThreshold_35;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMF_Bloom_HDRP::RemapThresholdZero
	float ___RemapThresholdZero_36;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMF_Bloom_HDRP::RemapThresholdOne
	float ___RemapThresholdOne_37;
};

struct MMF_Bloom_HDRP_t583E4BC36988860792A3694FAAA4ACB4A61AEE8C_StaticFields
{
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_Bloom_HDRP::FeedbackTypeAuthorized
	bool ___FeedbackTypeAuthorized_27;
};

// MoreMountains.FeedbacksForThirdParty.MMF_ChannelMixer_HDRP
struct MMF_ChannelMixer_HDRP_tC2DC756B34F42806D3167C44141414379772DB24  : public MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D
{
	// System.Single MoreMountains.FeedbacksForThirdParty.MMF_ChannelMixer_HDRP::ShakeDuration
	float ___ShakeDuration_28;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_ChannelMixer_HDRP::RelativeIntensity
	bool ___RelativeIntensity_29;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_ChannelMixer_HDRP::ResetShakerValuesAfterShake
	bool ___ResetShakerValuesAfterShake_30;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_ChannelMixer_HDRP::ResetTargetValuesAfterShake
	bool ___ResetTargetValuesAfterShake_31;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMF_ChannelMixer_HDRP::ShakeRed
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___ShakeRed_32;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMF_ChannelMixer_HDRP::RemapRedZero
	float ___RemapRedZero_33;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMF_ChannelMixer_HDRP::RemapRedOne
	float ___RemapRedOne_34;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMF_ChannelMixer_HDRP::ShakeGreen
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___ShakeGreen_35;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMF_ChannelMixer_HDRP::RemapGreenZero
	float ___RemapGreenZero_36;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMF_ChannelMixer_HDRP::RemapGreenOne
	float ___RemapGreenOne_37;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMF_ChannelMixer_HDRP::ShakeBlue
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___ShakeBlue_38;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMF_ChannelMixer_HDRP::RemapBlueZero
	float ___RemapBlueZero_39;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMF_ChannelMixer_HDRP::RemapBlueOne
	float ___RemapBlueOne_40;
};

struct MMF_ChannelMixer_HDRP_tC2DC756B34F42806D3167C44141414379772DB24_StaticFields
{
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_ChannelMixer_HDRP::FeedbackTypeAuthorized
	bool ___FeedbackTypeAuthorized_27;
};

// MoreMountains.FeedbacksForThirdParty.MMF_ChromaticAberration_HDRP
struct MMF_ChromaticAberration_HDRP_tD7D36DC2674B8207EBCFCFAEF6EAEF7D13520240  : public MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D
{
	// System.Single MoreMountains.FeedbacksForThirdParty.MMF_ChromaticAberration_HDRP::Duration
	float ___Duration_28;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_ChromaticAberration_HDRP::ResetShakerValuesAfterShake
	bool ___ResetShakerValuesAfterShake_29;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_ChromaticAberration_HDRP::ResetTargetValuesAfterShake
	bool ___ResetTargetValuesAfterShake_30;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMF_ChromaticAberration_HDRP::RemapIntensityZero
	float ___RemapIntensityZero_31;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMF_ChromaticAberration_HDRP::RemapIntensityOne
	float ___RemapIntensityOne_32;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMF_ChromaticAberration_HDRP::Intensity
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___Intensity_33;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMF_ChromaticAberration_HDRP::Amplitude
	float ___Amplitude_34;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_ChromaticAberration_HDRP::RelativeIntensity
	bool ___RelativeIntensity_35;
};

struct MMF_ChromaticAberration_HDRP_tD7D36DC2674B8207EBCFCFAEF6EAEF7D13520240_StaticFields
{
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_ChromaticAberration_HDRP::FeedbackTypeAuthorized
	bool ___FeedbackTypeAuthorized_27;
};

// MoreMountains.FeedbacksForThirdParty.MMF_ColorAdjustments_HDRP
struct MMF_ColorAdjustments_HDRP_t70D2A2F27CA819A0F1E7CE7996B7A17AEFDB124B  : public MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D
{
	// System.Single MoreMountains.FeedbacksForThirdParty.MMF_ColorAdjustments_HDRP::ShakeDuration
	float ___ShakeDuration_28;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_ColorAdjustments_HDRP::RelativeIntensity
	bool ___RelativeIntensity_29;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_ColorAdjustments_HDRP::ResetShakerValuesAfterShake
	bool ___ResetShakerValuesAfterShake_30;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_ColorAdjustments_HDRP::ResetTargetValuesAfterShake
	bool ___ResetTargetValuesAfterShake_31;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMF_ColorAdjustments_HDRP::ShakePostExposure
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___ShakePostExposure_32;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMF_ColorAdjustments_HDRP::RemapPostExposureZero
	float ___RemapPostExposureZero_33;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMF_ColorAdjustments_HDRP::RemapPostExposureOne
	float ___RemapPostExposureOne_34;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMF_ColorAdjustments_HDRP::ShakeHueShift
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___ShakeHueShift_35;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMF_ColorAdjustments_HDRP::RemapHueShiftZero
	float ___RemapHueShiftZero_36;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMF_ColorAdjustments_HDRP::RemapHueShiftOne
	float ___RemapHueShiftOne_37;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMF_ColorAdjustments_HDRP::ShakeSaturation
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___ShakeSaturation_38;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMF_ColorAdjustments_HDRP::RemapSaturationZero
	float ___RemapSaturationZero_39;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMF_ColorAdjustments_HDRP::RemapSaturationOne
	float ___RemapSaturationOne_40;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMF_ColorAdjustments_HDRP::ShakeContrast
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___ShakeContrast_41;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMF_ColorAdjustments_HDRP::RemapContrastZero
	float ___RemapContrastZero_42;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMF_ColorAdjustments_HDRP::RemapContrastOne
	float ___RemapContrastOne_43;
	// MoreMountains.FeedbacksForThirdParty.MMColorAdjustmentsShaker_HDRP/ColorFilterModes MoreMountains.FeedbacksForThirdParty.MMF_ColorAdjustments_HDRP::ColorFilterMode
	int32_t ___ColorFilterMode_44;
	// UnityEngine.Gradient MoreMountains.FeedbacksForThirdParty.MMF_ColorAdjustments_HDRP::ColorFilterGradient
	Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E* ___ColorFilterGradient_45;
	// UnityEngine.Color MoreMountains.FeedbacksForThirdParty.MMF_ColorAdjustments_HDRP::ColorFilterDestination
	Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___ColorFilterDestination_46;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMF_ColorAdjustments_HDRP::ColorFilterCurve
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___ColorFilterCurve_47;
};

struct MMF_ColorAdjustments_HDRP_t70D2A2F27CA819A0F1E7CE7996B7A17AEFDB124B_StaticFields
{
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_ColorAdjustments_HDRP::FeedbackTypeAuthorized
	bool ___FeedbackTypeAuthorized_27;
};

// MoreMountains.FeedbacksForThirdParty.MMF_Exposure_HDRP
struct MMF_Exposure_HDRP_tD40DE5A57861581BA0D7198465A6683F481AC412  : public MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D
{
	// System.Single MoreMountains.FeedbacksForThirdParty.MMF_Exposure_HDRP::Duration
	float ___Duration_28;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_Exposure_HDRP::ResetShakerValuesAfterShake
	bool ___ResetShakerValuesAfterShake_29;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_Exposure_HDRP::ResetTargetValuesAfterShake
	bool ___ResetTargetValuesAfterShake_30;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMF_Exposure_HDRP::FixedExposure
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___FixedExposure_31;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMF_Exposure_HDRP::RemapFixedExposureZero
	float ___RemapFixedExposureZero_32;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMF_Exposure_HDRP::RemapFixedExposureOne
	float ___RemapFixedExposureOne_33;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_Exposure_HDRP::RelativeFixedExposure
	bool ___RelativeFixedExposure_34;
};

struct MMF_Exposure_HDRP_tD40DE5A57861581BA0D7198465A6683F481AC412_StaticFields
{
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_Exposure_HDRP::FeedbackTypeAuthorized
	bool ___FeedbackTypeAuthorized_27;
};

// MoreMountains.FeedbacksForThirdParty.MMF_FilmGrain_HDRP
struct MMF_FilmGrain_HDRP_tD693F1E63ABEEF2285669284914A08CE5C6E06DC  : public MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D
{
	// System.Single MoreMountains.FeedbacksForThirdParty.MMF_FilmGrain_HDRP::Duration
	float ___Duration_28;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_FilmGrain_HDRP::ResetShakerValuesAfterShake
	bool ___ResetShakerValuesAfterShake_29;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_FilmGrain_HDRP::ResetTargetValuesAfterShake
	bool ___ResetTargetValuesAfterShake_30;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMF_FilmGrain_HDRP::Intensity
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___Intensity_31;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMF_FilmGrain_HDRP::RemapIntensityZero
	float ___RemapIntensityZero_32;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMF_FilmGrain_HDRP::RemapIntensityOne
	float ___RemapIntensityOne_33;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_FilmGrain_HDRP::RelativeIntensity
	bool ___RelativeIntensity_34;
};

struct MMF_FilmGrain_HDRP_tD693F1E63ABEEF2285669284914A08CE5C6E06DC_StaticFields
{
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_FilmGrain_HDRP::FeedbackTypeAuthorized
	bool ___FeedbackTypeAuthorized_27;
};

// MoreMountains.FeedbacksForThirdParty.MMF_LensDistortion_HDRP
struct MMF_LensDistortion_HDRP_t1CBCDEC25ED40B9644C9104EE2EF9E7F76EA0823  : public MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D
{
	// System.Single MoreMountains.FeedbacksForThirdParty.MMF_LensDistortion_HDRP::Duration
	float ___Duration_28;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_LensDistortion_HDRP::ResetShakerValuesAfterShake
	bool ___ResetShakerValuesAfterShake_29;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_LensDistortion_HDRP::ResetTargetValuesAfterShake
	bool ___ResetTargetValuesAfterShake_30;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_LensDistortion_HDRP::RelativeIntensity
	bool ___RelativeIntensity_31;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMF_LensDistortion_HDRP::Intensity
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___Intensity_32;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMF_LensDistortion_HDRP::RemapIntensityZero
	float ___RemapIntensityZero_33;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMF_LensDistortion_HDRP::RemapIntensityOne
	float ___RemapIntensityOne_34;
};

struct MMF_LensDistortion_HDRP_t1CBCDEC25ED40B9644C9104EE2EF9E7F76EA0823_StaticFields
{
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_LensDistortion_HDRP::FeedbackTypeAuthorized
	bool ___FeedbackTypeAuthorized_27;
};

// MoreMountains.FeedbacksForThirdParty.MMF_MotionBlur_HDRP
struct MMF_MotionBlur_HDRP_tF0EE4FD8B93630B1A5AFE3686B359264F68FB63F  : public MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D
{
	// System.Single MoreMountains.FeedbacksForThirdParty.MMF_MotionBlur_HDRP::Duration
	float ___Duration_28;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_MotionBlur_HDRP::ResetShakerValuesAfterShake
	bool ___ResetShakerValuesAfterShake_29;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_MotionBlur_HDRP::ResetTargetValuesAfterShake
	bool ___ResetTargetValuesAfterShake_30;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMF_MotionBlur_HDRP::Intensity
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___Intensity_31;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMF_MotionBlur_HDRP::RemapIntensityZero
	float ___RemapIntensityZero_32;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMF_MotionBlur_HDRP::RemapIntensityOne
	float ___RemapIntensityOne_33;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_MotionBlur_HDRP::RelativeIntensity
	bool ___RelativeIntensity_34;
};

struct MMF_MotionBlur_HDRP_tF0EE4FD8B93630B1A5AFE3686B359264F68FB63F_StaticFields
{
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_MotionBlur_HDRP::FeedbackTypeAuthorized
	bool ___FeedbackTypeAuthorized_27;
};

// MoreMountains.FeedbacksForThirdParty.MMF_PaniniProjection_HDRP
struct MMF_PaniniProjection_HDRP_tDDC11106E1AD99645085221E893B9A46C02C8B40  : public MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D
{
	// System.Single MoreMountains.FeedbacksForThirdParty.MMF_PaniniProjection_HDRP::Duration
	float ___Duration_28;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_PaniniProjection_HDRP::ResetShakerValuesAfterShake
	bool ___ResetShakerValuesAfterShake_29;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_PaniniProjection_HDRP::ResetTargetValuesAfterShake
	bool ___ResetTargetValuesAfterShake_30;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_PaniniProjection_HDRP::RelativeDistance
	bool ___RelativeDistance_31;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMF_PaniniProjection_HDRP::ShakeDistance
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___ShakeDistance_32;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMF_PaniniProjection_HDRP::RemapDistanceZero
	float ___RemapDistanceZero_33;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMF_PaniniProjection_HDRP::RemapDistanceOne
	float ___RemapDistanceOne_34;
};

struct MMF_PaniniProjection_HDRP_tDDC11106E1AD99645085221E893B9A46C02C8B40_StaticFields
{
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_PaniniProjection_HDRP::FeedbackTypeAuthorized
	bool ___FeedbackTypeAuthorized_27;
};

// MoreMountains.FeedbacksForThirdParty.MMF_Vignette_HDRP
struct MMF_Vignette_HDRP_t433C1F57FA003E5F6BFF1409F73E44528F35C229  : public MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D
{
	// System.Single MoreMountains.FeedbacksForThirdParty.MMF_Vignette_HDRP::Duration
	float ___Duration_28;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_Vignette_HDRP::ResetShakerValuesAfterShake
	bool ___ResetShakerValuesAfterShake_29;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_Vignette_HDRP::ResetTargetValuesAfterShake
	bool ___ResetTargetValuesAfterShake_30;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMF_Vignette_HDRP::Intensity
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___Intensity_31;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMF_Vignette_HDRP::RemapIntensityZero
	float ___RemapIntensityZero_32;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMF_Vignette_HDRP::RemapIntensityOne
	float ___RemapIntensityOne_33;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_Vignette_HDRP::RelativeIntensity
	bool ___RelativeIntensity_34;
};

struct MMF_Vignette_HDRP_t433C1F57FA003E5F6BFF1409F73E44528F35C229_StaticFields
{
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_Vignette_HDRP::FeedbackTypeAuthorized
	bool ___FeedbackTypeAuthorized_27;
};

// MoreMountains.FeedbacksForThirdParty.MMF_WhiteBalance_HDRP
struct MMF_WhiteBalance_HDRP_t37FAFEF0B791B3E1EE7863DD1CAE220CC225606A  : public MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D
{
	// System.Single MoreMountains.FeedbacksForThirdParty.MMF_WhiteBalance_HDRP::ShakeDuration
	float ___ShakeDuration_28;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_WhiteBalance_HDRP::RelativeValues
	bool ___RelativeValues_29;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_WhiteBalance_HDRP::ResetShakerValuesAfterShake
	bool ___ResetShakerValuesAfterShake_30;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_WhiteBalance_HDRP::ResetTargetValuesAfterShake
	bool ___ResetTargetValuesAfterShake_31;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMF_WhiteBalance_HDRP::ShakeTemperature
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___ShakeTemperature_32;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMF_WhiteBalance_HDRP::RemapTemperatureZero
	float ___RemapTemperatureZero_33;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMF_WhiteBalance_HDRP::RemapTemperatureOne
	float ___RemapTemperatureOne_34;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMF_WhiteBalance_HDRP::ShakeTint
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___ShakeTint_35;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMF_WhiteBalance_HDRP::RemapTintZero
	float ___RemapTintZero_36;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMF_WhiteBalance_HDRP::RemapTintOne
	float ___RemapTintOne_37;
};

struct MMF_WhiteBalance_HDRP_t37FAFEF0B791B3E1EE7863DD1CAE220CC225606A_StaticFields
{
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_WhiteBalance_HDRP::FeedbackTypeAuthorized
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

// System.AsyncCallback
struct AsyncCallback_t7FEF460CBDCFB9C5FA2EF776984778B9A4145F4C  : public MulticastDelegate_t
{
};

// UnityEngine.Behaviour
struct Behaviour_t01970CFBBA658497AE30F311C447DB0440BAB7FA  : public Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3
{
};

// MoreMountains.FeedbacksForThirdParty.MMBloomShakeEvent_HDRP/Delegate
struct Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8  : public MulticastDelegate_t
{
};

// MoreMountains.FeedbacksForThirdParty.MMChannelMixerShakeEvent_HDRP/Delegate
struct Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176  : public MulticastDelegate_t
{
};

// MoreMountains.FeedbacksForThirdParty.MMChromaticAberrationShakeEvent_HDRP/Delegate
struct Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2  : public MulticastDelegate_t
{
};

// MoreMountains.FeedbacksForThirdParty.MMColorAdjustmentsShakeEvent_HDRP/Delegate
struct Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19  : public MulticastDelegate_t
{
};

// MoreMountains.FeedbacksForThirdParty.MMExposureShakeEvent_HDRP/Delegate
struct Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0  : public MulticastDelegate_t
{
};

// MoreMountains.FeedbacksForThirdParty.MMFilmGrainShakeEvent_HDRP/Delegate
struct Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15  : public MulticastDelegate_t
{
};

// MoreMountains.FeedbacksForThirdParty.MMLensDistortionShakeEvent_HDRP/Delegate
struct Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994  : public MulticastDelegate_t
{
};

// MoreMountains.FeedbacksForThirdParty.MMMotionBlurShakeEvent_HDRP/Delegate
struct Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8  : public MulticastDelegate_t
{
};

// MoreMountains.FeedbacksForThirdParty.MMPaniniProjectionShakeEvent_HDRP/Delegate
struct Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79  : public MulticastDelegate_t
{
};

// MoreMountains.FeedbacksForThirdParty.MMVignetteShakeEvent_HDRP/Delegate
struct Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78  : public MulticastDelegate_t
{
};

// MoreMountains.FeedbacksForThirdParty.MMWhiteBalanceShakeEvent_HDRP/Delegate
struct Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7  : public MulticastDelegate_t
{
};

// UnityEngine.MonoBehaviour
struct MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71  : public Behaviour_t01970CFBBA658497AE30F311C447DB0440BAB7FA
{
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

// MoreMountains.FeedbacksForThirdParty.MMFeedbackBloom_HDRP
struct MMFeedbackBloom_HDRP_t0BF688EBD458BA2F7F0E5834DBC5E2011CD66174  : public MMFeedback_tE51A2F7A01B1E3BE46047E5A0D6BA5C79199FDCA
{
	// System.Int32 MoreMountains.FeedbacksForThirdParty.MMFeedbackBloom_HDRP::Channel
	int32_t ___Channel_29;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackBloom_HDRP::ShakeDuration
	float ___ShakeDuration_30;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMFeedbackBloom_HDRP::ResetShakerValuesAfterShake
	bool ___ResetShakerValuesAfterShake_31;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMFeedbackBloom_HDRP::ResetTargetValuesAfterShake
	bool ___ResetTargetValuesAfterShake_32;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMFeedbackBloom_HDRP::RelativeValues
	bool ___RelativeValues_33;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMFeedbackBloom_HDRP::ShakeIntensity
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___ShakeIntensity_34;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackBloom_HDRP::RemapIntensityZero
	float ___RemapIntensityZero_35;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackBloom_HDRP::RemapIntensityOne
	float ___RemapIntensityOne_36;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMFeedbackBloom_HDRP::ShakeThreshold
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___ShakeThreshold_37;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackBloom_HDRP::RemapThresholdZero
	float ___RemapThresholdZero_38;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackBloom_HDRP::RemapThresholdOne
	float ___RemapThresholdOne_39;
};

struct MMFeedbackBloom_HDRP_t0BF688EBD458BA2F7F0E5834DBC5E2011CD66174_StaticFields
{
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMFeedbackBloom_HDRP::FeedbackTypeAuthorized
	bool ___FeedbackTypeAuthorized_28;
};

// MoreMountains.FeedbacksForThirdParty.MMFeedbackChannelMixer_HDRP
struct MMFeedbackChannelMixer_HDRP_tFC9637D2DBA8B0F6CE6D58226C992B5CD30B0680  : public MMFeedback_tE51A2F7A01B1E3BE46047E5A0D6BA5C79199FDCA
{
	// System.Int32 MoreMountains.FeedbacksForThirdParty.MMFeedbackChannelMixer_HDRP::Channel
	int32_t ___Channel_29;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackChannelMixer_HDRP::ShakeDuration
	float ___ShakeDuration_30;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMFeedbackChannelMixer_HDRP::RelativeIntensity
	bool ___RelativeIntensity_31;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMFeedbackChannelMixer_HDRP::ResetShakerValuesAfterShake
	bool ___ResetShakerValuesAfterShake_32;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMFeedbackChannelMixer_HDRP::ResetTargetValuesAfterShake
	bool ___ResetTargetValuesAfterShake_33;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMFeedbackChannelMixer_HDRP::ShakeRed
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___ShakeRed_34;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackChannelMixer_HDRP::RemapRedZero
	float ___RemapRedZero_35;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackChannelMixer_HDRP::RemapRedOne
	float ___RemapRedOne_36;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMFeedbackChannelMixer_HDRP::ShakeGreen
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___ShakeGreen_37;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackChannelMixer_HDRP::RemapGreenZero
	float ___RemapGreenZero_38;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackChannelMixer_HDRP::RemapGreenOne
	float ___RemapGreenOne_39;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMFeedbackChannelMixer_HDRP::ShakeBlue
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___ShakeBlue_40;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackChannelMixer_HDRP::RemapBlueZero
	float ___RemapBlueZero_41;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackChannelMixer_HDRP::RemapBlueOne
	float ___RemapBlueOne_42;
};

struct MMFeedbackChannelMixer_HDRP_tFC9637D2DBA8B0F6CE6D58226C992B5CD30B0680_StaticFields
{
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMFeedbackChannelMixer_HDRP::FeedbackTypeAuthorized
	bool ___FeedbackTypeAuthorized_28;
};

// MoreMountains.FeedbacksForThirdParty.MMFeedbackChromaticAberration_HDRP
struct MMFeedbackChromaticAberration_HDRP_t2F1C669FEDB2F3DD0732EF9B63569FB42EB25929  : public MMFeedback_tE51A2F7A01B1E3BE46047E5A0D6BA5C79199FDCA
{
	// System.Int32 MoreMountains.FeedbacksForThirdParty.MMFeedbackChromaticAberration_HDRP::Channel
	int32_t ___Channel_29;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackChromaticAberration_HDRP::Duration
	float ___Duration_30;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMFeedbackChromaticAberration_HDRP::ResetShakerValuesAfterShake
	bool ___ResetShakerValuesAfterShake_31;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMFeedbackChromaticAberration_HDRP::ResetTargetValuesAfterShake
	bool ___ResetTargetValuesAfterShake_32;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackChromaticAberration_HDRP::RemapIntensityZero
	float ___RemapIntensityZero_33;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackChromaticAberration_HDRP::RemapIntensityOne
	float ___RemapIntensityOne_34;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMFeedbackChromaticAberration_HDRP::Intensity
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___Intensity_35;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackChromaticAberration_HDRP::Amplitude
	float ___Amplitude_36;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMFeedbackChromaticAberration_HDRP::RelativeIntensity
	bool ___RelativeIntensity_37;
};

struct MMFeedbackChromaticAberration_HDRP_t2F1C669FEDB2F3DD0732EF9B63569FB42EB25929_StaticFields
{
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMFeedbackChromaticAberration_HDRP::FeedbackTypeAuthorized
	bool ___FeedbackTypeAuthorized_28;
};

// MoreMountains.FeedbacksForThirdParty.MMFeedbackColorAdjustments_HDRP
struct MMFeedbackColorAdjustments_HDRP_t99AF449C9842B06883E26C14553A117A6EA0D216  : public MMFeedback_tE51A2F7A01B1E3BE46047E5A0D6BA5C79199FDCA
{
	// System.Int32 MoreMountains.FeedbacksForThirdParty.MMFeedbackColorAdjustments_HDRP::Channel
	int32_t ___Channel_29;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackColorAdjustments_HDRP::ShakeDuration
	float ___ShakeDuration_30;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMFeedbackColorAdjustments_HDRP::RelativeIntensity
	bool ___RelativeIntensity_31;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMFeedbackColorAdjustments_HDRP::ResetShakerValuesAfterShake
	bool ___ResetShakerValuesAfterShake_32;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMFeedbackColorAdjustments_HDRP::ResetTargetValuesAfterShake
	bool ___ResetTargetValuesAfterShake_33;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMFeedbackColorAdjustments_HDRP::ShakePostExposure
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___ShakePostExposure_34;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackColorAdjustments_HDRP::RemapPostExposureZero
	float ___RemapPostExposureZero_35;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackColorAdjustments_HDRP::RemapPostExposureOne
	float ___RemapPostExposureOne_36;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMFeedbackColorAdjustments_HDRP::ShakeHueShift
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___ShakeHueShift_37;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackColorAdjustments_HDRP::RemapHueShiftZero
	float ___RemapHueShiftZero_38;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackColorAdjustments_HDRP::RemapHueShiftOne
	float ___RemapHueShiftOne_39;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMFeedbackColorAdjustments_HDRP::ShakeSaturation
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___ShakeSaturation_40;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackColorAdjustments_HDRP::RemapSaturationZero
	float ___RemapSaturationZero_41;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackColorAdjustments_HDRP::RemapSaturationOne
	float ___RemapSaturationOne_42;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMFeedbackColorAdjustments_HDRP::ShakeContrast
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___ShakeContrast_43;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackColorAdjustments_HDRP::RemapContrastZero
	float ___RemapContrastZero_44;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackColorAdjustments_HDRP::RemapContrastOne
	float ___RemapContrastOne_45;
	// MoreMountains.FeedbacksForThirdParty.MMColorAdjustmentsShaker_HDRP/ColorFilterModes MoreMountains.FeedbacksForThirdParty.MMFeedbackColorAdjustments_HDRP::ColorFilterMode
	int32_t ___ColorFilterMode_46;
	// UnityEngine.Gradient MoreMountains.FeedbacksForThirdParty.MMFeedbackColorAdjustments_HDRP::ColorFilterGradient
	Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E* ___ColorFilterGradient_47;
	// UnityEngine.Color MoreMountains.FeedbacksForThirdParty.MMFeedbackColorAdjustments_HDRP::ColorFilterDestination
	Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___ColorFilterDestination_48;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMFeedbackColorAdjustments_HDRP::ColorFilterCurve
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___ColorFilterCurve_49;
};

struct MMFeedbackColorAdjustments_HDRP_t99AF449C9842B06883E26C14553A117A6EA0D216_StaticFields
{
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMFeedbackColorAdjustments_HDRP::FeedbackTypeAuthorized
	bool ___FeedbackTypeAuthorized_28;
};

// MoreMountains.FeedbacksForThirdParty.MMFeedbackExposure_HDRP
struct MMFeedbackExposure_HDRP_t7D28A8ECA50B6411205FF1E72D45E78055A36395  : public MMFeedback_tE51A2F7A01B1E3BE46047E5A0D6BA5C79199FDCA
{
	// System.Int32 MoreMountains.FeedbacksForThirdParty.MMFeedbackExposure_HDRP::Channel
	int32_t ___Channel_29;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackExposure_HDRP::Duration
	float ___Duration_30;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMFeedbackExposure_HDRP::ResetShakerValuesAfterShake
	bool ___ResetShakerValuesAfterShake_31;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMFeedbackExposure_HDRP::ResetTargetValuesAfterShake
	bool ___ResetTargetValuesAfterShake_32;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMFeedbackExposure_HDRP::FixedExposure
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___FixedExposure_33;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackExposure_HDRP::RemapFixedExposureZero
	float ___RemapFixedExposureZero_34;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackExposure_HDRP::RemapFixedExposureOne
	float ___RemapFixedExposureOne_35;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMFeedbackExposure_HDRP::RelativeFixedExposure
	bool ___RelativeFixedExposure_36;
};

struct MMFeedbackExposure_HDRP_t7D28A8ECA50B6411205FF1E72D45E78055A36395_StaticFields
{
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMFeedbackExposure_HDRP::FeedbackTypeAuthorized
	bool ___FeedbackTypeAuthorized_28;
};

// MoreMountains.FeedbacksForThirdParty.MMFeedbackFilmGrain_HDRP
struct MMFeedbackFilmGrain_HDRP_tA820A4A0D3AF519A8B4AF875A1CD16A7AC494503  : public MMFeedback_tE51A2F7A01B1E3BE46047E5A0D6BA5C79199FDCA
{
	// System.Int32 MoreMountains.FeedbacksForThirdParty.MMFeedbackFilmGrain_HDRP::Channel
	int32_t ___Channel_29;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackFilmGrain_HDRP::Duration
	float ___Duration_30;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMFeedbackFilmGrain_HDRP::ResetShakerValuesAfterShake
	bool ___ResetShakerValuesAfterShake_31;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMFeedbackFilmGrain_HDRP::ResetTargetValuesAfterShake
	bool ___ResetTargetValuesAfterShake_32;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMFeedbackFilmGrain_HDRP::Intensity
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___Intensity_33;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackFilmGrain_HDRP::RemapIntensityZero
	float ___RemapIntensityZero_34;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackFilmGrain_HDRP::RemapIntensityOne
	float ___RemapIntensityOne_35;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMFeedbackFilmGrain_HDRP::RelativeIntensity
	bool ___RelativeIntensity_36;
};

struct MMFeedbackFilmGrain_HDRP_tA820A4A0D3AF519A8B4AF875A1CD16A7AC494503_StaticFields
{
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMFeedbackFilmGrain_HDRP::FeedbackTypeAuthorized
	bool ___FeedbackTypeAuthorized_28;
};

// MoreMountains.FeedbacksForThirdParty.MMFeedbackLensDistortion_HDRP
struct MMFeedbackLensDistortion_HDRP_tCC834E1D0D5B6F46A8F512F480B8A9952D662380  : public MMFeedback_tE51A2F7A01B1E3BE46047E5A0D6BA5C79199FDCA
{
	// System.Int32 MoreMountains.FeedbacksForThirdParty.MMFeedbackLensDistortion_HDRP::Channel
	int32_t ___Channel_29;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackLensDistortion_HDRP::Duration
	float ___Duration_30;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMFeedbackLensDistortion_HDRP::ResetShakerValuesAfterShake
	bool ___ResetShakerValuesAfterShake_31;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMFeedbackLensDistortion_HDRP::ResetTargetValuesAfterShake
	bool ___ResetTargetValuesAfterShake_32;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMFeedbackLensDistortion_HDRP::RelativeIntensity
	bool ___RelativeIntensity_33;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMFeedbackLensDistortion_HDRP::Intensity
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___Intensity_34;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackLensDistortion_HDRP::RemapIntensityZero
	float ___RemapIntensityZero_35;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackLensDistortion_HDRP::RemapIntensityOne
	float ___RemapIntensityOne_36;
};

struct MMFeedbackLensDistortion_HDRP_tCC834E1D0D5B6F46A8F512F480B8A9952D662380_StaticFields
{
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMFeedbackLensDistortion_HDRP::FeedbackTypeAuthorized
	bool ___FeedbackTypeAuthorized_28;
};

// MoreMountains.FeedbacksForThirdParty.MMFeedbackMotionBlur_HDRP
struct MMFeedbackMotionBlur_HDRP_t726897213A8066AA7377F6281608B75D9E5B6410  : public MMFeedback_tE51A2F7A01B1E3BE46047E5A0D6BA5C79199FDCA
{
	// System.Int32 MoreMountains.FeedbacksForThirdParty.MMFeedbackMotionBlur_HDRP::Channel
	int32_t ___Channel_29;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackMotionBlur_HDRP::Duration
	float ___Duration_30;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMFeedbackMotionBlur_HDRP::ResetShakerValuesAfterShake
	bool ___ResetShakerValuesAfterShake_31;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMFeedbackMotionBlur_HDRP::ResetTargetValuesAfterShake
	bool ___ResetTargetValuesAfterShake_32;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMFeedbackMotionBlur_HDRP::Intensity
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___Intensity_33;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackMotionBlur_HDRP::RemapIntensityZero
	float ___RemapIntensityZero_34;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackMotionBlur_HDRP::RemapIntensityOne
	float ___RemapIntensityOne_35;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMFeedbackMotionBlur_HDRP::RelativeIntensity
	bool ___RelativeIntensity_36;
};

struct MMFeedbackMotionBlur_HDRP_t726897213A8066AA7377F6281608B75D9E5B6410_StaticFields
{
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMFeedbackMotionBlur_HDRP::FeedbackTypeAuthorized
	bool ___FeedbackTypeAuthorized_28;
};

// MoreMountains.FeedbacksForThirdParty.MMFeedbackPaniniProjection_HDRP
struct MMFeedbackPaniniProjection_HDRP_tE2401287FF42E493F48B927B259C4A9EA85B2536  : public MMFeedback_tE51A2F7A01B1E3BE46047E5A0D6BA5C79199FDCA
{
	// System.Int32 MoreMountains.FeedbacksForThirdParty.MMFeedbackPaniniProjection_HDRP::Channel
	int32_t ___Channel_29;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackPaniniProjection_HDRP::Duration
	float ___Duration_30;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMFeedbackPaniniProjection_HDRP::ResetShakerValuesAfterShake
	bool ___ResetShakerValuesAfterShake_31;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMFeedbackPaniniProjection_HDRP::ResetTargetValuesAfterShake
	bool ___ResetTargetValuesAfterShake_32;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMFeedbackPaniniProjection_HDRP::RelativeDistance
	bool ___RelativeDistance_33;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMFeedbackPaniniProjection_HDRP::ShakeDistance
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___ShakeDistance_34;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackPaniniProjection_HDRP::RemapDistanceZero
	float ___RemapDistanceZero_35;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackPaniniProjection_HDRP::RemapDistanceOne
	float ___RemapDistanceOne_36;
};

struct MMFeedbackPaniniProjection_HDRP_tE2401287FF42E493F48B927B259C4A9EA85B2536_StaticFields
{
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMFeedbackPaniniProjection_HDRP::FeedbackTypeAuthorized
	bool ___FeedbackTypeAuthorized_28;
};

// MoreMountains.FeedbacksForThirdParty.MMFeedbackVignette_HDRP
struct MMFeedbackVignette_HDRP_tBB217D0E1DDEA10E932AB75E962FBB1EC382342A  : public MMFeedback_tE51A2F7A01B1E3BE46047E5A0D6BA5C79199FDCA
{
	// System.Int32 MoreMountains.FeedbacksForThirdParty.MMFeedbackVignette_HDRP::Channel
	int32_t ___Channel_29;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackVignette_HDRP::Duration
	float ___Duration_30;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMFeedbackVignette_HDRP::ResetShakerValuesAfterShake
	bool ___ResetShakerValuesAfterShake_31;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMFeedbackVignette_HDRP::ResetTargetValuesAfterShake
	bool ___ResetTargetValuesAfterShake_32;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMFeedbackVignette_HDRP::Intensity
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___Intensity_33;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackVignette_HDRP::RemapIntensityZero
	float ___RemapIntensityZero_34;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackVignette_HDRP::RemapIntensityOne
	float ___RemapIntensityOne_35;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMFeedbackVignette_HDRP::RelativeIntensity
	bool ___RelativeIntensity_36;
};

struct MMFeedbackVignette_HDRP_tBB217D0E1DDEA10E932AB75E962FBB1EC382342A_StaticFields
{
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMFeedbackVignette_HDRP::FeedbackTypeAuthorized
	bool ___FeedbackTypeAuthorized_28;
};

// MoreMountains.FeedbacksForThirdParty.MMFeedbackWhiteBalance_HDRP
struct MMFeedbackWhiteBalance_HDRP_t4D7756DFBD852A605B201C0F63F472455C03E48E  : public MMFeedback_tE51A2F7A01B1E3BE46047E5A0D6BA5C79199FDCA
{
	// System.Int32 MoreMountains.FeedbacksForThirdParty.MMFeedbackWhiteBalance_HDRP::Channel
	int32_t ___Channel_29;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackWhiteBalance_HDRP::ShakeDuration
	float ___ShakeDuration_30;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMFeedbackWhiteBalance_HDRP::RelativeValues
	bool ___RelativeValues_31;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMFeedbackWhiteBalance_HDRP::ResetShakerValuesAfterShake
	bool ___ResetShakerValuesAfterShake_32;
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMFeedbackWhiteBalance_HDRP::ResetTargetValuesAfterShake
	bool ___ResetTargetValuesAfterShake_33;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMFeedbackWhiteBalance_HDRP::ShakeTemperature
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___ShakeTemperature_34;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackWhiteBalance_HDRP::RemapTemperatureZero
	float ___RemapTemperatureZero_35;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackWhiteBalance_HDRP::RemapTemperatureOne
	float ___RemapTemperatureOne_36;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMFeedbackWhiteBalance_HDRP::ShakeTint
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___ShakeTint_37;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackWhiteBalance_HDRP::RemapTintZero
	float ___RemapTintZero_38;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackWhiteBalance_HDRP::RemapTintOne
	float ___RemapTintOne_39;
};

struct MMFeedbackWhiteBalance_HDRP_t4D7756DFBD852A605B201C0F63F472455C03E48E_StaticFields
{
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMFeedbackWhiteBalance_HDRP::FeedbackTypeAuthorized
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

// MoreMountains.FeedbacksForThirdParty.MMBloomShaker_HDRP
struct MMBloomShaker_HDRP_tD2D9A71961AFE4E5FFFDAD5E37B7DB19DD990CA8  : public MMShaker_t48AAF716B7D3FC0C6FB15A32772D7DF0D57FCC31
{
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMBloomShaker_HDRP::RelativeValues
	bool ___RelativeValues_20;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMBloomShaker_HDRP::ShakeIntensity
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___ShakeIntensity_21;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMBloomShaker_HDRP::RemapIntensityZero
	float ___RemapIntensityZero_22;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMBloomShaker_HDRP::RemapIntensityOne
	float ___RemapIntensityOne_23;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMBloomShaker_HDRP::ShakeThreshold
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___ShakeThreshold_24;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMBloomShaker_HDRP::RemapThresholdZero
	float ___RemapThresholdZero_25;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMBloomShaker_HDRP::RemapThresholdOne
	float ___RemapThresholdOne_26;
};

// MoreMountains.FeedbacksForThirdParty.MMChannelMixerShaker_HDRP
struct MMChannelMixerShaker_HDRP_t78DBC564D348F7D72193C967D7866E87F57079FE  : public MMShaker_t48AAF716B7D3FC0C6FB15A32772D7DF0D57FCC31
{
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMChannelMixerShaker_HDRP::RelativeValues
	bool ___RelativeValues_20;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMChannelMixerShaker_HDRP::ShakeRed
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___ShakeRed_21;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMChannelMixerShaker_HDRP::RemapRedZero
	float ___RemapRedZero_22;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMChannelMixerShaker_HDRP::RemapRedOne
	float ___RemapRedOne_23;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMChannelMixerShaker_HDRP::ShakeGreen
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___ShakeGreen_24;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMChannelMixerShaker_HDRP::RemapGreenZero
	float ___RemapGreenZero_25;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMChannelMixerShaker_HDRP::RemapGreenOne
	float ___RemapGreenOne_26;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMChannelMixerShaker_HDRP::ShakeBlue
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___ShakeBlue_27;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMChannelMixerShaker_HDRP::RemapBlueZero
	float ___RemapBlueZero_28;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMChannelMixerShaker_HDRP::RemapBlueOne
	float ___RemapBlueOne_29;
};

// MoreMountains.FeedbacksForThirdParty.MMChromaticAberrationShaker_HDRP
struct MMChromaticAberrationShaker_HDRP_t472F090F0A238CD24FFB7783BEFAE79680D74ECD  : public MMShaker_t48AAF716B7D3FC0C6FB15A32772D7DF0D57FCC31
{
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMChromaticAberrationShaker_HDRP::RelativeIntensity
	bool ___RelativeIntensity_20;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMChromaticAberrationShaker_HDRP::ShakeIntensity
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___ShakeIntensity_21;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMChromaticAberrationShaker_HDRP::RemapIntensityZero
	float ___RemapIntensityZero_22;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMChromaticAberrationShaker_HDRP::RemapIntensityOne
	float ___RemapIntensityOne_23;
};

// MoreMountains.FeedbacksForThirdParty.MMColorAdjustmentsShaker_HDRP
struct MMColorAdjustmentsShaker_HDRP_t9171C6E1A7365800B6688933DC93F11BC338793A  : public MMShaker_t48AAF716B7D3FC0C6FB15A32772D7DF0D57FCC31
{
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMColorAdjustmentsShaker_HDRP::RelativeValues
	bool ___RelativeValues_20;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMColorAdjustmentsShaker_HDRP::ShakePostExposure
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___ShakePostExposure_21;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMColorAdjustmentsShaker_HDRP::RemapPostExposureZero
	float ___RemapPostExposureZero_22;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMColorAdjustmentsShaker_HDRP::RemapPostExposureOne
	float ___RemapPostExposureOne_23;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMColorAdjustmentsShaker_HDRP::ShakeHueShift
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___ShakeHueShift_24;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMColorAdjustmentsShaker_HDRP::RemapHueShiftZero
	float ___RemapHueShiftZero_25;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMColorAdjustmentsShaker_HDRP::RemapHueShiftOne
	float ___RemapHueShiftOne_26;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMColorAdjustmentsShaker_HDRP::ShakeSaturation
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___ShakeSaturation_27;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMColorAdjustmentsShaker_HDRP::RemapSaturationZero
	float ___RemapSaturationZero_28;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMColorAdjustmentsShaker_HDRP::RemapSaturationOne
	float ___RemapSaturationOne_29;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMColorAdjustmentsShaker_HDRP::ShakeContrast
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___ShakeContrast_30;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMColorAdjustmentsShaker_HDRP::RemapContrastZero
	float ___RemapContrastZero_31;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMColorAdjustmentsShaker_HDRP::RemapContrastOne
	float ___RemapContrastOne_32;
	// MoreMountains.FeedbacksForThirdParty.MMColorAdjustmentsShaker_HDRP/ColorFilterModes MoreMountains.FeedbacksForThirdParty.MMColorAdjustmentsShaker_HDRP::ColorFilterMode
	int32_t ___ColorFilterMode_33;
	// UnityEngine.Gradient MoreMountains.FeedbacksForThirdParty.MMColorAdjustmentsShaker_HDRP::ColorFilterGradient
	Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E* ___ColorFilterGradient_34;
	// UnityEngine.Color MoreMountains.FeedbacksForThirdParty.MMColorAdjustmentsShaker_HDRP::ColorFilterDestination
	Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___ColorFilterDestination_35;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMColorAdjustmentsShaker_HDRP::ColorFilterCurve
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___ColorFilterCurve_36;
};

// MoreMountains.FeedbacksForThirdParty.MMExposureShaker_HDRP
struct MMExposureShaker_HDRP_t178AB71E45D967A121DFA78C5761DC7F02CC94BD  : public MMShaker_t48AAF716B7D3FC0C6FB15A32772D7DF0D57FCC31
{
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMExposureShaker_HDRP::RelativeIntensity
	bool ___RelativeIntensity_20;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMExposureShaker_HDRP::ShakeFixedExposure
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___ShakeFixedExposure_21;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMExposureShaker_HDRP::RemapFixedExposureZero
	float ___RemapFixedExposureZero_22;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMExposureShaker_HDRP::RemapFixedExposureOne
	float ___RemapFixedExposureOne_23;
};

// MoreMountains.FeedbacksForThirdParty.MMFilmGrainShaker_HDRP
struct MMFilmGrainShaker_HDRP_t642417F8C9001ECE6687F790C023D752011D9BC9  : public MMShaker_t48AAF716B7D3FC0C6FB15A32772D7DF0D57FCC31
{
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMFilmGrainShaker_HDRP::RelativeIntensity
	bool ___RelativeIntensity_20;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMFilmGrainShaker_HDRP::ShakeIntensity
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___ShakeIntensity_21;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMFilmGrainShaker_HDRP::RemapIntensityZero
	float ___RemapIntensityZero_22;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMFilmGrainShaker_HDRP::RemapIntensityOne
	float ___RemapIntensityOne_23;
};

// MoreMountains.FeedbacksForThirdParty.MMLensDistortionShaker_HDRP
struct MMLensDistortionShaker_HDRP_t0B49054863BD3B0C6DEBFDCD95FD027FC66E31A4  : public MMShaker_t48AAF716B7D3FC0C6FB15A32772D7DF0D57FCC31
{
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMLensDistortionShaker_HDRP::RelativeIntensity
	bool ___RelativeIntensity_20;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMLensDistortionShaker_HDRP::ShakeIntensity
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___ShakeIntensity_21;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMLensDistortionShaker_HDRP::RemapIntensityZero
	float ___RemapIntensityZero_22;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMLensDistortionShaker_HDRP::RemapIntensityOne
	float ___RemapIntensityOne_23;
};

// MoreMountains.FeedbacksForThirdParty.MMMotionBlurShaker_HDRP
struct MMMotionBlurShaker_HDRP_t2143D5FAF199B1BF22C56DC7A080A2A0BA6AEC3A  : public MMShaker_t48AAF716B7D3FC0C6FB15A32772D7DF0D57FCC31
{
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMMotionBlurShaker_HDRP::RelativeIntensity
	bool ___RelativeIntensity_20;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMMotionBlurShaker_HDRP::ShakeIntensity
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___ShakeIntensity_21;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMMotionBlurShaker_HDRP::RemapIntensityZero
	float ___RemapIntensityZero_22;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMMotionBlurShaker_HDRP::RemapIntensityOne
	float ___RemapIntensityOne_23;
};

// MoreMountains.FeedbacksForThirdParty.MMPaniniProjectionShaker_HDRP
struct MMPaniniProjectionShaker_HDRP_t8AD69F4068D255EDE69BA9597B9EAF1AB4641054  : public MMShaker_t48AAF716B7D3FC0C6FB15A32772D7DF0D57FCC31
{
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMPaniniProjectionShaker_HDRP::RelativeDistance
	bool ___RelativeDistance_20;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMPaniniProjectionShaker_HDRP::ShakeDistance
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___ShakeDistance_21;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMPaniniProjectionShaker_HDRP::RemapDistanceZero
	float ___RemapDistanceZero_22;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMPaniniProjectionShaker_HDRP::RemapDistanceOne
	float ___RemapDistanceOne_23;
};

// MoreMountains.FeedbacksForThirdParty.MMVignetteShaker_HDRP
struct MMVignetteShaker_HDRP_t210D4D7C056D8ECE4C934F3A13B817FA2EEDB376  : public MMShaker_t48AAF716B7D3FC0C6FB15A32772D7DF0D57FCC31
{
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMVignetteShaker_HDRP::RelativeIntensity
	bool ___RelativeIntensity_20;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMVignetteShaker_HDRP::ShakeIntensity
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___ShakeIntensity_21;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMVignetteShaker_HDRP::RemapIntensityZero
	float ___RemapIntensityZero_22;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMVignetteShaker_HDRP::RemapIntensityOne
	float ___RemapIntensityOne_23;
};

// MoreMountains.FeedbacksForThirdParty.MMWhiteBalanceShaker_HDRP
struct MMWhiteBalanceShaker_HDRP_t65113CD3FFAFC79CAE06093A6D758FB158F20A63  : public MMShaker_t48AAF716B7D3FC0C6FB15A32772D7DF0D57FCC31
{
	// System.Boolean MoreMountains.FeedbacksForThirdParty.MMWhiteBalanceShaker_HDRP::RelativeValues
	bool ___RelativeValues_20;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMWhiteBalanceShaker_HDRP::ShakeTemperature
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___ShakeTemperature_21;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMWhiteBalanceShaker_HDRP::RemapTemperatureZero
	float ___RemapTemperatureZero_22;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMWhiteBalanceShaker_HDRP::RemapTemperatureOne
	float ___RemapTemperatureOne_23;
	// UnityEngine.AnimationCurve MoreMountains.FeedbacksForThirdParty.MMWhiteBalanceShaker_HDRP::ShakeTint
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___ShakeTint_24;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMWhiteBalanceShaker_HDRP::RemapTintZero
	float ___RemapTintZero_25;
	// System.Single MoreMountains.FeedbacksForThirdParty.MMWhiteBalanceShaker_HDRP::RemapTintOne
	float ___RemapTintOne_26;
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

IL2CPP_EXTERN_C void AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke(const AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354& unmarshaled, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshaled_pinvoke& marshaled);
IL2CPP_EXTERN_C void AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke_back(const AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshaled_pinvoke& marshaled, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354& unmarshaled);
IL2CPP_EXTERN_C void AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke_cleanup(AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshaled_pinvoke& marshaled);
IL2CPP_EXTERN_C void Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E_marshal_pinvoke(const Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E& unmarshaled, Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E_marshaled_pinvoke& marshaled);
IL2CPP_EXTERN_C void Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E_marshal_pinvoke_back(const Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E_marshaled_pinvoke& marshaled, Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E& unmarshaled);
IL2CPP_EXTERN_C void Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E_marshal_pinvoke_cleanup(Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E_marshaled_pinvoke& marshaled);


// System.Void MoreMountains.FeedbacksForThirdParty.MMBloomShakeEvent_HDRP::Trigger(UnityEngine.AnimationCurve,System.Single,System.Single,System.Single,UnityEngine.AnimationCurve,System.Single,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMBloomShakeEvent_HDRP_Trigger_mD6CDB0DABD19FEA6B4F331F7D6F6EBF0B683F7DD (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___threshold4, float ___remapThresholdMin5, float ___remapThresholdMax6, bool ___relativeIntensity7, float ___attenuation8, int32_t ___channel9, bool ___resetShakerValuesAfterShake10, bool ___resetTargetValuesAfterShake11, bool ___forwardDirection12, int32_t ___timescaleMode13, bool ___stop14, const RuntimeMethod* method) ;
// System.Void MoreMountains.Feedbacks.MMFeedback::CustomStopFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedback_CustomStopFeedback_m812755E219AA8EF519A2D89F6C91AB793AE27EDD (MMFeedback_tE51A2F7A01B1E3BE46047E5A0D6BA5C79199FDCA* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) ;
// System.Void UnityEngine.Keyframe::.ctor(System.Single,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34 (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0* __this, float ___time0, float ___value1, const RuntimeMethod* method) ;
// System.Void UnityEngine.AnimationCurve::.ctor(UnityEngine.Keyframe[])
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AnimationCurve__ctor_mEABC98C03805713354D61E50D9340766BD5B717E (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* __this, KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* ___keys0, const RuntimeMethod* method) ;
// System.Void MoreMountains.Feedbacks.MMFeedback::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedback__ctor_mCD506F8FC949D7574B8EB30A5C0CC117C19BD647 (MMFeedback_tE51A2F7A01B1E3BE46047E5A0D6BA5C79199FDCA* __this, const RuntimeMethod* method) ;
// System.Void MoreMountains.FeedbacksForThirdParty.MMChannelMixerShakeEvent_HDRP::Trigger(UnityEngine.AnimationCurve,System.Single,System.Single,UnityEngine.AnimationCurve,System.Single,System.Single,UnityEngine.AnimationCurve,System.Single,System.Single,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMChannelMixerShakeEvent_HDRP_Trigger_m0137922D2B53BC7162F552A9F4CD722733123CF7 (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeRed0, float ___remapRedZero1, float ___remapRedOne2, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeGreen3, float ___remapGreenZero4, float ___remapGreenOne5, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeBlue6, float ___remapBlueZero7, float ___remapBlueOne8, float ___duration9, bool ___relativeValues10, float ___attenuation11, int32_t ___channel12, bool ___resetShakerValuesAfterShake13, bool ___resetTargetValuesAfterShake14, bool ___forwardDirection15, int32_t ___timescaleMode16, bool ___stop17, const RuntimeMethod* method) ;
// System.Void MoreMountains.FeedbacksForThirdParty.MMChromaticAberrationShakeEvent_HDRP::Trigger(UnityEngine.AnimationCurve,System.Single,System.Single,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMChromaticAberrationShakeEvent_HDRP_Trigger_m2BF26327003EB129A7B88CBA28534150C418456E (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method) ;
// System.Void MoreMountains.FeedbacksForThirdParty.MMColorAdjustmentsShakeEvent_HDRP::Trigger(UnityEngine.AnimationCurve,System.Single,System.Single,UnityEngine.AnimationCurve,System.Single,System.Single,UnityEngine.AnimationCurve,System.Single,System.Single,UnityEngine.AnimationCurve,System.Single,System.Single,MoreMountains.FeedbacksForThirdParty.MMColorAdjustmentsShaker_HDRP/ColorFilterModes,UnityEngine.Gradient,UnityEngine.Color,UnityEngine.AnimationCurve,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMColorAdjustmentsShakeEvent_HDRP_Trigger_mEFEAD45DF484AF38F46422ABDEE911B21935BB16 (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakePostExposure0, float ___remapPostExposureZero1, float ___remapPostExposureOne2, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeHueShift3, float ___remapHueShiftZero4, float ___remapHueShiftOne5, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeSaturation6, float ___remapSaturationZero7, float ___remapSaturationOne8, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeContrast9, float ___remapContrastZero10, float ___remapContrastOne11, int32_t ___colorFilterMode12, Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E* ___colorFilterGradient13, Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___colorFilterDestination14, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___colorFilterCurve15, float ___duration16, bool ___relativeValues17, float ___attenuation18, int32_t ___channel19, bool ___resetShakerValuesAfterShake20, bool ___resetTargetValuesAfterShake21, bool ___forwardDirection22, int32_t ___timescaleMode23, bool ___stop24, const RuntimeMethod* method) ;
// UnityEngine.Color UnityEngine.Color::get_yellow()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Color_tD001788D726C3A7F1379BEED0260B9591F440C1F Color_get_yellow_m66637FA14383E8D74F24AE256B577CE1D55D469F_inline (const RuntimeMethod* method) ;
// System.Void MoreMountains.FeedbacksForThirdParty.MMExposureShakeEvent_HDRP::Trigger(UnityEngine.AnimationCurve,System.Single,System.Single,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMExposureShakeEvent_HDRP_Trigger_m1896AC3294CC9A9ECAC33EBE25DD0E9FD7E816A6 (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___fixedExposure0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeFixedExposure4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method) ;
// System.Void MoreMountains.FeedbacksForThirdParty.MMFilmGrainShakeEvent_HDRP::Trigger(UnityEngine.AnimationCurve,System.Single,System.Single,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFilmGrainShakeEvent_HDRP_Trigger_mE93E1C6A7C883DD107BBDFDFAA8D8FDC6090D147 (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method) ;
// System.Void MoreMountains.FeedbacksForThirdParty.MMLensDistortionShakeEvent_HDRP::Trigger(UnityEngine.AnimationCurve,System.Single,System.Single,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMLensDistortionShakeEvent_HDRP_Trigger_mDACE6D0F2A1411F1F1D8914EF04250023C3065BC (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method) ;
// System.Void MoreMountains.FeedbacksForThirdParty.MMMotionBlurShakeEvent_HDRP::Trigger(UnityEngine.AnimationCurve,System.Single,System.Single,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMMotionBlurShakeEvent_HDRP_Trigger_m91FD70589D40180513688CF1469168B97995EE6C (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method) ;
// System.Void MoreMountains.FeedbacksForThirdParty.MMPaniniProjectionShakeEvent_HDRP::Trigger(UnityEngine.AnimationCurve,System.Single,System.Single,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMPaniniProjectionShakeEvent_HDRP_Trigger_m8BC36B04EDE4E0A775110B51573142062BE2209F (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___distance0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeDistance4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method) ;
// System.Void MoreMountains.FeedbacksForThirdParty.MMVignetteShakeEvent_HDRP::Trigger(UnityEngine.AnimationCurve,System.Single,System.Single,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMVignetteShakeEvent_HDRP_Trigger_mF821317AF76CAA81B63DAD57A3D4DB379EF40B47 (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method) ;
// System.Void MoreMountains.FeedbacksForThirdParty.MMWhiteBalanceShakeEvent_HDRP::Trigger(UnityEngine.AnimationCurve,System.Single,System.Single,System.Single,UnityEngine.AnimationCurve,System.Single,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMWhiteBalanceShakeEvent_HDRP_Trigger_mAB52FBCD73353B6F59806FD3216FFCCA35F97A6D (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___temperature0, float ___duration1, float ___remapTemperatureMin2, float ___remapTemperatureMax3, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___tint4, float ___remapTintMin5, float ___remapTintMax6, bool ___relativeValues7, float ___attenuation8, int32_t ___channel9, bool ___resetShakerValuesAfterShake10, bool ___resetTargetValuesAfterShake11, bool ___forwardDirection12, int32_t ___timescaleMode13, bool ___stop14, const RuntimeMethod* method) ;
// System.Void MoreMountains.Feedbacks.MMF_Feedback::CustomStopFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_Feedback_CustomStopFeedback_m9388036D957D90AD8C6BC3C4B17AC9A7B3B49A30 (MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) ;
// System.Void MoreMountains.Feedbacks.MMF_Feedback::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_Feedback__ctor_mCD413701DAEE304A0840C520FF3EB470EE324AC5 (MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D* __this, const RuntimeMethod* method) ;
// System.Void MoreMountains.Feedbacks.MMShaker::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMShaker__ctor_mF8C6BFF676BA0F272791D3B64B0E5EB2E598A709 (MMShaker_t48AAF716B7D3FC0C6FB15A32772D7DF0D57FCC31* __this, const RuntimeMethod* method) ;
// System.Delegate System.Delegate::Combine(System.Delegate,System.Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Delegate_t* Delegate_Combine_m1F725AEF318BE6F0426863490691A6F4606E7D00 (Delegate_t* ___a0, Delegate_t* ___b1, const RuntimeMethod* method) ;
// System.Delegate System.Delegate::Remove(System.Delegate,System.Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Delegate_t* Delegate_Remove_m8B7DD5661308FA972E23CA1CC3FC9CEB355504E3 (Delegate_t* ___source0, Delegate_t* ___value1, const RuntimeMethod* method) ;
// System.Void MoreMountains.FeedbacksForThirdParty.MMBloomShakeEvent_HDRP::add_OnEvent(MoreMountains.FeedbacksForThirdParty.MMBloomShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMBloomShakeEvent_HDRP_add_OnEvent_mFC9B6DC3932EDF1182F55480809688638725AEE8 (Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8* ___value0, const RuntimeMethod* method) ;
// System.Void MoreMountains.FeedbacksForThirdParty.MMBloomShakeEvent_HDRP::remove_OnEvent(MoreMountains.FeedbacksForThirdParty.MMBloomShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMBloomShakeEvent_HDRP_remove_OnEvent_m4BF14FE9ABCFE9929BCBD0267E79F6F1B232A901 (Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8* ___value0, const RuntimeMethod* method) ;
// System.Void MoreMountains.FeedbacksForThirdParty.MMBloomShakeEvent_HDRP/Delegate::Invoke(UnityEngine.AnimationCurve,System.Single,System.Single,System.Single,UnityEngine.AnimationCurve,System.Single,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Delegate_Invoke_mF7FAC8B0ACC743B9DE90ADF2388F38135399AD35_inline (Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___threshold4, float ___remapThresholdMin5, float ___remapThresholdMax6, bool ___relativeIntensity7, float ___attenuation8, int32_t ___channel9, bool ___resetShakerValuesAfterShake10, bool ___resetTargetValuesAfterShake11, bool ___forwardDirection12, int32_t ___timescaleMode13, bool ___stop14, const RuntimeMethod* method) ;
// System.Void MoreMountains.FeedbacksForThirdParty.MMChannelMixerShakeEvent_HDRP::add_OnEvent(MoreMountains.FeedbacksForThirdParty.MMChannelMixerShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMChannelMixerShakeEvent_HDRP_add_OnEvent_m5E67DDF1A02305E222B01893CC707F59E4B19C05 (Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176* ___value0, const RuntimeMethod* method) ;
// System.Void MoreMountains.FeedbacksForThirdParty.MMChannelMixerShakeEvent_HDRP::remove_OnEvent(MoreMountains.FeedbacksForThirdParty.MMChannelMixerShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMChannelMixerShakeEvent_HDRP_remove_OnEvent_m21FBD55F43B1BC94894908F7EA57B7C6D824DA48 (Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176* ___value0, const RuntimeMethod* method) ;
// System.Void MoreMountains.FeedbacksForThirdParty.MMChannelMixerShakeEvent_HDRP/Delegate::Invoke(UnityEngine.AnimationCurve,System.Single,System.Single,UnityEngine.AnimationCurve,System.Single,System.Single,UnityEngine.AnimationCurve,System.Single,System.Single,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Delegate_Invoke_m1BF2E87CE04FB3085F026AEF72BB8D6BB6AE1483_inline (Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeRed0, float ___remapRedZero1, float ___remapRedOne2, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeGreen3, float ___remapGreenZero4, float ___remapGreenOne5, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeBlue6, float ___remapBlueZero7, float ___remapBlueOne8, float ___duration9, bool ___relativeValues10, float ___attenuation11, int32_t ___channel12, bool ___resetShakerValuesAfterShake13, bool ___resetTargetValuesAfterShake14, bool ___forwardDirection15, int32_t ___timescaleMode16, bool ___stop17, const RuntimeMethod* method) ;
// System.Void MoreMountains.FeedbacksForThirdParty.MMChromaticAberrationShakeEvent_HDRP::add_OnEvent(MoreMountains.FeedbacksForThirdParty.MMChromaticAberrationShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMChromaticAberrationShakeEvent_HDRP_add_OnEvent_m6E3CD5B372C7F98B31673ADD478D65A8CC7FCB82 (Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2* ___value0, const RuntimeMethod* method) ;
// System.Void MoreMountains.FeedbacksForThirdParty.MMChromaticAberrationShakeEvent_HDRP::remove_OnEvent(MoreMountains.FeedbacksForThirdParty.MMChromaticAberrationShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMChromaticAberrationShakeEvent_HDRP_remove_OnEvent_m8796459E997E5C5BBAE2F7F3DD7C86BE19387A82 (Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2* ___value0, const RuntimeMethod* method) ;
// System.Void MoreMountains.FeedbacksForThirdParty.MMChromaticAberrationShakeEvent_HDRP/Delegate::Invoke(UnityEngine.AnimationCurve,System.Single,System.Single,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Delegate_Invoke_mD47FC069DCC89CDB71DF4618BC9D58ABA8AF77A3_inline (Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method) ;
// System.Void MoreMountains.FeedbacksForThirdParty.MMColorAdjustmentsShakeEvent_HDRP::add_OnEvent(MoreMountains.FeedbacksForThirdParty.MMColorAdjustmentsShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMColorAdjustmentsShakeEvent_HDRP_add_OnEvent_m80DBD8516C0450D107EEBA6413A4C5CADB4BB21F (Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19* ___value0, const RuntimeMethod* method) ;
// System.Void MoreMountains.FeedbacksForThirdParty.MMColorAdjustmentsShakeEvent_HDRP::remove_OnEvent(MoreMountains.FeedbacksForThirdParty.MMColorAdjustmentsShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMColorAdjustmentsShakeEvent_HDRP_remove_OnEvent_m1FACF78DED1583793CE088198D88C6A2842BA5BD (Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19* ___value0, const RuntimeMethod* method) ;
// System.Void MoreMountains.FeedbacksForThirdParty.MMColorAdjustmentsShakeEvent_HDRP/Delegate::Invoke(UnityEngine.AnimationCurve,System.Single,System.Single,UnityEngine.AnimationCurve,System.Single,System.Single,UnityEngine.AnimationCurve,System.Single,System.Single,UnityEngine.AnimationCurve,System.Single,System.Single,MoreMountains.FeedbacksForThirdParty.MMColorAdjustmentsShaker_HDRP/ColorFilterModes,UnityEngine.Gradient,UnityEngine.Color,UnityEngine.AnimationCurve,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Delegate_Invoke_mF4923867EB16C9EB4E8B71E48F04C5173E122D3A_inline (Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakePostExposure0, float ___remapPostExposureZero1, float ___remapPostExposureOne2, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeHueShift3, float ___remapHueShiftZero4, float ___remapHueShiftOne5, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeSaturation6, float ___remapSaturationZero7, float ___remapSaturationOne8, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeContrast9, float ___remapContrastZero10, float ___remapContrastOne11, int32_t ___colorFilterMode12, Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E* ___colorFilterGradient13, Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___colorFilterDestination14, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___colorFilterCurve15, float ___duration16, bool ___relativeValues17, float ___attenuation18, int32_t ___channel19, bool ___resetShakerValuesAfterShake20, bool ___resetTargetValuesAfterShake21, bool ___forwardDirection22, int32_t ___timescaleMode23, bool ___stop24, const RuntimeMethod* method) ;
// System.Void MoreMountains.FeedbacksForThirdParty.MMExposureShakeEvent_HDRP::add_OnEvent(MoreMountains.FeedbacksForThirdParty.MMExposureShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMExposureShakeEvent_HDRP_add_OnEvent_mA396F83872851E4C98D4979DB69DA5871A3AF03B (Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0* ___value0, const RuntimeMethod* method) ;
// System.Void MoreMountains.FeedbacksForThirdParty.MMExposureShakeEvent_HDRP::remove_OnEvent(MoreMountains.FeedbacksForThirdParty.MMExposureShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMExposureShakeEvent_HDRP_remove_OnEvent_m2437F0ED157BD98B104D7279467B576072CB9EA3 (Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0* ___value0, const RuntimeMethod* method) ;
// System.Void MoreMountains.FeedbacksForThirdParty.MMExposureShakeEvent_HDRP/Delegate::Invoke(UnityEngine.AnimationCurve,System.Single,System.Single,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Delegate_Invoke_mB3B6C56776FE0B118D170C735745148F1F55D1E8_inline (Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___fixedExposure0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeFixedExposure4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method) ;
// System.Void MoreMountains.FeedbacksForThirdParty.MMFilmGrainShakeEvent_HDRP::add_OnEvent(MoreMountains.FeedbacksForThirdParty.MMFilmGrainShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFilmGrainShakeEvent_HDRP_add_OnEvent_mAADB23B251FEA84CA61F5FB4BEB2385DE7F0F507 (Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15* ___value0, const RuntimeMethod* method) ;
// System.Void MoreMountains.FeedbacksForThirdParty.MMFilmGrainShakeEvent_HDRP::remove_OnEvent(MoreMountains.FeedbacksForThirdParty.MMFilmGrainShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFilmGrainShakeEvent_HDRP_remove_OnEvent_mA677E16C938DEB6380C0F737358347A8EB7C15A0 (Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15* ___value0, const RuntimeMethod* method) ;
// System.Void MoreMountains.FeedbacksForThirdParty.MMFilmGrainShakeEvent_HDRP/Delegate::Invoke(UnityEngine.AnimationCurve,System.Single,System.Single,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Delegate_Invoke_mA4BC5FEA6FD70F9E70251A4AC32D5E91CD5D0ED3_inline (Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method) ;
// System.Void MoreMountains.FeedbacksForThirdParty.MMLensDistortionShakeEvent_HDRP::add_OnEvent(MoreMountains.FeedbacksForThirdParty.MMLensDistortionShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMLensDistortionShakeEvent_HDRP_add_OnEvent_m5659AB86CAA44AA21940C4D9388C8654ECAAB464 (Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994* ___value0, const RuntimeMethod* method) ;
// System.Void MoreMountains.FeedbacksForThirdParty.MMLensDistortionShakeEvent_HDRP::remove_OnEvent(MoreMountains.FeedbacksForThirdParty.MMLensDistortionShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMLensDistortionShakeEvent_HDRP_remove_OnEvent_mD8296A9B3F361FA3CC53A486795BF188100EF1C4 (Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994* ___value0, const RuntimeMethod* method) ;
// System.Void MoreMountains.FeedbacksForThirdParty.MMLensDistortionShakeEvent_HDRP/Delegate::Invoke(UnityEngine.AnimationCurve,System.Single,System.Single,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Delegate_Invoke_mDA47912E1B3F9FE408E601FA5C1227E138AEABAD_inline (Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method) ;
// System.Void MoreMountains.FeedbacksForThirdParty.MMMotionBlurShakeEvent_HDRP::add_OnEvent(MoreMountains.FeedbacksForThirdParty.MMMotionBlurShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMMotionBlurShakeEvent_HDRP_add_OnEvent_m2B55597C397FF978CFC7D73923DC247A8E24B312 (Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8* ___value0, const RuntimeMethod* method) ;
// System.Void MoreMountains.FeedbacksForThirdParty.MMMotionBlurShakeEvent_HDRP::remove_OnEvent(MoreMountains.FeedbacksForThirdParty.MMMotionBlurShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMMotionBlurShakeEvent_HDRP_remove_OnEvent_m8D97E1F5258AE3BB04715EA773F43BF08A8D99E0 (Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8* ___value0, const RuntimeMethod* method) ;
// System.Void MoreMountains.FeedbacksForThirdParty.MMMotionBlurShakeEvent_HDRP/Delegate::Invoke(UnityEngine.AnimationCurve,System.Single,System.Single,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Delegate_Invoke_mDC19B891E8784D90FDB7B09764639E93850BC2EA_inline (Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method) ;
// System.Void MoreMountains.FeedbacksForThirdParty.MMPaniniProjectionShakeEvent_HDRP::add_OnEvent(MoreMountains.FeedbacksForThirdParty.MMPaniniProjectionShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMPaniniProjectionShakeEvent_HDRP_add_OnEvent_m1EA38950F7D81041ACD9CBF4A07581A3F8554DC6 (Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79* ___value0, const RuntimeMethod* method) ;
// System.Void MoreMountains.FeedbacksForThirdParty.MMPaniniProjectionShakeEvent_HDRP::remove_OnEvent(MoreMountains.FeedbacksForThirdParty.MMPaniniProjectionShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMPaniniProjectionShakeEvent_HDRP_remove_OnEvent_m1060630D1CE706CD84255E6DA2F7EED5796C8FE5 (Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79* ___value0, const RuntimeMethod* method) ;
// System.Void MoreMountains.FeedbacksForThirdParty.MMPaniniProjectionShakeEvent_HDRP/Delegate::Invoke(UnityEngine.AnimationCurve,System.Single,System.Single,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Delegate_Invoke_m6BBDE2816C59B866513C70D4B1CE63FE43C95414_inline (Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___distance0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeDistance4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method) ;
// System.Void MoreMountains.FeedbacksForThirdParty.MMVignetteShakeEvent_HDRP::add_OnEvent(MoreMountains.FeedbacksForThirdParty.MMVignetteShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMVignetteShakeEvent_HDRP_add_OnEvent_m94469987DF4BA63AE35681FD67943A67B111FB21 (Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78* ___value0, const RuntimeMethod* method) ;
// System.Void MoreMountains.FeedbacksForThirdParty.MMVignetteShakeEvent_HDRP::remove_OnEvent(MoreMountains.FeedbacksForThirdParty.MMVignetteShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMVignetteShakeEvent_HDRP_remove_OnEvent_mB24A5FEF84AA3B83E933E4FF687006B351A6541B (Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78* ___value0, const RuntimeMethod* method) ;
// System.Void MoreMountains.FeedbacksForThirdParty.MMVignetteShakeEvent_HDRP/Delegate::Invoke(UnityEngine.AnimationCurve,System.Single,System.Single,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Delegate_Invoke_mE669B4A49B0DC7BA342141849CCF6770DCD7EE31_inline (Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method) ;
// System.Void MoreMountains.FeedbacksForThirdParty.MMWhiteBalanceShakeEvent_HDRP::add_OnEvent(MoreMountains.FeedbacksForThirdParty.MMWhiteBalanceShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMWhiteBalanceShakeEvent_HDRP_add_OnEvent_m5DEF76B1DA3AB60585FCBE0A6962354B11FBA6C6 (Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7* ___value0, const RuntimeMethod* method) ;
// System.Void MoreMountains.FeedbacksForThirdParty.MMWhiteBalanceShakeEvent_HDRP::remove_OnEvent(MoreMountains.FeedbacksForThirdParty.MMWhiteBalanceShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMWhiteBalanceShakeEvent_HDRP_remove_OnEvent_m298BFA2E2BAE1232FEA8B604CE19155F362DCCFE (Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7* ___value0, const RuntimeMethod* method) ;
// System.Void MoreMountains.FeedbacksForThirdParty.MMWhiteBalanceShakeEvent_HDRP/Delegate::Invoke(UnityEngine.AnimationCurve,System.Single,System.Single,System.Single,UnityEngine.AnimationCurve,System.Single,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Delegate_Invoke_mADB133D3DC64B7E1356EEE4F3C5461C4409AFF19_inline (Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___temperature0, float ___duration1, float ___remapTemperatureMin2, float ___remapTemperatureMax3, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___tint4, float ___remapTintMin5, float ___remapTintMax6, bool ___relativeValues7, float ___attenuation8, int32_t ___channel9, bool ___resetShakerValuesAfterShake10, bool ___resetTargetValuesAfterShake11, bool ___forwardDirection12, int32_t ___timescaleMode13, bool ___stop14, const RuntimeMethod* method) ;
// System.Void UnityEngine.Color::.ctor(System.Single,System.Single,System.Single,System.Single)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Color__ctor_m3786F0D6E510D9CFA544523A955870BD2A514C8C_inline (Color_tD001788D726C3A7F1379BEED0260B9591F440C1F* __this, float ___r0, float ___g1, float ___b2, float ___a3, const RuntimeMethod* method) ;
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
// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackBloom_HDRP::get_FeedbackDuration()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float MMFeedbackBloom_HDRP_get_FeedbackDuration_m7447EE817BB0F086500E472C9EA62B296293C94C (MMFeedbackBloom_HDRP_t0BF688EBD458BA2F7F0E5834DBC5E2011CD66174* __this, const RuntimeMethod* method) 
{
	{
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(ShakeDuration); }  set { ShakeDuration = value;  } }
		float L_0 = __this->___ShakeDuration_30;
		float L_1;
		L_1 = VirtualFuncInvoker1< float, float >::Invoke(36 /* System.Single MoreMountains.Feedbacks.MMFeedback::ApplyTimeMultiplier(System.Single) */, __this, L_0);
		return L_1;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackBloom_HDRP::set_FeedbackDuration(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackBloom_HDRP_set_FeedbackDuration_m6889C6F38A830EF9347B741DCB2400A094B6925B (MMFeedbackBloom_HDRP_t0BF688EBD458BA2F7F0E5834DBC5E2011CD66174* __this, float ___value0, const RuntimeMethod* method) 
{
	{
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(ShakeDuration); }  set { ShakeDuration = value;  } }
		float L_0 = ___value0;
		__this->___ShakeDuration_30 = L_0;
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(ShakeDuration); }  set { ShakeDuration = value;  } }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackBloom_HDRP::CustomPlayFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackBloom_HDRP_CustomPlayFeedback_m40B3E6F94B7F73C229ED0913D4620B873714FA38 (MMFeedbackBloom_HDRP_t0BF688EBD458BA2F7F0E5834DBC5E2011CD66174* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___attenuation1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMFeedbackBloom_HDRP_t0BF688EBD458BA2F7F0E5834DBC5E2011CD66174_il2cpp_TypeInfo_var);
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
		il2cpp_codegen_runtime_class_init_inline(MMFeedbackBloom_HDRP_t0BF688EBD458BA2F7F0E5834DBC5E2011CD66174_il2cpp_TypeInfo_var);
		bool L_1 = ((MMFeedbackBloom_HDRP_t0BF688EBD458BA2F7F0E5834DBC5E2011CD66174_StaticFields*)il2cpp_codegen_static_fields_for(MMFeedbackBloom_HDRP_t0BF688EBD458BA2F7F0E5834DBC5E2011CD66174_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_28;
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
		// MMBloomShakeEvent_HDRP.Trigger(ShakeIntensity, FeedbackDuration, RemapIntensityZero, RemapIntensityOne, ShakeThreshold, RemapThresholdZero, RemapThresholdOne,
		//     RelativeValues, attenuation, Channel, ResetShakerValuesAfterShake, ResetTargetValuesAfterShake, NormalPlayDirection, Timing.TimescaleMode);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_2 = __this->___ShakeIntensity_34;
		float L_3;
		L_3 = VirtualFuncInvoker0< float >::Invoke(16 /* System.Single MoreMountains.Feedbacks.MMFeedback::get_FeedbackDuration() */, __this);
		float L_4 = __this->___RemapIntensityZero_35;
		float L_5 = __this->___RemapIntensityOne_36;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_6 = __this->___ShakeThreshold_37;
		float L_7 = __this->___RemapThresholdZero_38;
		float L_8 = __this->___RemapThresholdOne_39;
		bool L_9 = __this->___RelativeValues_33;
		float L_10 = ___attenuation1;
		int32_t L_11 = __this->___Channel_29;
		bool L_12 = __this->___ResetShakerValuesAfterShake_31;
		bool L_13 = __this->___ResetTargetValuesAfterShake_32;
		bool L_14;
		L_14 = VirtualFuncInvoker0< bool >::Invoke(33 /* System.Boolean MoreMountains.Feedbacks.MMFeedback::get_NormalPlayDirection() */, __this);
		MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD* L_15 = ((MMFeedback_tE51A2F7A01B1E3BE46047E5A0D6BA5C79199FDCA*)__this)->___Timing_7;
		NullCheck(L_15);
		int32_t L_16 = L_15->___TimescaleMode_0;
		MMBloomShakeEvent_HDRP_Trigger_mD6CDB0DABD19FEA6B4F331F7D6F6EBF0B683F7DD(L_2, L_3, L_4, L_5, L_6, L_7, L_8, L_9, L_10, L_11, L_12, L_13, L_14, L_16, (bool)0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackBloom_HDRP::CustomStopFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackBloom_HDRP_CustomStopFeedback_m44230EF52F612C7FD14CEC414BA6346B9DF2877F (MMFeedbackBloom_HDRP_t0BF688EBD458BA2F7F0E5834DBC5E2011CD66174* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMFeedbackBloom_HDRP_t0BF688EBD458BA2F7F0E5834DBC5E2011CD66174_il2cpp_TypeInfo_var);
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
		il2cpp_codegen_runtime_class_init_inline(MMFeedbackBloom_HDRP_t0BF688EBD458BA2F7F0E5834DBC5E2011CD66174_il2cpp_TypeInfo_var);
		bool L_1 = ((MMFeedbackBloom_HDRP_t0BF688EBD458BA2F7F0E5834DBC5E2011CD66174_StaticFields*)il2cpp_codegen_static_fields_for(MMFeedbackBloom_HDRP_t0BF688EBD458BA2F7F0E5834DBC5E2011CD66174_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_28;
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
		// base.CustomStopFeedback(position, feedbacksIntensity);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2 = ___position0;
		float L_3 = ___feedbacksIntensity1;
		MMFeedback_CustomStopFeedback_m812755E219AA8EF519A2D89F6C91AB793AE27EDD(__this, L_2, L_3, NULL);
		// MMBloomShakeEvent_HDRP.Trigger(ShakeIntensity, FeedbackDuration, RemapIntensityZero, RemapIntensityOne, ShakeThreshold, RemapThresholdZero, RemapThresholdOne,
		//     RelativeValues, channel:Channel, stop:true);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_4 = __this->___ShakeIntensity_34;
		float L_5;
		L_5 = VirtualFuncInvoker0< float >::Invoke(16 /* System.Single MoreMountains.Feedbacks.MMFeedback::get_FeedbackDuration() */, __this);
		float L_6 = __this->___RemapIntensityZero_35;
		float L_7 = __this->___RemapIntensityOne_36;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_8 = __this->___ShakeThreshold_37;
		float L_9 = __this->___RemapThresholdZero_38;
		float L_10 = __this->___RemapThresholdOne_39;
		bool L_11 = __this->___RelativeValues_33;
		int32_t L_12 = __this->___Channel_29;
		MMBloomShakeEvent_HDRP_Trigger_mD6CDB0DABD19FEA6B4F331F7D6F6EBF0B683F7DD(L_4, L_5, L_6, L_7, L_8, L_9, L_10, L_11, (1.0f), L_12, (bool)1, (bool)1, (bool)1, 0, (bool)1, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackBloom_HDRP::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackBloom_HDRP__ctor_m9D37742B641E270B180E4ABA4A6C638E26658E60 (MMFeedbackBloom_HDRP_t0BF688EBD458BA2F7F0E5834DBC5E2011CD66174* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public float ShakeDuration = 0.2f;
		__this->___ShakeDuration_30 = (0.200000003f);
		// public bool ResetShakerValuesAfterShake = true;
		__this->___ResetShakerValuesAfterShake_31 = (bool)1;
		// public bool ResetTargetValuesAfterShake = true;
		__this->___ResetTargetValuesAfterShake_32 = (bool)1;
		// public bool RelativeValues = true;
		__this->___RelativeValues_33 = (bool)1;
		// public AnimationCurve ShakeIntensity = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
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
		__this->___ShakeIntensity_34 = L_7;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ShakeIntensity_34), (void*)L_7);
		// public float RemapIntensityOne = 1f;
		__this->___RemapIntensityOne_36 = (1.0f);
		// public AnimationCurve ShakeThreshold = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
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
		__this->___ShakeThreshold_37 = L_15;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ShakeThreshold_37), (void*)L_15);
		MMFeedback__ctor_mCD506F8FC949D7574B8EB30A5C0CC117C19BD647(__this, NULL);
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackBloom_HDRP::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackBloom_HDRP__cctor_m62A83AAEB43464781D9E86C14F8106682F321A22 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMFeedbackBloom_HDRP_t0BF688EBD458BA2F7F0E5834DBC5E2011CD66174_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public static bool FeedbackTypeAuthorized = true;
		((MMFeedbackBloom_HDRP_t0BF688EBD458BA2F7F0E5834DBC5E2011CD66174_StaticFields*)il2cpp_codegen_static_fields_for(MMFeedbackBloom_HDRP_t0BF688EBD458BA2F7F0E5834DBC5E2011CD66174_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_28 = (bool)1;
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
// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackChannelMixer_HDRP::get_FeedbackDuration()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float MMFeedbackChannelMixer_HDRP_get_FeedbackDuration_m8C2A4A81B489D8DF84DCCD29F9686CD3A692D558 (MMFeedbackChannelMixer_HDRP_tFC9637D2DBA8B0F6CE6D58226C992B5CD30B0680* __this, const RuntimeMethod* method) 
{
	{
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(ShakeDuration); } set { ShakeDuration = value; } }
		float L_0 = __this->___ShakeDuration_30;
		float L_1;
		L_1 = VirtualFuncInvoker1< float, float >::Invoke(36 /* System.Single MoreMountains.Feedbacks.MMFeedback::ApplyTimeMultiplier(System.Single) */, __this, L_0);
		return L_1;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackChannelMixer_HDRP::set_FeedbackDuration(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackChannelMixer_HDRP_set_FeedbackDuration_mA037C8379EFA72B3DBD218794C6ED85AF1785E0D (MMFeedbackChannelMixer_HDRP_tFC9637D2DBA8B0F6CE6D58226C992B5CD30B0680* __this, float ___value0, const RuntimeMethod* method) 
{
	{
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(ShakeDuration); } set { ShakeDuration = value; } }
		float L_0 = ___value0;
		__this->___ShakeDuration_30 = L_0;
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(ShakeDuration); } set { ShakeDuration = value; } }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackChannelMixer_HDRP::CustomPlayFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackChannelMixer_HDRP_CustomPlayFeedback_m41FCF42D2DBFC9F6865E8FA029157E18444E25D1 (MMFeedbackChannelMixer_HDRP_tFC9637D2DBA8B0F6CE6D58226C992B5CD30B0680* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMFeedbackChannelMixer_HDRP_tFC9637D2DBA8B0F6CE6D58226C992B5CD30B0680_il2cpp_TypeInfo_var);
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
		il2cpp_codegen_runtime_class_init_inline(MMFeedbackChannelMixer_HDRP_tFC9637D2DBA8B0F6CE6D58226C992B5CD30B0680_il2cpp_TypeInfo_var);
		bool L_1 = ((MMFeedbackChannelMixer_HDRP_tFC9637D2DBA8B0F6CE6D58226C992B5CD30B0680_StaticFields*)il2cpp_codegen_static_fields_for(MMFeedbackChannelMixer_HDRP_tFC9637D2DBA8B0F6CE6D58226C992B5CD30B0680_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_28;
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
		// float intensityMultiplier = Timing.ConstantIntensity ? 1f : feedbacksIntensity;
		MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD* L_2 = ((MMFeedback_tE51A2F7A01B1E3BE46047E5A0D6BA5C79199FDCA*)__this)->___Timing_7;
		NullCheck(L_2);
		bool L_3 = L_2->___ConstantIntensity_11;
		if (L_3)
		{
			goto IL_0020;
		}
	}
	{
		float L_4 = ___feedbacksIntensity1;
		G_B6_0 = L_4;
		goto IL_0025;
	}

IL_0020:
	{
		G_B6_0 = (1.0f);
	}

IL_0025:
	{
		V_0 = G_B6_0;
		// MMChannelMixerShakeEvent_HDRP.Trigger(ShakeRed, RemapRedZero, RemapRedOne,
		//     ShakeGreen, RemapGreenZero, RemapGreenOne,
		//     ShakeBlue, RemapBlueZero, RemapBlueOne,
		//     FeedbackDuration,
		//     RelativeIntensity, intensityMultiplier, Channel, ResetShakerValuesAfterShake, ResetTargetValuesAfterShake, NormalPlayDirection, Timing.TimescaleMode);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_5 = __this->___ShakeRed_34;
		float L_6 = __this->___RemapRedZero_35;
		float L_7 = __this->___RemapRedOne_36;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_8 = __this->___ShakeGreen_37;
		float L_9 = __this->___RemapGreenZero_38;
		float L_10 = __this->___RemapGreenOne_39;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_11 = __this->___ShakeBlue_40;
		float L_12 = __this->___RemapBlueZero_41;
		float L_13 = __this->___RemapBlueOne_42;
		float L_14;
		L_14 = VirtualFuncInvoker0< float >::Invoke(16 /* System.Single MoreMountains.Feedbacks.MMFeedback::get_FeedbackDuration() */, __this);
		bool L_15 = __this->___RelativeIntensity_31;
		float L_16 = V_0;
		int32_t L_17 = __this->___Channel_29;
		bool L_18 = __this->___ResetShakerValuesAfterShake_32;
		bool L_19 = __this->___ResetTargetValuesAfterShake_33;
		bool L_20;
		L_20 = VirtualFuncInvoker0< bool >::Invoke(33 /* System.Boolean MoreMountains.Feedbacks.MMFeedback::get_NormalPlayDirection() */, __this);
		MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD* L_21 = ((MMFeedback_tE51A2F7A01B1E3BE46047E5A0D6BA5C79199FDCA*)__this)->___Timing_7;
		NullCheck(L_21);
		int32_t L_22 = L_21->___TimescaleMode_0;
		MMChannelMixerShakeEvent_HDRP_Trigger_m0137922D2B53BC7162F552A9F4CD722733123CF7(L_5, L_6, L_7, L_8, L_9, L_10, L_11, L_12, L_13, L_14, L_15, L_16, L_17, L_18, L_19, L_20, L_22, (bool)0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackChannelMixer_HDRP::CustomStopFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackChannelMixer_HDRP_CustomStopFeedback_m1940CFE3260B5558DB6CDD5B0D134E932DEA04A2 (MMFeedbackChannelMixer_HDRP_tFC9637D2DBA8B0F6CE6D58226C992B5CD30B0680* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMFeedbackChannelMixer_HDRP_tFC9637D2DBA8B0F6CE6D58226C992B5CD30B0680_il2cpp_TypeInfo_var);
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
		il2cpp_codegen_runtime_class_init_inline(MMFeedbackChannelMixer_HDRP_tFC9637D2DBA8B0F6CE6D58226C992B5CD30B0680_il2cpp_TypeInfo_var);
		bool L_1 = ((MMFeedbackChannelMixer_HDRP_tFC9637D2DBA8B0F6CE6D58226C992B5CD30B0680_StaticFields*)il2cpp_codegen_static_fields_for(MMFeedbackChannelMixer_HDRP_tFC9637D2DBA8B0F6CE6D58226C992B5CD30B0680_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_28;
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
		// base.CustomStopFeedback(position, feedbacksIntensity);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2 = ___position0;
		float L_3 = ___feedbacksIntensity1;
		MMFeedback_CustomStopFeedback_m812755E219AA8EF519A2D89F6C91AB793AE27EDD(__this, L_2, L_3, NULL);
		// MMChannelMixerShakeEvent_HDRP.Trigger(ShakeRed, RemapRedZero, RemapRedOne,
		//     ShakeGreen, RemapGreenZero, RemapGreenOne,
		//     ShakeBlue, RemapBlueZero, RemapBlueOne,
		//     FeedbackDuration,
		//     RelativeIntensity, channel:Channel, stop:true);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_4 = __this->___ShakeRed_34;
		float L_5 = __this->___RemapRedZero_35;
		float L_6 = __this->___RemapRedOne_36;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_7 = __this->___ShakeGreen_37;
		float L_8 = __this->___RemapGreenZero_38;
		float L_9 = __this->___RemapGreenOne_39;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_10 = __this->___ShakeBlue_40;
		float L_11 = __this->___RemapBlueZero_41;
		float L_12 = __this->___RemapBlueOne_42;
		float L_13;
		L_13 = VirtualFuncInvoker0< float >::Invoke(16 /* System.Single MoreMountains.Feedbacks.MMFeedback::get_FeedbackDuration() */, __this);
		bool L_14 = __this->___RelativeIntensity_31;
		int32_t L_15 = __this->___Channel_29;
		MMChannelMixerShakeEvent_HDRP_Trigger_m0137922D2B53BC7162F552A9F4CD722733123CF7(L_4, L_5, L_6, L_7, L_8, L_9, L_10, L_11, L_12, L_13, L_14, (1.0f), L_15, (bool)1, (bool)1, (bool)1, 0, (bool)1, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackChannelMixer_HDRP::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackChannelMixer_HDRP__ctor_m90F26F158CB608C57D7782901775DAD8706CE8B3 (MMFeedbackChannelMixer_HDRP_tFC9637D2DBA8B0F6CE6D58226C992B5CD30B0680* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public float ShakeDuration = 1f;
		__this->___ShakeDuration_30 = (1.0f);
		// public bool RelativeIntensity = true;
		__this->___RelativeIntensity_31 = (bool)1;
		// public bool ResetShakerValuesAfterShake = true;
		__this->___ResetShakerValuesAfterShake_32 = (bool)1;
		// public bool ResetTargetValuesAfterShake = true;
		__this->___ResetTargetValuesAfterShake_33 = (bool)1;
		// public AnimationCurve ShakeRed = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
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
		__this->___ShakeRed_34 = L_7;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ShakeRed_34), (void*)L_7);
		// public float RemapRedOne = 200f;
		__this->___RemapRedOne_36 = (200.0f);
		// public AnimationCurve ShakeGreen = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
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
		__this->___ShakeGreen_37 = L_15;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ShakeGreen_37), (void*)L_15);
		// public float RemapGreenOne = 200f;
		__this->___RemapGreenOne_39 = (200.0f);
		// public AnimationCurve ShakeBlue = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_16 = (KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3*)(KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3*)SZArrayNew(KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var, (uint32_t)3);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_17 = L_16;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_18;
		memset((&L_18), 0, sizeof(L_18));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_18), (0.0f), (0.0f), /*hidden argument*/NULL);
		NullCheck(L_17);
		(L_17)->SetAt(static_cast<il2cpp_array_size_t>(0), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_18);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_19 = L_17;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_20;
		memset((&L_20), 0, sizeof(L_20));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_20), (0.5f), (1.0f), /*hidden argument*/NULL);
		NullCheck(L_19);
		(L_19)->SetAt(static_cast<il2cpp_array_size_t>(1), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_20);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_21 = L_19;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_22;
		memset((&L_22), 0, sizeof(L_22));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_22), (1.0f), (0.0f), /*hidden argument*/NULL);
		NullCheck(L_21);
		(L_21)->SetAt(static_cast<il2cpp_array_size_t>(2), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_22);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_23 = (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*)il2cpp_codegen_object_new(AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		NullCheck(L_23);
		AnimationCurve__ctor_mEABC98C03805713354D61E50D9340766BD5B717E(L_23, L_21, NULL);
		__this->___ShakeBlue_40 = L_23;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ShakeBlue_40), (void*)L_23);
		// public float RemapBlueOne = 200f;
		__this->___RemapBlueOne_42 = (200.0f);
		MMFeedback__ctor_mCD506F8FC949D7574B8EB30A5C0CC117C19BD647(__this, NULL);
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackChannelMixer_HDRP::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackChannelMixer_HDRP__cctor_m89E15B2DB6952EF70BF2BE0EAD83D84D110CBE51 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMFeedbackChannelMixer_HDRP_tFC9637D2DBA8B0F6CE6D58226C992B5CD30B0680_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public static bool FeedbackTypeAuthorized = true;
		((MMFeedbackChannelMixer_HDRP_tFC9637D2DBA8B0F6CE6D58226C992B5CD30B0680_StaticFields*)il2cpp_codegen_static_fields_for(MMFeedbackChannelMixer_HDRP_tFC9637D2DBA8B0F6CE6D58226C992B5CD30B0680_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_28 = (bool)1;
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
// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackChromaticAberration_HDRP::get_FeedbackDuration()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float MMFeedbackChromaticAberration_HDRP_get_FeedbackDuration_m8EE823BA0BF373DB32376A4781CA3BB149AD889C (MMFeedbackChromaticAberration_HDRP_t2F1C669FEDB2F3DD0732EF9B63569FB42EB25929* __this, const RuntimeMethod* method) 
{
	{
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(Duration); } set { Duration = value;  } }
		float L_0 = __this->___Duration_30;
		float L_1;
		L_1 = VirtualFuncInvoker1< float, float >::Invoke(36 /* System.Single MoreMountains.Feedbacks.MMFeedback::ApplyTimeMultiplier(System.Single) */, __this, L_0);
		return L_1;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackChromaticAberration_HDRP::set_FeedbackDuration(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackChromaticAberration_HDRP_set_FeedbackDuration_mA1F57691EAFCF378E8C3649677C13A50210341E0 (MMFeedbackChromaticAberration_HDRP_t2F1C669FEDB2F3DD0732EF9B63569FB42EB25929* __this, float ___value0, const RuntimeMethod* method) 
{
	{
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(Duration); } set { Duration = value;  } }
		float L_0 = ___value0;
		__this->___Duration_30 = L_0;
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(Duration); } set { Duration = value;  } }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackChromaticAberration_HDRP::CustomPlayFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackChromaticAberration_HDRP_CustomPlayFeedback_m786BE0C5EEC3F5D41E643D3056C6E2E0AD81A046 (MMFeedbackChromaticAberration_HDRP_t2F1C669FEDB2F3DD0732EF9B63569FB42EB25929* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMFeedbackChromaticAberration_HDRP_t2F1C669FEDB2F3DD0732EF9B63569FB42EB25929_il2cpp_TypeInfo_var);
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
		il2cpp_codegen_runtime_class_init_inline(MMFeedbackChromaticAberration_HDRP_t2F1C669FEDB2F3DD0732EF9B63569FB42EB25929_il2cpp_TypeInfo_var);
		bool L_1 = ((MMFeedbackChromaticAberration_HDRP_t2F1C669FEDB2F3DD0732EF9B63569FB42EB25929_StaticFields*)il2cpp_codegen_static_fields_for(MMFeedbackChromaticAberration_HDRP_t2F1C669FEDB2F3DD0732EF9B63569FB42EB25929_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_28;
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
		// float intensityMultiplier = Timing.ConstantIntensity ? 1f : feedbacksIntensity;
		MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD* L_2 = ((MMFeedback_tE51A2F7A01B1E3BE46047E5A0D6BA5C79199FDCA*)__this)->___Timing_7;
		NullCheck(L_2);
		bool L_3 = L_2->___ConstantIntensity_11;
		if (L_3)
		{
			goto IL_0020;
		}
	}
	{
		float L_4 = ___feedbacksIntensity1;
		G_B6_0 = L_4;
		goto IL_0025;
	}

IL_0020:
	{
		G_B6_0 = (1.0f);
	}

IL_0025:
	{
		V_0 = G_B6_0;
		// MMChromaticAberrationShakeEvent_HDRP.Trigger(Intensity, FeedbackDuration, RemapIntensityZero, RemapIntensityOne, RelativeIntensity, intensityMultiplier,
		//     Channel, ResetShakerValuesAfterShake, ResetTargetValuesAfterShake, NormalPlayDirection, Timing.TimescaleMode);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_5 = __this->___Intensity_35;
		float L_6;
		L_6 = VirtualFuncInvoker0< float >::Invoke(16 /* System.Single MoreMountains.Feedbacks.MMFeedback::get_FeedbackDuration() */, __this);
		float L_7 = __this->___RemapIntensityZero_33;
		float L_8 = __this->___RemapIntensityOne_34;
		bool L_9 = __this->___RelativeIntensity_37;
		float L_10 = V_0;
		int32_t L_11 = __this->___Channel_29;
		bool L_12 = __this->___ResetShakerValuesAfterShake_31;
		bool L_13 = __this->___ResetTargetValuesAfterShake_32;
		bool L_14;
		L_14 = VirtualFuncInvoker0< bool >::Invoke(33 /* System.Boolean MoreMountains.Feedbacks.MMFeedback::get_NormalPlayDirection() */, __this);
		MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD* L_15 = ((MMFeedback_tE51A2F7A01B1E3BE46047E5A0D6BA5C79199FDCA*)__this)->___Timing_7;
		NullCheck(L_15);
		int32_t L_16 = L_15->___TimescaleMode_0;
		MMChromaticAberrationShakeEvent_HDRP_Trigger_m2BF26327003EB129A7B88CBA28534150C418456E(L_5, L_6, L_7, L_8, L_9, L_10, L_11, L_12, L_13, L_14, L_16, (bool)0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackChromaticAberration_HDRP::CustomStopFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackChromaticAberration_HDRP_CustomStopFeedback_m9D0D39C5446E8E67094369F26A2F474C5FF78792 (MMFeedbackChromaticAberration_HDRP_t2F1C669FEDB2F3DD0732EF9B63569FB42EB25929* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMFeedbackChromaticAberration_HDRP_t2F1C669FEDB2F3DD0732EF9B63569FB42EB25929_il2cpp_TypeInfo_var);
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
		il2cpp_codegen_runtime_class_init_inline(MMFeedbackChromaticAberration_HDRP_t2F1C669FEDB2F3DD0732EF9B63569FB42EB25929_il2cpp_TypeInfo_var);
		bool L_1 = ((MMFeedbackChromaticAberration_HDRP_t2F1C669FEDB2F3DD0732EF9B63569FB42EB25929_StaticFields*)il2cpp_codegen_static_fields_for(MMFeedbackChromaticAberration_HDRP_t2F1C669FEDB2F3DD0732EF9B63569FB42EB25929_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_28;
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
		// base.CustomStopFeedback(position, feedbacksIntensity);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2 = ___position0;
		float L_3 = ___feedbacksIntensity1;
		MMFeedback_CustomStopFeedback_m812755E219AA8EF519A2D89F6C91AB793AE27EDD(__this, L_2, L_3, NULL);
		// MMChromaticAberrationShakeEvent_HDRP.Trigger(Intensity, FeedbackDuration, RemapIntensityZero, RemapIntensityOne, RelativeIntensity, channel:Channel, stop:true);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_4 = __this->___Intensity_35;
		float L_5;
		L_5 = VirtualFuncInvoker0< float >::Invoke(16 /* System.Single MoreMountains.Feedbacks.MMFeedback::get_FeedbackDuration() */, __this);
		float L_6 = __this->___RemapIntensityZero_33;
		float L_7 = __this->___RemapIntensityOne_34;
		bool L_8 = __this->___RelativeIntensity_37;
		int32_t L_9 = __this->___Channel_29;
		MMChromaticAberrationShakeEvent_HDRP_Trigger_m2BF26327003EB129A7B88CBA28534150C418456E(L_4, L_5, L_6, L_7, L_8, (1.0f), L_9, (bool)1, (bool)1, (bool)1, 0, (bool)1, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackChromaticAberration_HDRP::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackChromaticAberration_HDRP__ctor_m580D47E71B89E0440D6431A65041EC3222507734 (MMFeedbackChromaticAberration_HDRP_t2F1C669FEDB2F3DD0732EF9B63569FB42EB25929* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public float Duration = 0.2f;
		__this->___Duration_30 = (0.200000003f);
		// public bool ResetShakerValuesAfterShake = true;
		__this->___ResetShakerValuesAfterShake_31 = (bool)1;
		// public bool ResetTargetValuesAfterShake = true;
		__this->___ResetTargetValuesAfterShake_32 = (bool)1;
		// public float RemapIntensityOne = 1f;
		__this->___RemapIntensityOne_34 = (1.0f);
		// public AnimationCurve Intensity = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
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
		__this->___Intensity_35 = L_7;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___Intensity_35), (void*)L_7);
		// public float Amplitude = 1.0f;
		__this->___Amplitude_36 = (1.0f);
		MMFeedback__ctor_mCD506F8FC949D7574B8EB30A5C0CC117C19BD647(__this, NULL);
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackChromaticAberration_HDRP::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackChromaticAberration_HDRP__cctor_m825507FB5BE0E6FA968944B10E0E744F70629188 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMFeedbackChromaticAberration_HDRP_t2F1C669FEDB2F3DD0732EF9B63569FB42EB25929_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public static bool FeedbackTypeAuthorized = true;
		((MMFeedbackChromaticAberration_HDRP_t2F1C669FEDB2F3DD0732EF9B63569FB42EB25929_StaticFields*)il2cpp_codegen_static_fields_for(MMFeedbackChromaticAberration_HDRP_t2F1C669FEDB2F3DD0732EF9B63569FB42EB25929_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_28 = (bool)1;
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
// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackColorAdjustments_HDRP::get_FeedbackDuration()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float MMFeedbackColorAdjustments_HDRP_get_FeedbackDuration_mC276E75744908FCD38D1B64E39E0B6FE5815E877 (MMFeedbackColorAdjustments_HDRP_t99AF449C9842B06883E26C14553A117A6EA0D216* __this, const RuntimeMethod* method) 
{
	{
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(ShakeDuration); } set { ShakeDuration = value; } }
		float L_0 = __this->___ShakeDuration_30;
		float L_1;
		L_1 = VirtualFuncInvoker1< float, float >::Invoke(36 /* System.Single MoreMountains.Feedbacks.MMFeedback::ApplyTimeMultiplier(System.Single) */, __this, L_0);
		return L_1;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackColorAdjustments_HDRP::set_FeedbackDuration(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackColorAdjustments_HDRP_set_FeedbackDuration_m3244EE22A0F19054E33C9076ECC88975B960A4CC (MMFeedbackColorAdjustments_HDRP_t99AF449C9842B06883E26C14553A117A6EA0D216* __this, float ___value0, const RuntimeMethod* method) 
{
	{
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(ShakeDuration); } set { ShakeDuration = value; } }
		float L_0 = ___value0;
		__this->___ShakeDuration_30 = L_0;
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(ShakeDuration); } set { ShakeDuration = value; } }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackColorAdjustments_HDRP::CustomPlayFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackColorAdjustments_HDRP_CustomPlayFeedback_mC61A1C1243C890D5D7F291E71E2B1289B5D61804 (MMFeedbackColorAdjustments_HDRP_t99AF449C9842B06883E26C14553A117A6EA0D216* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMFeedbackColorAdjustments_HDRP_t99AF449C9842B06883E26C14553A117A6EA0D216_il2cpp_TypeInfo_var);
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
		il2cpp_codegen_runtime_class_init_inline(MMFeedbackColorAdjustments_HDRP_t99AF449C9842B06883E26C14553A117A6EA0D216_il2cpp_TypeInfo_var);
		bool L_1 = ((MMFeedbackColorAdjustments_HDRP_t99AF449C9842B06883E26C14553A117A6EA0D216_StaticFields*)il2cpp_codegen_static_fields_for(MMFeedbackColorAdjustments_HDRP_t99AF449C9842B06883E26C14553A117A6EA0D216_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_28;
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
		// float intensityMultiplier = Timing.ConstantIntensity ? 1f : feedbacksIntensity;
		MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD* L_2 = ((MMFeedback_tE51A2F7A01B1E3BE46047E5A0D6BA5C79199FDCA*)__this)->___Timing_7;
		NullCheck(L_2);
		bool L_3 = L_2->___ConstantIntensity_11;
		if (L_3)
		{
			goto IL_0020;
		}
	}
	{
		float L_4 = ___feedbacksIntensity1;
		G_B6_0 = L_4;
		goto IL_0025;
	}

IL_0020:
	{
		G_B6_0 = (1.0f);
	}

IL_0025:
	{
		V_0 = G_B6_0;
		// MMColorAdjustmentsShakeEvent_HDRP.Trigger(ShakePostExposure, RemapPostExposureZero, RemapPostExposureOne,
		//     ShakeHueShift, RemapHueShiftZero, RemapHueShiftOne,
		//     ShakeSaturation, RemapSaturationZero, RemapSaturationOne,
		//     ShakeContrast, RemapContrastZero, RemapContrastOne,
		//     ColorFilterMode, ColorFilterGradient, ColorFilterDestination, ColorFilterCurve,
		//     FeedbackDuration,
		//     RelativeIntensity, intensityMultiplier, Channel, ResetShakerValuesAfterShake, ResetTargetValuesAfterShake, NormalPlayDirection, Timing.TimescaleMode);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_5 = __this->___ShakePostExposure_34;
		float L_6 = __this->___RemapPostExposureZero_35;
		float L_7 = __this->___RemapPostExposureOne_36;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_8 = __this->___ShakeHueShift_37;
		float L_9 = __this->___RemapHueShiftZero_38;
		float L_10 = __this->___RemapHueShiftOne_39;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_11 = __this->___ShakeSaturation_40;
		float L_12 = __this->___RemapSaturationZero_41;
		float L_13 = __this->___RemapSaturationOne_42;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_14 = __this->___ShakeContrast_43;
		float L_15 = __this->___RemapContrastZero_44;
		float L_16 = __this->___RemapContrastOne_45;
		int32_t L_17 = __this->___ColorFilterMode_46;
		Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E* L_18 = __this->___ColorFilterGradient_47;
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F L_19 = __this->___ColorFilterDestination_48;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_20 = __this->___ColorFilterCurve_49;
		float L_21;
		L_21 = VirtualFuncInvoker0< float >::Invoke(16 /* System.Single MoreMountains.Feedbacks.MMFeedback::get_FeedbackDuration() */, __this);
		bool L_22 = __this->___RelativeIntensity_31;
		float L_23 = V_0;
		int32_t L_24 = __this->___Channel_29;
		bool L_25 = __this->___ResetShakerValuesAfterShake_32;
		bool L_26 = __this->___ResetTargetValuesAfterShake_33;
		bool L_27;
		L_27 = VirtualFuncInvoker0< bool >::Invoke(33 /* System.Boolean MoreMountains.Feedbacks.MMFeedback::get_NormalPlayDirection() */, __this);
		MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD* L_28 = ((MMFeedback_tE51A2F7A01B1E3BE46047E5A0D6BA5C79199FDCA*)__this)->___Timing_7;
		NullCheck(L_28);
		int32_t L_29 = L_28->___TimescaleMode_0;
		MMColorAdjustmentsShakeEvent_HDRP_Trigger_mEFEAD45DF484AF38F46422ABDEE911B21935BB16(L_5, L_6, L_7, L_8, L_9, L_10, L_11, L_12, L_13, L_14, L_15, L_16, L_17, L_18, L_19, L_20, L_21, L_22, L_23, L_24, L_25, L_26, L_27, L_29, (bool)0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackColorAdjustments_HDRP::CustomStopFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackColorAdjustments_HDRP_CustomStopFeedback_mDC15C94FEE7C306911F0FE0B9113B302EF684694 (MMFeedbackColorAdjustments_HDRP_t99AF449C9842B06883E26C14553A117A6EA0D216* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMFeedbackColorAdjustments_HDRP_t99AF449C9842B06883E26C14553A117A6EA0D216_il2cpp_TypeInfo_var);
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
		il2cpp_codegen_runtime_class_init_inline(MMFeedbackColorAdjustments_HDRP_t99AF449C9842B06883E26C14553A117A6EA0D216_il2cpp_TypeInfo_var);
		bool L_1 = ((MMFeedbackColorAdjustments_HDRP_t99AF449C9842B06883E26C14553A117A6EA0D216_StaticFields*)il2cpp_codegen_static_fields_for(MMFeedbackColorAdjustments_HDRP_t99AF449C9842B06883E26C14553A117A6EA0D216_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_28;
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
		// base.CustomStopFeedback(position, feedbacksIntensity);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2 = ___position0;
		float L_3 = ___feedbacksIntensity1;
		MMFeedback_CustomStopFeedback_m812755E219AA8EF519A2D89F6C91AB793AE27EDD(__this, L_2, L_3, NULL);
		// MMColorAdjustmentsShakeEvent_HDRP.Trigger(ShakePostExposure, RemapPostExposureZero, RemapPostExposureOne,
		//     ShakeHueShift, RemapHueShiftZero, RemapHueShiftOne,
		//     ShakeSaturation, RemapSaturationZero, RemapSaturationOne,
		//     ShakeContrast, RemapContrastZero, RemapContrastOne,
		//     ColorFilterMode, ColorFilterGradient, ColorFilterDestination, ColorFilterCurve,
		//     FeedbackDuration,
		//     RelativeIntensity, channel:Channel, stop:true);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_4 = __this->___ShakePostExposure_34;
		float L_5 = __this->___RemapPostExposureZero_35;
		float L_6 = __this->___RemapPostExposureOne_36;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_7 = __this->___ShakeHueShift_37;
		float L_8 = __this->___RemapHueShiftZero_38;
		float L_9 = __this->___RemapHueShiftOne_39;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_10 = __this->___ShakeSaturation_40;
		float L_11 = __this->___RemapSaturationZero_41;
		float L_12 = __this->___RemapSaturationOne_42;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_13 = __this->___ShakeContrast_43;
		float L_14 = __this->___RemapContrastZero_44;
		float L_15 = __this->___RemapContrastOne_45;
		int32_t L_16 = __this->___ColorFilterMode_46;
		Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E* L_17 = __this->___ColorFilterGradient_47;
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F L_18 = __this->___ColorFilterDestination_48;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_19 = __this->___ColorFilterCurve_49;
		float L_20;
		L_20 = VirtualFuncInvoker0< float >::Invoke(16 /* System.Single MoreMountains.Feedbacks.MMFeedback::get_FeedbackDuration() */, __this);
		bool L_21 = __this->___RelativeIntensity_31;
		int32_t L_22 = __this->___Channel_29;
		MMColorAdjustmentsShakeEvent_HDRP_Trigger_mEFEAD45DF484AF38F46422ABDEE911B21935BB16(L_4, L_5, L_6, L_7, L_8, L_9, L_10, L_11, L_12, L_13, L_14, L_15, L_16, L_17, L_18, L_19, L_20, L_21, (1.0f), L_22, (bool)1, (bool)1, (bool)1, 0, (bool)1, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackColorAdjustments_HDRP::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackColorAdjustments_HDRP__ctor_m6C06943A341DBE654D27D952689CCABED7205CD6 (MMFeedbackColorAdjustments_HDRP_t99AF449C9842B06883E26C14553A117A6EA0D216* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public float ShakeDuration = 1f;
		__this->___ShakeDuration_30 = (1.0f);
		// public bool RelativeIntensity = true;
		__this->___RelativeIntensity_31 = (bool)1;
		// public bool ResetShakerValuesAfterShake = true;
		__this->___ResetShakerValuesAfterShake_32 = (bool)1;
		// public bool ResetTargetValuesAfterShake = true;
		__this->___ResetTargetValuesAfterShake_33 = (bool)1;
		// public AnimationCurve ShakePostExposure = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
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
		__this->___ShakePostExposure_34 = L_7;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ShakePostExposure_34), (void*)L_7);
		// public float RemapPostExposureOne = 1f;
		__this->___RemapPostExposureOne_36 = (1.0f);
		// public AnimationCurve ShakeHueShift = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
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
		__this->___ShakeHueShift_37 = L_15;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ShakeHueShift_37), (void*)L_15);
		// public float RemapHueShiftOne = 180f;
		__this->___RemapHueShiftOne_39 = (180.0f);
		// public AnimationCurve ShakeSaturation = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_16 = (KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3*)(KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3*)SZArrayNew(KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var, (uint32_t)3);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_17 = L_16;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_18;
		memset((&L_18), 0, sizeof(L_18));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_18), (0.0f), (0.0f), /*hidden argument*/NULL);
		NullCheck(L_17);
		(L_17)->SetAt(static_cast<il2cpp_array_size_t>(0), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_18);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_19 = L_17;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_20;
		memset((&L_20), 0, sizeof(L_20));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_20), (0.5f), (1.0f), /*hidden argument*/NULL);
		NullCheck(L_19);
		(L_19)->SetAt(static_cast<il2cpp_array_size_t>(1), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_20);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_21 = L_19;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_22;
		memset((&L_22), 0, sizeof(L_22));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_22), (1.0f), (0.0f), /*hidden argument*/NULL);
		NullCheck(L_21);
		(L_21)->SetAt(static_cast<il2cpp_array_size_t>(2), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_22);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_23 = (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*)il2cpp_codegen_object_new(AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		NullCheck(L_23);
		AnimationCurve__ctor_mEABC98C03805713354D61E50D9340766BD5B717E(L_23, L_21, NULL);
		__this->___ShakeSaturation_40 = L_23;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ShakeSaturation_40), (void*)L_23);
		// public float RemapSaturationOne = 100f;
		__this->___RemapSaturationOne_42 = (100.0f);
		// public AnimationCurve ShakeContrast = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_24 = (KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3*)(KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3*)SZArrayNew(KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var, (uint32_t)3);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_25 = L_24;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_26;
		memset((&L_26), 0, sizeof(L_26));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_26), (0.0f), (0.0f), /*hidden argument*/NULL);
		NullCheck(L_25);
		(L_25)->SetAt(static_cast<il2cpp_array_size_t>(0), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_26);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_27 = L_25;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_28;
		memset((&L_28), 0, sizeof(L_28));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_28), (0.5f), (1.0f), /*hidden argument*/NULL);
		NullCheck(L_27);
		(L_27)->SetAt(static_cast<il2cpp_array_size_t>(1), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_28);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_29 = L_27;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_30;
		memset((&L_30), 0, sizeof(L_30));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_30), (1.0f), (0.0f), /*hidden argument*/NULL);
		NullCheck(L_29);
		(L_29)->SetAt(static_cast<il2cpp_array_size_t>(2), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_30);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_31 = (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*)il2cpp_codegen_object_new(AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		NullCheck(L_31);
		AnimationCurve__ctor_mEABC98C03805713354D61E50D9340766BD5B717E(L_31, L_29, NULL);
		__this->___ShakeContrast_43 = L_31;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ShakeContrast_43), (void*)L_31);
		// public float RemapContrastOne = 100f;
		__this->___RemapContrastOne_45 = (100.0f);
		// public Color ColorFilterDestination = Color.yellow;
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F L_32;
		L_32 = Color_get_yellow_m66637FA14383E8D74F24AE256B577CE1D55D469F_inline(NULL);
		__this->___ColorFilterDestination_48 = L_32;
		// public AnimationCurve ColorFilterCurve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_33 = (KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3*)(KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3*)SZArrayNew(KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var, (uint32_t)3);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_34 = L_33;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_35;
		memset((&L_35), 0, sizeof(L_35));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_35), (0.0f), (0.0f), /*hidden argument*/NULL);
		NullCheck(L_34);
		(L_34)->SetAt(static_cast<il2cpp_array_size_t>(0), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_35);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_36 = L_34;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_37;
		memset((&L_37), 0, sizeof(L_37));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_37), (0.5f), (1.0f), /*hidden argument*/NULL);
		NullCheck(L_36);
		(L_36)->SetAt(static_cast<il2cpp_array_size_t>(1), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_37);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_38 = L_36;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_39;
		memset((&L_39), 0, sizeof(L_39));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_39), (1.0f), (0.0f), /*hidden argument*/NULL);
		NullCheck(L_38);
		(L_38)->SetAt(static_cast<il2cpp_array_size_t>(2), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_39);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_40 = (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*)il2cpp_codegen_object_new(AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		NullCheck(L_40);
		AnimationCurve__ctor_mEABC98C03805713354D61E50D9340766BD5B717E(L_40, L_38, NULL);
		__this->___ColorFilterCurve_49 = L_40;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ColorFilterCurve_49), (void*)L_40);
		MMFeedback__ctor_mCD506F8FC949D7574B8EB30A5C0CC117C19BD647(__this, NULL);
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackColorAdjustments_HDRP::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackColorAdjustments_HDRP__cctor_m2FDD4C843FC52F4335088C105E1CCE6D6BA9C8CC (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMFeedbackColorAdjustments_HDRP_t99AF449C9842B06883E26C14553A117A6EA0D216_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public static bool FeedbackTypeAuthorized = true;
		((MMFeedbackColorAdjustments_HDRP_t99AF449C9842B06883E26C14553A117A6EA0D216_StaticFields*)il2cpp_codegen_static_fields_for(MMFeedbackColorAdjustments_HDRP_t99AF449C9842B06883E26C14553A117A6EA0D216_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_28 = (bool)1;
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
// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackExposure_HDRP::get_FeedbackDuration()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float MMFeedbackExposure_HDRP_get_FeedbackDuration_mA19478BBE0FA043DE7B0E228C6FC312A3A6C8A77 (MMFeedbackExposure_HDRP_t7D28A8ECA50B6411205FF1E72D45E78055A36395* __this, const RuntimeMethod* method) 
{
	{
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(Duration); } set { Duration = value; } }
		float L_0 = __this->___Duration_30;
		float L_1;
		L_1 = VirtualFuncInvoker1< float, float >::Invoke(36 /* System.Single MoreMountains.Feedbacks.MMFeedback::ApplyTimeMultiplier(System.Single) */, __this, L_0);
		return L_1;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackExposure_HDRP::set_FeedbackDuration(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackExposure_HDRP_set_FeedbackDuration_m233F29BD602A5D5F86FAE7669A2808C21F15321F (MMFeedbackExposure_HDRP_t7D28A8ECA50B6411205FF1E72D45E78055A36395* __this, float ___value0, const RuntimeMethod* method) 
{
	{
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(Duration); } set { Duration = value; } }
		float L_0 = ___value0;
		__this->___Duration_30 = L_0;
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(Duration); } set { Duration = value; } }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackExposure_HDRP::CustomPlayFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackExposure_HDRP_CustomPlayFeedback_m25157A6CAD106B71A217A0E4D9B34F1984B1C545 (MMFeedbackExposure_HDRP_t7D28A8ECA50B6411205FF1E72D45E78055A36395* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMFeedbackExposure_HDRP_t7D28A8ECA50B6411205FF1E72D45E78055A36395_il2cpp_TypeInfo_var);
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
		il2cpp_codegen_runtime_class_init_inline(MMFeedbackExposure_HDRP_t7D28A8ECA50B6411205FF1E72D45E78055A36395_il2cpp_TypeInfo_var);
		bool L_1 = ((MMFeedbackExposure_HDRP_t7D28A8ECA50B6411205FF1E72D45E78055A36395_StaticFields*)il2cpp_codegen_static_fields_for(MMFeedbackExposure_HDRP_t7D28A8ECA50B6411205FF1E72D45E78055A36395_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_28;
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
		// float intensityMultiplier = Timing.ConstantIntensity ? 1f : feedbacksIntensity;
		MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD* L_2 = ((MMFeedback_tE51A2F7A01B1E3BE46047E5A0D6BA5C79199FDCA*)__this)->___Timing_7;
		NullCheck(L_2);
		bool L_3 = L_2->___ConstantIntensity_11;
		if (L_3)
		{
			goto IL_0020;
		}
	}
	{
		float L_4 = ___feedbacksIntensity1;
		G_B6_0 = L_4;
		goto IL_0025;
	}

IL_0020:
	{
		G_B6_0 = (1.0f);
	}

IL_0025:
	{
		V_0 = G_B6_0;
		// MMExposureShakeEvent_HDRP.Trigger(FixedExposure, FeedbackDuration, RemapFixedExposureZero, RemapFixedExposureOne, RelativeFixedExposure, intensityMultiplier,
		//     Channel, ResetShakerValuesAfterShake, ResetTargetValuesAfterShake, NormalPlayDirection, Timing.TimescaleMode);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_5 = __this->___FixedExposure_33;
		float L_6;
		L_6 = VirtualFuncInvoker0< float >::Invoke(16 /* System.Single MoreMountains.Feedbacks.MMFeedback::get_FeedbackDuration() */, __this);
		float L_7 = __this->___RemapFixedExposureZero_34;
		float L_8 = __this->___RemapFixedExposureOne_35;
		bool L_9 = __this->___RelativeFixedExposure_36;
		float L_10 = V_0;
		int32_t L_11 = __this->___Channel_29;
		bool L_12 = __this->___ResetShakerValuesAfterShake_31;
		bool L_13 = __this->___ResetTargetValuesAfterShake_32;
		bool L_14;
		L_14 = VirtualFuncInvoker0< bool >::Invoke(33 /* System.Boolean MoreMountains.Feedbacks.MMFeedback::get_NormalPlayDirection() */, __this);
		MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD* L_15 = ((MMFeedback_tE51A2F7A01B1E3BE46047E5A0D6BA5C79199FDCA*)__this)->___Timing_7;
		NullCheck(L_15);
		int32_t L_16 = L_15->___TimescaleMode_0;
		MMExposureShakeEvent_HDRP_Trigger_m1896AC3294CC9A9ECAC33EBE25DD0E9FD7E816A6(L_5, L_6, L_7, L_8, L_9, L_10, L_11, L_12, L_13, L_14, L_16, (bool)0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackExposure_HDRP::CustomStopFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackExposure_HDRP_CustomStopFeedback_m5C1670E6E2684C81592C1D36DFD7A81CE583CE2B (MMFeedbackExposure_HDRP_t7D28A8ECA50B6411205FF1E72D45E78055A36395* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMFeedbackExposure_HDRP_t7D28A8ECA50B6411205FF1E72D45E78055A36395_il2cpp_TypeInfo_var);
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
		il2cpp_codegen_runtime_class_init_inline(MMFeedbackExposure_HDRP_t7D28A8ECA50B6411205FF1E72D45E78055A36395_il2cpp_TypeInfo_var);
		bool L_1 = ((MMFeedbackExposure_HDRP_t7D28A8ECA50B6411205FF1E72D45E78055A36395_StaticFields*)il2cpp_codegen_static_fields_for(MMFeedbackExposure_HDRP_t7D28A8ECA50B6411205FF1E72D45E78055A36395_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_28;
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
		// base.CustomStopFeedback(position, feedbacksIntensity);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2 = ___position0;
		float L_3 = ___feedbacksIntensity1;
		MMFeedback_CustomStopFeedback_m812755E219AA8EF519A2D89F6C91AB793AE27EDD(__this, L_2, L_3, NULL);
		// MMExposureShakeEvent_HDRP.Trigger(FixedExposure, FeedbackDuration, RemapFixedExposureZero, RemapFixedExposureOne, RelativeFixedExposure, channel:Channel, stop:true);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_4 = __this->___FixedExposure_33;
		float L_5;
		L_5 = VirtualFuncInvoker0< float >::Invoke(16 /* System.Single MoreMountains.Feedbacks.MMFeedback::get_FeedbackDuration() */, __this);
		float L_6 = __this->___RemapFixedExposureZero_34;
		float L_7 = __this->___RemapFixedExposureOne_35;
		bool L_8 = __this->___RelativeFixedExposure_36;
		int32_t L_9 = __this->___Channel_29;
		MMExposureShakeEvent_HDRP_Trigger_m1896AC3294CC9A9ECAC33EBE25DD0E9FD7E816A6(L_4, L_5, L_6, L_7, L_8, (1.0f), L_9, (bool)1, (bool)1, (bool)1, 0, (bool)1, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackExposure_HDRP::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackExposure_HDRP__ctor_m1E6C12ADDEED7CD84CF55AA0B98408EBE4DCF823 (MMFeedbackExposure_HDRP_t7D28A8ECA50B6411205FF1E72D45E78055A36395* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public float Duration = 0.2f;
		__this->___Duration_30 = (0.200000003f);
		// public bool ResetShakerValuesAfterShake = true;
		__this->___ResetShakerValuesAfterShake_31 = (bool)1;
		// public bool ResetTargetValuesAfterShake = true;
		__this->___ResetTargetValuesAfterShake_32 = (bool)1;
		// public AnimationCurve FixedExposure = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
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
		__this->___FixedExposure_33 = L_7;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___FixedExposure_33), (void*)L_7);
		// public float RemapFixedExposureZero = 8.5f;
		__this->___RemapFixedExposureZero_34 = (8.5f);
		// public float RemapFixedExposureOne = 6f;
		__this->___RemapFixedExposureOne_35 = (6.0f);
		MMFeedback__ctor_mCD506F8FC949D7574B8EB30A5C0CC117C19BD647(__this, NULL);
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackExposure_HDRP::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackExposure_HDRP__cctor_mBD64DC1968671284C88C5913811BF75E68C0762E (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMFeedbackExposure_HDRP_t7D28A8ECA50B6411205FF1E72D45E78055A36395_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public static bool FeedbackTypeAuthorized = true;
		((MMFeedbackExposure_HDRP_t7D28A8ECA50B6411205FF1E72D45E78055A36395_StaticFields*)il2cpp_codegen_static_fields_for(MMFeedbackExposure_HDRP_t7D28A8ECA50B6411205FF1E72D45E78055A36395_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_28 = (bool)1;
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
// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackFilmGrain_HDRP::get_FeedbackDuration()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float MMFeedbackFilmGrain_HDRP_get_FeedbackDuration_mDE235B5B113B9CA58B7E49C7C17067F26120B3E1 (MMFeedbackFilmGrain_HDRP_tA820A4A0D3AF519A8B4AF875A1CD16A7AC494503* __this, const RuntimeMethod* method) 
{
	{
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(Duration); } set { Duration = value; } }
		float L_0 = __this->___Duration_30;
		float L_1;
		L_1 = VirtualFuncInvoker1< float, float >::Invoke(36 /* System.Single MoreMountains.Feedbacks.MMFeedback::ApplyTimeMultiplier(System.Single) */, __this, L_0);
		return L_1;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackFilmGrain_HDRP::set_FeedbackDuration(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackFilmGrain_HDRP_set_FeedbackDuration_m7BC4419EA8D8804A8B53E1C42F68D95CE1888DC3 (MMFeedbackFilmGrain_HDRP_tA820A4A0D3AF519A8B4AF875A1CD16A7AC494503* __this, float ___value0, const RuntimeMethod* method) 
{
	{
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(Duration); } set { Duration = value; } }
		float L_0 = ___value0;
		__this->___Duration_30 = L_0;
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(Duration); } set { Duration = value; } }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackFilmGrain_HDRP::CustomPlayFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackFilmGrain_HDRP_CustomPlayFeedback_m9BA2C19CC51DD3FF3E2E5D9A5534A77900DC558A (MMFeedbackFilmGrain_HDRP_tA820A4A0D3AF519A8B4AF875A1CD16A7AC494503* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMFeedbackFilmGrain_HDRP_tA820A4A0D3AF519A8B4AF875A1CD16A7AC494503_il2cpp_TypeInfo_var);
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
		il2cpp_codegen_runtime_class_init_inline(MMFeedbackFilmGrain_HDRP_tA820A4A0D3AF519A8B4AF875A1CD16A7AC494503_il2cpp_TypeInfo_var);
		bool L_1 = ((MMFeedbackFilmGrain_HDRP_tA820A4A0D3AF519A8B4AF875A1CD16A7AC494503_StaticFields*)il2cpp_codegen_static_fields_for(MMFeedbackFilmGrain_HDRP_tA820A4A0D3AF519A8B4AF875A1CD16A7AC494503_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_28;
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
		// float intensityMultiplier = Timing.ConstantIntensity ? 1f : feedbacksIntensity;
		MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD* L_2 = ((MMFeedback_tE51A2F7A01B1E3BE46047E5A0D6BA5C79199FDCA*)__this)->___Timing_7;
		NullCheck(L_2);
		bool L_3 = L_2->___ConstantIntensity_11;
		if (L_3)
		{
			goto IL_0020;
		}
	}
	{
		float L_4 = ___feedbacksIntensity1;
		G_B6_0 = L_4;
		goto IL_0025;
	}

IL_0020:
	{
		G_B6_0 = (1.0f);
	}

IL_0025:
	{
		V_0 = G_B6_0;
		// MMFilmGrainShakeEvent_HDRP.Trigger(Intensity, FeedbackDuration, RemapIntensityZero, RemapIntensityOne, RelativeIntensity, intensityMultiplier,
		//     Channel, ResetShakerValuesAfterShake, ResetTargetValuesAfterShake, NormalPlayDirection, Timing.TimescaleMode);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_5 = __this->___Intensity_33;
		float L_6;
		L_6 = VirtualFuncInvoker0< float >::Invoke(16 /* System.Single MoreMountains.Feedbacks.MMFeedback::get_FeedbackDuration() */, __this);
		float L_7 = __this->___RemapIntensityZero_34;
		float L_8 = __this->___RemapIntensityOne_35;
		bool L_9 = __this->___RelativeIntensity_36;
		float L_10 = V_0;
		int32_t L_11 = __this->___Channel_29;
		bool L_12 = __this->___ResetShakerValuesAfterShake_31;
		bool L_13 = __this->___ResetTargetValuesAfterShake_32;
		bool L_14;
		L_14 = VirtualFuncInvoker0< bool >::Invoke(33 /* System.Boolean MoreMountains.Feedbacks.MMFeedback::get_NormalPlayDirection() */, __this);
		MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD* L_15 = ((MMFeedback_tE51A2F7A01B1E3BE46047E5A0D6BA5C79199FDCA*)__this)->___Timing_7;
		NullCheck(L_15);
		int32_t L_16 = L_15->___TimescaleMode_0;
		MMFilmGrainShakeEvent_HDRP_Trigger_mE93E1C6A7C883DD107BBDFDFAA8D8FDC6090D147(L_5, L_6, L_7, L_8, L_9, L_10, L_11, L_12, L_13, L_14, L_16, (bool)0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackFilmGrain_HDRP::CustomStopFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackFilmGrain_HDRP_CustomStopFeedback_mB58BC6B47B718CE726A1E457F975351A3B6BC203 (MMFeedbackFilmGrain_HDRP_tA820A4A0D3AF519A8B4AF875A1CD16A7AC494503* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMFeedbackFilmGrain_HDRP_tA820A4A0D3AF519A8B4AF875A1CD16A7AC494503_il2cpp_TypeInfo_var);
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
		il2cpp_codegen_runtime_class_init_inline(MMFeedbackFilmGrain_HDRP_tA820A4A0D3AF519A8B4AF875A1CD16A7AC494503_il2cpp_TypeInfo_var);
		bool L_1 = ((MMFeedbackFilmGrain_HDRP_tA820A4A0D3AF519A8B4AF875A1CD16A7AC494503_StaticFields*)il2cpp_codegen_static_fields_for(MMFeedbackFilmGrain_HDRP_tA820A4A0D3AF519A8B4AF875A1CD16A7AC494503_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_28;
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
		// base.CustomStopFeedback(position, feedbacksIntensity);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2 = ___position0;
		float L_3 = ___feedbacksIntensity1;
		MMFeedback_CustomStopFeedback_m812755E219AA8EF519A2D89F6C91AB793AE27EDD(__this, L_2, L_3, NULL);
		// MMFilmGrainShakeEvent_HDRP.Trigger(Intensity, FeedbackDuration, RemapIntensityZero, RemapIntensityOne, RelativeIntensity, channel:Channel, stop:true);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_4 = __this->___Intensity_33;
		float L_5;
		L_5 = VirtualFuncInvoker0< float >::Invoke(16 /* System.Single MoreMountains.Feedbacks.MMFeedback::get_FeedbackDuration() */, __this);
		float L_6 = __this->___RemapIntensityZero_34;
		float L_7 = __this->___RemapIntensityOne_35;
		bool L_8 = __this->___RelativeIntensity_36;
		int32_t L_9 = __this->___Channel_29;
		MMFilmGrainShakeEvent_HDRP_Trigger_mE93E1C6A7C883DD107BBDFDFAA8D8FDC6090D147(L_4, L_5, L_6, L_7, L_8, (1.0f), L_9, (bool)1, (bool)1, (bool)1, 0, (bool)1, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackFilmGrain_HDRP::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackFilmGrain_HDRP__ctor_m6CF0CF5F7D716B6C151890BC3BAB5F102EE4228B (MMFeedbackFilmGrain_HDRP_tA820A4A0D3AF519A8B4AF875A1CD16A7AC494503* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public float Duration = 0.2f;
		__this->___Duration_30 = (0.200000003f);
		// public bool ResetShakerValuesAfterShake = true;
		__this->___ResetShakerValuesAfterShake_31 = (bool)1;
		// public bool ResetTargetValuesAfterShake = true;
		__this->___ResetTargetValuesAfterShake_32 = (bool)1;
		// public AnimationCurve Intensity = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
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
		__this->___Intensity_33 = L_7;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___Intensity_33), (void*)L_7);
		// public float RemapIntensityOne = 1.0f;
		__this->___RemapIntensityOne_35 = (1.0f);
		MMFeedback__ctor_mCD506F8FC949D7574B8EB30A5C0CC117C19BD647(__this, NULL);
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackFilmGrain_HDRP::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackFilmGrain_HDRP__cctor_m7CBC5E5CB429DE0B41565B09D82697AF95F0A854 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMFeedbackFilmGrain_HDRP_tA820A4A0D3AF519A8B4AF875A1CD16A7AC494503_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public static bool FeedbackTypeAuthorized = true;
		((MMFeedbackFilmGrain_HDRP_tA820A4A0D3AF519A8B4AF875A1CD16A7AC494503_StaticFields*)il2cpp_codegen_static_fields_for(MMFeedbackFilmGrain_HDRP_tA820A4A0D3AF519A8B4AF875A1CD16A7AC494503_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_28 = (bool)1;
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
// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackLensDistortion_HDRP::get_FeedbackDuration()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float MMFeedbackLensDistortion_HDRP_get_FeedbackDuration_mA2725439AAFFC99B37D80046AAD35CFDB30D0393 (MMFeedbackLensDistortion_HDRP_tCC834E1D0D5B6F46A8F512F480B8A9952D662380* __this, const RuntimeMethod* method) 
{
	{
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(Duration); } set { Duration = value; } }
		float L_0 = __this->___Duration_30;
		float L_1;
		L_1 = VirtualFuncInvoker1< float, float >::Invoke(36 /* System.Single MoreMountains.Feedbacks.MMFeedback::ApplyTimeMultiplier(System.Single) */, __this, L_0);
		return L_1;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackLensDistortion_HDRP::set_FeedbackDuration(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackLensDistortion_HDRP_set_FeedbackDuration_m759ACE2521ABAA0922673BBE7E3F198575B5D930 (MMFeedbackLensDistortion_HDRP_tCC834E1D0D5B6F46A8F512F480B8A9952D662380* __this, float ___value0, const RuntimeMethod* method) 
{
	{
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(Duration); } set { Duration = value; } }
		float L_0 = ___value0;
		__this->___Duration_30 = L_0;
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(Duration); } set { Duration = value; } }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackLensDistortion_HDRP::CustomPlayFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackLensDistortion_HDRP_CustomPlayFeedback_m5ADADCB03616E5C6860D07D8A77239601F40476C (MMFeedbackLensDistortion_HDRP_tCC834E1D0D5B6F46A8F512F480B8A9952D662380* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMFeedbackLensDistortion_HDRP_tCC834E1D0D5B6F46A8F512F480B8A9952D662380_il2cpp_TypeInfo_var);
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
		il2cpp_codegen_runtime_class_init_inline(MMFeedbackLensDistortion_HDRP_tCC834E1D0D5B6F46A8F512F480B8A9952D662380_il2cpp_TypeInfo_var);
		bool L_1 = ((MMFeedbackLensDistortion_HDRP_tCC834E1D0D5B6F46A8F512F480B8A9952D662380_StaticFields*)il2cpp_codegen_static_fields_for(MMFeedbackLensDistortion_HDRP_tCC834E1D0D5B6F46A8F512F480B8A9952D662380_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_28;
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
		// float intensityMultiplier = Timing.ConstantIntensity ? 1f : feedbacksIntensity;
		MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD* L_2 = ((MMFeedback_tE51A2F7A01B1E3BE46047E5A0D6BA5C79199FDCA*)__this)->___Timing_7;
		NullCheck(L_2);
		bool L_3 = L_2->___ConstantIntensity_11;
		if (L_3)
		{
			goto IL_0020;
		}
	}
	{
		float L_4 = ___feedbacksIntensity1;
		G_B6_0 = L_4;
		goto IL_0025;
	}

IL_0020:
	{
		G_B6_0 = (1.0f);
	}

IL_0025:
	{
		V_0 = G_B6_0;
		// MMLensDistortionShakeEvent_HDRP.Trigger(Intensity, FeedbackDuration, RemapIntensityZero, RemapIntensityOne, RelativeIntensity, intensityMultiplier,
		//     Channel, ResetShakerValuesAfterShake, ResetTargetValuesAfterShake, NormalPlayDirection, Timing.TimescaleMode);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_5 = __this->___Intensity_34;
		float L_6;
		L_6 = VirtualFuncInvoker0< float >::Invoke(16 /* System.Single MoreMountains.Feedbacks.MMFeedback::get_FeedbackDuration() */, __this);
		float L_7 = __this->___RemapIntensityZero_35;
		float L_8 = __this->___RemapIntensityOne_36;
		bool L_9 = __this->___RelativeIntensity_33;
		float L_10 = V_0;
		int32_t L_11 = __this->___Channel_29;
		bool L_12 = __this->___ResetShakerValuesAfterShake_31;
		bool L_13 = __this->___ResetTargetValuesAfterShake_32;
		bool L_14;
		L_14 = VirtualFuncInvoker0< bool >::Invoke(33 /* System.Boolean MoreMountains.Feedbacks.MMFeedback::get_NormalPlayDirection() */, __this);
		MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD* L_15 = ((MMFeedback_tE51A2F7A01B1E3BE46047E5A0D6BA5C79199FDCA*)__this)->___Timing_7;
		NullCheck(L_15);
		int32_t L_16 = L_15->___TimescaleMode_0;
		MMLensDistortionShakeEvent_HDRP_Trigger_mDACE6D0F2A1411F1F1D8914EF04250023C3065BC(L_5, L_6, L_7, L_8, L_9, L_10, L_11, L_12, L_13, L_14, L_16, (bool)0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackLensDistortion_HDRP::CustomStopFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackLensDistortion_HDRP_CustomStopFeedback_mAF954B08E4EBB4207A900E806ADB8459A6A67E20 (MMFeedbackLensDistortion_HDRP_tCC834E1D0D5B6F46A8F512F480B8A9952D662380* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMFeedbackLensDistortion_HDRP_tCC834E1D0D5B6F46A8F512F480B8A9952D662380_il2cpp_TypeInfo_var);
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
		il2cpp_codegen_runtime_class_init_inline(MMFeedbackLensDistortion_HDRP_tCC834E1D0D5B6F46A8F512F480B8A9952D662380_il2cpp_TypeInfo_var);
		bool L_1 = ((MMFeedbackLensDistortion_HDRP_tCC834E1D0D5B6F46A8F512F480B8A9952D662380_StaticFields*)il2cpp_codegen_static_fields_for(MMFeedbackLensDistortion_HDRP_tCC834E1D0D5B6F46A8F512F480B8A9952D662380_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_28;
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
		// base.CustomStopFeedback(position, feedbacksIntensity);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2 = ___position0;
		float L_3 = ___feedbacksIntensity1;
		MMFeedback_CustomStopFeedback_m812755E219AA8EF519A2D89F6C91AB793AE27EDD(__this, L_2, L_3, NULL);
		// MMLensDistortionShakeEvent_HDRP.Trigger(Intensity, FeedbackDuration, RemapIntensityZero, RemapIntensityOne,
		//     RelativeIntensity, channel: Channel, stop: true);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_4 = __this->___Intensity_34;
		float L_5;
		L_5 = VirtualFuncInvoker0< float >::Invoke(16 /* System.Single MoreMountains.Feedbacks.MMFeedback::get_FeedbackDuration() */, __this);
		float L_6 = __this->___RemapIntensityZero_35;
		float L_7 = __this->___RemapIntensityOne_36;
		bool L_8 = __this->___RelativeIntensity_33;
		int32_t L_9 = __this->___Channel_29;
		MMLensDistortionShakeEvent_HDRP_Trigger_mDACE6D0F2A1411F1F1D8914EF04250023C3065BC(L_4, L_5, L_6, L_7, L_8, (1.0f), L_9, (bool)1, (bool)1, (bool)1, 0, (bool)1, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackLensDistortion_HDRP::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackLensDistortion_HDRP__ctor_m8AE27FE3D6749D06D8575D14736370ADD812AA26 (MMFeedbackLensDistortion_HDRP_tCC834E1D0D5B6F46A8F512F480B8A9952D662380* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public float Duration = 0.8f;
		__this->___Duration_30 = (0.800000012f);
		// public bool ResetShakerValuesAfterShake = true;
		__this->___ResetShakerValuesAfterShake_31 = (bool)1;
		// public bool ResetTargetValuesAfterShake = true;
		__this->___ResetTargetValuesAfterShake_32 = (bool)1;
		// public AnimationCurve Intensity = new AnimationCurve(new Keyframe(0, 0),
		//     new Keyframe(0.2f, 1),
		//     new Keyframe(0.25f, -1),
		//     new Keyframe(0.35f, 0.7f),
		//     new Keyframe(0.4f, -0.7f),
		//     new Keyframe(0.6f, 0.3f),
		//     new Keyframe(0.65f, -0.3f),
		//     new Keyframe(0.8f, 0.1f),
		//     new Keyframe(0.85f, -0.1f),
		//     new Keyframe(1, 0));
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_0 = (KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3*)(KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3*)SZArrayNew(KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var, (uint32_t)((int32_t)10));
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_1 = L_0;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_2;
		memset((&L_2), 0, sizeof(L_2));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_2), (0.0f), (0.0f), /*hidden argument*/NULL);
		NullCheck(L_1);
		(L_1)->SetAt(static_cast<il2cpp_array_size_t>(0), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_2);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_3 = L_1;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_4;
		memset((&L_4), 0, sizeof(L_4));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_4), (0.200000003f), (1.0f), /*hidden argument*/NULL);
		NullCheck(L_3);
		(L_3)->SetAt(static_cast<il2cpp_array_size_t>(1), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_4);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_5 = L_3;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_6;
		memset((&L_6), 0, sizeof(L_6));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_6), (0.25f), (-1.0f), /*hidden argument*/NULL);
		NullCheck(L_5);
		(L_5)->SetAt(static_cast<il2cpp_array_size_t>(2), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_6);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_7 = L_5;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_8;
		memset((&L_8), 0, sizeof(L_8));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_8), (0.349999994f), (0.699999988f), /*hidden argument*/NULL);
		NullCheck(L_7);
		(L_7)->SetAt(static_cast<il2cpp_array_size_t>(3), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_8);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_9 = L_7;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_10;
		memset((&L_10), 0, sizeof(L_10));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_10), (0.400000006f), (-0.699999988f), /*hidden argument*/NULL);
		NullCheck(L_9);
		(L_9)->SetAt(static_cast<il2cpp_array_size_t>(4), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_10);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_11 = L_9;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_12;
		memset((&L_12), 0, sizeof(L_12));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_12), (0.600000024f), (0.300000012f), /*hidden argument*/NULL);
		NullCheck(L_11);
		(L_11)->SetAt(static_cast<il2cpp_array_size_t>(5), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_12);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_13 = L_11;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_14;
		memset((&L_14), 0, sizeof(L_14));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_14), (0.649999976f), (-0.300000012f), /*hidden argument*/NULL);
		NullCheck(L_13);
		(L_13)->SetAt(static_cast<il2cpp_array_size_t>(6), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_14);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_15 = L_13;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_16;
		memset((&L_16), 0, sizeof(L_16));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_16), (0.800000012f), (0.100000001f), /*hidden argument*/NULL);
		NullCheck(L_15);
		(L_15)->SetAt(static_cast<il2cpp_array_size_t>(7), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_16);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_17 = L_15;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_18;
		memset((&L_18), 0, sizeof(L_18));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_18), (0.850000024f), (-0.100000001f), /*hidden argument*/NULL);
		NullCheck(L_17);
		(L_17)->SetAt(static_cast<il2cpp_array_size_t>(8), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_18);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_19 = L_17;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_20;
		memset((&L_20), 0, sizeof(L_20));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_20), (1.0f), (0.0f), /*hidden argument*/NULL);
		NullCheck(L_19);
		(L_19)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)9)), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_20);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_21 = (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*)il2cpp_codegen_object_new(AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		NullCheck(L_21);
		AnimationCurve__ctor_mEABC98C03805713354D61E50D9340766BD5B717E(L_21, L_19, NULL);
		__this->___Intensity_34 = L_21;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___Intensity_34), (void*)L_21);
		// public float RemapIntensityOne = 0.5f;
		__this->___RemapIntensityOne_36 = (0.5f);
		MMFeedback__ctor_mCD506F8FC949D7574B8EB30A5C0CC117C19BD647(__this, NULL);
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackLensDistortion_HDRP::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackLensDistortion_HDRP__cctor_mED4622E82407DEAB88C28501AEE568615B863CAD (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMFeedbackLensDistortion_HDRP_tCC834E1D0D5B6F46A8F512F480B8A9952D662380_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public static bool FeedbackTypeAuthorized = true;
		((MMFeedbackLensDistortion_HDRP_tCC834E1D0D5B6F46A8F512F480B8A9952D662380_StaticFields*)il2cpp_codegen_static_fields_for(MMFeedbackLensDistortion_HDRP_tCC834E1D0D5B6F46A8F512F480B8A9952D662380_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_28 = (bool)1;
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
// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackMotionBlur_HDRP::get_FeedbackDuration()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float MMFeedbackMotionBlur_HDRP_get_FeedbackDuration_m1F9DE054D6FE30212099AE38D44267184D161DA5 (MMFeedbackMotionBlur_HDRP_t726897213A8066AA7377F6281608B75D9E5B6410* __this, const RuntimeMethod* method) 
{
	{
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(Duration); } set { Duration = value; } }
		float L_0 = __this->___Duration_30;
		float L_1;
		L_1 = VirtualFuncInvoker1< float, float >::Invoke(36 /* System.Single MoreMountains.Feedbacks.MMFeedback::ApplyTimeMultiplier(System.Single) */, __this, L_0);
		return L_1;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackMotionBlur_HDRP::set_FeedbackDuration(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackMotionBlur_HDRP_set_FeedbackDuration_m46948812A33FE18610310AFC7706A0CD35C4F0B6 (MMFeedbackMotionBlur_HDRP_t726897213A8066AA7377F6281608B75D9E5B6410* __this, float ___value0, const RuntimeMethod* method) 
{
	{
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(Duration); } set { Duration = value; } }
		float L_0 = ___value0;
		__this->___Duration_30 = L_0;
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(Duration); } set { Duration = value; } }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackMotionBlur_HDRP::CustomPlayFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackMotionBlur_HDRP_CustomPlayFeedback_m42CC7042FCB84423EC3A83B68030BC5FF8923861 (MMFeedbackMotionBlur_HDRP_t726897213A8066AA7377F6281608B75D9E5B6410* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMFeedbackMotionBlur_HDRP_t726897213A8066AA7377F6281608B75D9E5B6410_il2cpp_TypeInfo_var);
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
		il2cpp_codegen_runtime_class_init_inline(MMFeedbackMotionBlur_HDRP_t726897213A8066AA7377F6281608B75D9E5B6410_il2cpp_TypeInfo_var);
		bool L_1 = ((MMFeedbackMotionBlur_HDRP_t726897213A8066AA7377F6281608B75D9E5B6410_StaticFields*)il2cpp_codegen_static_fields_for(MMFeedbackMotionBlur_HDRP_t726897213A8066AA7377F6281608B75D9E5B6410_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_28;
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
		// float intensityMultiplier = Timing.ConstantIntensity ? 1f : feedbacksIntensity;
		MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD* L_2 = ((MMFeedback_tE51A2F7A01B1E3BE46047E5A0D6BA5C79199FDCA*)__this)->___Timing_7;
		NullCheck(L_2);
		bool L_3 = L_2->___ConstantIntensity_11;
		if (L_3)
		{
			goto IL_0020;
		}
	}
	{
		float L_4 = ___feedbacksIntensity1;
		G_B6_0 = L_4;
		goto IL_0025;
	}

IL_0020:
	{
		G_B6_0 = (1.0f);
	}

IL_0025:
	{
		V_0 = G_B6_0;
		// MMMotionBlurShakeEvent_HDRP.Trigger(Intensity, FeedbackDuration, RemapIntensityZero, RemapIntensityOne, RelativeIntensity, intensityMultiplier,
		//     Channel, ResetShakerValuesAfterShake, ResetTargetValuesAfterShake, NormalPlayDirection, Timing.TimescaleMode);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_5 = __this->___Intensity_33;
		float L_6;
		L_6 = VirtualFuncInvoker0< float >::Invoke(16 /* System.Single MoreMountains.Feedbacks.MMFeedback::get_FeedbackDuration() */, __this);
		float L_7 = __this->___RemapIntensityZero_34;
		float L_8 = __this->___RemapIntensityOne_35;
		bool L_9 = __this->___RelativeIntensity_36;
		float L_10 = V_0;
		int32_t L_11 = __this->___Channel_29;
		bool L_12 = __this->___ResetShakerValuesAfterShake_31;
		bool L_13 = __this->___ResetTargetValuesAfterShake_32;
		bool L_14;
		L_14 = VirtualFuncInvoker0< bool >::Invoke(33 /* System.Boolean MoreMountains.Feedbacks.MMFeedback::get_NormalPlayDirection() */, __this);
		MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD* L_15 = ((MMFeedback_tE51A2F7A01B1E3BE46047E5A0D6BA5C79199FDCA*)__this)->___Timing_7;
		NullCheck(L_15);
		int32_t L_16 = L_15->___TimescaleMode_0;
		MMMotionBlurShakeEvent_HDRP_Trigger_m91FD70589D40180513688CF1469168B97995EE6C(L_5, L_6, L_7, L_8, L_9, L_10, L_11, L_12, L_13, L_14, L_16, (bool)0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackMotionBlur_HDRP::CustomStopFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackMotionBlur_HDRP_CustomStopFeedback_m09E1914C68F69611880E48D9724C591306E20E17 (MMFeedbackMotionBlur_HDRP_t726897213A8066AA7377F6281608B75D9E5B6410* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMFeedbackMotionBlur_HDRP_t726897213A8066AA7377F6281608B75D9E5B6410_il2cpp_TypeInfo_var);
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
		il2cpp_codegen_runtime_class_init_inline(MMFeedbackMotionBlur_HDRP_t726897213A8066AA7377F6281608B75D9E5B6410_il2cpp_TypeInfo_var);
		bool L_1 = ((MMFeedbackMotionBlur_HDRP_t726897213A8066AA7377F6281608B75D9E5B6410_StaticFields*)il2cpp_codegen_static_fields_for(MMFeedbackMotionBlur_HDRP_t726897213A8066AA7377F6281608B75D9E5B6410_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_28;
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
		// base.CustomStopFeedback(position, feedbacksIntensity);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2 = ___position0;
		float L_3 = ___feedbacksIntensity1;
		MMFeedback_CustomStopFeedback_m812755E219AA8EF519A2D89F6C91AB793AE27EDD(__this, L_2, L_3, NULL);
		// MMMotionBlurShakeEvent_HDRP.Trigger(Intensity, FeedbackDuration, RemapIntensityZero, RemapIntensityOne,
		//     RelativeIntensity, channel: Channel, stop: true);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_4 = __this->___Intensity_33;
		float L_5;
		L_5 = VirtualFuncInvoker0< float >::Invoke(16 /* System.Single MoreMountains.Feedbacks.MMFeedback::get_FeedbackDuration() */, __this);
		float L_6 = __this->___RemapIntensityZero_34;
		float L_7 = __this->___RemapIntensityOne_35;
		bool L_8 = __this->___RelativeIntensity_36;
		int32_t L_9 = __this->___Channel_29;
		MMMotionBlurShakeEvent_HDRP_Trigger_m91FD70589D40180513688CF1469168B97995EE6C(L_4, L_5, L_6, L_7, L_8, (1.0f), L_9, (bool)1, (bool)1, (bool)1, 0, (bool)1, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackMotionBlur_HDRP::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackMotionBlur_HDRP__ctor_m2A9F99EB73B19337AB8A23093533264B0F7E0A02 (MMFeedbackMotionBlur_HDRP_t726897213A8066AA7377F6281608B75D9E5B6410* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public float Duration = 0.2f;
		__this->___Duration_30 = (0.200000003f);
		// public bool ResetShakerValuesAfterShake = true;
		__this->___ResetShakerValuesAfterShake_31 = (bool)1;
		// public bool ResetTargetValuesAfterShake = true;
		__this->___ResetTargetValuesAfterShake_32 = (bool)1;
		// public AnimationCurve Intensity = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
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
		__this->___Intensity_33 = L_7;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___Intensity_33), (void*)L_7);
		// public float RemapIntensityOne = 1000f;
		__this->___RemapIntensityOne_35 = (1000.0f);
		MMFeedback__ctor_mCD506F8FC949D7574B8EB30A5C0CC117C19BD647(__this, NULL);
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackMotionBlur_HDRP::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackMotionBlur_HDRP__cctor_mBB66898C11E47521B2BA924BF9E11D559C33EE6D (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMFeedbackMotionBlur_HDRP_t726897213A8066AA7377F6281608B75D9E5B6410_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public static bool FeedbackTypeAuthorized = true;
		((MMFeedbackMotionBlur_HDRP_t726897213A8066AA7377F6281608B75D9E5B6410_StaticFields*)il2cpp_codegen_static_fields_for(MMFeedbackMotionBlur_HDRP_t726897213A8066AA7377F6281608B75D9E5B6410_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_28 = (bool)1;
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
// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackPaniniProjection_HDRP::get_FeedbackDuration()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float MMFeedbackPaniniProjection_HDRP_get_FeedbackDuration_m3276B71DC7C02577E9BEA50607C21370C6B4F2C5 (MMFeedbackPaniniProjection_HDRP_tE2401287FF42E493F48B927B259C4A9EA85B2536* __this, const RuntimeMethod* method) 
{
	{
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(Duration); } set { Duration = value; } }
		float L_0 = __this->___Duration_30;
		float L_1;
		L_1 = VirtualFuncInvoker1< float, float >::Invoke(36 /* System.Single MoreMountains.Feedbacks.MMFeedback::ApplyTimeMultiplier(System.Single) */, __this, L_0);
		return L_1;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackPaniniProjection_HDRP::set_FeedbackDuration(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackPaniniProjection_HDRP_set_FeedbackDuration_mAC894AB19FEF33803AB137CF907EF86D52A334B3 (MMFeedbackPaniniProjection_HDRP_tE2401287FF42E493F48B927B259C4A9EA85B2536* __this, float ___value0, const RuntimeMethod* method) 
{
	{
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(Duration); } set { Duration = value; } }
		float L_0 = ___value0;
		__this->___Duration_30 = L_0;
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(Duration); } set { Duration = value; } }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackPaniniProjection_HDRP::CustomPlayFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackPaniniProjection_HDRP_CustomPlayFeedback_m27FDB279120B9B01269FDC305412168616716E7E (MMFeedbackPaniniProjection_HDRP_tE2401287FF42E493F48B927B259C4A9EA85B2536* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMFeedbackPaniniProjection_HDRP_tE2401287FF42E493F48B927B259C4A9EA85B2536_il2cpp_TypeInfo_var);
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
		il2cpp_codegen_runtime_class_init_inline(MMFeedbackPaniniProjection_HDRP_tE2401287FF42E493F48B927B259C4A9EA85B2536_il2cpp_TypeInfo_var);
		bool L_1 = ((MMFeedbackPaniniProjection_HDRP_tE2401287FF42E493F48B927B259C4A9EA85B2536_StaticFields*)il2cpp_codegen_static_fields_for(MMFeedbackPaniniProjection_HDRP_tE2401287FF42E493F48B927B259C4A9EA85B2536_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_28;
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
		// float intensityMultiplier = Timing.ConstantIntensity ? 1f : feedbacksIntensity;
		MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD* L_2 = ((MMFeedback_tE51A2F7A01B1E3BE46047E5A0D6BA5C79199FDCA*)__this)->___Timing_7;
		NullCheck(L_2);
		bool L_3 = L_2->___ConstantIntensity_11;
		if (L_3)
		{
			goto IL_0020;
		}
	}
	{
		float L_4 = ___feedbacksIntensity1;
		G_B6_0 = L_4;
		goto IL_0025;
	}

IL_0020:
	{
		G_B6_0 = (1.0f);
	}

IL_0025:
	{
		V_0 = G_B6_0;
		// MMPaniniProjectionShakeEvent_HDRP.Trigger(ShakeDistance, FeedbackDuration, RemapDistanceZero, RemapDistanceOne, RelativeDistance, intensityMultiplier, Channel,
		//     ResetShakerValuesAfterShake, ResetTargetValuesAfterShake, NormalPlayDirection, Timing.TimescaleMode);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_5 = __this->___ShakeDistance_34;
		float L_6;
		L_6 = VirtualFuncInvoker0< float >::Invoke(16 /* System.Single MoreMountains.Feedbacks.MMFeedback::get_FeedbackDuration() */, __this);
		float L_7 = __this->___RemapDistanceZero_35;
		float L_8 = __this->___RemapDistanceOne_36;
		bool L_9 = __this->___RelativeDistance_33;
		float L_10 = V_0;
		int32_t L_11 = __this->___Channel_29;
		bool L_12 = __this->___ResetShakerValuesAfterShake_31;
		bool L_13 = __this->___ResetTargetValuesAfterShake_32;
		bool L_14;
		L_14 = VirtualFuncInvoker0< bool >::Invoke(33 /* System.Boolean MoreMountains.Feedbacks.MMFeedback::get_NormalPlayDirection() */, __this);
		MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD* L_15 = ((MMFeedback_tE51A2F7A01B1E3BE46047E5A0D6BA5C79199FDCA*)__this)->___Timing_7;
		NullCheck(L_15);
		int32_t L_16 = L_15->___TimescaleMode_0;
		MMPaniniProjectionShakeEvent_HDRP_Trigger_m8BC36B04EDE4E0A775110B51573142062BE2209F(L_5, L_6, L_7, L_8, L_9, L_10, L_11, L_12, L_13, L_14, L_16, (bool)0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackPaniniProjection_HDRP::CustomStopFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackPaniniProjection_HDRP_CustomStopFeedback_m15C6BB9EBA024D00656633CED9FC9ACF2DAB5E3A (MMFeedbackPaniniProjection_HDRP_tE2401287FF42E493F48B927B259C4A9EA85B2536* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMFeedbackPaniniProjection_HDRP_tE2401287FF42E493F48B927B259C4A9EA85B2536_il2cpp_TypeInfo_var);
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
		il2cpp_codegen_runtime_class_init_inline(MMFeedbackPaniniProjection_HDRP_tE2401287FF42E493F48B927B259C4A9EA85B2536_il2cpp_TypeInfo_var);
		bool L_1 = ((MMFeedbackPaniniProjection_HDRP_tE2401287FF42E493F48B927B259C4A9EA85B2536_StaticFields*)il2cpp_codegen_static_fields_for(MMFeedbackPaniniProjection_HDRP_tE2401287FF42E493F48B927B259C4A9EA85B2536_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_28;
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
		// base.CustomStopFeedback(position, feedbacksIntensity);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2 = ___position0;
		float L_3 = ___feedbacksIntensity1;
		MMFeedback_CustomStopFeedback_m812755E219AA8EF519A2D89F6C91AB793AE27EDD(__this, L_2, L_3, NULL);
		// MMPaniniProjectionShakeEvent_HDRP.Trigger(ShakeDistance, FeedbackDuration, RemapDistanceZero, RemapDistanceOne, RelativeDistance, channel:Channel, stop:true);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_4 = __this->___ShakeDistance_34;
		float L_5;
		L_5 = VirtualFuncInvoker0< float >::Invoke(16 /* System.Single MoreMountains.Feedbacks.MMFeedback::get_FeedbackDuration() */, __this);
		float L_6 = __this->___RemapDistanceZero_35;
		float L_7 = __this->___RemapDistanceOne_36;
		bool L_8 = __this->___RelativeDistance_33;
		int32_t L_9 = __this->___Channel_29;
		MMPaniniProjectionShakeEvent_HDRP_Trigger_m8BC36B04EDE4E0A775110B51573142062BE2209F(L_4, L_5, L_6, L_7, L_8, (1.0f), L_9, (bool)1, (bool)1, (bool)1, 0, (bool)1, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackPaniniProjection_HDRP::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackPaniniProjection_HDRP__ctor_mB667C416B3996218C8437A9342924BE9CC8D5C58 (MMFeedbackPaniniProjection_HDRP_tE2401287FF42E493F48B927B259C4A9EA85B2536* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public float Duration = 0.2f;
		__this->___Duration_30 = (0.200000003f);
		// public bool ResetShakerValuesAfterShake = true;
		__this->___ResetShakerValuesAfterShake_31 = (bool)1;
		// public bool ResetTargetValuesAfterShake = true;
		__this->___ResetTargetValuesAfterShake_32 = (bool)1;
		// public AnimationCurve ShakeDistance = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
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
		__this->___ShakeDistance_34 = L_7;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ShakeDistance_34), (void*)L_7);
		// public float RemapDistanceOne = 1f;
		__this->___RemapDistanceOne_36 = (1.0f);
		MMFeedback__ctor_mCD506F8FC949D7574B8EB30A5C0CC117C19BD647(__this, NULL);
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackPaniniProjection_HDRP::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackPaniniProjection_HDRP__cctor_m374D2221E5B2712CC2E0B69F74B81D4DB4502AE2 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMFeedbackPaniniProjection_HDRP_tE2401287FF42E493F48B927B259C4A9EA85B2536_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public static bool FeedbackTypeAuthorized = true;
		((MMFeedbackPaniniProjection_HDRP_tE2401287FF42E493F48B927B259C4A9EA85B2536_StaticFields*)il2cpp_codegen_static_fields_for(MMFeedbackPaniniProjection_HDRP_tE2401287FF42E493F48B927B259C4A9EA85B2536_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_28 = (bool)1;
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
// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackVignette_HDRP::get_FeedbackDuration()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float MMFeedbackVignette_HDRP_get_FeedbackDuration_m5458E1303D22DA8F084A579C91612FA020F70C85 (MMFeedbackVignette_HDRP_tBB217D0E1DDEA10E932AB75E962FBB1EC382342A* __this, const RuntimeMethod* method) 
{
	{
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(Duration); } set { Duration = value; } }
		float L_0 = __this->___Duration_30;
		float L_1;
		L_1 = VirtualFuncInvoker1< float, float >::Invoke(36 /* System.Single MoreMountains.Feedbacks.MMFeedback::ApplyTimeMultiplier(System.Single) */, __this, L_0);
		return L_1;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackVignette_HDRP::set_FeedbackDuration(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackVignette_HDRP_set_FeedbackDuration_m8D92323B1B9C06D97E2F5F5D4FC63D0843A6CCE6 (MMFeedbackVignette_HDRP_tBB217D0E1DDEA10E932AB75E962FBB1EC382342A* __this, float ___value0, const RuntimeMethod* method) 
{
	{
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(Duration); } set { Duration = value; } }
		float L_0 = ___value0;
		__this->___Duration_30 = L_0;
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(Duration); } set { Duration = value; } }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackVignette_HDRP::CustomPlayFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackVignette_HDRP_CustomPlayFeedback_m979D0DE2A507F8FF23D93F6150FF5FB46D827DAD (MMFeedbackVignette_HDRP_tBB217D0E1DDEA10E932AB75E962FBB1EC382342A* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMFeedbackVignette_HDRP_tBB217D0E1DDEA10E932AB75E962FBB1EC382342A_il2cpp_TypeInfo_var);
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
		il2cpp_codegen_runtime_class_init_inline(MMFeedbackVignette_HDRP_tBB217D0E1DDEA10E932AB75E962FBB1EC382342A_il2cpp_TypeInfo_var);
		bool L_1 = ((MMFeedbackVignette_HDRP_tBB217D0E1DDEA10E932AB75E962FBB1EC382342A_StaticFields*)il2cpp_codegen_static_fields_for(MMFeedbackVignette_HDRP_tBB217D0E1DDEA10E932AB75E962FBB1EC382342A_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_28;
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
		// float intensityMultiplier = Timing.ConstantIntensity ? 1f : feedbacksIntensity;
		MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD* L_2 = ((MMFeedback_tE51A2F7A01B1E3BE46047E5A0D6BA5C79199FDCA*)__this)->___Timing_7;
		NullCheck(L_2);
		bool L_3 = L_2->___ConstantIntensity_11;
		if (L_3)
		{
			goto IL_0020;
		}
	}
	{
		float L_4 = ___feedbacksIntensity1;
		G_B6_0 = L_4;
		goto IL_0025;
	}

IL_0020:
	{
		G_B6_0 = (1.0f);
	}

IL_0025:
	{
		V_0 = G_B6_0;
		// MMVignetteShakeEvent_HDRP.Trigger(Intensity, FeedbackDuration, RemapIntensityZero, RemapIntensityOne, RelativeIntensity, intensityMultiplier,
		//     Channel, ResetShakerValuesAfterShake, ResetTargetValuesAfterShake, NormalPlayDirection, Timing.TimescaleMode);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_5 = __this->___Intensity_33;
		float L_6;
		L_6 = VirtualFuncInvoker0< float >::Invoke(16 /* System.Single MoreMountains.Feedbacks.MMFeedback::get_FeedbackDuration() */, __this);
		float L_7 = __this->___RemapIntensityZero_34;
		float L_8 = __this->___RemapIntensityOne_35;
		bool L_9 = __this->___RelativeIntensity_36;
		float L_10 = V_0;
		int32_t L_11 = __this->___Channel_29;
		bool L_12 = __this->___ResetShakerValuesAfterShake_31;
		bool L_13 = __this->___ResetTargetValuesAfterShake_32;
		bool L_14;
		L_14 = VirtualFuncInvoker0< bool >::Invoke(33 /* System.Boolean MoreMountains.Feedbacks.MMFeedback::get_NormalPlayDirection() */, __this);
		MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD* L_15 = ((MMFeedback_tE51A2F7A01B1E3BE46047E5A0D6BA5C79199FDCA*)__this)->___Timing_7;
		NullCheck(L_15);
		int32_t L_16 = L_15->___TimescaleMode_0;
		MMVignetteShakeEvent_HDRP_Trigger_mF821317AF76CAA81B63DAD57A3D4DB379EF40B47(L_5, L_6, L_7, L_8, L_9, L_10, L_11, L_12, L_13, L_14, L_16, (bool)0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackVignette_HDRP::CustomStopFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackVignette_HDRP_CustomStopFeedback_m943A182C0371AE9BDA00700460BF444F64F866B1 (MMFeedbackVignette_HDRP_tBB217D0E1DDEA10E932AB75E962FBB1EC382342A* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMFeedbackVignette_HDRP_tBB217D0E1DDEA10E932AB75E962FBB1EC382342A_il2cpp_TypeInfo_var);
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
		il2cpp_codegen_runtime_class_init_inline(MMFeedbackVignette_HDRP_tBB217D0E1DDEA10E932AB75E962FBB1EC382342A_il2cpp_TypeInfo_var);
		bool L_1 = ((MMFeedbackVignette_HDRP_tBB217D0E1DDEA10E932AB75E962FBB1EC382342A_StaticFields*)il2cpp_codegen_static_fields_for(MMFeedbackVignette_HDRP_tBB217D0E1DDEA10E932AB75E962FBB1EC382342A_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_28;
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
		// base.CustomStopFeedback(position, feedbacksIntensity);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2 = ___position0;
		float L_3 = ___feedbacksIntensity1;
		MMFeedback_CustomStopFeedback_m812755E219AA8EF519A2D89F6C91AB793AE27EDD(__this, L_2, L_3, NULL);
		// MMVignetteShakeEvent_HDRP.Trigger(Intensity, FeedbackDuration, RemapIntensityZero, RemapIntensityOne, RelativeIntensity, channel:Channel, stop:true);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_4 = __this->___Intensity_33;
		float L_5;
		L_5 = VirtualFuncInvoker0< float >::Invoke(16 /* System.Single MoreMountains.Feedbacks.MMFeedback::get_FeedbackDuration() */, __this);
		float L_6 = __this->___RemapIntensityZero_34;
		float L_7 = __this->___RemapIntensityOne_35;
		bool L_8 = __this->___RelativeIntensity_36;
		int32_t L_9 = __this->___Channel_29;
		MMVignetteShakeEvent_HDRP_Trigger_mF821317AF76CAA81B63DAD57A3D4DB379EF40B47(L_4, L_5, L_6, L_7, L_8, (1.0f), L_9, (bool)1, (bool)1, (bool)1, 0, (bool)1, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackVignette_HDRP::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackVignette_HDRP__ctor_m24E5D110C2921AD6F04227EC8DBAC0B48E293D96 (MMFeedbackVignette_HDRP_tBB217D0E1DDEA10E932AB75E962FBB1EC382342A* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public float Duration = 0.2f;
		__this->___Duration_30 = (0.200000003f);
		// public bool ResetShakerValuesAfterShake = true;
		__this->___ResetShakerValuesAfterShake_31 = (bool)1;
		// public bool ResetTargetValuesAfterShake = true;
		__this->___ResetTargetValuesAfterShake_32 = (bool)1;
		// public AnimationCurve Intensity = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
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
		__this->___Intensity_33 = L_7;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___Intensity_33), (void*)L_7);
		// public float RemapIntensityOne = 1.0f;
		__this->___RemapIntensityOne_35 = (1.0f);
		MMFeedback__ctor_mCD506F8FC949D7574B8EB30A5C0CC117C19BD647(__this, NULL);
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackVignette_HDRP::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackVignette_HDRP__cctor_m4C626126260DC4F9BFB70AB1BBA01DB716C85815 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMFeedbackVignette_HDRP_tBB217D0E1DDEA10E932AB75E962FBB1EC382342A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public static bool FeedbackTypeAuthorized = true;
		((MMFeedbackVignette_HDRP_tBB217D0E1DDEA10E932AB75E962FBB1EC382342A_StaticFields*)il2cpp_codegen_static_fields_for(MMFeedbackVignette_HDRP_tBB217D0E1DDEA10E932AB75E962FBB1EC382342A_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_28 = (bool)1;
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
// System.Single MoreMountains.FeedbacksForThirdParty.MMFeedbackWhiteBalance_HDRP::get_FeedbackDuration()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float MMFeedbackWhiteBalance_HDRP_get_FeedbackDuration_mE17211EAA8B2B11A3C3E02A6C1CC9E1E9C8C2A92 (MMFeedbackWhiteBalance_HDRP_t4D7756DFBD852A605B201C0F63F472455C03E48E* __this, const RuntimeMethod* method) 
{
	{
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(ShakeDuration); } set { ShakeDuration = value; } }
		float L_0 = __this->___ShakeDuration_30;
		float L_1;
		L_1 = VirtualFuncInvoker1< float, float >::Invoke(36 /* System.Single MoreMountains.Feedbacks.MMFeedback::ApplyTimeMultiplier(System.Single) */, __this, L_0);
		return L_1;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackWhiteBalance_HDRP::set_FeedbackDuration(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackWhiteBalance_HDRP_set_FeedbackDuration_mFE4F48BA9E2871200829EEBF16080274184D1465 (MMFeedbackWhiteBalance_HDRP_t4D7756DFBD852A605B201C0F63F472455C03E48E* __this, float ___value0, const RuntimeMethod* method) 
{
	{
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(ShakeDuration); } set { ShakeDuration = value; } }
		float L_0 = ___value0;
		__this->___ShakeDuration_30 = L_0;
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(ShakeDuration); } set { ShakeDuration = value; } }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackWhiteBalance_HDRP::CustomPlayFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackWhiteBalance_HDRP_CustomPlayFeedback_m07C17B02B2D9A5EE30382CC10077835D452BA601 (MMFeedbackWhiteBalance_HDRP_t4D7756DFBD852A605B201C0F63F472455C03E48E* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMFeedbackWhiteBalance_HDRP_t4D7756DFBD852A605B201C0F63F472455C03E48E_il2cpp_TypeInfo_var);
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
		il2cpp_codegen_runtime_class_init_inline(MMFeedbackWhiteBalance_HDRP_t4D7756DFBD852A605B201C0F63F472455C03E48E_il2cpp_TypeInfo_var);
		bool L_1 = ((MMFeedbackWhiteBalance_HDRP_t4D7756DFBD852A605B201C0F63F472455C03E48E_StaticFields*)il2cpp_codegen_static_fields_for(MMFeedbackWhiteBalance_HDRP_t4D7756DFBD852A605B201C0F63F472455C03E48E_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_28;
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
		// float intensityMultiplier = Timing.ConstantIntensity ? 1f : feedbacksIntensity;
		MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD* L_2 = ((MMFeedback_tE51A2F7A01B1E3BE46047E5A0D6BA5C79199FDCA*)__this)->___Timing_7;
		NullCheck(L_2);
		bool L_3 = L_2->___ConstantIntensity_11;
		if (L_3)
		{
			goto IL_0020;
		}
	}
	{
		float L_4 = ___feedbacksIntensity1;
		G_B6_0 = L_4;
		goto IL_0025;
	}

IL_0020:
	{
		G_B6_0 = (1.0f);
	}

IL_0025:
	{
		V_0 = G_B6_0;
		// MMWhiteBalanceShakeEvent_HDRP.Trigger(ShakeTemperature, FeedbackDuration, RemapTemperatureZero, RemapTemperatureOne,
		//     ShakeTint, RemapTintZero, RemapTintOne, RelativeValues, intensityMultiplier,
		//     Channel, ResetShakerValuesAfterShake, ResetTargetValuesAfterShake, NormalPlayDirection, Timing.TimescaleMode);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_5 = __this->___ShakeTemperature_34;
		float L_6;
		L_6 = VirtualFuncInvoker0< float >::Invoke(16 /* System.Single MoreMountains.Feedbacks.MMFeedback::get_FeedbackDuration() */, __this);
		float L_7 = __this->___RemapTemperatureZero_35;
		float L_8 = __this->___RemapTemperatureOne_36;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_9 = __this->___ShakeTint_37;
		float L_10 = __this->___RemapTintZero_38;
		float L_11 = __this->___RemapTintOne_39;
		bool L_12 = __this->___RelativeValues_31;
		float L_13 = V_0;
		int32_t L_14 = __this->___Channel_29;
		bool L_15 = __this->___ResetShakerValuesAfterShake_32;
		bool L_16 = __this->___ResetTargetValuesAfterShake_33;
		bool L_17;
		L_17 = VirtualFuncInvoker0< bool >::Invoke(33 /* System.Boolean MoreMountains.Feedbacks.MMFeedback::get_NormalPlayDirection() */, __this);
		MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD* L_18 = ((MMFeedback_tE51A2F7A01B1E3BE46047E5A0D6BA5C79199FDCA*)__this)->___Timing_7;
		NullCheck(L_18);
		int32_t L_19 = L_18->___TimescaleMode_0;
		MMWhiteBalanceShakeEvent_HDRP_Trigger_mAB52FBCD73353B6F59806FD3216FFCCA35F97A6D(L_5, L_6, L_7, L_8, L_9, L_10, L_11, L_12, L_13, L_14, L_15, L_16, L_17, L_19, (bool)0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackWhiteBalance_HDRP::CustomStopFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackWhiteBalance_HDRP_CustomStopFeedback_m68DA6717DE21B24C6CC85094259A83C0B81D7F78 (MMFeedbackWhiteBalance_HDRP_t4D7756DFBD852A605B201C0F63F472455C03E48E* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMFeedbackWhiteBalance_HDRP_t4D7756DFBD852A605B201C0F63F472455C03E48E_il2cpp_TypeInfo_var);
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
		il2cpp_codegen_runtime_class_init_inline(MMFeedbackWhiteBalance_HDRP_t4D7756DFBD852A605B201C0F63F472455C03E48E_il2cpp_TypeInfo_var);
		bool L_1 = ((MMFeedbackWhiteBalance_HDRP_t4D7756DFBD852A605B201C0F63F472455C03E48E_StaticFields*)il2cpp_codegen_static_fields_for(MMFeedbackWhiteBalance_HDRP_t4D7756DFBD852A605B201C0F63F472455C03E48E_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_28;
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
		// base.CustomStopFeedback(position, feedbacksIntensity);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2 = ___position0;
		float L_3 = ___feedbacksIntensity1;
		MMFeedback_CustomStopFeedback_m812755E219AA8EF519A2D89F6C91AB793AE27EDD(__this, L_2, L_3, NULL);
		// MMWhiteBalanceShakeEvent_HDRP.Trigger(ShakeTemperature, FeedbackDuration, RemapTemperatureZero, RemapTemperatureOne,
		//     ShakeTint, RemapTintZero, RemapTintOne, RelativeValues, channel:Channel, stop:true);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_4 = __this->___ShakeTemperature_34;
		float L_5;
		L_5 = VirtualFuncInvoker0< float >::Invoke(16 /* System.Single MoreMountains.Feedbacks.MMFeedback::get_FeedbackDuration() */, __this);
		float L_6 = __this->___RemapTemperatureZero_35;
		float L_7 = __this->___RemapTemperatureOne_36;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_8 = __this->___ShakeTint_37;
		float L_9 = __this->___RemapTintZero_38;
		float L_10 = __this->___RemapTintOne_39;
		bool L_11 = __this->___RelativeValues_31;
		int32_t L_12 = __this->___Channel_29;
		MMWhiteBalanceShakeEvent_HDRP_Trigger_mAB52FBCD73353B6F59806FD3216FFCCA35F97A6D(L_4, L_5, L_6, L_7, L_8, L_9, L_10, L_11, (1.0f), L_12, (bool)1, (bool)1, (bool)1, 0, (bool)1, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackWhiteBalance_HDRP::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackWhiteBalance_HDRP__ctor_m08639EDD51B9414F9131899724C35045EAC52C18 (MMFeedbackWhiteBalance_HDRP_t4D7756DFBD852A605B201C0F63F472455C03E48E* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public float ShakeDuration = 1f;
		__this->___ShakeDuration_30 = (1.0f);
		// public bool RelativeValues = true;
		__this->___RelativeValues_31 = (bool)1;
		// public bool ResetShakerValuesAfterShake = true;
		__this->___ResetShakerValuesAfterShake_32 = (bool)1;
		// public bool ResetTargetValuesAfterShake = true;
		__this->___ResetTargetValuesAfterShake_33 = (bool)1;
		// public AnimationCurve ShakeTemperature = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
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
		__this->___ShakeTemperature_34 = L_7;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ShakeTemperature_34), (void*)L_7);
		// public float RemapTemperatureOne = 100f;
		__this->___RemapTemperatureOne_36 = (100.0f);
		// public AnimationCurve ShakeTint = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
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
		__this->___ShakeTint_37 = L_15;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ShakeTint_37), (void*)L_15);
		// public float RemapTintOne = 100f;
		__this->___RemapTintOne_39 = (100.0f);
		MMFeedback__ctor_mCD506F8FC949D7574B8EB30A5C0CC117C19BD647(__this, NULL);
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFeedbackWhiteBalance_HDRP::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFeedbackWhiteBalance_HDRP__cctor_mFED58CD45B0B1D5F76B487242B5F77E2930A9753 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMFeedbackWhiteBalance_HDRP_t4D7756DFBD852A605B201C0F63F472455C03E48E_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public static bool FeedbackTypeAuthorized = true;
		((MMFeedbackWhiteBalance_HDRP_t4D7756DFBD852A605B201C0F63F472455C03E48E_StaticFields*)il2cpp_codegen_static_fields_for(MMFeedbackWhiteBalance_HDRP_t4D7756DFBD852A605B201C0F63F472455C03E48E_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_28 = (bool)1;
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
// System.Single MoreMountains.FeedbacksForThirdParty.MMF_Bloom_HDRP::get_FeedbackDuration()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float MMF_Bloom_HDRP_get_FeedbackDuration_m286C52AA6A527A9DEEB9FFDE90A78D1576E7A1C0 (MMF_Bloom_HDRP_t583E4BC36988860792A3694FAAA4ACB4A61AEE8C* __this, const RuntimeMethod* method) 
{
	{
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(ShakeDuration); }  set { ShakeDuration = value;  } }
		float L_0 = __this->___ShakeDuration_28;
		float L_1;
		L_1 = VirtualFuncInvoker1< float, float >::Invoke(43 /* System.Single MoreMountains.Feedbacks.MMF_Feedback::ApplyTimeMultiplier(System.Single) */, __this, L_0);
		return L_1;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_Bloom_HDRP::set_FeedbackDuration(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_Bloom_HDRP_set_FeedbackDuration_m668B16FCED1C0380151CD8D0B5DB0B6B0731EF6E (MMF_Bloom_HDRP_t583E4BC36988860792A3694FAAA4ACB4A61AEE8C* __this, float ___value0, const RuntimeMethod* method) 
{
	{
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(ShakeDuration); }  set { ShakeDuration = value;  } }
		float L_0 = ___value0;
		__this->___ShakeDuration_28 = L_0;
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(ShakeDuration); }  set { ShakeDuration = value;  } }
		return;
	}
}
// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_Bloom_HDRP::get_HasChannel()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool MMF_Bloom_HDRP_get_HasChannel_m8BCA444CD31CB96EBD663EF823ACFCE848140DBE (MMF_Bloom_HDRP_t583E4BC36988860792A3694FAAA4ACB4A61AEE8C* __this, const RuntimeMethod* method) 
{
	{
		// public override bool HasChannel => true;
		return (bool)1;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_Bloom_HDRP::CustomPlayFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_Bloom_HDRP_CustomPlayFeedback_mDA8D0C28290DB71063F7534F0D3CB80B0670F2E9 (MMF_Bloom_HDRP_t583E4BC36988860792A3694FAAA4ACB4A61AEE8C* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___attenuation1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMF_Bloom_HDRP_t583E4BC36988860792A3694FAAA4ACB4A61AEE8C_il2cpp_TypeInfo_var);
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
		il2cpp_codegen_runtime_class_init_inline(MMF_Bloom_HDRP_t583E4BC36988860792A3694FAAA4ACB4A61AEE8C_il2cpp_TypeInfo_var);
		bool L_1 = ((MMF_Bloom_HDRP_t583E4BC36988860792A3694FAAA4ACB4A61AEE8C_StaticFields*)il2cpp_codegen_static_fields_for(MMF_Bloom_HDRP_t583E4BC36988860792A3694FAAA4ACB4A61AEE8C_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_27;
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
		// MMBloomShakeEvent_HDRP.Trigger(ShakeIntensity, FeedbackDuration, RemapIntensityZero, RemapIntensityOne, ShakeThreshold, RemapThresholdZero, RemapThresholdOne,
		//     RelativeValues, attenuation, Channel, ResetShakerValuesAfterShake, ResetTargetValuesAfterShake, NormalPlayDirection, Timing.TimescaleMode);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_2 = __this->___ShakeIntensity_32;
		float L_3;
		L_3 = VirtualFuncInvoker0< float >::Invoke(26 /* System.Single MoreMountains.Feedbacks.MMF_Feedback::get_FeedbackDuration() */, __this);
		float L_4 = __this->___RemapIntensityZero_33;
		float L_5 = __this->___RemapIntensityOne_34;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_6 = __this->___ShakeThreshold_35;
		float L_7 = __this->___RemapThresholdZero_36;
		float L_8 = __this->___RemapThresholdOne_37;
		bool L_9 = __this->___RelativeValues_31;
		float L_10 = ___attenuation1;
		int32_t L_11 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Channel_3;
		bool L_12 = __this->___ResetShakerValuesAfterShake_29;
		bool L_13 = __this->___ResetTargetValuesAfterShake_30;
		bool L_14;
		L_14 = VirtualFuncInvoker0< bool >::Invoke(45 /* System.Boolean MoreMountains.Feedbacks.MMF_Feedback::get_NormalPlayDirection() */, __this);
		MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD* L_15 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Timing_6;
		NullCheck(L_15);
		int32_t L_16 = L_15->___TimescaleMode_0;
		MMBloomShakeEvent_HDRP_Trigger_mD6CDB0DABD19FEA6B4F331F7D6F6EBF0B683F7DD(L_2, L_3, L_4, L_5, L_6, L_7, L_8, L_9, L_10, L_11, L_12, L_13, L_14, L_16, (bool)0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_Bloom_HDRP::CustomStopFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_Bloom_HDRP_CustomStopFeedback_m0A5492C234009B9ACE27F6C9E857C45242EAAAC9 (MMF_Bloom_HDRP_t583E4BC36988860792A3694FAAA4ACB4A61AEE8C* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMF_Bloom_HDRP_t583E4BC36988860792A3694FAAA4ACB4A61AEE8C_il2cpp_TypeInfo_var);
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
		il2cpp_codegen_runtime_class_init_inline(MMF_Bloom_HDRP_t583E4BC36988860792A3694FAAA4ACB4A61AEE8C_il2cpp_TypeInfo_var);
		bool L_1 = ((MMF_Bloom_HDRP_t583E4BC36988860792A3694FAAA4ACB4A61AEE8C_StaticFields*)il2cpp_codegen_static_fields_for(MMF_Bloom_HDRP_t583E4BC36988860792A3694FAAA4ACB4A61AEE8C_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_27;
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
		// base.CustomStopFeedback(position, feedbacksIntensity);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2 = ___position0;
		float L_3 = ___feedbacksIntensity1;
		MMF_Feedback_CustomStopFeedback_m9388036D957D90AD8C6BC3C4B17AC9A7B3B49A30(__this, L_2, L_3, NULL);
		// MMBloomShakeEvent_HDRP.Trigger(ShakeIntensity, FeedbackDuration, RemapIntensityZero, RemapIntensityOne, ShakeThreshold, RemapThresholdZero, RemapThresholdOne,
		//     RelativeValues, channel:Channel, stop:true);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_4 = __this->___ShakeIntensity_32;
		float L_5;
		L_5 = VirtualFuncInvoker0< float >::Invoke(26 /* System.Single MoreMountains.Feedbacks.MMF_Feedback::get_FeedbackDuration() */, __this);
		float L_6 = __this->___RemapIntensityZero_33;
		float L_7 = __this->___RemapIntensityOne_34;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_8 = __this->___ShakeThreshold_35;
		float L_9 = __this->___RemapThresholdZero_36;
		float L_10 = __this->___RemapThresholdOne_37;
		bool L_11 = __this->___RelativeValues_31;
		int32_t L_12 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Channel_3;
		MMBloomShakeEvent_HDRP_Trigger_mD6CDB0DABD19FEA6B4F331F7D6F6EBF0B683F7DD(L_4, L_5, L_6, L_7, L_8, L_9, L_10, L_11, (1.0f), L_12, (bool)1, (bool)1, (bool)1, 0, (bool)1, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_Bloom_HDRP::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_Bloom_HDRP__ctor_mDFCE713F8D63DD61315FA26B5B75B575FFF74DBE (MMF_Bloom_HDRP_t583E4BC36988860792A3694FAAA4ACB4A61AEE8C* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public float ShakeDuration = 0.2f;
		__this->___ShakeDuration_28 = (0.200000003f);
		// public bool ResetShakerValuesAfterShake = true;
		__this->___ResetShakerValuesAfterShake_29 = (bool)1;
		// public bool ResetTargetValuesAfterShake = true;
		__this->___ResetTargetValuesAfterShake_30 = (bool)1;
		// public bool RelativeValues = true;
		__this->___RelativeValues_31 = (bool)1;
		// public AnimationCurve ShakeIntensity = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
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
		__this->___ShakeIntensity_32 = L_7;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ShakeIntensity_32), (void*)L_7);
		// public float RemapIntensityOne = 1f;
		__this->___RemapIntensityOne_34 = (1.0f);
		// public AnimationCurve ShakeThreshold = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
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
		__this->___ShakeThreshold_35 = L_15;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ShakeThreshold_35), (void*)L_15);
		MMF_Feedback__ctor_mCD413701DAEE304A0840C520FF3EB470EE324AC5(__this, NULL);
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_Bloom_HDRP::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_Bloom_HDRP__cctor_m42C9662DF116DEB02BABD1D97100DE10C1947C67 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMF_Bloom_HDRP_t583E4BC36988860792A3694FAAA4ACB4A61AEE8C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public static bool FeedbackTypeAuthorized = true;
		((MMF_Bloom_HDRP_t583E4BC36988860792A3694FAAA4ACB4A61AEE8C_StaticFields*)il2cpp_codegen_static_fields_for(MMF_Bloom_HDRP_t583E4BC36988860792A3694FAAA4ACB4A61AEE8C_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_27 = (bool)1;
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
// System.Single MoreMountains.FeedbacksForThirdParty.MMF_ChannelMixer_HDRP::get_FeedbackDuration()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float MMF_ChannelMixer_HDRP_get_FeedbackDuration_mDAC281D160F0F8EB6DA46BCE9602F2BF8D21D4A6 (MMF_ChannelMixer_HDRP_tC2DC756B34F42806D3167C44141414379772DB24* __this, const RuntimeMethod* method) 
{
	{
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(ShakeDuration); } set { ShakeDuration = value;  } }
		float L_0 = __this->___ShakeDuration_28;
		float L_1;
		L_1 = VirtualFuncInvoker1< float, float >::Invoke(43 /* System.Single MoreMountains.Feedbacks.MMF_Feedback::ApplyTimeMultiplier(System.Single) */, __this, L_0);
		return L_1;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_ChannelMixer_HDRP::set_FeedbackDuration(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_ChannelMixer_HDRP_set_FeedbackDuration_mDCA5F2B7B83AFD32A565CC3941CA83FB5F0BC9E8 (MMF_ChannelMixer_HDRP_tC2DC756B34F42806D3167C44141414379772DB24* __this, float ___value0, const RuntimeMethod* method) 
{
	{
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(ShakeDuration); } set { ShakeDuration = value;  } }
		float L_0 = ___value0;
		__this->___ShakeDuration_28 = L_0;
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(ShakeDuration); } set { ShakeDuration = value;  } }
		return;
	}
}
// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_ChannelMixer_HDRP::get_HasChannel()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool MMF_ChannelMixer_HDRP_get_HasChannel_mC636DFA9360745429198104F5B049681F75A7370 (MMF_ChannelMixer_HDRP_tC2DC756B34F42806D3167C44141414379772DB24* __this, const RuntimeMethod* method) 
{
	{
		// public override bool HasChannel => true;
		return (bool)1;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_ChannelMixer_HDRP::CustomPlayFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_ChannelMixer_HDRP_CustomPlayFeedback_mCD4B30F5229F11113EFB2AA5A1F7C14DF9C2AA70 (MMF_ChannelMixer_HDRP_tC2DC756B34F42806D3167C44141414379772DB24* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMF_ChannelMixer_HDRP_tC2DC756B34F42806D3167C44141414379772DB24_il2cpp_TypeInfo_var);
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
		il2cpp_codegen_runtime_class_init_inline(MMF_ChannelMixer_HDRP_tC2DC756B34F42806D3167C44141414379772DB24_il2cpp_TypeInfo_var);
		bool L_1 = ((MMF_ChannelMixer_HDRP_tC2DC756B34F42806D3167C44141414379772DB24_StaticFields*)il2cpp_codegen_static_fields_for(MMF_ChannelMixer_HDRP_tC2DC756B34F42806D3167C44141414379772DB24_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_27;
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
		// float intensityMultiplier = Timing.ConstantIntensity ? 1f : feedbacksIntensity;
		MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD* L_2 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Timing_6;
		NullCheck(L_2);
		bool L_3 = L_2->___ConstantIntensity_11;
		if (L_3)
		{
			goto IL_0020;
		}
	}
	{
		float L_4 = ___feedbacksIntensity1;
		G_B6_0 = L_4;
		goto IL_0025;
	}

IL_0020:
	{
		G_B6_0 = (1.0f);
	}

IL_0025:
	{
		V_0 = G_B6_0;
		// MMChannelMixerShakeEvent_HDRP.Trigger(ShakeRed, RemapRedZero, RemapRedOne,
		//     ShakeGreen, RemapGreenZero, RemapGreenOne,
		//     ShakeBlue, RemapBlueZero, RemapBlueOne,
		//     FeedbackDuration,
		//     RelativeIntensity, intensityMultiplier, Channel, ResetShakerValuesAfterShake, ResetTargetValuesAfterShake, NormalPlayDirection, Timing.TimescaleMode);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_5 = __this->___ShakeRed_32;
		float L_6 = __this->___RemapRedZero_33;
		float L_7 = __this->___RemapRedOne_34;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_8 = __this->___ShakeGreen_35;
		float L_9 = __this->___RemapGreenZero_36;
		float L_10 = __this->___RemapGreenOne_37;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_11 = __this->___ShakeBlue_38;
		float L_12 = __this->___RemapBlueZero_39;
		float L_13 = __this->___RemapBlueOne_40;
		float L_14;
		L_14 = VirtualFuncInvoker0< float >::Invoke(26 /* System.Single MoreMountains.Feedbacks.MMF_Feedback::get_FeedbackDuration() */, __this);
		bool L_15 = __this->___RelativeIntensity_29;
		float L_16 = V_0;
		int32_t L_17 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Channel_3;
		bool L_18 = __this->___ResetShakerValuesAfterShake_30;
		bool L_19 = __this->___ResetTargetValuesAfterShake_31;
		bool L_20;
		L_20 = VirtualFuncInvoker0< bool >::Invoke(45 /* System.Boolean MoreMountains.Feedbacks.MMF_Feedback::get_NormalPlayDirection() */, __this);
		MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD* L_21 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Timing_6;
		NullCheck(L_21);
		int32_t L_22 = L_21->___TimescaleMode_0;
		MMChannelMixerShakeEvent_HDRP_Trigger_m0137922D2B53BC7162F552A9F4CD722733123CF7(L_5, L_6, L_7, L_8, L_9, L_10, L_11, L_12, L_13, L_14, L_15, L_16, L_17, L_18, L_19, L_20, L_22, (bool)0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_ChannelMixer_HDRP::CustomStopFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_ChannelMixer_HDRP_CustomStopFeedback_m259416760C90A4C0D559C3CF561A9C38B6BD49EB (MMF_ChannelMixer_HDRP_tC2DC756B34F42806D3167C44141414379772DB24* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMF_ChannelMixer_HDRP_tC2DC756B34F42806D3167C44141414379772DB24_il2cpp_TypeInfo_var);
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
		il2cpp_codegen_runtime_class_init_inline(MMF_ChannelMixer_HDRP_tC2DC756B34F42806D3167C44141414379772DB24_il2cpp_TypeInfo_var);
		bool L_1 = ((MMF_ChannelMixer_HDRP_tC2DC756B34F42806D3167C44141414379772DB24_StaticFields*)il2cpp_codegen_static_fields_for(MMF_ChannelMixer_HDRP_tC2DC756B34F42806D3167C44141414379772DB24_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_27;
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
		// base.CustomStopFeedback(position, feedbacksIntensity);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2 = ___position0;
		float L_3 = ___feedbacksIntensity1;
		MMF_Feedback_CustomStopFeedback_m9388036D957D90AD8C6BC3C4B17AC9A7B3B49A30(__this, L_2, L_3, NULL);
		// MMChannelMixerShakeEvent_HDRP.Trigger(ShakeRed, RemapRedZero, RemapRedOne,
		//     ShakeGreen, RemapGreenZero, RemapGreenOne,
		//     ShakeBlue, RemapBlueZero, RemapBlueOne,
		//     FeedbackDuration,
		//     RelativeIntensity, channel:Channel, stop:true);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_4 = __this->___ShakeRed_32;
		float L_5 = __this->___RemapRedZero_33;
		float L_6 = __this->___RemapRedOne_34;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_7 = __this->___ShakeGreen_35;
		float L_8 = __this->___RemapGreenZero_36;
		float L_9 = __this->___RemapGreenOne_37;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_10 = __this->___ShakeBlue_38;
		float L_11 = __this->___RemapBlueZero_39;
		float L_12 = __this->___RemapBlueOne_40;
		float L_13;
		L_13 = VirtualFuncInvoker0< float >::Invoke(26 /* System.Single MoreMountains.Feedbacks.MMF_Feedback::get_FeedbackDuration() */, __this);
		bool L_14 = __this->___RelativeIntensity_29;
		int32_t L_15 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Channel_3;
		MMChannelMixerShakeEvent_HDRP_Trigger_m0137922D2B53BC7162F552A9F4CD722733123CF7(L_4, L_5, L_6, L_7, L_8, L_9, L_10, L_11, L_12, L_13, L_14, (1.0f), L_15, (bool)1, (bool)1, (bool)1, 0, (bool)1, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_ChannelMixer_HDRP::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_ChannelMixer_HDRP__ctor_m24ABBCC841B5BFC4C00C7D02A9D02A020FB7E3B6 (MMF_ChannelMixer_HDRP_tC2DC756B34F42806D3167C44141414379772DB24* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public float ShakeDuration = 1f;
		__this->___ShakeDuration_28 = (1.0f);
		// public bool RelativeIntensity = true;
		__this->___RelativeIntensity_29 = (bool)1;
		// public bool ResetShakerValuesAfterShake = true;
		__this->___ResetShakerValuesAfterShake_30 = (bool)1;
		// public bool ResetTargetValuesAfterShake = true;
		__this->___ResetTargetValuesAfterShake_31 = (bool)1;
		// public AnimationCurve ShakeRed = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
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
		__this->___ShakeRed_32 = L_7;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ShakeRed_32), (void*)L_7);
		// public float RemapRedOne = 200f;
		__this->___RemapRedOne_34 = (200.0f);
		// public AnimationCurve ShakeGreen = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
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
		__this->___ShakeGreen_35 = L_15;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ShakeGreen_35), (void*)L_15);
		// public float RemapGreenOne = 200f;
		__this->___RemapGreenOne_37 = (200.0f);
		// public AnimationCurve ShakeBlue = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_16 = (KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3*)(KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3*)SZArrayNew(KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var, (uint32_t)3);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_17 = L_16;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_18;
		memset((&L_18), 0, sizeof(L_18));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_18), (0.0f), (0.0f), /*hidden argument*/NULL);
		NullCheck(L_17);
		(L_17)->SetAt(static_cast<il2cpp_array_size_t>(0), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_18);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_19 = L_17;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_20;
		memset((&L_20), 0, sizeof(L_20));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_20), (0.5f), (1.0f), /*hidden argument*/NULL);
		NullCheck(L_19);
		(L_19)->SetAt(static_cast<il2cpp_array_size_t>(1), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_20);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_21 = L_19;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_22;
		memset((&L_22), 0, sizeof(L_22));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_22), (1.0f), (0.0f), /*hidden argument*/NULL);
		NullCheck(L_21);
		(L_21)->SetAt(static_cast<il2cpp_array_size_t>(2), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_22);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_23 = (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*)il2cpp_codegen_object_new(AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		NullCheck(L_23);
		AnimationCurve__ctor_mEABC98C03805713354D61E50D9340766BD5B717E(L_23, L_21, NULL);
		__this->___ShakeBlue_38 = L_23;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ShakeBlue_38), (void*)L_23);
		// public float RemapBlueOne = 200f;
		__this->___RemapBlueOne_40 = (200.0f);
		MMF_Feedback__ctor_mCD413701DAEE304A0840C520FF3EB470EE324AC5(__this, NULL);
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_ChannelMixer_HDRP::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_ChannelMixer_HDRP__cctor_m0900D2F827A7EBAE678606B5DF3F3A07D786E021 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMF_ChannelMixer_HDRP_tC2DC756B34F42806D3167C44141414379772DB24_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public static bool FeedbackTypeAuthorized = true;
		((MMF_ChannelMixer_HDRP_tC2DC756B34F42806D3167C44141414379772DB24_StaticFields*)il2cpp_codegen_static_fields_for(MMF_ChannelMixer_HDRP_tC2DC756B34F42806D3167C44141414379772DB24_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_27 = (bool)1;
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
// System.Single MoreMountains.FeedbacksForThirdParty.MMF_ChromaticAberration_HDRP::get_FeedbackDuration()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float MMF_ChromaticAberration_HDRP_get_FeedbackDuration_mD234C9DCDEEDA6B1700EDEA311A3D0BF8E86DCE9 (MMF_ChromaticAberration_HDRP_tD7D36DC2674B8207EBCFCFAEF6EAEF7D13520240* __this, const RuntimeMethod* method) 
{
	{
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(Duration); } set { Duration = value;  } }
		float L_0 = __this->___Duration_28;
		float L_1;
		L_1 = VirtualFuncInvoker1< float, float >::Invoke(43 /* System.Single MoreMountains.Feedbacks.MMF_Feedback::ApplyTimeMultiplier(System.Single) */, __this, L_0);
		return L_1;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_ChromaticAberration_HDRP::set_FeedbackDuration(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_ChromaticAberration_HDRP_set_FeedbackDuration_mAAEA10F8E76BCCC3BBDF58B48974F98FE81AB29D (MMF_ChromaticAberration_HDRP_tD7D36DC2674B8207EBCFCFAEF6EAEF7D13520240* __this, float ___value0, const RuntimeMethod* method) 
{
	{
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(Duration); } set { Duration = value;  } }
		float L_0 = ___value0;
		__this->___Duration_28 = L_0;
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(Duration); } set { Duration = value;  } }
		return;
	}
}
// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_ChromaticAberration_HDRP::get_HasChannel()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool MMF_ChromaticAberration_HDRP_get_HasChannel_mCF3A578C8F3D794B95FFB3EDFFA5D71CBB773514 (MMF_ChromaticAberration_HDRP_tD7D36DC2674B8207EBCFCFAEF6EAEF7D13520240* __this, const RuntimeMethod* method) 
{
	{
		// public override bool HasChannel => true;
		return (bool)1;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_ChromaticAberration_HDRP::CustomPlayFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_ChromaticAberration_HDRP_CustomPlayFeedback_mB35756C912F86E4C98F9118D4B28A1B098D8828D (MMF_ChromaticAberration_HDRP_tD7D36DC2674B8207EBCFCFAEF6EAEF7D13520240* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMF_ChromaticAberration_HDRP_tD7D36DC2674B8207EBCFCFAEF6EAEF7D13520240_il2cpp_TypeInfo_var);
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
		il2cpp_codegen_runtime_class_init_inline(MMF_ChromaticAberration_HDRP_tD7D36DC2674B8207EBCFCFAEF6EAEF7D13520240_il2cpp_TypeInfo_var);
		bool L_1 = ((MMF_ChromaticAberration_HDRP_tD7D36DC2674B8207EBCFCFAEF6EAEF7D13520240_StaticFields*)il2cpp_codegen_static_fields_for(MMF_ChromaticAberration_HDRP_tD7D36DC2674B8207EBCFCFAEF6EAEF7D13520240_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_27;
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
		// float intensityMultiplier = Timing.ConstantIntensity ? 1f : feedbacksIntensity;
		MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD* L_2 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Timing_6;
		NullCheck(L_2);
		bool L_3 = L_2->___ConstantIntensity_11;
		if (L_3)
		{
			goto IL_0020;
		}
	}
	{
		float L_4 = ___feedbacksIntensity1;
		G_B6_0 = L_4;
		goto IL_0025;
	}

IL_0020:
	{
		G_B6_0 = (1.0f);
	}

IL_0025:
	{
		V_0 = G_B6_0;
		// MMChromaticAberrationShakeEvent_HDRP.Trigger(Intensity, FeedbackDuration, RemapIntensityZero, RemapIntensityOne, RelativeIntensity, intensityMultiplier,
		//     Channel, ResetShakerValuesAfterShake, ResetTargetValuesAfterShake, NormalPlayDirection, Timing.TimescaleMode);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_5 = __this->___Intensity_33;
		float L_6;
		L_6 = VirtualFuncInvoker0< float >::Invoke(26 /* System.Single MoreMountains.Feedbacks.MMF_Feedback::get_FeedbackDuration() */, __this);
		float L_7 = __this->___RemapIntensityZero_31;
		float L_8 = __this->___RemapIntensityOne_32;
		bool L_9 = __this->___RelativeIntensity_35;
		float L_10 = V_0;
		int32_t L_11 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Channel_3;
		bool L_12 = __this->___ResetShakerValuesAfterShake_29;
		bool L_13 = __this->___ResetTargetValuesAfterShake_30;
		bool L_14;
		L_14 = VirtualFuncInvoker0< bool >::Invoke(45 /* System.Boolean MoreMountains.Feedbacks.MMF_Feedback::get_NormalPlayDirection() */, __this);
		MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD* L_15 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Timing_6;
		NullCheck(L_15);
		int32_t L_16 = L_15->___TimescaleMode_0;
		MMChromaticAberrationShakeEvent_HDRP_Trigger_m2BF26327003EB129A7B88CBA28534150C418456E(L_5, L_6, L_7, L_8, L_9, L_10, L_11, L_12, L_13, L_14, L_16, (bool)0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_ChromaticAberration_HDRP::CustomStopFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_ChromaticAberration_HDRP_CustomStopFeedback_mDB47497ECDE95196243D082D8A45DBA646CA3FA9 (MMF_ChromaticAberration_HDRP_tD7D36DC2674B8207EBCFCFAEF6EAEF7D13520240* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMF_ChromaticAberration_HDRP_tD7D36DC2674B8207EBCFCFAEF6EAEF7D13520240_il2cpp_TypeInfo_var);
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
		il2cpp_codegen_runtime_class_init_inline(MMF_ChromaticAberration_HDRP_tD7D36DC2674B8207EBCFCFAEF6EAEF7D13520240_il2cpp_TypeInfo_var);
		bool L_1 = ((MMF_ChromaticAberration_HDRP_tD7D36DC2674B8207EBCFCFAEF6EAEF7D13520240_StaticFields*)il2cpp_codegen_static_fields_for(MMF_ChromaticAberration_HDRP_tD7D36DC2674B8207EBCFCFAEF6EAEF7D13520240_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_27;
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
		// base.CustomStopFeedback(position, feedbacksIntensity);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2 = ___position0;
		float L_3 = ___feedbacksIntensity1;
		MMF_Feedback_CustomStopFeedback_m9388036D957D90AD8C6BC3C4B17AC9A7B3B49A30(__this, L_2, L_3, NULL);
		// MMChromaticAberrationShakeEvent_HDRP.Trigger(Intensity, FeedbackDuration, RemapIntensityZero, RemapIntensityOne, RelativeIntensity, channel:Channel, stop:true);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_4 = __this->___Intensity_33;
		float L_5;
		L_5 = VirtualFuncInvoker0< float >::Invoke(26 /* System.Single MoreMountains.Feedbacks.MMF_Feedback::get_FeedbackDuration() */, __this);
		float L_6 = __this->___RemapIntensityZero_31;
		float L_7 = __this->___RemapIntensityOne_32;
		bool L_8 = __this->___RelativeIntensity_35;
		int32_t L_9 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Channel_3;
		MMChromaticAberrationShakeEvent_HDRP_Trigger_m2BF26327003EB129A7B88CBA28534150C418456E(L_4, L_5, L_6, L_7, L_8, (1.0f), L_9, (bool)1, (bool)1, (bool)1, 0, (bool)1, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_ChromaticAberration_HDRP::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_ChromaticAberration_HDRP__ctor_mF64FBF4ACD66F76A7205E753D1CB21AA5B68C448 (MMF_ChromaticAberration_HDRP_tD7D36DC2674B8207EBCFCFAEF6EAEF7D13520240* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public float Duration = 0.2f;
		__this->___Duration_28 = (0.200000003f);
		// public bool ResetShakerValuesAfterShake = true;
		__this->___ResetShakerValuesAfterShake_29 = (bool)1;
		// public bool ResetTargetValuesAfterShake = true;
		__this->___ResetTargetValuesAfterShake_30 = (bool)1;
		// public float RemapIntensityOne = 1f;
		__this->___RemapIntensityOne_32 = (1.0f);
		// public AnimationCurve Intensity = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
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
		__this->___Intensity_33 = L_7;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___Intensity_33), (void*)L_7);
		// public float Amplitude = 1.0f;
		__this->___Amplitude_34 = (1.0f);
		MMF_Feedback__ctor_mCD413701DAEE304A0840C520FF3EB470EE324AC5(__this, NULL);
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_ChromaticAberration_HDRP::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_ChromaticAberration_HDRP__cctor_m90AADAC59D8BDA7B03FCB5F5A171001D4A2C63EC (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMF_ChromaticAberration_HDRP_tD7D36DC2674B8207EBCFCFAEF6EAEF7D13520240_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public static bool FeedbackTypeAuthorized = true;
		((MMF_ChromaticAberration_HDRP_tD7D36DC2674B8207EBCFCFAEF6EAEF7D13520240_StaticFields*)il2cpp_codegen_static_fields_for(MMF_ChromaticAberration_HDRP_tD7D36DC2674B8207EBCFCFAEF6EAEF7D13520240_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_27 = (bool)1;
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
// System.Single MoreMountains.FeedbacksForThirdParty.MMF_ColorAdjustments_HDRP::get_FeedbackDuration()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float MMF_ColorAdjustments_HDRP_get_FeedbackDuration_m5B4AEB4987C821FE6FA94FE3D9B26E7F23349D29 (MMF_ColorAdjustments_HDRP_t70D2A2F27CA819A0F1E7CE7996B7A17AEFDB124B* __this, const RuntimeMethod* method) 
{
	{
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(ShakeDuration); } set { ShakeDuration = value; } }
		float L_0 = __this->___ShakeDuration_28;
		float L_1;
		L_1 = VirtualFuncInvoker1< float, float >::Invoke(43 /* System.Single MoreMountains.Feedbacks.MMF_Feedback::ApplyTimeMultiplier(System.Single) */, __this, L_0);
		return L_1;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_ColorAdjustments_HDRP::set_FeedbackDuration(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_ColorAdjustments_HDRP_set_FeedbackDuration_m70BFA847EB5D2F91539D8C1703DD32A151DD5EDD (MMF_ColorAdjustments_HDRP_t70D2A2F27CA819A0F1E7CE7996B7A17AEFDB124B* __this, float ___value0, const RuntimeMethod* method) 
{
	{
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(ShakeDuration); } set { ShakeDuration = value; } }
		float L_0 = ___value0;
		__this->___ShakeDuration_28 = L_0;
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(ShakeDuration); } set { ShakeDuration = value; } }
		return;
	}
}
// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_ColorAdjustments_HDRP::get_HasChannel()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool MMF_ColorAdjustments_HDRP_get_HasChannel_m119A3F15051C1E99C71DA30CF4E634901B085354 (MMF_ColorAdjustments_HDRP_t70D2A2F27CA819A0F1E7CE7996B7A17AEFDB124B* __this, const RuntimeMethod* method) 
{
	{
		// public override bool HasChannel => true;
		return (bool)1;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_ColorAdjustments_HDRP::CustomPlayFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_ColorAdjustments_HDRP_CustomPlayFeedback_m78B26261563BF809AFB7901446D3BE60D4FA6B42 (MMF_ColorAdjustments_HDRP_t70D2A2F27CA819A0F1E7CE7996B7A17AEFDB124B* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMF_ColorAdjustments_HDRP_t70D2A2F27CA819A0F1E7CE7996B7A17AEFDB124B_il2cpp_TypeInfo_var);
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
		il2cpp_codegen_runtime_class_init_inline(MMF_ColorAdjustments_HDRP_t70D2A2F27CA819A0F1E7CE7996B7A17AEFDB124B_il2cpp_TypeInfo_var);
		bool L_1 = ((MMF_ColorAdjustments_HDRP_t70D2A2F27CA819A0F1E7CE7996B7A17AEFDB124B_StaticFields*)il2cpp_codegen_static_fields_for(MMF_ColorAdjustments_HDRP_t70D2A2F27CA819A0F1E7CE7996B7A17AEFDB124B_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_27;
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
		// float intensityMultiplier = Timing.ConstantIntensity ? 1f : feedbacksIntensity;
		MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD* L_2 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Timing_6;
		NullCheck(L_2);
		bool L_3 = L_2->___ConstantIntensity_11;
		if (L_3)
		{
			goto IL_0020;
		}
	}
	{
		float L_4 = ___feedbacksIntensity1;
		G_B6_0 = L_4;
		goto IL_0025;
	}

IL_0020:
	{
		G_B6_0 = (1.0f);
	}

IL_0025:
	{
		V_0 = G_B6_0;
		// MMColorAdjustmentsShakeEvent_HDRP.Trigger(ShakePostExposure, RemapPostExposureZero, RemapPostExposureOne,
		//     ShakeHueShift, RemapHueShiftZero, RemapHueShiftOne,
		//     ShakeSaturation, RemapSaturationZero, RemapSaturationOne,
		//     ShakeContrast, RemapContrastZero, RemapContrastOne,
		//     ColorFilterMode, ColorFilterGradient, ColorFilterDestination, ColorFilterCurve,
		//     FeedbackDuration,
		//     RelativeIntensity, intensityMultiplier, Channel, ResetShakerValuesAfterShake, ResetTargetValuesAfterShake, NormalPlayDirection, Timing.TimescaleMode);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_5 = __this->___ShakePostExposure_32;
		float L_6 = __this->___RemapPostExposureZero_33;
		float L_7 = __this->___RemapPostExposureOne_34;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_8 = __this->___ShakeHueShift_35;
		float L_9 = __this->___RemapHueShiftZero_36;
		float L_10 = __this->___RemapHueShiftOne_37;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_11 = __this->___ShakeSaturation_38;
		float L_12 = __this->___RemapSaturationZero_39;
		float L_13 = __this->___RemapSaturationOne_40;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_14 = __this->___ShakeContrast_41;
		float L_15 = __this->___RemapContrastZero_42;
		float L_16 = __this->___RemapContrastOne_43;
		int32_t L_17 = __this->___ColorFilterMode_44;
		Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E* L_18 = __this->___ColorFilterGradient_45;
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F L_19 = __this->___ColorFilterDestination_46;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_20 = __this->___ColorFilterCurve_47;
		float L_21;
		L_21 = VirtualFuncInvoker0< float >::Invoke(26 /* System.Single MoreMountains.Feedbacks.MMF_Feedback::get_FeedbackDuration() */, __this);
		bool L_22 = __this->___RelativeIntensity_29;
		float L_23 = V_0;
		int32_t L_24 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Channel_3;
		bool L_25 = __this->___ResetShakerValuesAfterShake_30;
		bool L_26 = __this->___ResetTargetValuesAfterShake_31;
		bool L_27;
		L_27 = VirtualFuncInvoker0< bool >::Invoke(45 /* System.Boolean MoreMountains.Feedbacks.MMF_Feedback::get_NormalPlayDirection() */, __this);
		MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD* L_28 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Timing_6;
		NullCheck(L_28);
		int32_t L_29 = L_28->___TimescaleMode_0;
		MMColorAdjustmentsShakeEvent_HDRP_Trigger_mEFEAD45DF484AF38F46422ABDEE911B21935BB16(L_5, L_6, L_7, L_8, L_9, L_10, L_11, L_12, L_13, L_14, L_15, L_16, L_17, L_18, L_19, L_20, L_21, L_22, L_23, L_24, L_25, L_26, L_27, L_29, (bool)0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_ColorAdjustments_HDRP::CustomStopFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_ColorAdjustments_HDRP_CustomStopFeedback_m66C3B7E0924B4E49E2FFB637DC77D44FED490A60 (MMF_ColorAdjustments_HDRP_t70D2A2F27CA819A0F1E7CE7996B7A17AEFDB124B* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMF_ColorAdjustments_HDRP_t70D2A2F27CA819A0F1E7CE7996B7A17AEFDB124B_il2cpp_TypeInfo_var);
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
		il2cpp_codegen_runtime_class_init_inline(MMF_ColorAdjustments_HDRP_t70D2A2F27CA819A0F1E7CE7996B7A17AEFDB124B_il2cpp_TypeInfo_var);
		bool L_1 = ((MMF_ColorAdjustments_HDRP_t70D2A2F27CA819A0F1E7CE7996B7A17AEFDB124B_StaticFields*)il2cpp_codegen_static_fields_for(MMF_ColorAdjustments_HDRP_t70D2A2F27CA819A0F1E7CE7996B7A17AEFDB124B_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_27;
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
		// base.CustomStopFeedback(position, feedbacksIntensity);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2 = ___position0;
		float L_3 = ___feedbacksIntensity1;
		MMF_Feedback_CustomStopFeedback_m9388036D957D90AD8C6BC3C4B17AC9A7B3B49A30(__this, L_2, L_3, NULL);
		// MMColorAdjustmentsShakeEvent_HDRP.Trigger(ShakePostExposure, RemapPostExposureZero, RemapPostExposureOne,
		//     ShakeHueShift, RemapHueShiftZero, RemapHueShiftOne,
		//     ShakeSaturation, RemapSaturationZero, RemapSaturationOne,
		//     ShakeContrast, RemapContrastZero, RemapContrastOne,
		//     ColorFilterMode, ColorFilterGradient, ColorFilterDestination, ColorFilterCurve,
		//     FeedbackDuration,
		//     RelativeIntensity, channel:Channel, stop:true);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_4 = __this->___ShakePostExposure_32;
		float L_5 = __this->___RemapPostExposureZero_33;
		float L_6 = __this->___RemapPostExposureOne_34;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_7 = __this->___ShakeHueShift_35;
		float L_8 = __this->___RemapHueShiftZero_36;
		float L_9 = __this->___RemapHueShiftOne_37;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_10 = __this->___ShakeSaturation_38;
		float L_11 = __this->___RemapSaturationZero_39;
		float L_12 = __this->___RemapSaturationOne_40;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_13 = __this->___ShakeContrast_41;
		float L_14 = __this->___RemapContrastZero_42;
		float L_15 = __this->___RemapContrastOne_43;
		int32_t L_16 = __this->___ColorFilterMode_44;
		Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E* L_17 = __this->___ColorFilterGradient_45;
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F L_18 = __this->___ColorFilterDestination_46;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_19 = __this->___ColorFilterCurve_47;
		float L_20;
		L_20 = VirtualFuncInvoker0< float >::Invoke(26 /* System.Single MoreMountains.Feedbacks.MMF_Feedback::get_FeedbackDuration() */, __this);
		bool L_21 = __this->___RelativeIntensity_29;
		int32_t L_22 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Channel_3;
		MMColorAdjustmentsShakeEvent_HDRP_Trigger_mEFEAD45DF484AF38F46422ABDEE911B21935BB16(L_4, L_5, L_6, L_7, L_8, L_9, L_10, L_11, L_12, L_13, L_14, L_15, L_16, L_17, L_18, L_19, L_20, L_21, (1.0f), L_22, (bool)1, (bool)1, (bool)1, 0, (bool)1, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_ColorAdjustments_HDRP::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_ColorAdjustments_HDRP__ctor_mC8718AA0FADBEC1514A687127788ECD40F3ED1D0 (MMF_ColorAdjustments_HDRP_t70D2A2F27CA819A0F1E7CE7996B7A17AEFDB124B* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public float ShakeDuration = 1f;
		__this->___ShakeDuration_28 = (1.0f);
		// public bool RelativeIntensity = true;
		__this->___RelativeIntensity_29 = (bool)1;
		// public bool ResetShakerValuesAfterShake = true;
		__this->___ResetShakerValuesAfterShake_30 = (bool)1;
		// public bool ResetTargetValuesAfterShake = true;
		__this->___ResetTargetValuesAfterShake_31 = (bool)1;
		// public AnimationCurve ShakePostExposure = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
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
		__this->___ShakePostExposure_32 = L_7;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ShakePostExposure_32), (void*)L_7);
		// public float RemapPostExposureOne = 1f;
		__this->___RemapPostExposureOne_34 = (1.0f);
		// public AnimationCurve ShakeHueShift = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
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
		__this->___ShakeHueShift_35 = L_15;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ShakeHueShift_35), (void*)L_15);
		// public float RemapHueShiftOne = 180f;
		__this->___RemapHueShiftOne_37 = (180.0f);
		// public AnimationCurve ShakeSaturation = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_16 = (KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3*)(KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3*)SZArrayNew(KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var, (uint32_t)3);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_17 = L_16;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_18;
		memset((&L_18), 0, sizeof(L_18));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_18), (0.0f), (0.0f), /*hidden argument*/NULL);
		NullCheck(L_17);
		(L_17)->SetAt(static_cast<il2cpp_array_size_t>(0), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_18);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_19 = L_17;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_20;
		memset((&L_20), 0, sizeof(L_20));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_20), (0.5f), (1.0f), /*hidden argument*/NULL);
		NullCheck(L_19);
		(L_19)->SetAt(static_cast<il2cpp_array_size_t>(1), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_20);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_21 = L_19;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_22;
		memset((&L_22), 0, sizeof(L_22));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_22), (1.0f), (0.0f), /*hidden argument*/NULL);
		NullCheck(L_21);
		(L_21)->SetAt(static_cast<il2cpp_array_size_t>(2), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_22);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_23 = (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*)il2cpp_codegen_object_new(AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		NullCheck(L_23);
		AnimationCurve__ctor_mEABC98C03805713354D61E50D9340766BD5B717E(L_23, L_21, NULL);
		__this->___ShakeSaturation_38 = L_23;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ShakeSaturation_38), (void*)L_23);
		// public float RemapSaturationOne = 100f;
		__this->___RemapSaturationOne_40 = (100.0f);
		// public AnimationCurve ShakeContrast = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_24 = (KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3*)(KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3*)SZArrayNew(KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var, (uint32_t)3);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_25 = L_24;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_26;
		memset((&L_26), 0, sizeof(L_26));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_26), (0.0f), (0.0f), /*hidden argument*/NULL);
		NullCheck(L_25);
		(L_25)->SetAt(static_cast<il2cpp_array_size_t>(0), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_26);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_27 = L_25;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_28;
		memset((&L_28), 0, sizeof(L_28));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_28), (0.5f), (1.0f), /*hidden argument*/NULL);
		NullCheck(L_27);
		(L_27)->SetAt(static_cast<il2cpp_array_size_t>(1), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_28);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_29 = L_27;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_30;
		memset((&L_30), 0, sizeof(L_30));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_30), (1.0f), (0.0f), /*hidden argument*/NULL);
		NullCheck(L_29);
		(L_29)->SetAt(static_cast<il2cpp_array_size_t>(2), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_30);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_31 = (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*)il2cpp_codegen_object_new(AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		NullCheck(L_31);
		AnimationCurve__ctor_mEABC98C03805713354D61E50D9340766BD5B717E(L_31, L_29, NULL);
		__this->___ShakeContrast_41 = L_31;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ShakeContrast_41), (void*)L_31);
		// public float RemapContrastOne = 100f;
		__this->___RemapContrastOne_43 = (100.0f);
		// public Color ColorFilterDestination = Color.yellow;
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F L_32;
		L_32 = Color_get_yellow_m66637FA14383E8D74F24AE256B577CE1D55D469F_inline(NULL);
		__this->___ColorFilterDestination_46 = L_32;
		// public AnimationCurve ColorFilterCurve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_33 = (KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3*)(KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3*)SZArrayNew(KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var, (uint32_t)3);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_34 = L_33;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_35;
		memset((&L_35), 0, sizeof(L_35));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_35), (0.0f), (0.0f), /*hidden argument*/NULL);
		NullCheck(L_34);
		(L_34)->SetAt(static_cast<il2cpp_array_size_t>(0), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_35);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_36 = L_34;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_37;
		memset((&L_37), 0, sizeof(L_37));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_37), (0.5f), (1.0f), /*hidden argument*/NULL);
		NullCheck(L_36);
		(L_36)->SetAt(static_cast<il2cpp_array_size_t>(1), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_37);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_38 = L_36;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_39;
		memset((&L_39), 0, sizeof(L_39));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_39), (1.0f), (0.0f), /*hidden argument*/NULL);
		NullCheck(L_38);
		(L_38)->SetAt(static_cast<il2cpp_array_size_t>(2), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_39);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_40 = (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*)il2cpp_codegen_object_new(AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		NullCheck(L_40);
		AnimationCurve__ctor_mEABC98C03805713354D61E50D9340766BD5B717E(L_40, L_38, NULL);
		__this->___ColorFilterCurve_47 = L_40;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ColorFilterCurve_47), (void*)L_40);
		MMF_Feedback__ctor_mCD413701DAEE304A0840C520FF3EB470EE324AC5(__this, NULL);
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_ColorAdjustments_HDRP::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_ColorAdjustments_HDRP__cctor_m808A913F3EB62FD05774D07FC7414BA1B2231D00 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMF_ColorAdjustments_HDRP_t70D2A2F27CA819A0F1E7CE7996B7A17AEFDB124B_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public static bool FeedbackTypeAuthorized = true;
		((MMF_ColorAdjustments_HDRP_t70D2A2F27CA819A0F1E7CE7996B7A17AEFDB124B_StaticFields*)il2cpp_codegen_static_fields_for(MMF_ColorAdjustments_HDRP_t70D2A2F27CA819A0F1E7CE7996B7A17AEFDB124B_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_27 = (bool)1;
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
// System.Single MoreMountains.FeedbacksForThirdParty.MMF_Exposure_HDRP::get_FeedbackDuration()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float MMF_Exposure_HDRP_get_FeedbackDuration_m8D54ADD6AF5833142AAC22A636027E23CDDA1290 (MMF_Exposure_HDRP_tD40DE5A57861581BA0D7198465A6683F481AC412* __this, const RuntimeMethod* method) 
{
	{
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(Duration); } set { Duration = value; } }
		float L_0 = __this->___Duration_28;
		float L_1;
		L_1 = VirtualFuncInvoker1< float, float >::Invoke(43 /* System.Single MoreMountains.Feedbacks.MMF_Feedback::ApplyTimeMultiplier(System.Single) */, __this, L_0);
		return L_1;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_Exposure_HDRP::set_FeedbackDuration(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_Exposure_HDRP_set_FeedbackDuration_mAEBD75D714AF4C0C27A08EF7649493F7657470F9 (MMF_Exposure_HDRP_tD40DE5A57861581BA0D7198465A6683F481AC412* __this, float ___value0, const RuntimeMethod* method) 
{
	{
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(Duration); } set { Duration = value; } }
		float L_0 = ___value0;
		__this->___Duration_28 = L_0;
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(Duration); } set { Duration = value; } }
		return;
	}
}
// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_Exposure_HDRP::get_HasChannel()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool MMF_Exposure_HDRP_get_HasChannel_m03598848FDE5B1C499042F5E054B34ED2C657F88 (MMF_Exposure_HDRP_tD40DE5A57861581BA0D7198465A6683F481AC412* __this, const RuntimeMethod* method) 
{
	{
		// public override bool HasChannel => true;
		return (bool)1;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_Exposure_HDRP::CustomPlayFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_Exposure_HDRP_CustomPlayFeedback_m3A0E58211B34A0BB10DF2027779451FE76EA9EF0 (MMF_Exposure_HDRP_tD40DE5A57861581BA0D7198465A6683F481AC412* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMF_Exposure_HDRP_tD40DE5A57861581BA0D7198465A6683F481AC412_il2cpp_TypeInfo_var);
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
		il2cpp_codegen_runtime_class_init_inline(MMF_Exposure_HDRP_tD40DE5A57861581BA0D7198465A6683F481AC412_il2cpp_TypeInfo_var);
		bool L_1 = ((MMF_Exposure_HDRP_tD40DE5A57861581BA0D7198465A6683F481AC412_StaticFields*)il2cpp_codegen_static_fields_for(MMF_Exposure_HDRP_tD40DE5A57861581BA0D7198465A6683F481AC412_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_27;
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
		// float intensityMultiplier = Timing.ConstantIntensity ? 1f : feedbacksIntensity;
		MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD* L_2 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Timing_6;
		NullCheck(L_2);
		bool L_3 = L_2->___ConstantIntensity_11;
		if (L_3)
		{
			goto IL_0020;
		}
	}
	{
		float L_4 = ___feedbacksIntensity1;
		G_B6_0 = L_4;
		goto IL_0025;
	}

IL_0020:
	{
		G_B6_0 = (1.0f);
	}

IL_0025:
	{
		V_0 = G_B6_0;
		// MMExposureShakeEvent_HDRP.Trigger(FixedExposure, FeedbackDuration, RemapFixedExposureZero, RemapFixedExposureOne, RelativeFixedExposure, intensityMultiplier,
		//     Channel, ResetShakerValuesAfterShake, ResetTargetValuesAfterShake, NormalPlayDirection, Timing.TimescaleMode);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_5 = __this->___FixedExposure_31;
		float L_6;
		L_6 = VirtualFuncInvoker0< float >::Invoke(26 /* System.Single MoreMountains.Feedbacks.MMF_Feedback::get_FeedbackDuration() */, __this);
		float L_7 = __this->___RemapFixedExposureZero_32;
		float L_8 = __this->___RemapFixedExposureOne_33;
		bool L_9 = __this->___RelativeFixedExposure_34;
		float L_10 = V_0;
		int32_t L_11 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Channel_3;
		bool L_12 = __this->___ResetShakerValuesAfterShake_29;
		bool L_13 = __this->___ResetTargetValuesAfterShake_30;
		bool L_14;
		L_14 = VirtualFuncInvoker0< bool >::Invoke(45 /* System.Boolean MoreMountains.Feedbacks.MMF_Feedback::get_NormalPlayDirection() */, __this);
		MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD* L_15 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Timing_6;
		NullCheck(L_15);
		int32_t L_16 = L_15->___TimescaleMode_0;
		MMExposureShakeEvent_HDRP_Trigger_m1896AC3294CC9A9ECAC33EBE25DD0E9FD7E816A6(L_5, L_6, L_7, L_8, L_9, L_10, L_11, L_12, L_13, L_14, L_16, (bool)0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_Exposure_HDRP::CustomStopFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_Exposure_HDRP_CustomStopFeedback_m40942A99DC9BD22D13976C02795CB4514848096E (MMF_Exposure_HDRP_tD40DE5A57861581BA0D7198465A6683F481AC412* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMF_Exposure_HDRP_tD40DE5A57861581BA0D7198465A6683F481AC412_il2cpp_TypeInfo_var);
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
		il2cpp_codegen_runtime_class_init_inline(MMF_Exposure_HDRP_tD40DE5A57861581BA0D7198465A6683F481AC412_il2cpp_TypeInfo_var);
		bool L_1 = ((MMF_Exposure_HDRP_tD40DE5A57861581BA0D7198465A6683F481AC412_StaticFields*)il2cpp_codegen_static_fields_for(MMF_Exposure_HDRP_tD40DE5A57861581BA0D7198465A6683F481AC412_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_27;
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
		// base.CustomStopFeedback(position, feedbacksIntensity);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2 = ___position0;
		float L_3 = ___feedbacksIntensity1;
		MMF_Feedback_CustomStopFeedback_m9388036D957D90AD8C6BC3C4B17AC9A7B3B49A30(__this, L_2, L_3, NULL);
		// MMExposureShakeEvent_HDRP.Trigger(FixedExposure, FeedbackDuration, RemapFixedExposureZero, RemapFixedExposureOne, RelativeFixedExposure, channel:Channel, stop:true);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_4 = __this->___FixedExposure_31;
		float L_5;
		L_5 = VirtualFuncInvoker0< float >::Invoke(26 /* System.Single MoreMountains.Feedbacks.MMF_Feedback::get_FeedbackDuration() */, __this);
		float L_6 = __this->___RemapFixedExposureZero_32;
		float L_7 = __this->___RemapFixedExposureOne_33;
		bool L_8 = __this->___RelativeFixedExposure_34;
		int32_t L_9 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Channel_3;
		MMExposureShakeEvent_HDRP_Trigger_m1896AC3294CC9A9ECAC33EBE25DD0E9FD7E816A6(L_4, L_5, L_6, L_7, L_8, (1.0f), L_9, (bool)1, (bool)1, (bool)1, 0, (bool)1, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_Exposure_HDRP::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_Exposure_HDRP__ctor_m7254DC1438910ADA9291937A1B78D5C984EE778A (MMF_Exposure_HDRP_tD40DE5A57861581BA0D7198465A6683F481AC412* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public float Duration = 0.2f;
		__this->___Duration_28 = (0.200000003f);
		// public bool ResetShakerValuesAfterShake = true;
		__this->___ResetShakerValuesAfterShake_29 = (bool)1;
		// public bool ResetTargetValuesAfterShake = true;
		__this->___ResetTargetValuesAfterShake_30 = (bool)1;
		// public AnimationCurve FixedExposure = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
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
		__this->___FixedExposure_31 = L_7;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___FixedExposure_31), (void*)L_7);
		// public float RemapFixedExposureZero = 8.5f;
		__this->___RemapFixedExposureZero_32 = (8.5f);
		// public float RemapFixedExposureOne = 6f;
		__this->___RemapFixedExposureOne_33 = (6.0f);
		MMF_Feedback__ctor_mCD413701DAEE304A0840C520FF3EB470EE324AC5(__this, NULL);
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_Exposure_HDRP::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_Exposure_HDRP__cctor_mA79379D4965A9F82E82BB400860486CD26001AEA (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMF_Exposure_HDRP_tD40DE5A57861581BA0D7198465A6683F481AC412_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public static bool FeedbackTypeAuthorized = true;
		((MMF_Exposure_HDRP_tD40DE5A57861581BA0D7198465A6683F481AC412_StaticFields*)il2cpp_codegen_static_fields_for(MMF_Exposure_HDRP_tD40DE5A57861581BA0D7198465A6683F481AC412_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_27 = (bool)1;
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
// System.Single MoreMountains.FeedbacksForThirdParty.MMF_FilmGrain_HDRP::get_FeedbackDuration()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float MMF_FilmGrain_HDRP_get_FeedbackDuration_m6D5DD445070AE178EA5B32C87868642D017B784D (MMF_FilmGrain_HDRP_tD693F1E63ABEEF2285669284914A08CE5C6E06DC* __this, const RuntimeMethod* method) 
{
	{
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(Duration); } set { Duration = value; } }
		float L_0 = __this->___Duration_28;
		float L_1;
		L_1 = VirtualFuncInvoker1< float, float >::Invoke(43 /* System.Single MoreMountains.Feedbacks.MMF_Feedback::ApplyTimeMultiplier(System.Single) */, __this, L_0);
		return L_1;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_FilmGrain_HDRP::set_FeedbackDuration(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_FilmGrain_HDRP_set_FeedbackDuration_m25BAE2A212764A3B720813EAE829B4E921737E51 (MMF_FilmGrain_HDRP_tD693F1E63ABEEF2285669284914A08CE5C6E06DC* __this, float ___value0, const RuntimeMethod* method) 
{
	{
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(Duration); } set { Duration = value; } }
		float L_0 = ___value0;
		__this->___Duration_28 = L_0;
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(Duration); } set { Duration = value; } }
		return;
	}
}
// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_FilmGrain_HDRP::get_HasChannel()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool MMF_FilmGrain_HDRP_get_HasChannel_m0BAD468C14538307E400CFD6A6327BDFE54CEAE9 (MMF_FilmGrain_HDRP_tD693F1E63ABEEF2285669284914A08CE5C6E06DC* __this, const RuntimeMethod* method) 
{
	{
		// public override bool HasChannel => true;
		return (bool)1;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_FilmGrain_HDRP::CustomPlayFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_FilmGrain_HDRP_CustomPlayFeedback_m39A3D6672F05A93BDDB1C0D78C809B4D73C238F5 (MMF_FilmGrain_HDRP_tD693F1E63ABEEF2285669284914A08CE5C6E06DC* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMF_FilmGrain_HDRP_tD693F1E63ABEEF2285669284914A08CE5C6E06DC_il2cpp_TypeInfo_var);
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
		il2cpp_codegen_runtime_class_init_inline(MMF_FilmGrain_HDRP_tD693F1E63ABEEF2285669284914A08CE5C6E06DC_il2cpp_TypeInfo_var);
		bool L_1 = ((MMF_FilmGrain_HDRP_tD693F1E63ABEEF2285669284914A08CE5C6E06DC_StaticFields*)il2cpp_codegen_static_fields_for(MMF_FilmGrain_HDRP_tD693F1E63ABEEF2285669284914A08CE5C6E06DC_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_27;
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
		// float intensityMultiplier = Timing.ConstantIntensity ? 1f : feedbacksIntensity;
		MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD* L_2 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Timing_6;
		NullCheck(L_2);
		bool L_3 = L_2->___ConstantIntensity_11;
		if (L_3)
		{
			goto IL_0020;
		}
	}
	{
		float L_4 = ___feedbacksIntensity1;
		G_B6_0 = L_4;
		goto IL_0025;
	}

IL_0020:
	{
		G_B6_0 = (1.0f);
	}

IL_0025:
	{
		V_0 = G_B6_0;
		// MMFilmGrainShakeEvent_HDRP.Trigger(Intensity, FeedbackDuration, RemapIntensityZero, RemapIntensityOne, RelativeIntensity, intensityMultiplier,
		//     Channel, ResetShakerValuesAfterShake, ResetTargetValuesAfterShake, NormalPlayDirection, Timing.TimescaleMode);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_5 = __this->___Intensity_31;
		float L_6;
		L_6 = VirtualFuncInvoker0< float >::Invoke(26 /* System.Single MoreMountains.Feedbacks.MMF_Feedback::get_FeedbackDuration() */, __this);
		float L_7 = __this->___RemapIntensityZero_32;
		float L_8 = __this->___RemapIntensityOne_33;
		bool L_9 = __this->___RelativeIntensity_34;
		float L_10 = V_0;
		int32_t L_11 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Channel_3;
		bool L_12 = __this->___ResetShakerValuesAfterShake_29;
		bool L_13 = __this->___ResetTargetValuesAfterShake_30;
		bool L_14;
		L_14 = VirtualFuncInvoker0< bool >::Invoke(45 /* System.Boolean MoreMountains.Feedbacks.MMF_Feedback::get_NormalPlayDirection() */, __this);
		MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD* L_15 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Timing_6;
		NullCheck(L_15);
		int32_t L_16 = L_15->___TimescaleMode_0;
		MMFilmGrainShakeEvent_HDRP_Trigger_mE93E1C6A7C883DD107BBDFDFAA8D8FDC6090D147(L_5, L_6, L_7, L_8, L_9, L_10, L_11, L_12, L_13, L_14, L_16, (bool)0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_FilmGrain_HDRP::CustomStopFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_FilmGrain_HDRP_CustomStopFeedback_m06F8ACD663F6949CDF85C1DB2FC1D345E7861098 (MMF_FilmGrain_HDRP_tD693F1E63ABEEF2285669284914A08CE5C6E06DC* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMF_FilmGrain_HDRP_tD693F1E63ABEEF2285669284914A08CE5C6E06DC_il2cpp_TypeInfo_var);
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
		il2cpp_codegen_runtime_class_init_inline(MMF_FilmGrain_HDRP_tD693F1E63ABEEF2285669284914A08CE5C6E06DC_il2cpp_TypeInfo_var);
		bool L_1 = ((MMF_FilmGrain_HDRP_tD693F1E63ABEEF2285669284914A08CE5C6E06DC_StaticFields*)il2cpp_codegen_static_fields_for(MMF_FilmGrain_HDRP_tD693F1E63ABEEF2285669284914A08CE5C6E06DC_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_27;
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
		// base.CustomStopFeedback(position, feedbacksIntensity);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2 = ___position0;
		float L_3 = ___feedbacksIntensity1;
		MMF_Feedback_CustomStopFeedback_m9388036D957D90AD8C6BC3C4B17AC9A7B3B49A30(__this, L_2, L_3, NULL);
		// MMFilmGrainShakeEvent_HDRP.Trigger(Intensity, FeedbackDuration, RemapIntensityZero, RemapIntensityOne, RelativeIntensity, channel:Channel, stop:true);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_4 = __this->___Intensity_31;
		float L_5;
		L_5 = VirtualFuncInvoker0< float >::Invoke(26 /* System.Single MoreMountains.Feedbacks.MMF_Feedback::get_FeedbackDuration() */, __this);
		float L_6 = __this->___RemapIntensityZero_32;
		float L_7 = __this->___RemapIntensityOne_33;
		bool L_8 = __this->___RelativeIntensity_34;
		int32_t L_9 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Channel_3;
		MMFilmGrainShakeEvent_HDRP_Trigger_mE93E1C6A7C883DD107BBDFDFAA8D8FDC6090D147(L_4, L_5, L_6, L_7, L_8, (1.0f), L_9, (bool)1, (bool)1, (bool)1, 0, (bool)1, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_FilmGrain_HDRP::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_FilmGrain_HDRP__ctor_mAB88D20DB346996A0E042972DD1FC952BC14A42E (MMF_FilmGrain_HDRP_tD693F1E63ABEEF2285669284914A08CE5C6E06DC* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public float Duration = 0.2f;
		__this->___Duration_28 = (0.200000003f);
		// public bool ResetShakerValuesAfterShake = true;
		__this->___ResetShakerValuesAfterShake_29 = (bool)1;
		// public bool ResetTargetValuesAfterShake = true;
		__this->___ResetTargetValuesAfterShake_30 = (bool)1;
		// public AnimationCurve Intensity = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
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
		__this->___Intensity_31 = L_7;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___Intensity_31), (void*)L_7);
		// public float RemapIntensityOne = 1.0f;
		__this->___RemapIntensityOne_33 = (1.0f);
		MMF_Feedback__ctor_mCD413701DAEE304A0840C520FF3EB470EE324AC5(__this, NULL);
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_FilmGrain_HDRP::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_FilmGrain_HDRP__cctor_m5E2AA1200A484D4B869109B4FC9D95CBB52FFFA7 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMF_FilmGrain_HDRP_tD693F1E63ABEEF2285669284914A08CE5C6E06DC_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public static bool FeedbackTypeAuthorized = true;
		((MMF_FilmGrain_HDRP_tD693F1E63ABEEF2285669284914A08CE5C6E06DC_StaticFields*)il2cpp_codegen_static_fields_for(MMF_FilmGrain_HDRP_tD693F1E63ABEEF2285669284914A08CE5C6E06DC_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_27 = (bool)1;
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
// System.Single MoreMountains.FeedbacksForThirdParty.MMF_LensDistortion_HDRP::get_FeedbackDuration()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float MMF_LensDistortion_HDRP_get_FeedbackDuration_mDEADE95E0805C2286EC54E3235365B4CDF3DF5C6 (MMF_LensDistortion_HDRP_t1CBCDEC25ED40B9644C9104EE2EF9E7F76EA0823* __this, const RuntimeMethod* method) 
{
	{
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(Duration); } set { Duration = value; } }
		float L_0 = __this->___Duration_28;
		float L_1;
		L_1 = VirtualFuncInvoker1< float, float >::Invoke(43 /* System.Single MoreMountains.Feedbacks.MMF_Feedback::ApplyTimeMultiplier(System.Single) */, __this, L_0);
		return L_1;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_LensDistortion_HDRP::set_FeedbackDuration(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_LensDistortion_HDRP_set_FeedbackDuration_m1F395678929910FB480C48BF0777636F241B127D (MMF_LensDistortion_HDRP_t1CBCDEC25ED40B9644C9104EE2EF9E7F76EA0823* __this, float ___value0, const RuntimeMethod* method) 
{
	{
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(Duration); } set { Duration = value; } }
		float L_0 = ___value0;
		__this->___Duration_28 = L_0;
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(Duration); } set { Duration = value; } }
		return;
	}
}
// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_LensDistortion_HDRP::get_HasChannel()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool MMF_LensDistortion_HDRP_get_HasChannel_mB974AE8472FC63CC4FDC9EEC6273829B2EAC0790 (MMF_LensDistortion_HDRP_t1CBCDEC25ED40B9644C9104EE2EF9E7F76EA0823* __this, const RuntimeMethod* method) 
{
	{
		// public override bool HasChannel => true;
		return (bool)1;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_LensDistortion_HDRP::CustomPlayFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_LensDistortion_HDRP_CustomPlayFeedback_mC3A10FEF062B69C37900CB2FC11B1D66795B8559 (MMF_LensDistortion_HDRP_t1CBCDEC25ED40B9644C9104EE2EF9E7F76EA0823* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMF_LensDistortion_HDRP_t1CBCDEC25ED40B9644C9104EE2EF9E7F76EA0823_il2cpp_TypeInfo_var);
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
		il2cpp_codegen_runtime_class_init_inline(MMF_LensDistortion_HDRP_t1CBCDEC25ED40B9644C9104EE2EF9E7F76EA0823_il2cpp_TypeInfo_var);
		bool L_1 = ((MMF_LensDistortion_HDRP_t1CBCDEC25ED40B9644C9104EE2EF9E7F76EA0823_StaticFields*)il2cpp_codegen_static_fields_for(MMF_LensDistortion_HDRP_t1CBCDEC25ED40B9644C9104EE2EF9E7F76EA0823_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_27;
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
		// float intensityMultiplier = Timing.ConstantIntensity ? 1f : feedbacksIntensity;
		MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD* L_2 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Timing_6;
		NullCheck(L_2);
		bool L_3 = L_2->___ConstantIntensity_11;
		if (L_3)
		{
			goto IL_0020;
		}
	}
	{
		float L_4 = ___feedbacksIntensity1;
		G_B6_0 = L_4;
		goto IL_0025;
	}

IL_0020:
	{
		G_B6_0 = (1.0f);
	}

IL_0025:
	{
		V_0 = G_B6_0;
		// MMLensDistortionShakeEvent_HDRP.Trigger(Intensity, FeedbackDuration, RemapIntensityZero, RemapIntensityOne, RelativeIntensity, intensityMultiplier,
		//     Channel, ResetShakerValuesAfterShake, ResetTargetValuesAfterShake, NormalPlayDirection, Timing.TimescaleMode);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_5 = __this->___Intensity_32;
		float L_6;
		L_6 = VirtualFuncInvoker0< float >::Invoke(26 /* System.Single MoreMountains.Feedbacks.MMF_Feedback::get_FeedbackDuration() */, __this);
		float L_7 = __this->___RemapIntensityZero_33;
		float L_8 = __this->___RemapIntensityOne_34;
		bool L_9 = __this->___RelativeIntensity_31;
		float L_10 = V_0;
		int32_t L_11 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Channel_3;
		bool L_12 = __this->___ResetShakerValuesAfterShake_29;
		bool L_13 = __this->___ResetTargetValuesAfterShake_30;
		bool L_14;
		L_14 = VirtualFuncInvoker0< bool >::Invoke(45 /* System.Boolean MoreMountains.Feedbacks.MMF_Feedback::get_NormalPlayDirection() */, __this);
		MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD* L_15 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Timing_6;
		NullCheck(L_15);
		int32_t L_16 = L_15->___TimescaleMode_0;
		MMLensDistortionShakeEvent_HDRP_Trigger_mDACE6D0F2A1411F1F1D8914EF04250023C3065BC(L_5, L_6, L_7, L_8, L_9, L_10, L_11, L_12, L_13, L_14, L_16, (bool)0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_LensDistortion_HDRP::CustomStopFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_LensDistortion_HDRP_CustomStopFeedback_m1E01B55EB0EE947D9432BBD1510914CC47350D53 (MMF_LensDistortion_HDRP_t1CBCDEC25ED40B9644C9104EE2EF9E7F76EA0823* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMF_LensDistortion_HDRP_t1CBCDEC25ED40B9644C9104EE2EF9E7F76EA0823_il2cpp_TypeInfo_var);
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
		il2cpp_codegen_runtime_class_init_inline(MMF_LensDistortion_HDRP_t1CBCDEC25ED40B9644C9104EE2EF9E7F76EA0823_il2cpp_TypeInfo_var);
		bool L_1 = ((MMF_LensDistortion_HDRP_t1CBCDEC25ED40B9644C9104EE2EF9E7F76EA0823_StaticFields*)il2cpp_codegen_static_fields_for(MMF_LensDistortion_HDRP_t1CBCDEC25ED40B9644C9104EE2EF9E7F76EA0823_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_27;
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
		// base.CustomStopFeedback(position, feedbacksIntensity);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2 = ___position0;
		float L_3 = ___feedbacksIntensity1;
		MMF_Feedback_CustomStopFeedback_m9388036D957D90AD8C6BC3C4B17AC9A7B3B49A30(__this, L_2, L_3, NULL);
		// MMLensDistortionShakeEvent_HDRP.Trigger(Intensity, FeedbackDuration, RemapIntensityZero, RemapIntensityOne,
		//     RelativeIntensity, channel: Channel, stop: true);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_4 = __this->___Intensity_32;
		float L_5;
		L_5 = VirtualFuncInvoker0< float >::Invoke(26 /* System.Single MoreMountains.Feedbacks.MMF_Feedback::get_FeedbackDuration() */, __this);
		float L_6 = __this->___RemapIntensityZero_33;
		float L_7 = __this->___RemapIntensityOne_34;
		bool L_8 = __this->___RelativeIntensity_31;
		int32_t L_9 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Channel_3;
		MMLensDistortionShakeEvent_HDRP_Trigger_mDACE6D0F2A1411F1F1D8914EF04250023C3065BC(L_4, L_5, L_6, L_7, L_8, (1.0f), L_9, (bool)1, (bool)1, (bool)1, 0, (bool)1, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_LensDistortion_HDRP::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_LensDistortion_HDRP__ctor_mA10B4539A4BEA260D191AA8F0B9BC5C6602FDBF0 (MMF_LensDistortion_HDRP_t1CBCDEC25ED40B9644C9104EE2EF9E7F76EA0823* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public float Duration = 0.8f;
		__this->___Duration_28 = (0.800000012f);
		// public bool ResetShakerValuesAfterShake = true;
		__this->___ResetShakerValuesAfterShake_29 = (bool)1;
		// public bool ResetTargetValuesAfterShake = true;
		__this->___ResetTargetValuesAfterShake_30 = (bool)1;
		// public AnimationCurve Intensity = new AnimationCurve(new Keyframe(0, 0),
		//     new Keyframe(0.2f, 1),
		//     new Keyframe(0.25f, -1),
		//     new Keyframe(0.35f, 0.7f),
		//     new Keyframe(0.4f, -0.7f),
		//     new Keyframe(0.6f, 0.3f),
		//     new Keyframe(0.65f, -0.3f),
		//     new Keyframe(0.8f, 0.1f),
		//     new Keyframe(0.85f, -0.1f),
		//     new Keyframe(1, 0));
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_0 = (KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3*)(KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3*)SZArrayNew(KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var, (uint32_t)((int32_t)10));
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_1 = L_0;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_2;
		memset((&L_2), 0, sizeof(L_2));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_2), (0.0f), (0.0f), /*hidden argument*/NULL);
		NullCheck(L_1);
		(L_1)->SetAt(static_cast<il2cpp_array_size_t>(0), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_2);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_3 = L_1;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_4;
		memset((&L_4), 0, sizeof(L_4));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_4), (0.200000003f), (1.0f), /*hidden argument*/NULL);
		NullCheck(L_3);
		(L_3)->SetAt(static_cast<il2cpp_array_size_t>(1), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_4);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_5 = L_3;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_6;
		memset((&L_6), 0, sizeof(L_6));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_6), (0.25f), (-1.0f), /*hidden argument*/NULL);
		NullCheck(L_5);
		(L_5)->SetAt(static_cast<il2cpp_array_size_t>(2), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_6);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_7 = L_5;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_8;
		memset((&L_8), 0, sizeof(L_8));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_8), (0.349999994f), (0.699999988f), /*hidden argument*/NULL);
		NullCheck(L_7);
		(L_7)->SetAt(static_cast<il2cpp_array_size_t>(3), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_8);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_9 = L_7;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_10;
		memset((&L_10), 0, sizeof(L_10));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_10), (0.400000006f), (-0.699999988f), /*hidden argument*/NULL);
		NullCheck(L_9);
		(L_9)->SetAt(static_cast<il2cpp_array_size_t>(4), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_10);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_11 = L_9;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_12;
		memset((&L_12), 0, sizeof(L_12));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_12), (0.600000024f), (0.300000012f), /*hidden argument*/NULL);
		NullCheck(L_11);
		(L_11)->SetAt(static_cast<il2cpp_array_size_t>(5), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_12);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_13 = L_11;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_14;
		memset((&L_14), 0, sizeof(L_14));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_14), (0.649999976f), (-0.300000012f), /*hidden argument*/NULL);
		NullCheck(L_13);
		(L_13)->SetAt(static_cast<il2cpp_array_size_t>(6), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_14);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_15 = L_13;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_16;
		memset((&L_16), 0, sizeof(L_16));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_16), (0.800000012f), (0.100000001f), /*hidden argument*/NULL);
		NullCheck(L_15);
		(L_15)->SetAt(static_cast<il2cpp_array_size_t>(7), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_16);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_17 = L_15;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_18;
		memset((&L_18), 0, sizeof(L_18));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_18), (0.850000024f), (-0.100000001f), /*hidden argument*/NULL);
		NullCheck(L_17);
		(L_17)->SetAt(static_cast<il2cpp_array_size_t>(8), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_18);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_19 = L_17;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_20;
		memset((&L_20), 0, sizeof(L_20));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_20), (1.0f), (0.0f), /*hidden argument*/NULL);
		NullCheck(L_19);
		(L_19)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)9)), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_20);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_21 = (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*)il2cpp_codegen_object_new(AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		NullCheck(L_21);
		AnimationCurve__ctor_mEABC98C03805713354D61E50D9340766BD5B717E(L_21, L_19, NULL);
		__this->___Intensity_32 = L_21;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___Intensity_32), (void*)L_21);
		// public float RemapIntensityOne = 0.5f;
		__this->___RemapIntensityOne_34 = (0.5f);
		MMF_Feedback__ctor_mCD413701DAEE304A0840C520FF3EB470EE324AC5(__this, NULL);
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_LensDistortion_HDRP::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_LensDistortion_HDRP__cctor_m0A5180FFF07F9300FCB89CE0676F272FA0A70EB7 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMF_LensDistortion_HDRP_t1CBCDEC25ED40B9644C9104EE2EF9E7F76EA0823_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public static bool FeedbackTypeAuthorized = true;
		((MMF_LensDistortion_HDRP_t1CBCDEC25ED40B9644C9104EE2EF9E7F76EA0823_StaticFields*)il2cpp_codegen_static_fields_for(MMF_LensDistortion_HDRP_t1CBCDEC25ED40B9644C9104EE2EF9E7F76EA0823_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_27 = (bool)1;
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
// System.Single MoreMountains.FeedbacksForThirdParty.MMF_MotionBlur_HDRP::get_FeedbackDuration()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float MMF_MotionBlur_HDRP_get_FeedbackDuration_mABCB5E7727BE756DB9E75CEE4AFD575C6A40720E (MMF_MotionBlur_HDRP_tF0EE4FD8B93630B1A5AFE3686B359264F68FB63F* __this, const RuntimeMethod* method) 
{
	{
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(Duration); } set { Duration = value; } }
		float L_0 = __this->___Duration_28;
		float L_1;
		L_1 = VirtualFuncInvoker1< float, float >::Invoke(43 /* System.Single MoreMountains.Feedbacks.MMF_Feedback::ApplyTimeMultiplier(System.Single) */, __this, L_0);
		return L_1;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_MotionBlur_HDRP::set_FeedbackDuration(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_MotionBlur_HDRP_set_FeedbackDuration_m1863EA13A88C410C0C510DABFAA13DE8D02FFCD5 (MMF_MotionBlur_HDRP_tF0EE4FD8B93630B1A5AFE3686B359264F68FB63F* __this, float ___value0, const RuntimeMethod* method) 
{
	{
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(Duration); } set { Duration = value; } }
		float L_0 = ___value0;
		__this->___Duration_28 = L_0;
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(Duration); } set { Duration = value; } }
		return;
	}
}
// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_MotionBlur_HDRP::get_HasChannel()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool MMF_MotionBlur_HDRP_get_HasChannel_m3A56ACA69459B3CF196B6A9EEA4046F5AD57458D (MMF_MotionBlur_HDRP_tF0EE4FD8B93630B1A5AFE3686B359264F68FB63F* __this, const RuntimeMethod* method) 
{
	{
		// public override bool HasChannel => true;
		return (bool)1;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_MotionBlur_HDRP::CustomPlayFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_MotionBlur_HDRP_CustomPlayFeedback_mA46C8DC39E50DC9B4EB0EDC5902BF046882C65BE (MMF_MotionBlur_HDRP_tF0EE4FD8B93630B1A5AFE3686B359264F68FB63F* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMF_MotionBlur_HDRP_tF0EE4FD8B93630B1A5AFE3686B359264F68FB63F_il2cpp_TypeInfo_var);
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
		il2cpp_codegen_runtime_class_init_inline(MMF_MotionBlur_HDRP_tF0EE4FD8B93630B1A5AFE3686B359264F68FB63F_il2cpp_TypeInfo_var);
		bool L_1 = ((MMF_MotionBlur_HDRP_tF0EE4FD8B93630B1A5AFE3686B359264F68FB63F_StaticFields*)il2cpp_codegen_static_fields_for(MMF_MotionBlur_HDRP_tF0EE4FD8B93630B1A5AFE3686B359264F68FB63F_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_27;
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
		// float intensityMultiplier = Timing.ConstantIntensity ? 1f : feedbacksIntensity;
		MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD* L_2 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Timing_6;
		NullCheck(L_2);
		bool L_3 = L_2->___ConstantIntensity_11;
		if (L_3)
		{
			goto IL_0020;
		}
	}
	{
		float L_4 = ___feedbacksIntensity1;
		G_B6_0 = L_4;
		goto IL_0025;
	}

IL_0020:
	{
		G_B6_0 = (1.0f);
	}

IL_0025:
	{
		V_0 = G_B6_0;
		// MMMotionBlurShakeEvent_HDRP.Trigger(Intensity, FeedbackDuration, RemapIntensityZero, RemapIntensityOne, RelativeIntensity, intensityMultiplier,
		//     Channel, ResetShakerValuesAfterShake, ResetTargetValuesAfterShake, NormalPlayDirection, Timing.TimescaleMode);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_5 = __this->___Intensity_31;
		float L_6;
		L_6 = VirtualFuncInvoker0< float >::Invoke(26 /* System.Single MoreMountains.Feedbacks.MMF_Feedback::get_FeedbackDuration() */, __this);
		float L_7 = __this->___RemapIntensityZero_32;
		float L_8 = __this->___RemapIntensityOne_33;
		bool L_9 = __this->___RelativeIntensity_34;
		float L_10 = V_0;
		int32_t L_11 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Channel_3;
		bool L_12 = __this->___ResetShakerValuesAfterShake_29;
		bool L_13 = __this->___ResetTargetValuesAfterShake_30;
		bool L_14;
		L_14 = VirtualFuncInvoker0< bool >::Invoke(45 /* System.Boolean MoreMountains.Feedbacks.MMF_Feedback::get_NormalPlayDirection() */, __this);
		MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD* L_15 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Timing_6;
		NullCheck(L_15);
		int32_t L_16 = L_15->___TimescaleMode_0;
		MMMotionBlurShakeEvent_HDRP_Trigger_m91FD70589D40180513688CF1469168B97995EE6C(L_5, L_6, L_7, L_8, L_9, L_10, L_11, L_12, L_13, L_14, L_16, (bool)0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_MotionBlur_HDRP::CustomStopFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_MotionBlur_HDRP_CustomStopFeedback_m0E86C49FAAAB9532FD77BDF56365BA7B9242EB1B (MMF_MotionBlur_HDRP_tF0EE4FD8B93630B1A5AFE3686B359264F68FB63F* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMF_MotionBlur_HDRP_tF0EE4FD8B93630B1A5AFE3686B359264F68FB63F_il2cpp_TypeInfo_var);
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
		il2cpp_codegen_runtime_class_init_inline(MMF_MotionBlur_HDRP_tF0EE4FD8B93630B1A5AFE3686B359264F68FB63F_il2cpp_TypeInfo_var);
		bool L_1 = ((MMF_MotionBlur_HDRP_tF0EE4FD8B93630B1A5AFE3686B359264F68FB63F_StaticFields*)il2cpp_codegen_static_fields_for(MMF_MotionBlur_HDRP_tF0EE4FD8B93630B1A5AFE3686B359264F68FB63F_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_27;
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
		// base.CustomStopFeedback(position, feedbacksIntensity);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2 = ___position0;
		float L_3 = ___feedbacksIntensity1;
		MMF_Feedback_CustomStopFeedback_m9388036D957D90AD8C6BC3C4B17AC9A7B3B49A30(__this, L_2, L_3, NULL);
		// MMMotionBlurShakeEvent_HDRP.Trigger(Intensity, FeedbackDuration, RemapIntensityZero, RemapIntensityOne,
		//     RelativeIntensity, channel: Channel, stop: true);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_4 = __this->___Intensity_31;
		float L_5;
		L_5 = VirtualFuncInvoker0< float >::Invoke(26 /* System.Single MoreMountains.Feedbacks.MMF_Feedback::get_FeedbackDuration() */, __this);
		float L_6 = __this->___RemapIntensityZero_32;
		float L_7 = __this->___RemapIntensityOne_33;
		bool L_8 = __this->___RelativeIntensity_34;
		int32_t L_9 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Channel_3;
		MMMotionBlurShakeEvent_HDRP_Trigger_m91FD70589D40180513688CF1469168B97995EE6C(L_4, L_5, L_6, L_7, L_8, (1.0f), L_9, (bool)1, (bool)1, (bool)1, 0, (bool)1, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_MotionBlur_HDRP::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_MotionBlur_HDRP__ctor_mD1AA4F45FB42AE283F574B9D4325E60243034A7C (MMF_MotionBlur_HDRP_tF0EE4FD8B93630B1A5AFE3686B359264F68FB63F* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public float Duration = 0.2f;
		__this->___Duration_28 = (0.200000003f);
		// public bool ResetShakerValuesAfterShake = true;
		__this->___ResetShakerValuesAfterShake_29 = (bool)1;
		// public bool ResetTargetValuesAfterShake = true;
		__this->___ResetTargetValuesAfterShake_30 = (bool)1;
		// public AnimationCurve Intensity = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
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
		__this->___Intensity_31 = L_7;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___Intensity_31), (void*)L_7);
		// public float RemapIntensityOne = 1000f;
		__this->___RemapIntensityOne_33 = (1000.0f);
		MMF_Feedback__ctor_mCD413701DAEE304A0840C520FF3EB470EE324AC5(__this, NULL);
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_MotionBlur_HDRP::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_MotionBlur_HDRP__cctor_m46EC9D0D8444B7FC9230748768C9CF275C583520 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMF_MotionBlur_HDRP_tF0EE4FD8B93630B1A5AFE3686B359264F68FB63F_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public static bool FeedbackTypeAuthorized = true;
		((MMF_MotionBlur_HDRP_tF0EE4FD8B93630B1A5AFE3686B359264F68FB63F_StaticFields*)il2cpp_codegen_static_fields_for(MMF_MotionBlur_HDRP_tF0EE4FD8B93630B1A5AFE3686B359264F68FB63F_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_27 = (bool)1;
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
// System.Single MoreMountains.FeedbacksForThirdParty.MMF_PaniniProjection_HDRP::get_FeedbackDuration()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float MMF_PaniniProjection_HDRP_get_FeedbackDuration_mC129D7D92286E1160AA4717E6BA8112AB4127C50 (MMF_PaniniProjection_HDRP_tDDC11106E1AD99645085221E893B9A46C02C8B40* __this, const RuntimeMethod* method) 
{
	{
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(Duration); } set { Duration = value; } }
		float L_0 = __this->___Duration_28;
		float L_1;
		L_1 = VirtualFuncInvoker1< float, float >::Invoke(43 /* System.Single MoreMountains.Feedbacks.MMF_Feedback::ApplyTimeMultiplier(System.Single) */, __this, L_0);
		return L_1;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_PaniniProjection_HDRP::set_FeedbackDuration(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_PaniniProjection_HDRP_set_FeedbackDuration_mF2F7884599E1EA7894B6020894024642B7BA6F62 (MMF_PaniniProjection_HDRP_tDDC11106E1AD99645085221E893B9A46C02C8B40* __this, float ___value0, const RuntimeMethod* method) 
{
	{
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(Duration); } set { Duration = value; } }
		float L_0 = ___value0;
		__this->___Duration_28 = L_0;
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(Duration); } set { Duration = value; } }
		return;
	}
}
// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_PaniniProjection_HDRP::get_HasChannel()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool MMF_PaniniProjection_HDRP_get_HasChannel_m1A22469BE898B18271FB2F27F35FD86AC086345C (MMF_PaniniProjection_HDRP_tDDC11106E1AD99645085221E893B9A46C02C8B40* __this, const RuntimeMethod* method) 
{
	{
		// public override bool HasChannel => true;
		return (bool)1;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_PaniniProjection_HDRP::CustomPlayFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_PaniniProjection_HDRP_CustomPlayFeedback_m634BE893777F5FF176374DDAA0AE967C9372C7BF (MMF_PaniniProjection_HDRP_tDDC11106E1AD99645085221E893B9A46C02C8B40* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMF_PaniniProjection_HDRP_tDDC11106E1AD99645085221E893B9A46C02C8B40_il2cpp_TypeInfo_var);
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
		il2cpp_codegen_runtime_class_init_inline(MMF_PaniniProjection_HDRP_tDDC11106E1AD99645085221E893B9A46C02C8B40_il2cpp_TypeInfo_var);
		bool L_1 = ((MMF_PaniniProjection_HDRP_tDDC11106E1AD99645085221E893B9A46C02C8B40_StaticFields*)il2cpp_codegen_static_fields_for(MMF_PaniniProjection_HDRP_tDDC11106E1AD99645085221E893B9A46C02C8B40_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_27;
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
		// float intensityMultiplier = Timing.ConstantIntensity ? 1f : feedbacksIntensity;
		MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD* L_2 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Timing_6;
		NullCheck(L_2);
		bool L_3 = L_2->___ConstantIntensity_11;
		if (L_3)
		{
			goto IL_0020;
		}
	}
	{
		float L_4 = ___feedbacksIntensity1;
		G_B6_0 = L_4;
		goto IL_0025;
	}

IL_0020:
	{
		G_B6_0 = (1.0f);
	}

IL_0025:
	{
		V_0 = G_B6_0;
		// MMPaniniProjectionShakeEvent_HDRP.Trigger(ShakeDistance, FeedbackDuration, RemapDistanceZero, RemapDistanceOne, RelativeDistance, intensityMultiplier, Channel,
		//     ResetShakerValuesAfterShake, ResetTargetValuesAfterShake, NormalPlayDirection, Timing.TimescaleMode);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_5 = __this->___ShakeDistance_32;
		float L_6;
		L_6 = VirtualFuncInvoker0< float >::Invoke(26 /* System.Single MoreMountains.Feedbacks.MMF_Feedback::get_FeedbackDuration() */, __this);
		float L_7 = __this->___RemapDistanceZero_33;
		float L_8 = __this->___RemapDistanceOne_34;
		bool L_9 = __this->___RelativeDistance_31;
		float L_10 = V_0;
		int32_t L_11 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Channel_3;
		bool L_12 = __this->___ResetShakerValuesAfterShake_29;
		bool L_13 = __this->___ResetTargetValuesAfterShake_30;
		bool L_14;
		L_14 = VirtualFuncInvoker0< bool >::Invoke(45 /* System.Boolean MoreMountains.Feedbacks.MMF_Feedback::get_NormalPlayDirection() */, __this);
		MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD* L_15 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Timing_6;
		NullCheck(L_15);
		int32_t L_16 = L_15->___TimescaleMode_0;
		MMPaniniProjectionShakeEvent_HDRP_Trigger_m8BC36B04EDE4E0A775110B51573142062BE2209F(L_5, L_6, L_7, L_8, L_9, L_10, L_11, L_12, L_13, L_14, L_16, (bool)0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_PaniniProjection_HDRP::CustomStopFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_PaniniProjection_HDRP_CustomStopFeedback_m62D1C359815BDC3E00E862592AABEB2CF9895EA9 (MMF_PaniniProjection_HDRP_tDDC11106E1AD99645085221E893B9A46C02C8B40* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMF_PaniniProjection_HDRP_tDDC11106E1AD99645085221E893B9A46C02C8B40_il2cpp_TypeInfo_var);
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
		il2cpp_codegen_runtime_class_init_inline(MMF_PaniniProjection_HDRP_tDDC11106E1AD99645085221E893B9A46C02C8B40_il2cpp_TypeInfo_var);
		bool L_1 = ((MMF_PaniniProjection_HDRP_tDDC11106E1AD99645085221E893B9A46C02C8B40_StaticFields*)il2cpp_codegen_static_fields_for(MMF_PaniniProjection_HDRP_tDDC11106E1AD99645085221E893B9A46C02C8B40_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_27;
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
		// base.CustomStopFeedback(position, feedbacksIntensity);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2 = ___position0;
		float L_3 = ___feedbacksIntensity1;
		MMF_Feedback_CustomStopFeedback_m9388036D957D90AD8C6BC3C4B17AC9A7B3B49A30(__this, L_2, L_3, NULL);
		// MMPaniniProjectionShakeEvent_HDRP.Trigger(ShakeDistance, FeedbackDuration, RemapDistanceZero, RemapDistanceOne, RelativeDistance, channel:Channel, stop:true);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_4 = __this->___ShakeDistance_32;
		float L_5;
		L_5 = VirtualFuncInvoker0< float >::Invoke(26 /* System.Single MoreMountains.Feedbacks.MMF_Feedback::get_FeedbackDuration() */, __this);
		float L_6 = __this->___RemapDistanceZero_33;
		float L_7 = __this->___RemapDistanceOne_34;
		bool L_8 = __this->___RelativeDistance_31;
		int32_t L_9 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Channel_3;
		MMPaniniProjectionShakeEvent_HDRP_Trigger_m8BC36B04EDE4E0A775110B51573142062BE2209F(L_4, L_5, L_6, L_7, L_8, (1.0f), L_9, (bool)1, (bool)1, (bool)1, 0, (bool)1, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_PaniniProjection_HDRP::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_PaniniProjection_HDRP__ctor_mC8E9F75D50859E4D36EDFF7EB81CE979206848AC (MMF_PaniniProjection_HDRP_tDDC11106E1AD99645085221E893B9A46C02C8B40* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public float Duration = 0.2f;
		__this->___Duration_28 = (0.200000003f);
		// public bool ResetShakerValuesAfterShake = true;
		__this->___ResetShakerValuesAfterShake_29 = (bool)1;
		// public bool ResetTargetValuesAfterShake = true;
		__this->___ResetTargetValuesAfterShake_30 = (bool)1;
		// public AnimationCurve ShakeDistance = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
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
		__this->___ShakeDistance_32 = L_7;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ShakeDistance_32), (void*)L_7);
		// public float RemapDistanceOne = 1f;
		__this->___RemapDistanceOne_34 = (1.0f);
		MMF_Feedback__ctor_mCD413701DAEE304A0840C520FF3EB470EE324AC5(__this, NULL);
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_PaniniProjection_HDRP::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_PaniniProjection_HDRP__cctor_m85E85A7ABF5989201617291957E663BA3D97C277 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMF_PaniniProjection_HDRP_tDDC11106E1AD99645085221E893B9A46C02C8B40_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public static bool FeedbackTypeAuthorized = true;
		((MMF_PaniniProjection_HDRP_tDDC11106E1AD99645085221E893B9A46C02C8B40_StaticFields*)il2cpp_codegen_static_fields_for(MMF_PaniniProjection_HDRP_tDDC11106E1AD99645085221E893B9A46C02C8B40_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_27 = (bool)1;
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
// System.Single MoreMountains.FeedbacksForThirdParty.MMF_Vignette_HDRP::get_FeedbackDuration()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float MMF_Vignette_HDRP_get_FeedbackDuration_m64F44CFBE56044F14726120A50EB54F1437BE12B (MMF_Vignette_HDRP_t433C1F57FA003E5F6BFF1409F73E44528F35C229* __this, const RuntimeMethod* method) 
{
	{
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(Duration); } set { Duration = value; } }
		float L_0 = __this->___Duration_28;
		float L_1;
		L_1 = VirtualFuncInvoker1< float, float >::Invoke(43 /* System.Single MoreMountains.Feedbacks.MMF_Feedback::ApplyTimeMultiplier(System.Single) */, __this, L_0);
		return L_1;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_Vignette_HDRP::set_FeedbackDuration(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_Vignette_HDRP_set_FeedbackDuration_m705FF2C895890EEF03810C6DA670DA80BFAB036A (MMF_Vignette_HDRP_t433C1F57FA003E5F6BFF1409F73E44528F35C229* __this, float ___value0, const RuntimeMethod* method) 
{
	{
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(Duration); } set { Duration = value; } }
		float L_0 = ___value0;
		__this->___Duration_28 = L_0;
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(Duration); } set { Duration = value; } }
		return;
	}
}
// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_Vignette_HDRP::get_HasChannel()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool MMF_Vignette_HDRP_get_HasChannel_mA0EE616AFA36D21FBA0CAC282C7D0808E08E4F1A (MMF_Vignette_HDRP_t433C1F57FA003E5F6BFF1409F73E44528F35C229* __this, const RuntimeMethod* method) 
{
	{
		// public override bool HasChannel => true;
		return (bool)1;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_Vignette_HDRP::CustomPlayFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_Vignette_HDRP_CustomPlayFeedback_m360661581656539574702DEDF2AB56CF3D4FA405 (MMF_Vignette_HDRP_t433C1F57FA003E5F6BFF1409F73E44528F35C229* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMF_Vignette_HDRP_t433C1F57FA003E5F6BFF1409F73E44528F35C229_il2cpp_TypeInfo_var);
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
		il2cpp_codegen_runtime_class_init_inline(MMF_Vignette_HDRP_t433C1F57FA003E5F6BFF1409F73E44528F35C229_il2cpp_TypeInfo_var);
		bool L_1 = ((MMF_Vignette_HDRP_t433C1F57FA003E5F6BFF1409F73E44528F35C229_StaticFields*)il2cpp_codegen_static_fields_for(MMF_Vignette_HDRP_t433C1F57FA003E5F6BFF1409F73E44528F35C229_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_27;
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
		// float intensityMultiplier = Timing.ConstantIntensity ? 1f : feedbacksIntensity;
		MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD* L_2 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Timing_6;
		NullCheck(L_2);
		bool L_3 = L_2->___ConstantIntensity_11;
		if (L_3)
		{
			goto IL_0020;
		}
	}
	{
		float L_4 = ___feedbacksIntensity1;
		G_B6_0 = L_4;
		goto IL_0025;
	}

IL_0020:
	{
		G_B6_0 = (1.0f);
	}

IL_0025:
	{
		V_0 = G_B6_0;
		// MMVignetteShakeEvent_HDRP.Trigger(Intensity, FeedbackDuration, RemapIntensityZero, RemapIntensityOne, RelativeIntensity, intensityMultiplier,
		//     Channel, ResetShakerValuesAfterShake, ResetTargetValuesAfterShake, NormalPlayDirection, Timing.TimescaleMode);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_5 = __this->___Intensity_31;
		float L_6;
		L_6 = VirtualFuncInvoker0< float >::Invoke(26 /* System.Single MoreMountains.Feedbacks.MMF_Feedback::get_FeedbackDuration() */, __this);
		float L_7 = __this->___RemapIntensityZero_32;
		float L_8 = __this->___RemapIntensityOne_33;
		bool L_9 = __this->___RelativeIntensity_34;
		float L_10 = V_0;
		int32_t L_11 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Channel_3;
		bool L_12 = __this->___ResetShakerValuesAfterShake_29;
		bool L_13 = __this->___ResetTargetValuesAfterShake_30;
		bool L_14;
		L_14 = VirtualFuncInvoker0< bool >::Invoke(45 /* System.Boolean MoreMountains.Feedbacks.MMF_Feedback::get_NormalPlayDirection() */, __this);
		MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD* L_15 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Timing_6;
		NullCheck(L_15);
		int32_t L_16 = L_15->___TimescaleMode_0;
		MMVignetteShakeEvent_HDRP_Trigger_mF821317AF76CAA81B63DAD57A3D4DB379EF40B47(L_5, L_6, L_7, L_8, L_9, L_10, L_11, L_12, L_13, L_14, L_16, (bool)0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_Vignette_HDRP::CustomStopFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_Vignette_HDRP_CustomStopFeedback_mD0D9605056F2EFDB8273C59BA5E67CE1E206D0CB (MMF_Vignette_HDRP_t433C1F57FA003E5F6BFF1409F73E44528F35C229* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMF_Vignette_HDRP_t433C1F57FA003E5F6BFF1409F73E44528F35C229_il2cpp_TypeInfo_var);
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
		il2cpp_codegen_runtime_class_init_inline(MMF_Vignette_HDRP_t433C1F57FA003E5F6BFF1409F73E44528F35C229_il2cpp_TypeInfo_var);
		bool L_1 = ((MMF_Vignette_HDRP_t433C1F57FA003E5F6BFF1409F73E44528F35C229_StaticFields*)il2cpp_codegen_static_fields_for(MMF_Vignette_HDRP_t433C1F57FA003E5F6BFF1409F73E44528F35C229_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_27;
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
		// base.CustomStopFeedback(position, feedbacksIntensity);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2 = ___position0;
		float L_3 = ___feedbacksIntensity1;
		MMF_Feedback_CustomStopFeedback_m9388036D957D90AD8C6BC3C4B17AC9A7B3B49A30(__this, L_2, L_3, NULL);
		// MMVignetteShakeEvent_HDRP.Trigger(Intensity, FeedbackDuration, RemapIntensityZero, RemapIntensityOne, RelativeIntensity, channel:Channel, stop:true);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_4 = __this->___Intensity_31;
		float L_5;
		L_5 = VirtualFuncInvoker0< float >::Invoke(26 /* System.Single MoreMountains.Feedbacks.MMF_Feedback::get_FeedbackDuration() */, __this);
		float L_6 = __this->___RemapIntensityZero_32;
		float L_7 = __this->___RemapIntensityOne_33;
		bool L_8 = __this->___RelativeIntensity_34;
		int32_t L_9 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Channel_3;
		MMVignetteShakeEvent_HDRP_Trigger_mF821317AF76CAA81B63DAD57A3D4DB379EF40B47(L_4, L_5, L_6, L_7, L_8, (1.0f), L_9, (bool)1, (bool)1, (bool)1, 0, (bool)1, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_Vignette_HDRP::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_Vignette_HDRP__ctor_m175DBBC03C2A84949A19A8F429165F3530EEC972 (MMF_Vignette_HDRP_t433C1F57FA003E5F6BFF1409F73E44528F35C229* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public float Duration = 0.2f;
		__this->___Duration_28 = (0.200000003f);
		// public bool ResetShakerValuesAfterShake = true;
		__this->___ResetShakerValuesAfterShake_29 = (bool)1;
		// public bool ResetTargetValuesAfterShake = true;
		__this->___ResetTargetValuesAfterShake_30 = (bool)1;
		// public AnimationCurve Intensity = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
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
		__this->___Intensity_31 = L_7;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___Intensity_31), (void*)L_7);
		// public float RemapIntensityOne = 1.0f;
		__this->___RemapIntensityOne_33 = (1.0f);
		MMF_Feedback__ctor_mCD413701DAEE304A0840C520FF3EB470EE324AC5(__this, NULL);
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_Vignette_HDRP::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_Vignette_HDRP__cctor_mD3402AAD02BF66DC716BCCE02C8899F22EC7A555 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMF_Vignette_HDRP_t433C1F57FA003E5F6BFF1409F73E44528F35C229_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public static bool FeedbackTypeAuthorized = true;
		((MMF_Vignette_HDRP_t433C1F57FA003E5F6BFF1409F73E44528F35C229_StaticFields*)il2cpp_codegen_static_fields_for(MMF_Vignette_HDRP_t433C1F57FA003E5F6BFF1409F73E44528F35C229_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_27 = (bool)1;
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
// System.Single MoreMountains.FeedbacksForThirdParty.MMF_WhiteBalance_HDRP::get_FeedbackDuration()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float MMF_WhiteBalance_HDRP_get_FeedbackDuration_m4BBA0280B7CEE1B0D47A66122BBD3484F4837C7D (MMF_WhiteBalance_HDRP_t37FAFEF0B791B3E1EE7863DD1CAE220CC225606A* __this, const RuntimeMethod* method) 
{
	{
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(ShakeDuration); } set { ShakeDuration = value; } }
		float L_0 = __this->___ShakeDuration_28;
		float L_1;
		L_1 = VirtualFuncInvoker1< float, float >::Invoke(43 /* System.Single MoreMountains.Feedbacks.MMF_Feedback::ApplyTimeMultiplier(System.Single) */, __this, L_0);
		return L_1;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_WhiteBalance_HDRP::set_FeedbackDuration(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_WhiteBalance_HDRP_set_FeedbackDuration_m17345EC33D35E057A072454028E872BD035A22B4 (MMF_WhiteBalance_HDRP_t37FAFEF0B791B3E1EE7863DD1CAE220CC225606A* __this, float ___value0, const RuntimeMethod* method) 
{
	{
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(ShakeDuration); } set { ShakeDuration = value; } }
		float L_0 = ___value0;
		__this->___ShakeDuration_28 = L_0;
		// public override float FeedbackDuration { get { return ApplyTimeMultiplier(ShakeDuration); } set { ShakeDuration = value; } }
		return;
	}
}
// System.Boolean MoreMountains.FeedbacksForThirdParty.MMF_WhiteBalance_HDRP::get_HasChannel()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool MMF_WhiteBalance_HDRP_get_HasChannel_mCE55D5A57A0B128F1BB79A444553D0B8212F5206 (MMF_WhiteBalance_HDRP_t37FAFEF0B791B3E1EE7863DD1CAE220CC225606A* __this, const RuntimeMethod* method) 
{
	{
		// public override bool HasChannel => true;
		return (bool)1;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_WhiteBalance_HDRP::CustomPlayFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_WhiteBalance_HDRP_CustomPlayFeedback_m15B01FCB109F3E75B4AA56D2320CCBCF542066CC (MMF_WhiteBalance_HDRP_t37FAFEF0B791B3E1EE7863DD1CAE220CC225606A* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMF_WhiteBalance_HDRP_t37FAFEF0B791B3E1EE7863DD1CAE220CC225606A_il2cpp_TypeInfo_var);
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
		il2cpp_codegen_runtime_class_init_inline(MMF_WhiteBalance_HDRP_t37FAFEF0B791B3E1EE7863DD1CAE220CC225606A_il2cpp_TypeInfo_var);
		bool L_1 = ((MMF_WhiteBalance_HDRP_t37FAFEF0B791B3E1EE7863DD1CAE220CC225606A_StaticFields*)il2cpp_codegen_static_fields_for(MMF_WhiteBalance_HDRP_t37FAFEF0B791B3E1EE7863DD1CAE220CC225606A_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_27;
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
		// float intensityMultiplier = Timing.ConstantIntensity ? 1f : feedbacksIntensity;
		MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD* L_2 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Timing_6;
		NullCheck(L_2);
		bool L_3 = L_2->___ConstantIntensity_11;
		if (L_3)
		{
			goto IL_0020;
		}
	}
	{
		float L_4 = ___feedbacksIntensity1;
		G_B6_0 = L_4;
		goto IL_0025;
	}

IL_0020:
	{
		G_B6_0 = (1.0f);
	}

IL_0025:
	{
		V_0 = G_B6_0;
		// MMWhiteBalanceShakeEvent_HDRP.Trigger(ShakeTemperature, FeedbackDuration, RemapTemperatureZero, RemapTemperatureOne,
		//     ShakeTint, RemapTintZero, RemapTintOne, RelativeValues, intensityMultiplier,
		//     Channel, ResetShakerValuesAfterShake, ResetTargetValuesAfterShake, NormalPlayDirection, Timing.TimescaleMode);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_5 = __this->___ShakeTemperature_32;
		float L_6;
		L_6 = VirtualFuncInvoker0< float >::Invoke(26 /* System.Single MoreMountains.Feedbacks.MMF_Feedback::get_FeedbackDuration() */, __this);
		float L_7 = __this->___RemapTemperatureZero_33;
		float L_8 = __this->___RemapTemperatureOne_34;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_9 = __this->___ShakeTint_35;
		float L_10 = __this->___RemapTintZero_36;
		float L_11 = __this->___RemapTintOne_37;
		bool L_12 = __this->___RelativeValues_29;
		float L_13 = V_0;
		int32_t L_14 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Channel_3;
		bool L_15 = __this->___ResetShakerValuesAfterShake_30;
		bool L_16 = __this->___ResetTargetValuesAfterShake_31;
		bool L_17;
		L_17 = VirtualFuncInvoker0< bool >::Invoke(45 /* System.Boolean MoreMountains.Feedbacks.MMF_Feedback::get_NormalPlayDirection() */, __this);
		MMFeedbackTiming_t4F4BD4FA251C4038C8FAF0BEB673A8CCC479A9CD* L_18 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Timing_6;
		NullCheck(L_18);
		int32_t L_19 = L_18->___TimescaleMode_0;
		MMWhiteBalanceShakeEvent_HDRP_Trigger_mAB52FBCD73353B6F59806FD3216FFCCA35F97A6D(L_5, L_6, L_7, L_8, L_9, L_10, L_11, L_12, L_13, L_14, L_15, L_16, L_17, L_19, (bool)0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_WhiteBalance_HDRP::CustomStopFeedback(UnityEngine.Vector3,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_WhiteBalance_HDRP_CustomStopFeedback_m563FABB92ED6045202CD74718EBE5FF1700423E9 (MMF_WhiteBalance_HDRP_t37FAFEF0B791B3E1EE7863DD1CAE220CC225606A* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position0, float ___feedbacksIntensity1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMF_WhiteBalance_HDRP_t37FAFEF0B791B3E1EE7863DD1CAE220CC225606A_il2cpp_TypeInfo_var);
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
		il2cpp_codegen_runtime_class_init_inline(MMF_WhiteBalance_HDRP_t37FAFEF0B791B3E1EE7863DD1CAE220CC225606A_il2cpp_TypeInfo_var);
		bool L_1 = ((MMF_WhiteBalance_HDRP_t37FAFEF0B791B3E1EE7863DD1CAE220CC225606A_StaticFields*)il2cpp_codegen_static_fields_for(MMF_WhiteBalance_HDRP_t37FAFEF0B791B3E1EE7863DD1CAE220CC225606A_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_27;
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
		// base.CustomStopFeedback(position, feedbacksIntensity);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2 = ___position0;
		float L_3 = ___feedbacksIntensity1;
		MMF_Feedback_CustomStopFeedback_m9388036D957D90AD8C6BC3C4B17AC9A7B3B49A30(__this, L_2, L_3, NULL);
		// MMWhiteBalanceShakeEvent_HDRP.Trigger(ShakeTemperature, FeedbackDuration, RemapTemperatureZero, RemapTemperatureOne,
		//     ShakeTint, RemapTintZero, RemapTintOne, RelativeValues, channel:Channel, stop:true);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_4 = __this->___ShakeTemperature_32;
		float L_5;
		L_5 = VirtualFuncInvoker0< float >::Invoke(26 /* System.Single MoreMountains.Feedbacks.MMF_Feedback::get_FeedbackDuration() */, __this);
		float L_6 = __this->___RemapTemperatureZero_33;
		float L_7 = __this->___RemapTemperatureOne_34;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_8 = __this->___ShakeTint_35;
		float L_9 = __this->___RemapTintZero_36;
		float L_10 = __this->___RemapTintOne_37;
		bool L_11 = __this->___RelativeValues_29;
		int32_t L_12 = ((MMF_Feedback_t0B678D199FBB49B4BFF7B25186C23D19553ADA1D*)__this)->___Channel_3;
		MMWhiteBalanceShakeEvent_HDRP_Trigger_mAB52FBCD73353B6F59806FD3216FFCCA35F97A6D(L_4, L_5, L_6, L_7, L_8, L_9, L_10, L_11, (1.0f), L_12, (bool)1, (bool)1, (bool)1, 0, (bool)1, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_WhiteBalance_HDRP::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_WhiteBalance_HDRP__ctor_m779E36E3BED2B4551CE3848FB63963303344E35F (MMF_WhiteBalance_HDRP_t37FAFEF0B791B3E1EE7863DD1CAE220CC225606A* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public float ShakeDuration = 1f;
		__this->___ShakeDuration_28 = (1.0f);
		// public bool RelativeValues = true;
		__this->___RelativeValues_29 = (bool)1;
		// public bool ResetShakerValuesAfterShake = true;
		__this->___ResetShakerValuesAfterShake_30 = (bool)1;
		// public bool ResetTargetValuesAfterShake = true;
		__this->___ResetTargetValuesAfterShake_31 = (bool)1;
		// public AnimationCurve ShakeTemperature = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
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
		__this->___ShakeTemperature_32 = L_7;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ShakeTemperature_32), (void*)L_7);
		// public float RemapTemperatureOne = 100f;
		__this->___RemapTemperatureOne_34 = (100.0f);
		// public AnimationCurve ShakeTint = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
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
		__this->___ShakeTint_35 = L_15;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ShakeTint_35), (void*)L_15);
		// public float RemapTintOne = 100f;
		__this->___RemapTintOne_37 = (100.0f);
		MMF_Feedback__ctor_mCD413701DAEE304A0840C520FF3EB470EE324AC5(__this, NULL);
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMF_WhiteBalance_HDRP::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMF_WhiteBalance_HDRP__cctor_mC17BD21E8C9CAFEA960175FA3877A44363F914D1 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMF_WhiteBalance_HDRP_t37FAFEF0B791B3E1EE7863DD1CAE220CC225606A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public static bool FeedbackTypeAuthorized = true;
		((MMF_WhiteBalance_HDRP_t37FAFEF0B791B3E1EE7863DD1CAE220CC225606A_StaticFields*)il2cpp_codegen_static_fields_for(MMF_WhiteBalance_HDRP_t37FAFEF0B791B3E1EE7863DD1CAE220CC225606A_il2cpp_TypeInfo_var))->___FeedbackTypeAuthorized_27 = (bool)1;
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
// System.Void MoreMountains.FeedbacksForThirdParty.MMBloomShaker_HDRP::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMBloomShaker_HDRP__ctor_m301249DFC2BECD10C17F7A65F65E15DCF791CBC6 (MMBloomShaker_HDRP_tD2D9A71961AFE4E5FFFDAD5E37B7DB19DD990CA8* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public bool RelativeValues = true;
		__this->___RelativeValues_20 = (bool)1;
		// public AnimationCurve ShakeIntensity = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
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
		__this->___ShakeIntensity_21 = L_7;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ShakeIntensity_21), (void*)L_7);
		// public float RemapIntensityOne = 1f;
		__this->___RemapIntensityOne_23 = (1.0f);
		// public AnimationCurve ShakeThreshold = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
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
		__this->___ShakeThreshold_24 = L_15;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ShakeThreshold_24), (void*)L_15);
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
// System.Void MoreMountains.FeedbacksForThirdParty.MMBloomShakeEvent_HDRP::add_OnEvent(MoreMountains.FeedbacksForThirdParty.MMBloomShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMBloomShakeEvent_HDRP_add_OnEvent_mFC9B6DC3932EDF1182F55480809688638725AEE8 (Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8* ___value0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMBloomShakeEvent_HDRP_t2A48F2352C66505C62C6A80DABF3D3F0DE3738B0_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8* V_0 = NULL;
	Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8* V_1 = NULL;
	Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8* V_2 = NULL;
	{
		Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8* L_0 = ((MMBloomShakeEvent_HDRP_t2A48F2352C66505C62C6A80DABF3D3F0DE3738B0_StaticFields*)il2cpp_codegen_static_fields_for(MMBloomShakeEvent_HDRP_t2A48F2352C66505C62C6A80DABF3D3F0DE3738B0_il2cpp_TypeInfo_var))->___OnEvent_0;
		V_0 = L_0;
	}

IL_0006:
	{
		Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8* L_1 = V_0;
		V_1 = L_1;
		Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8* L_2 = V_1;
		Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8* L_3 = ___value0;
		Delegate_t* L_4;
		L_4 = Delegate_Combine_m1F725AEF318BE6F0426863490691A6F4606E7D00(L_2, L_3, NULL);
		V_2 = ((Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8*)CastclassSealed((RuntimeObject*)L_4, Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8_il2cpp_TypeInfo_var));
		Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8* L_5 = V_2;
		Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8* L_6 = V_1;
		Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8* L_7;
		L_7 = InterlockedCompareExchangeImpl<Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8*>((&((MMBloomShakeEvent_HDRP_t2A48F2352C66505C62C6A80DABF3D3F0DE3738B0_StaticFields*)il2cpp_codegen_static_fields_for(MMBloomShakeEvent_HDRP_t2A48F2352C66505C62C6A80DABF3D3F0DE3738B0_il2cpp_TypeInfo_var))->___OnEvent_0), L_5, L_6);
		V_0 = L_7;
		Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8* L_8 = V_0;
		Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8* L_9 = V_1;
		if ((!(((RuntimeObject*)(Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8*)L_8) == ((RuntimeObject*)(Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8*)L_9))))
		{
			goto IL_0006;
		}
	}
	{
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMBloomShakeEvent_HDRP::remove_OnEvent(MoreMountains.FeedbacksForThirdParty.MMBloomShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMBloomShakeEvent_HDRP_remove_OnEvent_m4BF14FE9ABCFE9929BCBD0267E79F6F1B232A901 (Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8* ___value0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMBloomShakeEvent_HDRP_t2A48F2352C66505C62C6A80DABF3D3F0DE3738B0_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8* V_0 = NULL;
	Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8* V_1 = NULL;
	Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8* V_2 = NULL;
	{
		Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8* L_0 = ((MMBloomShakeEvent_HDRP_t2A48F2352C66505C62C6A80DABF3D3F0DE3738B0_StaticFields*)il2cpp_codegen_static_fields_for(MMBloomShakeEvent_HDRP_t2A48F2352C66505C62C6A80DABF3D3F0DE3738B0_il2cpp_TypeInfo_var))->___OnEvent_0;
		V_0 = L_0;
	}

IL_0006:
	{
		Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8* L_1 = V_0;
		V_1 = L_1;
		Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8* L_2 = V_1;
		Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8* L_3 = ___value0;
		Delegate_t* L_4;
		L_4 = Delegate_Remove_m8B7DD5661308FA972E23CA1CC3FC9CEB355504E3(L_2, L_3, NULL);
		V_2 = ((Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8*)CastclassSealed((RuntimeObject*)L_4, Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8_il2cpp_TypeInfo_var));
		Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8* L_5 = V_2;
		Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8* L_6 = V_1;
		Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8* L_7;
		L_7 = InterlockedCompareExchangeImpl<Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8*>((&((MMBloomShakeEvent_HDRP_t2A48F2352C66505C62C6A80DABF3D3F0DE3738B0_StaticFields*)il2cpp_codegen_static_fields_for(MMBloomShakeEvent_HDRP_t2A48F2352C66505C62C6A80DABF3D3F0DE3738B0_il2cpp_TypeInfo_var))->___OnEvent_0), L_5, L_6);
		V_0 = L_7;
		Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8* L_8 = V_0;
		Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8* L_9 = V_1;
		if ((!(((RuntimeObject*)(Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8*)L_8) == ((RuntimeObject*)(Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8*)L_9))))
		{
			goto IL_0006;
		}
	}
	{
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMBloomShakeEvent_HDRP::Register(MoreMountains.FeedbacksForThirdParty.MMBloomShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMBloomShakeEvent_HDRP_Register_m8875DC38841130BB483E90B6D658F0206C1101F7 (Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8* ___callback0, const RuntimeMethod* method) 
{
	{
		// OnEvent += callback;
		Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8* L_0 = ___callback0;
		MMBloomShakeEvent_HDRP_add_OnEvent_mFC9B6DC3932EDF1182F55480809688638725AEE8(L_0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMBloomShakeEvent_HDRP::Unregister(MoreMountains.FeedbacksForThirdParty.MMBloomShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMBloomShakeEvent_HDRP_Unregister_mC6C35D06BEE815DBBD8C97BAE331AE74DF60F8F6 (Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8* ___callback0, const RuntimeMethod* method) 
{
	{
		// OnEvent -= callback;
		Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8* L_0 = ___callback0;
		MMBloomShakeEvent_HDRP_remove_OnEvent_m4BF14FE9ABCFE9929BCBD0267E79F6F1B232A901(L_0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMBloomShakeEvent_HDRP::Trigger(UnityEngine.AnimationCurve,System.Single,System.Single,System.Single,UnityEngine.AnimationCurve,System.Single,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMBloomShakeEvent_HDRP_Trigger_mD6CDB0DABD19FEA6B4F331F7D6F6EBF0B683F7DD (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___threshold4, float ___remapThresholdMin5, float ___remapThresholdMax6, bool ___relativeIntensity7, float ___attenuation8, int32_t ___channel9, bool ___resetShakerValuesAfterShake10, bool ___resetTargetValuesAfterShake11, bool ___forwardDirection12, int32_t ___timescaleMode13, bool ___stop14, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMBloomShakeEvent_HDRP_t2A48F2352C66505C62C6A80DABF3D3F0DE3738B0_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8* G_B2_0 = NULL;
	Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8* G_B1_0 = NULL;
	{
		// OnEvent?.Invoke(intensity, duration, remapMin, remapMax, threshold, remapThresholdMin, remapThresholdMax, relativeIntensity,
		//     attenuation, channel, resetShakerValuesAfterShake, resetTargetValuesAfterShake, forwardDirection, timescaleMode, stop);
		Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8* L_0 = ((MMBloomShakeEvent_HDRP_t2A48F2352C66505C62C6A80DABF3D3F0DE3738B0_StaticFields*)il2cpp_codegen_static_fields_for(MMBloomShakeEvent_HDRP_t2A48F2352C66505C62C6A80DABF3D3F0DE3738B0_il2cpp_TypeInfo_var))->___OnEvent_0;
		Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8* L_1 = L_0;
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
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_2 = ___intensity0;
		float L_3 = ___duration1;
		float L_4 = ___remapMin2;
		float L_5 = ___remapMax3;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_6 = ___threshold4;
		float L_7 = ___remapThresholdMin5;
		float L_8 = ___remapThresholdMax6;
		bool L_9 = ___relativeIntensity7;
		float L_10 = ___attenuation8;
		int32_t L_11 = ___channel9;
		bool L_12 = ___resetShakerValuesAfterShake10;
		bool L_13 = ___resetTargetValuesAfterShake11;
		bool L_14 = ___forwardDirection12;
		int32_t L_15 = ___timescaleMode13;
		bool L_16 = ___stop14;
		NullCheck(G_B2_0);
		Delegate_Invoke_mF7FAC8B0ACC743B9DE90ADF2388F38135399AD35_inline(G_B2_0, L_2, L_3, L_4, L_5, L_6, L_7, L_8, L_9, L_10, L_11, L_12, L_13, L_14, L_15, L_16, NULL);
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
void Delegate_Invoke_mF7FAC8B0ACC743B9DE90ADF2388F38135399AD35_Multicast(Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___threshold4, float ___remapThresholdMin5, float ___remapThresholdMax6, bool ___relativeIntensity7, float ___attenuation8, int32_t ___channel9, bool ___resetShakerValuesAfterShake10, bool ___resetTargetValuesAfterShake11, bool ___forwardDirection12, int32_t ___timescaleMode13, bool ___stop14, const RuntimeMethod* method)
{
	il2cpp_array_size_t length = __this->___delegates_13->max_length;
	Delegate_t** delegatesToInvoke = reinterpret_cast<Delegate_t**>(__this->___delegates_13->GetAddressAtUnchecked(0));
	for (il2cpp_array_size_t i = 0; i < length; i++)
	{
		Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8* currentDelegate = reinterpret_cast<Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8*>(delegatesToInvoke[i]);
		typedef void (*FunctionPointerType) (RuntimeObject*, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
		((FunctionPointerType)currentDelegate->___invoke_impl_1)((Il2CppObject*)currentDelegate->___method_code_6, ___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___threshold4, ___remapThresholdMin5, ___remapThresholdMax6, ___relativeIntensity7, ___attenuation8, ___channel9, ___resetShakerValuesAfterShake10, ___resetTargetValuesAfterShake11, ___forwardDirection12, ___timescaleMode13, ___stop14, reinterpret_cast<RuntimeMethod*>(currentDelegate->___method_3));
	}
}
void Delegate_Invoke_mF7FAC8B0ACC743B9DE90ADF2388F38135399AD35_OpenInst(Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___threshold4, float ___remapThresholdMin5, float ___remapThresholdMax6, bool ___relativeIntensity7, float ___attenuation8, int32_t ___channel9, bool ___resetShakerValuesAfterShake10, bool ___resetTargetValuesAfterShake11, bool ___forwardDirection12, int32_t ___timescaleMode13, bool ___stop14, const RuntimeMethod* method)
{
	NullCheck(___intensity0);
	typedef void (*FunctionPointerType) (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___method_ptr_0)(___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___threshold4, ___remapThresholdMin5, ___remapThresholdMax6, ___relativeIntensity7, ___attenuation8, ___channel9, ___resetShakerValuesAfterShake10, ___resetTargetValuesAfterShake11, ___forwardDirection12, ___timescaleMode13, ___stop14, method);
}
void Delegate_Invoke_mF7FAC8B0ACC743B9DE90ADF2388F38135399AD35_OpenStatic(Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___threshold4, float ___remapThresholdMin5, float ___remapThresholdMax6, bool ___relativeIntensity7, float ___attenuation8, int32_t ___channel9, bool ___resetShakerValuesAfterShake10, bool ___resetTargetValuesAfterShake11, bool ___forwardDirection12, int32_t ___timescaleMode13, bool ___stop14, const RuntimeMethod* method)
{
	typedef void (*FunctionPointerType) (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___method_ptr_0)(___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___threshold4, ___remapThresholdMin5, ___remapThresholdMax6, ___relativeIntensity7, ___attenuation8, ___channel9, ___resetShakerValuesAfterShake10, ___resetTargetValuesAfterShake11, ___forwardDirection12, ___timescaleMode13, ___stop14, method);
}
void Delegate_Invoke_mF7FAC8B0ACC743B9DE90ADF2388F38135399AD35_OpenStaticInvoker(Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___threshold4, float ___remapThresholdMin5, float ___remapThresholdMax6, bool ___relativeIntensity7, float ___attenuation8, int32_t ___channel9, bool ___resetShakerValuesAfterShake10, bool ___resetTargetValuesAfterShake11, bool ___forwardDirection12, int32_t ___timescaleMode13, bool ___stop14, const RuntimeMethod* method)
{
	InvokerActionInvoker15< AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(__this->___method_ptr_0, method, NULL, ___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___threshold4, ___remapThresholdMin5, ___remapThresholdMax6, ___relativeIntensity7, ___attenuation8, ___channel9, ___resetShakerValuesAfterShake10, ___resetTargetValuesAfterShake11, ___forwardDirection12, ___timescaleMode13, ___stop14);
}
void Delegate_Invoke_mF7FAC8B0ACC743B9DE90ADF2388F38135399AD35_ClosedStaticInvoker(Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___threshold4, float ___remapThresholdMin5, float ___remapThresholdMax6, bool ___relativeIntensity7, float ___attenuation8, int32_t ___channel9, bool ___resetShakerValuesAfterShake10, bool ___resetTargetValuesAfterShake11, bool ___forwardDirection12, int32_t ___timescaleMode13, bool ___stop14, const RuntimeMethod* method)
{
	InvokerActionInvoker16< RuntimeObject*, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(__this->___method_ptr_0, method, NULL, __this->___m_target_2, ___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___threshold4, ___remapThresholdMin5, ___remapThresholdMax6, ___relativeIntensity7, ___attenuation8, ___channel9, ___resetShakerValuesAfterShake10, ___resetTargetValuesAfterShake11, ___forwardDirection12, ___timescaleMode13, ___stop14);
}
void Delegate_Invoke_mF7FAC8B0ACC743B9DE90ADF2388F38135399AD35_OpenVirtual(Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___threshold4, float ___remapThresholdMin5, float ___remapThresholdMax6, bool ___relativeIntensity7, float ___attenuation8, int32_t ___channel9, bool ___resetShakerValuesAfterShake10, bool ___resetTargetValuesAfterShake11, bool ___forwardDirection12, int32_t ___timescaleMode13, bool ___stop14, const RuntimeMethod* method)
{
	NullCheck(___intensity0);
	VirtualActionInvoker14< float, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(il2cpp_codegen_method_get_slot(method), ___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___threshold4, ___remapThresholdMin5, ___remapThresholdMax6, ___relativeIntensity7, ___attenuation8, ___channel9, ___resetShakerValuesAfterShake10, ___resetTargetValuesAfterShake11, ___forwardDirection12, ___timescaleMode13, ___stop14);
}
void Delegate_Invoke_mF7FAC8B0ACC743B9DE90ADF2388F38135399AD35_OpenInterface(Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___threshold4, float ___remapThresholdMin5, float ___remapThresholdMax6, bool ___relativeIntensity7, float ___attenuation8, int32_t ___channel9, bool ___resetShakerValuesAfterShake10, bool ___resetTargetValuesAfterShake11, bool ___forwardDirection12, int32_t ___timescaleMode13, bool ___stop14, const RuntimeMethod* method)
{
	NullCheck(___intensity0);
	InterfaceActionInvoker14< float, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(il2cpp_codegen_method_get_slot(method), il2cpp_codegen_method_get_declaring_type(method), ___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___threshold4, ___remapThresholdMin5, ___remapThresholdMax6, ___relativeIntensity7, ___attenuation8, ___channel9, ___resetShakerValuesAfterShake10, ___resetTargetValuesAfterShake11, ___forwardDirection12, ___timescaleMode13, ___stop14);
}
void Delegate_Invoke_mF7FAC8B0ACC743B9DE90ADF2388F38135399AD35_OpenGenericVirtual(Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___threshold4, float ___remapThresholdMin5, float ___remapThresholdMax6, bool ___relativeIntensity7, float ___attenuation8, int32_t ___channel9, bool ___resetShakerValuesAfterShake10, bool ___resetTargetValuesAfterShake11, bool ___forwardDirection12, int32_t ___timescaleMode13, bool ___stop14, const RuntimeMethod* method)
{
	NullCheck(___intensity0);
	GenericVirtualActionInvoker14< float, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(method, ___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___threshold4, ___remapThresholdMin5, ___remapThresholdMax6, ___relativeIntensity7, ___attenuation8, ___channel9, ___resetShakerValuesAfterShake10, ___resetTargetValuesAfterShake11, ___forwardDirection12, ___timescaleMode13, ___stop14);
}
void Delegate_Invoke_mF7FAC8B0ACC743B9DE90ADF2388F38135399AD35_OpenGenericInterface(Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___threshold4, float ___remapThresholdMin5, float ___remapThresholdMax6, bool ___relativeIntensity7, float ___attenuation8, int32_t ___channel9, bool ___resetShakerValuesAfterShake10, bool ___resetTargetValuesAfterShake11, bool ___forwardDirection12, int32_t ___timescaleMode13, bool ___stop14, const RuntimeMethod* method)
{
	NullCheck(___intensity0);
	GenericInterfaceActionInvoker14< float, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(method, ___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___threshold4, ___remapThresholdMin5, ___remapThresholdMax6, ___relativeIntensity7, ___attenuation8, ___channel9, ___resetShakerValuesAfterShake10, ___resetTargetValuesAfterShake11, ___forwardDirection12, ___timescaleMode13, ___stop14);
}
IL2CPP_EXTERN_C  void DelegatePInvokeWrapper_Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8 (Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___threshold4, float ___remapThresholdMin5, float ___remapThresholdMax6, bool ___relativeIntensity7, float ___attenuation8, int32_t ___channel9, bool ___resetShakerValuesAfterShake10, bool ___resetTargetValuesAfterShake11, bool ___forwardDirection12, int32_t ___timescaleMode13, bool ___stop14, const RuntimeMethod* method)
{




	typedef void (DEFAULT_CALL *PInvokeFunc)(AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshaled_pinvoke*, float, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshaled_pinvoke*, float, float, int32_t, float, int32_t, int32_t, int32_t, int32_t, int32_t, int32_t);
	PInvokeFunc il2cppPInvokeFunc = reinterpret_cast<PInvokeFunc>(il2cpp_codegen_get_reverse_pinvoke_function_ptr(__this));
	// Marshaling of parameter '___intensity0' to native representation
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshaled_pinvoke ____intensity0_marshaled = {};
	if (___intensity0 != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke(*___intensity0, ____intensity0_marshaled);
	}

	// Marshaling of parameter '___threshold4' to native representation
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshaled_pinvoke ____threshold4_marshaled = {};
	if (___threshold4 != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke(*___threshold4, ____threshold4_marshaled);
	}

	// Native function invocation
	il2cppPInvokeFunc(___intensity0 != NULL ? (&____intensity0_marshaled) : NULL, ___duration1, ___remapMin2, ___remapMax3, ___threshold4 != NULL ? (&____threshold4_marshaled) : NULL, ___remapThresholdMin5, ___remapThresholdMax6, static_cast<int32_t>(___relativeIntensity7), ___attenuation8, ___channel9, static_cast<int32_t>(___resetShakerValuesAfterShake10), static_cast<int32_t>(___resetTargetValuesAfterShake11), static_cast<int32_t>(___forwardDirection12), ___timescaleMode13, static_cast<int32_t>(___stop14));

	// Marshaling of parameter '___intensity0' back from native representation
	if (___intensity0 != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke_back(____intensity0_marshaled, *___intensity0);
	}

	// Marshaling cleanup of parameter '___intensity0' native representation
	if ((&____intensity0_marshaled) != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke_cleanup(____intensity0_marshaled);
	}

	// Marshaling of parameter '___threshold4' back from native representation
	if (___threshold4 != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke_back(____threshold4_marshaled, *___threshold4);
	}

	// Marshaling cleanup of parameter '___threshold4' native representation
	if ((&____threshold4_marshaled) != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke_cleanup(____threshold4_marshaled);
	}

}
// System.Void MoreMountains.FeedbacksForThirdParty.MMBloomShakeEvent_HDRP/Delegate::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Delegate__ctor_m5B297FE7168B4C630CBB41DD5F5E107C1ED3E044 (Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8* __this, RuntimeObject* ___object0, intptr_t ___method1, const RuntimeMethod* method) 
{
	__this->___method_ptr_0 = il2cpp_codegen_get_virtual_call_method_pointer((RuntimeMethod*)___method1);
	__this->___method_3 = ___method1;
	__this->___m_target_2 = ___object0;
	Il2CppCodeGenWriteBarrier((void**)(&__this->___m_target_2), (void*)___object0);
	int parameterCount = il2cpp_codegen_method_parameter_count((RuntimeMethod*)___method1);
	__this->___method_code_6 = (intptr_t)__this;
	if (MethodIsStatic((RuntimeMethod*)___method1))
	{
		bool isOpen = parameterCount == 15;
		if (il2cpp_codegen_call_method_via_invoker((RuntimeMethod*)___method1))
			if (isOpen)
				__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mF7FAC8B0ACC743B9DE90ADF2388F38135399AD35_OpenStaticInvoker;
			else
				__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mF7FAC8B0ACC743B9DE90ADF2388F38135399AD35_ClosedStaticInvoker;
		else
			if (isOpen)
				__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mF7FAC8B0ACC743B9DE90ADF2388F38135399AD35_OpenStatic;
			else
				{
					__this->___invoke_impl_1 = (intptr_t)__this->___method_ptr_0;
					__this->___method_code_6 = (intptr_t)__this->___m_target_2;
				}
	}
	else
	{
		bool isOpen = parameterCount == 14;
		if (isOpen)
		{
			if (__this->___method_is_virtual_12)
			{
				if (il2cpp_codegen_method_is_generic_instance_method((RuntimeMethod*)___method1))
					if (il2cpp_codegen_method_is_interface_method((RuntimeMethod*)___method1))
						__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mF7FAC8B0ACC743B9DE90ADF2388F38135399AD35_OpenGenericInterface;
					else
						__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mF7FAC8B0ACC743B9DE90ADF2388F38135399AD35_OpenGenericVirtual;
				else
					if (il2cpp_codegen_method_is_interface_method((RuntimeMethod*)___method1))
						__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mF7FAC8B0ACC743B9DE90ADF2388F38135399AD35_OpenInterface;
					else
						__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mF7FAC8B0ACC743B9DE90ADF2388F38135399AD35_OpenVirtual;
			}
			else
			{
				__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mF7FAC8B0ACC743B9DE90ADF2388F38135399AD35_OpenInst;
			}
		}
		else
		{
			if (___object0 == NULL)
				il2cpp_codegen_raise_exception(il2cpp_codegen_get_argument_exception(NULL, "Delegate to an instance method cannot have null 'this'."), NULL);
			__this->___invoke_impl_1 = (intptr_t)__this->___method_ptr_0;
			__this->___method_code_6 = (intptr_t)__this->___m_target_2;
		}
	}
	__this->___extra_arg_5 = (intptr_t)&Delegate_Invoke_mF7FAC8B0ACC743B9DE90ADF2388F38135399AD35_Multicast;
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMBloomShakeEvent_HDRP/Delegate::Invoke(UnityEngine.AnimationCurve,System.Single,System.Single,System.Single,UnityEngine.AnimationCurve,System.Single,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Delegate_Invoke_mF7FAC8B0ACC743B9DE90ADF2388F38135399AD35 (Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___threshold4, float ___remapThresholdMin5, float ___remapThresholdMax6, bool ___relativeIntensity7, float ___attenuation8, int32_t ___channel9, bool ___resetShakerValuesAfterShake10, bool ___resetTargetValuesAfterShake11, bool ___forwardDirection12, int32_t ___timescaleMode13, bool ___stop14, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___threshold4, ___remapThresholdMin5, ___remapThresholdMax6, ___relativeIntensity7, ___attenuation8, ___channel9, ___resetShakerValuesAfterShake10, ___resetTargetValuesAfterShake11, ___forwardDirection12, ___timescaleMode13, ___stop14, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
// System.IAsyncResult MoreMountains.FeedbacksForThirdParty.MMBloomShakeEvent_HDRP/Delegate::BeginInvoke(UnityEngine.AnimationCurve,System.Single,System.Single,System.Single,UnityEngine.AnimationCurve,System.Single,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean,System.AsyncCallback,System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* Delegate_BeginInvoke_m0706B0E04AAE7B550D9A113FAD6C86FCEB2DEB48 (Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___threshold4, float ___remapThresholdMin5, float ___remapThresholdMax6, bool ___relativeIntensity7, float ___attenuation8, int32_t ___channel9, bool ___resetShakerValuesAfterShake10, bool ___resetTargetValuesAfterShake11, bool ___forwardDirection12, int32_t ___timescaleMode13, bool ___stop14, AsyncCallback_t7FEF460CBDCFB9C5FA2EF776984778B9A4145F4C* ___callback15, RuntimeObject* ___object16, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TimescaleModes_t567213DC39EEE1AA073F8E8473E19F2B71FC9A68_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	void *__d_args[16] = {0};
	__d_args[0] = ___intensity0;
	__d_args[1] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___duration1);
	__d_args[2] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___remapMin2);
	__d_args[3] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___remapMax3);
	__d_args[4] = ___threshold4;
	__d_args[5] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___remapThresholdMin5);
	__d_args[6] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___remapThresholdMax6);
	__d_args[7] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___relativeIntensity7);
	__d_args[8] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___attenuation8);
	__d_args[9] = Box(Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var, &___channel9);
	__d_args[10] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___resetShakerValuesAfterShake10);
	__d_args[11] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___resetTargetValuesAfterShake11);
	__d_args[12] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___forwardDirection12);
	__d_args[13] = Box(TimescaleModes_t567213DC39EEE1AA073F8E8473E19F2B71FC9A68_il2cpp_TypeInfo_var, &___timescaleMode13);
	__d_args[14] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___stop14);
	return (RuntimeObject*)il2cpp_codegen_delegate_begin_invoke((RuntimeDelegate*)__this, __d_args, (RuntimeDelegate*)___callback15, (RuntimeObject*)___object16);
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMBloomShakeEvent_HDRP/Delegate::EndInvoke(System.IAsyncResult)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Delegate_EndInvoke_mFAD7E45587EC1A1713B211E5E07366B210BD4763 (Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8* __this, RuntimeObject* ___result0, const RuntimeMethod* method) 
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
// System.Void MoreMountains.FeedbacksForThirdParty.MMChannelMixerShaker_HDRP::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMChannelMixerShaker_HDRP__ctor_mC7D664C4CF3A278AF2821F56428C1D699B1EBAAC (MMChannelMixerShaker_HDRP_t78DBC564D348F7D72193C967D7866E87F57079FE* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public bool RelativeValues = true;
		__this->___RelativeValues_20 = (bool)1;
		// public AnimationCurve ShakeRed = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
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
		__this->___ShakeRed_21 = L_7;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ShakeRed_21), (void*)L_7);
		// public float RemapRedOne = 200f;
		__this->___RemapRedOne_23 = (200.0f);
		// public AnimationCurve ShakeGreen = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
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
		__this->___ShakeGreen_24 = L_15;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ShakeGreen_24), (void*)L_15);
		// public float RemapGreenOne = 200f;
		__this->___RemapGreenOne_26 = (200.0f);
		// public AnimationCurve ShakeBlue = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_16 = (KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3*)(KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3*)SZArrayNew(KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var, (uint32_t)3);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_17 = L_16;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_18;
		memset((&L_18), 0, sizeof(L_18));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_18), (0.0f), (0.0f), /*hidden argument*/NULL);
		NullCheck(L_17);
		(L_17)->SetAt(static_cast<il2cpp_array_size_t>(0), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_18);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_19 = L_17;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_20;
		memset((&L_20), 0, sizeof(L_20));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_20), (0.5f), (1.0f), /*hidden argument*/NULL);
		NullCheck(L_19);
		(L_19)->SetAt(static_cast<il2cpp_array_size_t>(1), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_20);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_21 = L_19;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_22;
		memset((&L_22), 0, sizeof(L_22));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_22), (1.0f), (0.0f), /*hidden argument*/NULL);
		NullCheck(L_21);
		(L_21)->SetAt(static_cast<il2cpp_array_size_t>(2), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_22);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_23 = (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*)il2cpp_codegen_object_new(AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		NullCheck(L_23);
		AnimationCurve__ctor_mEABC98C03805713354D61E50D9340766BD5B717E(L_23, L_21, NULL);
		__this->___ShakeBlue_27 = L_23;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ShakeBlue_27), (void*)L_23);
		// public float RemapBlueOne = 200f;
		__this->___RemapBlueOne_29 = (200.0f);
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
// System.Void MoreMountains.FeedbacksForThirdParty.MMChannelMixerShakeEvent_HDRP::add_OnEvent(MoreMountains.FeedbacksForThirdParty.MMChannelMixerShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMChannelMixerShakeEvent_HDRP_add_OnEvent_m5E67DDF1A02305E222B01893CC707F59E4B19C05 (Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176* ___value0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMChannelMixerShakeEvent_HDRP_tBD77FF8BBEF92186F80603D199DBFC62DC4CE948_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176* V_0 = NULL;
	Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176* V_1 = NULL;
	Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176* V_2 = NULL;
	{
		Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176* L_0 = ((MMChannelMixerShakeEvent_HDRP_tBD77FF8BBEF92186F80603D199DBFC62DC4CE948_StaticFields*)il2cpp_codegen_static_fields_for(MMChannelMixerShakeEvent_HDRP_tBD77FF8BBEF92186F80603D199DBFC62DC4CE948_il2cpp_TypeInfo_var))->___OnEvent_0;
		V_0 = L_0;
	}

IL_0006:
	{
		Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176* L_1 = V_0;
		V_1 = L_1;
		Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176* L_2 = V_1;
		Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176* L_3 = ___value0;
		Delegate_t* L_4;
		L_4 = Delegate_Combine_m1F725AEF318BE6F0426863490691A6F4606E7D00(L_2, L_3, NULL);
		V_2 = ((Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176*)CastclassSealed((RuntimeObject*)L_4, Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176_il2cpp_TypeInfo_var));
		Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176* L_5 = V_2;
		Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176* L_6 = V_1;
		Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176* L_7;
		L_7 = InterlockedCompareExchangeImpl<Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176*>((&((MMChannelMixerShakeEvent_HDRP_tBD77FF8BBEF92186F80603D199DBFC62DC4CE948_StaticFields*)il2cpp_codegen_static_fields_for(MMChannelMixerShakeEvent_HDRP_tBD77FF8BBEF92186F80603D199DBFC62DC4CE948_il2cpp_TypeInfo_var))->___OnEvent_0), L_5, L_6);
		V_0 = L_7;
		Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176* L_8 = V_0;
		Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176* L_9 = V_1;
		if ((!(((RuntimeObject*)(Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176*)L_8) == ((RuntimeObject*)(Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176*)L_9))))
		{
			goto IL_0006;
		}
	}
	{
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMChannelMixerShakeEvent_HDRP::remove_OnEvent(MoreMountains.FeedbacksForThirdParty.MMChannelMixerShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMChannelMixerShakeEvent_HDRP_remove_OnEvent_m21FBD55F43B1BC94894908F7EA57B7C6D824DA48 (Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176* ___value0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMChannelMixerShakeEvent_HDRP_tBD77FF8BBEF92186F80603D199DBFC62DC4CE948_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176* V_0 = NULL;
	Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176* V_1 = NULL;
	Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176* V_2 = NULL;
	{
		Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176* L_0 = ((MMChannelMixerShakeEvent_HDRP_tBD77FF8BBEF92186F80603D199DBFC62DC4CE948_StaticFields*)il2cpp_codegen_static_fields_for(MMChannelMixerShakeEvent_HDRP_tBD77FF8BBEF92186F80603D199DBFC62DC4CE948_il2cpp_TypeInfo_var))->___OnEvent_0;
		V_0 = L_0;
	}

IL_0006:
	{
		Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176* L_1 = V_0;
		V_1 = L_1;
		Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176* L_2 = V_1;
		Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176* L_3 = ___value0;
		Delegate_t* L_4;
		L_4 = Delegate_Remove_m8B7DD5661308FA972E23CA1CC3FC9CEB355504E3(L_2, L_3, NULL);
		V_2 = ((Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176*)CastclassSealed((RuntimeObject*)L_4, Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176_il2cpp_TypeInfo_var));
		Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176* L_5 = V_2;
		Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176* L_6 = V_1;
		Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176* L_7;
		L_7 = InterlockedCompareExchangeImpl<Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176*>((&((MMChannelMixerShakeEvent_HDRP_tBD77FF8BBEF92186F80603D199DBFC62DC4CE948_StaticFields*)il2cpp_codegen_static_fields_for(MMChannelMixerShakeEvent_HDRP_tBD77FF8BBEF92186F80603D199DBFC62DC4CE948_il2cpp_TypeInfo_var))->___OnEvent_0), L_5, L_6);
		V_0 = L_7;
		Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176* L_8 = V_0;
		Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176* L_9 = V_1;
		if ((!(((RuntimeObject*)(Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176*)L_8) == ((RuntimeObject*)(Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176*)L_9))))
		{
			goto IL_0006;
		}
	}
	{
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMChannelMixerShakeEvent_HDRP::Register(MoreMountains.FeedbacksForThirdParty.MMChannelMixerShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMChannelMixerShakeEvent_HDRP_Register_m5D9FABA9E3B79E831F314B1BD4F95DABA0740F48 (Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176* ___callback0, const RuntimeMethod* method) 
{
	{
		// OnEvent += callback;
		Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176* L_0 = ___callback0;
		MMChannelMixerShakeEvent_HDRP_add_OnEvent_m5E67DDF1A02305E222B01893CC707F59E4B19C05(L_0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMChannelMixerShakeEvent_HDRP::Unregister(MoreMountains.FeedbacksForThirdParty.MMChannelMixerShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMChannelMixerShakeEvent_HDRP_Unregister_m81A1D4358FF0A43D7083D0D92F161E338A40F5CF (Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176* ___callback0, const RuntimeMethod* method) 
{
	{
		// OnEvent -= callback;
		Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176* L_0 = ___callback0;
		MMChannelMixerShakeEvent_HDRP_remove_OnEvent_m21FBD55F43B1BC94894908F7EA57B7C6D824DA48(L_0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMChannelMixerShakeEvent_HDRP::Trigger(UnityEngine.AnimationCurve,System.Single,System.Single,UnityEngine.AnimationCurve,System.Single,System.Single,UnityEngine.AnimationCurve,System.Single,System.Single,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMChannelMixerShakeEvent_HDRP_Trigger_m0137922D2B53BC7162F552A9F4CD722733123CF7 (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeRed0, float ___remapRedZero1, float ___remapRedOne2, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeGreen3, float ___remapGreenZero4, float ___remapGreenOne5, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeBlue6, float ___remapBlueZero7, float ___remapBlueOne8, float ___duration9, bool ___relativeValues10, float ___attenuation11, int32_t ___channel12, bool ___resetShakerValuesAfterShake13, bool ___resetTargetValuesAfterShake14, bool ___forwardDirection15, int32_t ___timescaleMode16, bool ___stop17, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMChannelMixerShakeEvent_HDRP_tBD77FF8BBEF92186F80603D199DBFC62DC4CE948_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176* G_B2_0 = NULL;
	Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176* G_B1_0 = NULL;
	{
		// OnEvent?.Invoke(shakeRed, remapRedZero, remapRedOne,
		//     shakeGreen, remapGreenZero, remapGreenOne,
		//     shakeBlue, remapBlueZero, remapBlueOne,
		//     duration, relativeValues, attenuation, channel, resetShakerValuesAfterShake, resetTargetValuesAfterShake, forwardDirection, timescaleMode, stop);
		Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176* L_0 = ((MMChannelMixerShakeEvent_HDRP_tBD77FF8BBEF92186F80603D199DBFC62DC4CE948_StaticFields*)il2cpp_codegen_static_fields_for(MMChannelMixerShakeEvent_HDRP_tBD77FF8BBEF92186F80603D199DBFC62DC4CE948_il2cpp_TypeInfo_var))->___OnEvent_0;
		Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176* L_1 = L_0;
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
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_2 = ___shakeRed0;
		float L_3 = ___remapRedZero1;
		float L_4 = ___remapRedOne2;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_5 = ___shakeGreen3;
		float L_6 = ___remapGreenZero4;
		float L_7 = ___remapGreenOne5;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_8 = ___shakeBlue6;
		float L_9 = ___remapBlueZero7;
		float L_10 = ___remapBlueOne8;
		float L_11 = ___duration9;
		bool L_12 = ___relativeValues10;
		float L_13 = ___attenuation11;
		int32_t L_14 = ___channel12;
		bool L_15 = ___resetShakerValuesAfterShake13;
		bool L_16 = ___resetTargetValuesAfterShake14;
		bool L_17 = ___forwardDirection15;
		int32_t L_18 = ___timescaleMode16;
		bool L_19 = ___stop17;
		NullCheck(G_B2_0);
		Delegate_Invoke_m1BF2E87CE04FB3085F026AEF72BB8D6BB6AE1483_inline(G_B2_0, L_2, L_3, L_4, L_5, L_6, L_7, L_8, L_9, L_10, L_11, L_12, L_13, L_14, L_15, L_16, L_17, L_18, L_19, NULL);
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
void Delegate_Invoke_m1BF2E87CE04FB3085F026AEF72BB8D6BB6AE1483_Multicast(Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeRed0, float ___remapRedZero1, float ___remapRedOne2, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeGreen3, float ___remapGreenZero4, float ___remapGreenOne5, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeBlue6, float ___remapBlueZero7, float ___remapBlueOne8, float ___duration9, bool ___relativeValues10, float ___attenuation11, int32_t ___channel12, bool ___resetShakerValuesAfterShake13, bool ___resetTargetValuesAfterShake14, bool ___forwardDirection15, int32_t ___timescaleMode16, bool ___stop17, const RuntimeMethod* method)
{
	il2cpp_array_size_t length = __this->___delegates_13->max_length;
	Delegate_t** delegatesToInvoke = reinterpret_cast<Delegate_t**>(__this->___delegates_13->GetAddressAtUnchecked(0));
	for (il2cpp_array_size_t i = 0; i < length; i++)
	{
		Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176* currentDelegate = reinterpret_cast<Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176*>(delegatesToInvoke[i]);
		typedef void (*FunctionPointerType) (RuntimeObject*, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
		((FunctionPointerType)currentDelegate->___invoke_impl_1)((Il2CppObject*)currentDelegate->___method_code_6, ___shakeRed0, ___remapRedZero1, ___remapRedOne2, ___shakeGreen3, ___remapGreenZero4, ___remapGreenOne5, ___shakeBlue6, ___remapBlueZero7, ___remapBlueOne8, ___duration9, ___relativeValues10, ___attenuation11, ___channel12, ___resetShakerValuesAfterShake13, ___resetTargetValuesAfterShake14, ___forwardDirection15, ___timescaleMode16, ___stop17, reinterpret_cast<RuntimeMethod*>(currentDelegate->___method_3));
	}
}
void Delegate_Invoke_m1BF2E87CE04FB3085F026AEF72BB8D6BB6AE1483_OpenInst(Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeRed0, float ___remapRedZero1, float ___remapRedOne2, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeGreen3, float ___remapGreenZero4, float ___remapGreenOne5, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeBlue6, float ___remapBlueZero7, float ___remapBlueOne8, float ___duration9, bool ___relativeValues10, float ___attenuation11, int32_t ___channel12, bool ___resetShakerValuesAfterShake13, bool ___resetTargetValuesAfterShake14, bool ___forwardDirection15, int32_t ___timescaleMode16, bool ___stop17, const RuntimeMethod* method)
{
	NullCheck(___shakeRed0);
	typedef void (*FunctionPointerType) (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___method_ptr_0)(___shakeRed0, ___remapRedZero1, ___remapRedOne2, ___shakeGreen3, ___remapGreenZero4, ___remapGreenOne5, ___shakeBlue6, ___remapBlueZero7, ___remapBlueOne8, ___duration9, ___relativeValues10, ___attenuation11, ___channel12, ___resetShakerValuesAfterShake13, ___resetTargetValuesAfterShake14, ___forwardDirection15, ___timescaleMode16, ___stop17, method);
}
void Delegate_Invoke_m1BF2E87CE04FB3085F026AEF72BB8D6BB6AE1483_OpenStatic(Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeRed0, float ___remapRedZero1, float ___remapRedOne2, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeGreen3, float ___remapGreenZero4, float ___remapGreenOne5, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeBlue6, float ___remapBlueZero7, float ___remapBlueOne8, float ___duration9, bool ___relativeValues10, float ___attenuation11, int32_t ___channel12, bool ___resetShakerValuesAfterShake13, bool ___resetTargetValuesAfterShake14, bool ___forwardDirection15, int32_t ___timescaleMode16, bool ___stop17, const RuntimeMethod* method)
{
	typedef void (*FunctionPointerType) (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___method_ptr_0)(___shakeRed0, ___remapRedZero1, ___remapRedOne2, ___shakeGreen3, ___remapGreenZero4, ___remapGreenOne5, ___shakeBlue6, ___remapBlueZero7, ___remapBlueOne8, ___duration9, ___relativeValues10, ___attenuation11, ___channel12, ___resetShakerValuesAfterShake13, ___resetTargetValuesAfterShake14, ___forwardDirection15, ___timescaleMode16, ___stop17, method);
}
void Delegate_Invoke_m1BF2E87CE04FB3085F026AEF72BB8D6BB6AE1483_OpenStaticInvoker(Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeRed0, float ___remapRedZero1, float ___remapRedOne2, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeGreen3, float ___remapGreenZero4, float ___remapGreenOne5, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeBlue6, float ___remapBlueZero7, float ___remapBlueOne8, float ___duration9, bool ___relativeValues10, float ___attenuation11, int32_t ___channel12, bool ___resetShakerValuesAfterShake13, bool ___resetTargetValuesAfterShake14, bool ___forwardDirection15, int32_t ___timescaleMode16, bool ___stop17, const RuntimeMethod* method)
{
	InvokerActionInvoker18< AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(__this->___method_ptr_0, method, NULL, ___shakeRed0, ___remapRedZero1, ___remapRedOne2, ___shakeGreen3, ___remapGreenZero4, ___remapGreenOne5, ___shakeBlue6, ___remapBlueZero7, ___remapBlueOne8, ___duration9, ___relativeValues10, ___attenuation11, ___channel12, ___resetShakerValuesAfterShake13, ___resetTargetValuesAfterShake14, ___forwardDirection15, ___timescaleMode16, ___stop17);
}
void Delegate_Invoke_m1BF2E87CE04FB3085F026AEF72BB8D6BB6AE1483_ClosedStaticInvoker(Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeRed0, float ___remapRedZero1, float ___remapRedOne2, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeGreen3, float ___remapGreenZero4, float ___remapGreenOne5, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeBlue6, float ___remapBlueZero7, float ___remapBlueOne8, float ___duration9, bool ___relativeValues10, float ___attenuation11, int32_t ___channel12, bool ___resetShakerValuesAfterShake13, bool ___resetTargetValuesAfterShake14, bool ___forwardDirection15, int32_t ___timescaleMode16, bool ___stop17, const RuntimeMethod* method)
{
	InvokerActionInvoker19< RuntimeObject*, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(__this->___method_ptr_0, method, NULL, __this->___m_target_2, ___shakeRed0, ___remapRedZero1, ___remapRedOne2, ___shakeGreen3, ___remapGreenZero4, ___remapGreenOne5, ___shakeBlue6, ___remapBlueZero7, ___remapBlueOne8, ___duration9, ___relativeValues10, ___attenuation11, ___channel12, ___resetShakerValuesAfterShake13, ___resetTargetValuesAfterShake14, ___forwardDirection15, ___timescaleMode16, ___stop17);
}
void Delegate_Invoke_m1BF2E87CE04FB3085F026AEF72BB8D6BB6AE1483_OpenVirtual(Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeRed0, float ___remapRedZero1, float ___remapRedOne2, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeGreen3, float ___remapGreenZero4, float ___remapGreenOne5, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeBlue6, float ___remapBlueZero7, float ___remapBlueOne8, float ___duration9, bool ___relativeValues10, float ___attenuation11, int32_t ___channel12, bool ___resetShakerValuesAfterShake13, bool ___resetTargetValuesAfterShake14, bool ___forwardDirection15, int32_t ___timescaleMode16, bool ___stop17, const RuntimeMethod* method)
{
	NullCheck(___shakeRed0);
	VirtualActionInvoker17< float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(il2cpp_codegen_method_get_slot(method), ___shakeRed0, ___remapRedZero1, ___remapRedOne2, ___shakeGreen3, ___remapGreenZero4, ___remapGreenOne5, ___shakeBlue6, ___remapBlueZero7, ___remapBlueOne8, ___duration9, ___relativeValues10, ___attenuation11, ___channel12, ___resetShakerValuesAfterShake13, ___resetTargetValuesAfterShake14, ___forwardDirection15, ___timescaleMode16, ___stop17);
}
void Delegate_Invoke_m1BF2E87CE04FB3085F026AEF72BB8D6BB6AE1483_OpenInterface(Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeRed0, float ___remapRedZero1, float ___remapRedOne2, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeGreen3, float ___remapGreenZero4, float ___remapGreenOne5, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeBlue6, float ___remapBlueZero7, float ___remapBlueOne8, float ___duration9, bool ___relativeValues10, float ___attenuation11, int32_t ___channel12, bool ___resetShakerValuesAfterShake13, bool ___resetTargetValuesAfterShake14, bool ___forwardDirection15, int32_t ___timescaleMode16, bool ___stop17, const RuntimeMethod* method)
{
	NullCheck(___shakeRed0);
	InterfaceActionInvoker17< float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(il2cpp_codegen_method_get_slot(method), il2cpp_codegen_method_get_declaring_type(method), ___shakeRed0, ___remapRedZero1, ___remapRedOne2, ___shakeGreen3, ___remapGreenZero4, ___remapGreenOne5, ___shakeBlue6, ___remapBlueZero7, ___remapBlueOne8, ___duration9, ___relativeValues10, ___attenuation11, ___channel12, ___resetShakerValuesAfterShake13, ___resetTargetValuesAfterShake14, ___forwardDirection15, ___timescaleMode16, ___stop17);
}
void Delegate_Invoke_m1BF2E87CE04FB3085F026AEF72BB8D6BB6AE1483_OpenGenericVirtual(Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeRed0, float ___remapRedZero1, float ___remapRedOne2, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeGreen3, float ___remapGreenZero4, float ___remapGreenOne5, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeBlue6, float ___remapBlueZero7, float ___remapBlueOne8, float ___duration9, bool ___relativeValues10, float ___attenuation11, int32_t ___channel12, bool ___resetShakerValuesAfterShake13, bool ___resetTargetValuesAfterShake14, bool ___forwardDirection15, int32_t ___timescaleMode16, bool ___stop17, const RuntimeMethod* method)
{
	NullCheck(___shakeRed0);
	GenericVirtualActionInvoker17< float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(method, ___shakeRed0, ___remapRedZero1, ___remapRedOne2, ___shakeGreen3, ___remapGreenZero4, ___remapGreenOne5, ___shakeBlue6, ___remapBlueZero7, ___remapBlueOne8, ___duration9, ___relativeValues10, ___attenuation11, ___channel12, ___resetShakerValuesAfterShake13, ___resetTargetValuesAfterShake14, ___forwardDirection15, ___timescaleMode16, ___stop17);
}
void Delegate_Invoke_m1BF2E87CE04FB3085F026AEF72BB8D6BB6AE1483_OpenGenericInterface(Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeRed0, float ___remapRedZero1, float ___remapRedOne2, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeGreen3, float ___remapGreenZero4, float ___remapGreenOne5, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeBlue6, float ___remapBlueZero7, float ___remapBlueOne8, float ___duration9, bool ___relativeValues10, float ___attenuation11, int32_t ___channel12, bool ___resetShakerValuesAfterShake13, bool ___resetTargetValuesAfterShake14, bool ___forwardDirection15, int32_t ___timescaleMode16, bool ___stop17, const RuntimeMethod* method)
{
	NullCheck(___shakeRed0);
	GenericInterfaceActionInvoker17< float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(method, ___shakeRed0, ___remapRedZero1, ___remapRedOne2, ___shakeGreen3, ___remapGreenZero4, ___remapGreenOne5, ___shakeBlue6, ___remapBlueZero7, ___remapBlueOne8, ___duration9, ___relativeValues10, ___attenuation11, ___channel12, ___resetShakerValuesAfterShake13, ___resetTargetValuesAfterShake14, ___forwardDirection15, ___timescaleMode16, ___stop17);
}
IL2CPP_EXTERN_C  void DelegatePInvokeWrapper_Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176 (Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeRed0, float ___remapRedZero1, float ___remapRedOne2, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeGreen3, float ___remapGreenZero4, float ___remapGreenOne5, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeBlue6, float ___remapBlueZero7, float ___remapBlueOne8, float ___duration9, bool ___relativeValues10, float ___attenuation11, int32_t ___channel12, bool ___resetShakerValuesAfterShake13, bool ___resetTargetValuesAfterShake14, bool ___forwardDirection15, int32_t ___timescaleMode16, bool ___stop17, const RuntimeMethod* method)
{






	typedef void (DEFAULT_CALL *PInvokeFunc)(AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshaled_pinvoke*, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshaled_pinvoke*, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshaled_pinvoke*, float, float, float, int32_t, float, int32_t, int32_t, int32_t, int32_t, int32_t, int32_t);
	PInvokeFunc il2cppPInvokeFunc = reinterpret_cast<PInvokeFunc>(il2cpp_codegen_get_reverse_pinvoke_function_ptr(__this));
	// Marshaling of parameter '___shakeRed0' to native representation
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshaled_pinvoke ____shakeRed0_marshaled = {};
	if (___shakeRed0 != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke(*___shakeRed0, ____shakeRed0_marshaled);
	}

	// Marshaling of parameter '___shakeGreen3' to native representation
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshaled_pinvoke ____shakeGreen3_marshaled = {};
	if (___shakeGreen3 != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke(*___shakeGreen3, ____shakeGreen3_marshaled);
	}

	// Marshaling of parameter '___shakeBlue6' to native representation
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshaled_pinvoke ____shakeBlue6_marshaled = {};
	if (___shakeBlue6 != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke(*___shakeBlue6, ____shakeBlue6_marshaled);
	}

	// Native function invocation
	il2cppPInvokeFunc(___shakeRed0 != NULL ? (&____shakeRed0_marshaled) : NULL, ___remapRedZero1, ___remapRedOne2, ___shakeGreen3 != NULL ? (&____shakeGreen3_marshaled) : NULL, ___remapGreenZero4, ___remapGreenOne5, ___shakeBlue6 != NULL ? (&____shakeBlue6_marshaled) : NULL, ___remapBlueZero7, ___remapBlueOne8, ___duration9, static_cast<int32_t>(___relativeValues10), ___attenuation11, ___channel12, static_cast<int32_t>(___resetShakerValuesAfterShake13), static_cast<int32_t>(___resetTargetValuesAfterShake14), static_cast<int32_t>(___forwardDirection15), ___timescaleMode16, static_cast<int32_t>(___stop17));

	// Marshaling of parameter '___shakeRed0' back from native representation
	if (___shakeRed0 != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke_back(____shakeRed0_marshaled, *___shakeRed0);
	}

	// Marshaling cleanup of parameter '___shakeRed0' native representation
	if ((&____shakeRed0_marshaled) != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke_cleanup(____shakeRed0_marshaled);
	}

	// Marshaling of parameter '___shakeGreen3' back from native representation
	if (___shakeGreen3 != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke_back(____shakeGreen3_marshaled, *___shakeGreen3);
	}

	// Marshaling cleanup of parameter '___shakeGreen3' native representation
	if ((&____shakeGreen3_marshaled) != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke_cleanup(____shakeGreen3_marshaled);
	}

	// Marshaling of parameter '___shakeBlue6' back from native representation
	if (___shakeBlue6 != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke_back(____shakeBlue6_marshaled, *___shakeBlue6);
	}

	// Marshaling cleanup of parameter '___shakeBlue6' native representation
	if ((&____shakeBlue6_marshaled) != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke_cleanup(____shakeBlue6_marshaled);
	}

}
// System.Void MoreMountains.FeedbacksForThirdParty.MMChannelMixerShakeEvent_HDRP/Delegate::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Delegate__ctor_m5E6292FE26E8924E5BFEEA5045E28913BD12E95D (Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176* __this, RuntimeObject* ___object0, intptr_t ___method1, const RuntimeMethod* method) 
{
	__this->___method_ptr_0 = il2cpp_codegen_get_virtual_call_method_pointer((RuntimeMethod*)___method1);
	__this->___method_3 = ___method1;
	__this->___m_target_2 = ___object0;
	Il2CppCodeGenWriteBarrier((void**)(&__this->___m_target_2), (void*)___object0);
	int parameterCount = il2cpp_codegen_method_parameter_count((RuntimeMethod*)___method1);
	__this->___method_code_6 = (intptr_t)__this;
	if (MethodIsStatic((RuntimeMethod*)___method1))
	{
		bool isOpen = parameterCount == 18;
		if (il2cpp_codegen_call_method_via_invoker((RuntimeMethod*)___method1))
			if (isOpen)
				__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_m1BF2E87CE04FB3085F026AEF72BB8D6BB6AE1483_OpenStaticInvoker;
			else
				__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_m1BF2E87CE04FB3085F026AEF72BB8D6BB6AE1483_ClosedStaticInvoker;
		else
			if (isOpen)
				__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_m1BF2E87CE04FB3085F026AEF72BB8D6BB6AE1483_OpenStatic;
			else
				{
					__this->___invoke_impl_1 = (intptr_t)__this->___method_ptr_0;
					__this->___method_code_6 = (intptr_t)__this->___m_target_2;
				}
	}
	else
	{
		bool isOpen = parameterCount == 17;
		if (isOpen)
		{
			if (__this->___method_is_virtual_12)
			{
				if (il2cpp_codegen_method_is_generic_instance_method((RuntimeMethod*)___method1))
					if (il2cpp_codegen_method_is_interface_method((RuntimeMethod*)___method1))
						__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_m1BF2E87CE04FB3085F026AEF72BB8D6BB6AE1483_OpenGenericInterface;
					else
						__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_m1BF2E87CE04FB3085F026AEF72BB8D6BB6AE1483_OpenGenericVirtual;
				else
					if (il2cpp_codegen_method_is_interface_method((RuntimeMethod*)___method1))
						__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_m1BF2E87CE04FB3085F026AEF72BB8D6BB6AE1483_OpenInterface;
					else
						__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_m1BF2E87CE04FB3085F026AEF72BB8D6BB6AE1483_OpenVirtual;
			}
			else
			{
				__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_m1BF2E87CE04FB3085F026AEF72BB8D6BB6AE1483_OpenInst;
			}
		}
		else
		{
			if (___object0 == NULL)
				il2cpp_codegen_raise_exception(il2cpp_codegen_get_argument_exception(NULL, "Delegate to an instance method cannot have null 'this'."), NULL);
			__this->___invoke_impl_1 = (intptr_t)__this->___method_ptr_0;
			__this->___method_code_6 = (intptr_t)__this->___m_target_2;
		}
	}
	__this->___extra_arg_5 = (intptr_t)&Delegate_Invoke_m1BF2E87CE04FB3085F026AEF72BB8D6BB6AE1483_Multicast;
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMChannelMixerShakeEvent_HDRP/Delegate::Invoke(UnityEngine.AnimationCurve,System.Single,System.Single,UnityEngine.AnimationCurve,System.Single,System.Single,UnityEngine.AnimationCurve,System.Single,System.Single,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Delegate_Invoke_m1BF2E87CE04FB3085F026AEF72BB8D6BB6AE1483 (Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeRed0, float ___remapRedZero1, float ___remapRedOne2, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeGreen3, float ___remapGreenZero4, float ___remapGreenOne5, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeBlue6, float ___remapBlueZero7, float ___remapBlueOne8, float ___duration9, bool ___relativeValues10, float ___attenuation11, int32_t ___channel12, bool ___resetShakerValuesAfterShake13, bool ___resetTargetValuesAfterShake14, bool ___forwardDirection15, int32_t ___timescaleMode16, bool ___stop17, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___shakeRed0, ___remapRedZero1, ___remapRedOne2, ___shakeGreen3, ___remapGreenZero4, ___remapGreenOne5, ___shakeBlue6, ___remapBlueZero7, ___remapBlueOne8, ___duration9, ___relativeValues10, ___attenuation11, ___channel12, ___resetShakerValuesAfterShake13, ___resetTargetValuesAfterShake14, ___forwardDirection15, ___timescaleMode16, ___stop17, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
// System.IAsyncResult MoreMountains.FeedbacksForThirdParty.MMChannelMixerShakeEvent_HDRP/Delegate::BeginInvoke(UnityEngine.AnimationCurve,System.Single,System.Single,UnityEngine.AnimationCurve,System.Single,System.Single,UnityEngine.AnimationCurve,System.Single,System.Single,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean,System.AsyncCallback,System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* Delegate_BeginInvoke_mF23C829035F18A69C587E5D533A7CD7DCE92FA33 (Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeRed0, float ___remapRedZero1, float ___remapRedOne2, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeGreen3, float ___remapGreenZero4, float ___remapGreenOne5, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeBlue6, float ___remapBlueZero7, float ___remapBlueOne8, float ___duration9, bool ___relativeValues10, float ___attenuation11, int32_t ___channel12, bool ___resetShakerValuesAfterShake13, bool ___resetTargetValuesAfterShake14, bool ___forwardDirection15, int32_t ___timescaleMode16, bool ___stop17, AsyncCallback_t7FEF460CBDCFB9C5FA2EF776984778B9A4145F4C* ___callback18, RuntimeObject* ___object19, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TimescaleModes_t567213DC39EEE1AA073F8E8473E19F2B71FC9A68_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	void *__d_args[19] = {0};
	__d_args[0] = ___shakeRed0;
	__d_args[1] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___remapRedZero1);
	__d_args[2] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___remapRedOne2);
	__d_args[3] = ___shakeGreen3;
	__d_args[4] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___remapGreenZero4);
	__d_args[5] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___remapGreenOne5);
	__d_args[6] = ___shakeBlue6;
	__d_args[7] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___remapBlueZero7);
	__d_args[8] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___remapBlueOne8);
	__d_args[9] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___duration9);
	__d_args[10] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___relativeValues10);
	__d_args[11] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___attenuation11);
	__d_args[12] = Box(Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var, &___channel12);
	__d_args[13] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___resetShakerValuesAfterShake13);
	__d_args[14] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___resetTargetValuesAfterShake14);
	__d_args[15] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___forwardDirection15);
	__d_args[16] = Box(TimescaleModes_t567213DC39EEE1AA073F8E8473E19F2B71FC9A68_il2cpp_TypeInfo_var, &___timescaleMode16);
	__d_args[17] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___stop17);
	return (RuntimeObject*)il2cpp_codegen_delegate_begin_invoke((RuntimeDelegate*)__this, __d_args, (RuntimeDelegate*)___callback18, (RuntimeObject*)___object19);
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMChannelMixerShakeEvent_HDRP/Delegate::EndInvoke(System.IAsyncResult)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Delegate_EndInvoke_mF345042A43B5CBE512806194D929702D15B71B1E (Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176* __this, RuntimeObject* ___result0, const RuntimeMethod* method) 
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
// System.Void MoreMountains.FeedbacksForThirdParty.MMChromaticAberrationShaker_HDRP::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMChromaticAberrationShaker_HDRP__ctor_m9287FD8BB01BC65FEF9FA336C765DCA5A5CC079C (MMChromaticAberrationShaker_HDRP_t472F090F0A238CD24FFB7783BEFAE79680D74ECD* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public AnimationCurve ShakeIntensity = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
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
		__this->___ShakeIntensity_21 = L_7;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ShakeIntensity_21), (void*)L_7);
		// public float RemapIntensityOne = 1f;
		__this->___RemapIntensityOne_23 = (1.0f);
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
// System.Void MoreMountains.FeedbacksForThirdParty.MMChromaticAberrationShakeEvent_HDRP::add_OnEvent(MoreMountains.FeedbacksForThirdParty.MMChromaticAberrationShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMChromaticAberrationShakeEvent_HDRP_add_OnEvent_m6E3CD5B372C7F98B31673ADD478D65A8CC7FCB82 (Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2* ___value0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMChromaticAberrationShakeEvent_HDRP_t3A6944A1AAA0BD111C74BBAAFB4D8D0278088CE3_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2* V_0 = NULL;
	Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2* V_1 = NULL;
	Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2* V_2 = NULL;
	{
		Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2* L_0 = ((MMChromaticAberrationShakeEvent_HDRP_t3A6944A1AAA0BD111C74BBAAFB4D8D0278088CE3_StaticFields*)il2cpp_codegen_static_fields_for(MMChromaticAberrationShakeEvent_HDRP_t3A6944A1AAA0BD111C74BBAAFB4D8D0278088CE3_il2cpp_TypeInfo_var))->___OnEvent_0;
		V_0 = L_0;
	}

IL_0006:
	{
		Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2* L_1 = V_0;
		V_1 = L_1;
		Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2* L_2 = V_1;
		Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2* L_3 = ___value0;
		Delegate_t* L_4;
		L_4 = Delegate_Combine_m1F725AEF318BE6F0426863490691A6F4606E7D00(L_2, L_3, NULL);
		V_2 = ((Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2*)CastclassSealed((RuntimeObject*)L_4, Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2_il2cpp_TypeInfo_var));
		Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2* L_5 = V_2;
		Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2* L_6 = V_1;
		Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2* L_7;
		L_7 = InterlockedCompareExchangeImpl<Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2*>((&((MMChromaticAberrationShakeEvent_HDRP_t3A6944A1AAA0BD111C74BBAAFB4D8D0278088CE3_StaticFields*)il2cpp_codegen_static_fields_for(MMChromaticAberrationShakeEvent_HDRP_t3A6944A1AAA0BD111C74BBAAFB4D8D0278088CE3_il2cpp_TypeInfo_var))->___OnEvent_0), L_5, L_6);
		V_0 = L_7;
		Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2* L_8 = V_0;
		Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2* L_9 = V_1;
		if ((!(((RuntimeObject*)(Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2*)L_8) == ((RuntimeObject*)(Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2*)L_9))))
		{
			goto IL_0006;
		}
	}
	{
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMChromaticAberrationShakeEvent_HDRP::remove_OnEvent(MoreMountains.FeedbacksForThirdParty.MMChromaticAberrationShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMChromaticAberrationShakeEvent_HDRP_remove_OnEvent_m8796459E997E5C5BBAE2F7F3DD7C86BE19387A82 (Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2* ___value0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMChromaticAberrationShakeEvent_HDRP_t3A6944A1AAA0BD111C74BBAAFB4D8D0278088CE3_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2* V_0 = NULL;
	Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2* V_1 = NULL;
	Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2* V_2 = NULL;
	{
		Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2* L_0 = ((MMChromaticAberrationShakeEvent_HDRP_t3A6944A1AAA0BD111C74BBAAFB4D8D0278088CE3_StaticFields*)il2cpp_codegen_static_fields_for(MMChromaticAberrationShakeEvent_HDRP_t3A6944A1AAA0BD111C74BBAAFB4D8D0278088CE3_il2cpp_TypeInfo_var))->___OnEvent_0;
		V_0 = L_0;
	}

IL_0006:
	{
		Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2* L_1 = V_0;
		V_1 = L_1;
		Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2* L_2 = V_1;
		Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2* L_3 = ___value0;
		Delegate_t* L_4;
		L_4 = Delegate_Remove_m8B7DD5661308FA972E23CA1CC3FC9CEB355504E3(L_2, L_3, NULL);
		V_2 = ((Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2*)CastclassSealed((RuntimeObject*)L_4, Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2_il2cpp_TypeInfo_var));
		Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2* L_5 = V_2;
		Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2* L_6 = V_1;
		Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2* L_7;
		L_7 = InterlockedCompareExchangeImpl<Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2*>((&((MMChromaticAberrationShakeEvent_HDRP_t3A6944A1AAA0BD111C74BBAAFB4D8D0278088CE3_StaticFields*)il2cpp_codegen_static_fields_for(MMChromaticAberrationShakeEvent_HDRP_t3A6944A1AAA0BD111C74BBAAFB4D8D0278088CE3_il2cpp_TypeInfo_var))->___OnEvent_0), L_5, L_6);
		V_0 = L_7;
		Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2* L_8 = V_0;
		Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2* L_9 = V_1;
		if ((!(((RuntimeObject*)(Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2*)L_8) == ((RuntimeObject*)(Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2*)L_9))))
		{
			goto IL_0006;
		}
	}
	{
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMChromaticAberrationShakeEvent_HDRP::Register(MoreMountains.FeedbacksForThirdParty.MMChromaticAberrationShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMChromaticAberrationShakeEvent_HDRP_Register_m695D01716156B2FD2DFA42B3F62C6508EE2DD663 (Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2* ___callback0, const RuntimeMethod* method) 
{
	{
		// OnEvent += callback;
		Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2* L_0 = ___callback0;
		MMChromaticAberrationShakeEvent_HDRP_add_OnEvent_m6E3CD5B372C7F98B31673ADD478D65A8CC7FCB82(L_0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMChromaticAberrationShakeEvent_HDRP::Unregister(MoreMountains.FeedbacksForThirdParty.MMChromaticAberrationShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMChromaticAberrationShakeEvent_HDRP_Unregister_mCCE60A5D5068E6C5996D79BD4F09D59F7A54EE7E (Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2* ___callback0, const RuntimeMethod* method) 
{
	{
		// OnEvent -= callback;
		Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2* L_0 = ___callback0;
		MMChromaticAberrationShakeEvent_HDRP_remove_OnEvent_m8796459E997E5C5BBAE2F7F3DD7C86BE19387A82(L_0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMChromaticAberrationShakeEvent_HDRP::Trigger(UnityEngine.AnimationCurve,System.Single,System.Single,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMChromaticAberrationShakeEvent_HDRP_Trigger_m2BF26327003EB129A7B88CBA28534150C418456E (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMChromaticAberrationShakeEvent_HDRP_t3A6944A1AAA0BD111C74BBAAFB4D8D0278088CE3_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2* G_B2_0 = NULL;
	Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2* G_B1_0 = NULL;
	{
		// OnEvent?.Invoke(intensity, duration, remapMin, remapMax, relativeIntensity, attenuation, channel, resetShakerValuesAfterShake, resetTargetValuesAfterShake, forwardDirection, timescaleMode, stop);
		Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2* L_0 = ((MMChromaticAberrationShakeEvent_HDRP_t3A6944A1AAA0BD111C74BBAAFB4D8D0278088CE3_StaticFields*)il2cpp_codegen_static_fields_for(MMChromaticAberrationShakeEvent_HDRP_t3A6944A1AAA0BD111C74BBAAFB4D8D0278088CE3_il2cpp_TypeInfo_var))->___OnEvent_0;
		Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2* L_1 = L_0;
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
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_2 = ___intensity0;
		float L_3 = ___duration1;
		float L_4 = ___remapMin2;
		float L_5 = ___remapMax3;
		bool L_6 = ___relativeIntensity4;
		float L_7 = ___attenuation5;
		int32_t L_8 = ___channel6;
		bool L_9 = ___resetShakerValuesAfterShake7;
		bool L_10 = ___resetTargetValuesAfterShake8;
		bool L_11 = ___forwardDirection9;
		int32_t L_12 = ___timescaleMode10;
		bool L_13 = ___stop11;
		NullCheck(G_B2_0);
		Delegate_Invoke_mD47FC069DCC89CDB71DF4618BC9D58ABA8AF77A3_inline(G_B2_0, L_2, L_3, L_4, L_5, L_6, L_7, L_8, L_9, L_10, L_11, L_12, L_13, NULL);
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
void Delegate_Invoke_mD47FC069DCC89CDB71DF4618BC9D58ABA8AF77A3_Multicast(Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	il2cpp_array_size_t length = __this->___delegates_13->max_length;
	Delegate_t** delegatesToInvoke = reinterpret_cast<Delegate_t**>(__this->___delegates_13->GetAddressAtUnchecked(0));
	for (il2cpp_array_size_t i = 0; i < length; i++)
	{
		Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2* currentDelegate = reinterpret_cast<Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2*>(delegatesToInvoke[i]);
		typedef void (*FunctionPointerType) (RuntimeObject*, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
		((FunctionPointerType)currentDelegate->___invoke_impl_1)((Il2CppObject*)currentDelegate->___method_code_6, ___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11, reinterpret_cast<RuntimeMethod*>(currentDelegate->___method_3));
	}
}
void Delegate_Invoke_mD47FC069DCC89CDB71DF4618BC9D58ABA8AF77A3_OpenInst(Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	NullCheck(___intensity0);
	typedef void (*FunctionPointerType) (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___method_ptr_0)(___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11, method);
}
void Delegate_Invoke_mD47FC069DCC89CDB71DF4618BC9D58ABA8AF77A3_OpenStatic(Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	typedef void (*FunctionPointerType) (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___method_ptr_0)(___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11, method);
}
void Delegate_Invoke_mD47FC069DCC89CDB71DF4618BC9D58ABA8AF77A3_OpenStaticInvoker(Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	InvokerActionInvoker12< AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(__this->___method_ptr_0, method, NULL, ___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11);
}
void Delegate_Invoke_mD47FC069DCC89CDB71DF4618BC9D58ABA8AF77A3_ClosedStaticInvoker(Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	InvokerActionInvoker13< RuntimeObject*, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(__this->___method_ptr_0, method, NULL, __this->___m_target_2, ___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11);
}
void Delegate_Invoke_mD47FC069DCC89CDB71DF4618BC9D58ABA8AF77A3_OpenVirtual(Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	NullCheck(___intensity0);
	VirtualActionInvoker11< float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(il2cpp_codegen_method_get_slot(method), ___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11);
}
void Delegate_Invoke_mD47FC069DCC89CDB71DF4618BC9D58ABA8AF77A3_OpenInterface(Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	NullCheck(___intensity0);
	InterfaceActionInvoker11< float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(il2cpp_codegen_method_get_slot(method), il2cpp_codegen_method_get_declaring_type(method), ___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11);
}
void Delegate_Invoke_mD47FC069DCC89CDB71DF4618BC9D58ABA8AF77A3_OpenGenericVirtual(Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	NullCheck(___intensity0);
	GenericVirtualActionInvoker11< float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(method, ___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11);
}
void Delegate_Invoke_mD47FC069DCC89CDB71DF4618BC9D58ABA8AF77A3_OpenGenericInterface(Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	NullCheck(___intensity0);
	GenericInterfaceActionInvoker11< float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(method, ___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11);
}
IL2CPP_EXTERN_C  void DelegatePInvokeWrapper_Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2 (Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{


	typedef void (DEFAULT_CALL *PInvokeFunc)(AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshaled_pinvoke*, float, float, float, int32_t, float, int32_t, int32_t, int32_t, int32_t, int32_t, int32_t);
	PInvokeFunc il2cppPInvokeFunc = reinterpret_cast<PInvokeFunc>(il2cpp_codegen_get_reverse_pinvoke_function_ptr(__this));
	// Marshaling of parameter '___intensity0' to native representation
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshaled_pinvoke ____intensity0_marshaled = {};
	if (___intensity0 != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke(*___intensity0, ____intensity0_marshaled);
	}

	// Native function invocation
	il2cppPInvokeFunc(___intensity0 != NULL ? (&____intensity0_marshaled) : NULL, ___duration1, ___remapMin2, ___remapMax3, static_cast<int32_t>(___relativeIntensity4), ___attenuation5, ___channel6, static_cast<int32_t>(___resetShakerValuesAfterShake7), static_cast<int32_t>(___resetTargetValuesAfterShake8), static_cast<int32_t>(___forwardDirection9), ___timescaleMode10, static_cast<int32_t>(___stop11));

	// Marshaling of parameter '___intensity0' back from native representation
	if (___intensity0 != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke_back(____intensity0_marshaled, *___intensity0);
	}

	// Marshaling cleanup of parameter '___intensity0' native representation
	if ((&____intensity0_marshaled) != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke_cleanup(____intensity0_marshaled);
	}

}
// System.Void MoreMountains.FeedbacksForThirdParty.MMChromaticAberrationShakeEvent_HDRP/Delegate::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Delegate__ctor_m122276D5B739DF092B7F02C282DCBC7D145AA592 (Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2* __this, RuntimeObject* ___object0, intptr_t ___method1, const RuntimeMethod* method) 
{
	__this->___method_ptr_0 = il2cpp_codegen_get_virtual_call_method_pointer((RuntimeMethod*)___method1);
	__this->___method_3 = ___method1;
	__this->___m_target_2 = ___object0;
	Il2CppCodeGenWriteBarrier((void**)(&__this->___m_target_2), (void*)___object0);
	int parameterCount = il2cpp_codegen_method_parameter_count((RuntimeMethod*)___method1);
	__this->___method_code_6 = (intptr_t)__this;
	if (MethodIsStatic((RuntimeMethod*)___method1))
	{
		bool isOpen = parameterCount == 12;
		if (il2cpp_codegen_call_method_via_invoker((RuntimeMethod*)___method1))
			if (isOpen)
				__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mD47FC069DCC89CDB71DF4618BC9D58ABA8AF77A3_OpenStaticInvoker;
			else
				__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mD47FC069DCC89CDB71DF4618BC9D58ABA8AF77A3_ClosedStaticInvoker;
		else
			if (isOpen)
				__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mD47FC069DCC89CDB71DF4618BC9D58ABA8AF77A3_OpenStatic;
			else
				{
					__this->___invoke_impl_1 = (intptr_t)__this->___method_ptr_0;
					__this->___method_code_6 = (intptr_t)__this->___m_target_2;
				}
	}
	else
	{
		bool isOpen = parameterCount == 11;
		if (isOpen)
		{
			if (__this->___method_is_virtual_12)
			{
				if (il2cpp_codegen_method_is_generic_instance_method((RuntimeMethod*)___method1))
					if (il2cpp_codegen_method_is_interface_method((RuntimeMethod*)___method1))
						__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mD47FC069DCC89CDB71DF4618BC9D58ABA8AF77A3_OpenGenericInterface;
					else
						__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mD47FC069DCC89CDB71DF4618BC9D58ABA8AF77A3_OpenGenericVirtual;
				else
					if (il2cpp_codegen_method_is_interface_method((RuntimeMethod*)___method1))
						__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mD47FC069DCC89CDB71DF4618BC9D58ABA8AF77A3_OpenInterface;
					else
						__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mD47FC069DCC89CDB71DF4618BC9D58ABA8AF77A3_OpenVirtual;
			}
			else
			{
				__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mD47FC069DCC89CDB71DF4618BC9D58ABA8AF77A3_OpenInst;
			}
		}
		else
		{
			if (___object0 == NULL)
				il2cpp_codegen_raise_exception(il2cpp_codegen_get_argument_exception(NULL, "Delegate to an instance method cannot have null 'this'."), NULL);
			__this->___invoke_impl_1 = (intptr_t)__this->___method_ptr_0;
			__this->___method_code_6 = (intptr_t)__this->___m_target_2;
		}
	}
	__this->___extra_arg_5 = (intptr_t)&Delegate_Invoke_mD47FC069DCC89CDB71DF4618BC9D58ABA8AF77A3_Multicast;
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMChromaticAberrationShakeEvent_HDRP/Delegate::Invoke(UnityEngine.AnimationCurve,System.Single,System.Single,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Delegate_Invoke_mD47FC069DCC89CDB71DF4618BC9D58ABA8AF77A3 (Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
// System.IAsyncResult MoreMountains.FeedbacksForThirdParty.MMChromaticAberrationShakeEvent_HDRP/Delegate::BeginInvoke(UnityEngine.AnimationCurve,System.Single,System.Single,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean,System.AsyncCallback,System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* Delegate_BeginInvoke_mB0A1E43EF184B51C6207DD29A8E50BE6F0DDDB9D (Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, AsyncCallback_t7FEF460CBDCFB9C5FA2EF776984778B9A4145F4C* ___callback12, RuntimeObject* ___object13, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TimescaleModes_t567213DC39EEE1AA073F8E8473E19F2B71FC9A68_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	void *__d_args[13] = {0};
	__d_args[0] = ___intensity0;
	__d_args[1] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___duration1);
	__d_args[2] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___remapMin2);
	__d_args[3] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___remapMax3);
	__d_args[4] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___relativeIntensity4);
	__d_args[5] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___attenuation5);
	__d_args[6] = Box(Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var, &___channel6);
	__d_args[7] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___resetShakerValuesAfterShake7);
	__d_args[8] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___resetTargetValuesAfterShake8);
	__d_args[9] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___forwardDirection9);
	__d_args[10] = Box(TimescaleModes_t567213DC39EEE1AA073F8E8473E19F2B71FC9A68_il2cpp_TypeInfo_var, &___timescaleMode10);
	__d_args[11] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___stop11);
	return (RuntimeObject*)il2cpp_codegen_delegate_begin_invoke((RuntimeDelegate*)__this, __d_args, (RuntimeDelegate*)___callback12, (RuntimeObject*)___object13);
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMChromaticAberrationShakeEvent_HDRP/Delegate::EndInvoke(System.IAsyncResult)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Delegate_EndInvoke_mB49F3CDFF6C056F9273E2D6E5DCCAC79D8716BA8 (Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2* __this, RuntimeObject* ___result0, const RuntimeMethod* method) 
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
// System.Void MoreMountains.FeedbacksForThirdParty.MMColorAdjustmentsShaker_HDRP::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMColorAdjustmentsShaker_HDRP__ctor_m8EE6398D25FB162FE689BD793C53C8C16331B096 (MMColorAdjustmentsShaker_HDRP_t9171C6E1A7365800B6688933DC93F11BC338793A* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public bool RelativeValues = true;
		__this->___RelativeValues_20 = (bool)1;
		// public AnimationCurve ShakePostExposure = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
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
		__this->___ShakePostExposure_21 = L_7;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ShakePostExposure_21), (void*)L_7);
		// public float RemapPostExposureOne = 1f;
		__this->___RemapPostExposureOne_23 = (1.0f);
		// public AnimationCurve ShakeHueShift = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
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
		__this->___ShakeHueShift_24 = L_15;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ShakeHueShift_24), (void*)L_15);
		// public float RemapHueShiftOne = 180f;
		__this->___RemapHueShiftOne_26 = (180.0f);
		// public AnimationCurve ShakeSaturation = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_16 = (KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3*)(KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3*)SZArrayNew(KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var, (uint32_t)3);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_17 = L_16;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_18;
		memset((&L_18), 0, sizeof(L_18));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_18), (0.0f), (0.0f), /*hidden argument*/NULL);
		NullCheck(L_17);
		(L_17)->SetAt(static_cast<il2cpp_array_size_t>(0), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_18);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_19 = L_17;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_20;
		memset((&L_20), 0, sizeof(L_20));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_20), (0.5f), (1.0f), /*hidden argument*/NULL);
		NullCheck(L_19);
		(L_19)->SetAt(static_cast<il2cpp_array_size_t>(1), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_20);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_21 = L_19;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_22;
		memset((&L_22), 0, sizeof(L_22));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_22), (1.0f), (0.0f), /*hidden argument*/NULL);
		NullCheck(L_21);
		(L_21)->SetAt(static_cast<il2cpp_array_size_t>(2), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_22);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_23 = (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*)il2cpp_codegen_object_new(AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		NullCheck(L_23);
		AnimationCurve__ctor_mEABC98C03805713354D61E50D9340766BD5B717E(L_23, L_21, NULL);
		__this->___ShakeSaturation_27 = L_23;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ShakeSaturation_27), (void*)L_23);
		// public float RemapSaturationOne = 100f;
		__this->___RemapSaturationOne_29 = (100.0f);
		// public AnimationCurve ShakeContrast = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_24 = (KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3*)(KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3*)SZArrayNew(KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var, (uint32_t)3);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_25 = L_24;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_26;
		memset((&L_26), 0, sizeof(L_26));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_26), (0.0f), (0.0f), /*hidden argument*/NULL);
		NullCheck(L_25);
		(L_25)->SetAt(static_cast<il2cpp_array_size_t>(0), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_26);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_27 = L_25;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_28;
		memset((&L_28), 0, sizeof(L_28));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_28), (0.5f), (1.0f), /*hidden argument*/NULL);
		NullCheck(L_27);
		(L_27)->SetAt(static_cast<il2cpp_array_size_t>(1), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_28);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_29 = L_27;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_30;
		memset((&L_30), 0, sizeof(L_30));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_30), (1.0f), (0.0f), /*hidden argument*/NULL);
		NullCheck(L_29);
		(L_29)->SetAt(static_cast<il2cpp_array_size_t>(2), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_30);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_31 = (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*)il2cpp_codegen_object_new(AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		NullCheck(L_31);
		AnimationCurve__ctor_mEABC98C03805713354D61E50D9340766BD5B717E(L_31, L_29, NULL);
		__this->___ShakeContrast_30 = L_31;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ShakeContrast_30), (void*)L_31);
		// public float RemapContrastOne = 100f;
		__this->___RemapContrastOne_32 = (100.0f);
		// public Color ColorFilterDestination = Color.yellow;
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F L_32;
		L_32 = Color_get_yellow_m66637FA14383E8D74F24AE256B577CE1D55D469F_inline(NULL);
		__this->___ColorFilterDestination_35 = L_32;
		// public AnimationCurve ColorFilterCurve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_33 = (KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3*)(KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3*)SZArrayNew(KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var, (uint32_t)3);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_34 = L_33;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_35;
		memset((&L_35), 0, sizeof(L_35));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_35), (0.0f), (0.0f), /*hidden argument*/NULL);
		NullCheck(L_34);
		(L_34)->SetAt(static_cast<il2cpp_array_size_t>(0), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_35);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_36 = L_34;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_37;
		memset((&L_37), 0, sizeof(L_37));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_37), (0.5f), (1.0f), /*hidden argument*/NULL);
		NullCheck(L_36);
		(L_36)->SetAt(static_cast<il2cpp_array_size_t>(1), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_37);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_38 = L_36;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_39;
		memset((&L_39), 0, sizeof(L_39));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_39), (1.0f), (0.0f), /*hidden argument*/NULL);
		NullCheck(L_38);
		(L_38)->SetAt(static_cast<il2cpp_array_size_t>(2), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_39);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_40 = (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*)il2cpp_codegen_object_new(AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		NullCheck(L_40);
		AnimationCurve__ctor_mEABC98C03805713354D61E50D9340766BD5B717E(L_40, L_38, NULL);
		__this->___ColorFilterCurve_36 = L_40;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ColorFilterCurve_36), (void*)L_40);
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
// System.Void MoreMountains.FeedbacksForThirdParty.MMColorAdjustmentsShakeEvent_HDRP::add_OnEvent(MoreMountains.FeedbacksForThirdParty.MMColorAdjustmentsShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMColorAdjustmentsShakeEvent_HDRP_add_OnEvent_m80DBD8516C0450D107EEBA6413A4C5CADB4BB21F (Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19* ___value0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMColorAdjustmentsShakeEvent_HDRP_tD8B4F222BD3844D61BC606D3E8FFCF5D6B20B5FE_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19* V_0 = NULL;
	Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19* V_1 = NULL;
	Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19* V_2 = NULL;
	{
		Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19* L_0 = ((MMColorAdjustmentsShakeEvent_HDRP_tD8B4F222BD3844D61BC606D3E8FFCF5D6B20B5FE_StaticFields*)il2cpp_codegen_static_fields_for(MMColorAdjustmentsShakeEvent_HDRP_tD8B4F222BD3844D61BC606D3E8FFCF5D6B20B5FE_il2cpp_TypeInfo_var))->___OnEvent_0;
		V_0 = L_0;
	}

IL_0006:
	{
		Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19* L_1 = V_0;
		V_1 = L_1;
		Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19* L_2 = V_1;
		Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19* L_3 = ___value0;
		Delegate_t* L_4;
		L_4 = Delegate_Combine_m1F725AEF318BE6F0426863490691A6F4606E7D00(L_2, L_3, NULL);
		V_2 = ((Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19*)CastclassSealed((RuntimeObject*)L_4, Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19_il2cpp_TypeInfo_var));
		Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19* L_5 = V_2;
		Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19* L_6 = V_1;
		Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19* L_7;
		L_7 = InterlockedCompareExchangeImpl<Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19*>((&((MMColorAdjustmentsShakeEvent_HDRP_tD8B4F222BD3844D61BC606D3E8FFCF5D6B20B5FE_StaticFields*)il2cpp_codegen_static_fields_for(MMColorAdjustmentsShakeEvent_HDRP_tD8B4F222BD3844D61BC606D3E8FFCF5D6B20B5FE_il2cpp_TypeInfo_var))->___OnEvent_0), L_5, L_6);
		V_0 = L_7;
		Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19* L_8 = V_0;
		Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19* L_9 = V_1;
		if ((!(((RuntimeObject*)(Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19*)L_8) == ((RuntimeObject*)(Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19*)L_9))))
		{
			goto IL_0006;
		}
	}
	{
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMColorAdjustmentsShakeEvent_HDRP::remove_OnEvent(MoreMountains.FeedbacksForThirdParty.MMColorAdjustmentsShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMColorAdjustmentsShakeEvent_HDRP_remove_OnEvent_m1FACF78DED1583793CE088198D88C6A2842BA5BD (Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19* ___value0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMColorAdjustmentsShakeEvent_HDRP_tD8B4F222BD3844D61BC606D3E8FFCF5D6B20B5FE_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19* V_0 = NULL;
	Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19* V_1 = NULL;
	Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19* V_2 = NULL;
	{
		Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19* L_0 = ((MMColorAdjustmentsShakeEvent_HDRP_tD8B4F222BD3844D61BC606D3E8FFCF5D6B20B5FE_StaticFields*)il2cpp_codegen_static_fields_for(MMColorAdjustmentsShakeEvent_HDRP_tD8B4F222BD3844D61BC606D3E8FFCF5D6B20B5FE_il2cpp_TypeInfo_var))->___OnEvent_0;
		V_0 = L_0;
	}

IL_0006:
	{
		Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19* L_1 = V_0;
		V_1 = L_1;
		Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19* L_2 = V_1;
		Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19* L_3 = ___value0;
		Delegate_t* L_4;
		L_4 = Delegate_Remove_m8B7DD5661308FA972E23CA1CC3FC9CEB355504E3(L_2, L_3, NULL);
		V_2 = ((Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19*)CastclassSealed((RuntimeObject*)L_4, Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19_il2cpp_TypeInfo_var));
		Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19* L_5 = V_2;
		Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19* L_6 = V_1;
		Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19* L_7;
		L_7 = InterlockedCompareExchangeImpl<Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19*>((&((MMColorAdjustmentsShakeEvent_HDRP_tD8B4F222BD3844D61BC606D3E8FFCF5D6B20B5FE_StaticFields*)il2cpp_codegen_static_fields_for(MMColorAdjustmentsShakeEvent_HDRP_tD8B4F222BD3844D61BC606D3E8FFCF5D6B20B5FE_il2cpp_TypeInfo_var))->___OnEvent_0), L_5, L_6);
		V_0 = L_7;
		Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19* L_8 = V_0;
		Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19* L_9 = V_1;
		if ((!(((RuntimeObject*)(Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19*)L_8) == ((RuntimeObject*)(Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19*)L_9))))
		{
			goto IL_0006;
		}
	}
	{
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMColorAdjustmentsShakeEvent_HDRP::Register(MoreMountains.FeedbacksForThirdParty.MMColorAdjustmentsShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMColorAdjustmentsShakeEvent_HDRP_Register_m2EB5853B7C2B1666F83625564D7611747C674D52 (Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19* ___callback0, const RuntimeMethod* method) 
{
	{
		// OnEvent += callback;
		Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19* L_0 = ___callback0;
		MMColorAdjustmentsShakeEvent_HDRP_add_OnEvent_m80DBD8516C0450D107EEBA6413A4C5CADB4BB21F(L_0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMColorAdjustmentsShakeEvent_HDRP::Unregister(MoreMountains.FeedbacksForThirdParty.MMColorAdjustmentsShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMColorAdjustmentsShakeEvent_HDRP_Unregister_mD611D5056BF61A34E922B63DDE73FE081EB46C66 (Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19* ___callback0, const RuntimeMethod* method) 
{
	{
		// OnEvent -= callback;
		Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19* L_0 = ___callback0;
		MMColorAdjustmentsShakeEvent_HDRP_remove_OnEvent_m1FACF78DED1583793CE088198D88C6A2842BA5BD(L_0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMColorAdjustmentsShakeEvent_HDRP::Trigger(UnityEngine.AnimationCurve,System.Single,System.Single,UnityEngine.AnimationCurve,System.Single,System.Single,UnityEngine.AnimationCurve,System.Single,System.Single,UnityEngine.AnimationCurve,System.Single,System.Single,MoreMountains.FeedbacksForThirdParty.MMColorAdjustmentsShaker_HDRP/ColorFilterModes,UnityEngine.Gradient,UnityEngine.Color,UnityEngine.AnimationCurve,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMColorAdjustmentsShakeEvent_HDRP_Trigger_mEFEAD45DF484AF38F46422ABDEE911B21935BB16 (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakePostExposure0, float ___remapPostExposureZero1, float ___remapPostExposureOne2, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeHueShift3, float ___remapHueShiftZero4, float ___remapHueShiftOne5, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeSaturation6, float ___remapSaturationZero7, float ___remapSaturationOne8, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeContrast9, float ___remapContrastZero10, float ___remapContrastOne11, int32_t ___colorFilterMode12, Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E* ___colorFilterGradient13, Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___colorFilterDestination14, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___colorFilterCurve15, float ___duration16, bool ___relativeValues17, float ___attenuation18, int32_t ___channel19, bool ___resetShakerValuesAfterShake20, bool ___resetTargetValuesAfterShake21, bool ___forwardDirection22, int32_t ___timescaleMode23, bool ___stop24, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMColorAdjustmentsShakeEvent_HDRP_tD8B4F222BD3844D61BC606D3E8FFCF5D6B20B5FE_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19* G_B2_0 = NULL;
	Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19* G_B1_0 = NULL;
	{
		// OnEvent?.Invoke(shakePostExposure, remapPostExposureZero, remapPostExposureOne,
		//     shakeHueShift, remapHueShiftZero, remapHueShiftOne,
		//     shakeSaturation, remapSaturationZero, remapSaturationOne,
		//     shakeContrast, remapContrastZero, remapContrastOne,
		//     colorFilterMode, colorFilterGradient, colorFilterDestination, colorFilterCurve,
		//     duration, relativeValues, attenuation, channel, resetShakerValuesAfterShake, resetTargetValuesAfterShake, forwardDirection, timescaleMode, stop);
		Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19* L_0 = ((MMColorAdjustmentsShakeEvent_HDRP_tD8B4F222BD3844D61BC606D3E8FFCF5D6B20B5FE_StaticFields*)il2cpp_codegen_static_fields_for(MMColorAdjustmentsShakeEvent_HDRP_tD8B4F222BD3844D61BC606D3E8FFCF5D6B20B5FE_il2cpp_TypeInfo_var))->___OnEvent_0;
		Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19* L_1 = L_0;
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
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_2 = ___shakePostExposure0;
		float L_3 = ___remapPostExposureZero1;
		float L_4 = ___remapPostExposureOne2;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_5 = ___shakeHueShift3;
		float L_6 = ___remapHueShiftZero4;
		float L_7 = ___remapHueShiftOne5;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_8 = ___shakeSaturation6;
		float L_9 = ___remapSaturationZero7;
		float L_10 = ___remapSaturationOne8;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_11 = ___shakeContrast9;
		float L_12 = ___remapContrastZero10;
		float L_13 = ___remapContrastOne11;
		int32_t L_14 = ___colorFilterMode12;
		Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E* L_15 = ___colorFilterGradient13;
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F L_16 = ___colorFilterDestination14;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_17 = ___colorFilterCurve15;
		float L_18 = ___duration16;
		bool L_19 = ___relativeValues17;
		float L_20 = ___attenuation18;
		int32_t L_21 = ___channel19;
		bool L_22 = ___resetShakerValuesAfterShake20;
		bool L_23 = ___resetTargetValuesAfterShake21;
		bool L_24 = ___forwardDirection22;
		int32_t L_25 = ___timescaleMode23;
		bool L_26 = ___stop24;
		NullCheck(G_B2_0);
		Delegate_Invoke_mF4923867EB16C9EB4E8B71E48F04C5173E122D3A_inline(G_B2_0, L_2, L_3, L_4, L_5, L_6, L_7, L_8, L_9, L_10, L_11, L_12, L_13, L_14, L_15, L_16, L_17, L_18, L_19, L_20, L_21, L_22, L_23, L_24, L_25, L_26, NULL);
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
void Delegate_Invoke_mF4923867EB16C9EB4E8B71E48F04C5173E122D3A_Multicast(Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakePostExposure0, float ___remapPostExposureZero1, float ___remapPostExposureOne2, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeHueShift3, float ___remapHueShiftZero4, float ___remapHueShiftOne5, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeSaturation6, float ___remapSaturationZero7, float ___remapSaturationOne8, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeContrast9, float ___remapContrastZero10, float ___remapContrastOne11, int32_t ___colorFilterMode12, Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E* ___colorFilterGradient13, Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___colorFilterDestination14, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___colorFilterCurve15, float ___duration16, bool ___relativeValues17, float ___attenuation18, int32_t ___channel19, bool ___resetShakerValuesAfterShake20, bool ___resetTargetValuesAfterShake21, bool ___forwardDirection22, int32_t ___timescaleMode23, bool ___stop24, const RuntimeMethod* method)
{
	il2cpp_array_size_t length = __this->___delegates_13->max_length;
	Delegate_t** delegatesToInvoke = reinterpret_cast<Delegate_t**>(__this->___delegates_13->GetAddressAtUnchecked(0));
	for (il2cpp_array_size_t i = 0; i < length; i++)
	{
		Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19* currentDelegate = reinterpret_cast<Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19*>(delegatesToInvoke[i]);
		typedef void (*FunctionPointerType) (RuntimeObject*, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, int32_t, Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E*, Color_tD001788D726C3A7F1379BEED0260B9591F440C1F, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
		((FunctionPointerType)currentDelegate->___invoke_impl_1)((Il2CppObject*)currentDelegate->___method_code_6, ___shakePostExposure0, ___remapPostExposureZero1, ___remapPostExposureOne2, ___shakeHueShift3, ___remapHueShiftZero4, ___remapHueShiftOne5, ___shakeSaturation6, ___remapSaturationZero7, ___remapSaturationOne8, ___shakeContrast9, ___remapContrastZero10, ___remapContrastOne11, ___colorFilterMode12, ___colorFilterGradient13, ___colorFilterDestination14, ___colorFilterCurve15, ___duration16, ___relativeValues17, ___attenuation18, ___channel19, ___resetShakerValuesAfterShake20, ___resetTargetValuesAfterShake21, ___forwardDirection22, ___timescaleMode23, ___stop24, reinterpret_cast<RuntimeMethod*>(currentDelegate->___method_3));
	}
}
void Delegate_Invoke_mF4923867EB16C9EB4E8B71E48F04C5173E122D3A_OpenInst(Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakePostExposure0, float ___remapPostExposureZero1, float ___remapPostExposureOne2, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeHueShift3, float ___remapHueShiftZero4, float ___remapHueShiftOne5, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeSaturation6, float ___remapSaturationZero7, float ___remapSaturationOne8, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeContrast9, float ___remapContrastZero10, float ___remapContrastOne11, int32_t ___colorFilterMode12, Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E* ___colorFilterGradient13, Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___colorFilterDestination14, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___colorFilterCurve15, float ___duration16, bool ___relativeValues17, float ___attenuation18, int32_t ___channel19, bool ___resetShakerValuesAfterShake20, bool ___resetTargetValuesAfterShake21, bool ___forwardDirection22, int32_t ___timescaleMode23, bool ___stop24, const RuntimeMethod* method)
{
	NullCheck(___shakePostExposure0);
	typedef void (*FunctionPointerType) (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, int32_t, Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E*, Color_tD001788D726C3A7F1379BEED0260B9591F440C1F, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___method_ptr_0)(___shakePostExposure0, ___remapPostExposureZero1, ___remapPostExposureOne2, ___shakeHueShift3, ___remapHueShiftZero4, ___remapHueShiftOne5, ___shakeSaturation6, ___remapSaturationZero7, ___remapSaturationOne8, ___shakeContrast9, ___remapContrastZero10, ___remapContrastOne11, ___colorFilterMode12, ___colorFilterGradient13, ___colorFilterDestination14, ___colorFilterCurve15, ___duration16, ___relativeValues17, ___attenuation18, ___channel19, ___resetShakerValuesAfterShake20, ___resetTargetValuesAfterShake21, ___forwardDirection22, ___timescaleMode23, ___stop24, method);
}
void Delegate_Invoke_mF4923867EB16C9EB4E8B71E48F04C5173E122D3A_OpenStatic(Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakePostExposure0, float ___remapPostExposureZero1, float ___remapPostExposureOne2, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeHueShift3, float ___remapHueShiftZero4, float ___remapHueShiftOne5, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeSaturation6, float ___remapSaturationZero7, float ___remapSaturationOne8, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeContrast9, float ___remapContrastZero10, float ___remapContrastOne11, int32_t ___colorFilterMode12, Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E* ___colorFilterGradient13, Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___colorFilterDestination14, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___colorFilterCurve15, float ___duration16, bool ___relativeValues17, float ___attenuation18, int32_t ___channel19, bool ___resetShakerValuesAfterShake20, bool ___resetTargetValuesAfterShake21, bool ___forwardDirection22, int32_t ___timescaleMode23, bool ___stop24, const RuntimeMethod* method)
{
	typedef void (*FunctionPointerType) (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, int32_t, Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E*, Color_tD001788D726C3A7F1379BEED0260B9591F440C1F, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___method_ptr_0)(___shakePostExposure0, ___remapPostExposureZero1, ___remapPostExposureOne2, ___shakeHueShift3, ___remapHueShiftZero4, ___remapHueShiftOne5, ___shakeSaturation6, ___remapSaturationZero7, ___remapSaturationOne8, ___shakeContrast9, ___remapContrastZero10, ___remapContrastOne11, ___colorFilterMode12, ___colorFilterGradient13, ___colorFilterDestination14, ___colorFilterCurve15, ___duration16, ___relativeValues17, ___attenuation18, ___channel19, ___resetShakerValuesAfterShake20, ___resetTargetValuesAfterShake21, ___forwardDirection22, ___timescaleMode23, ___stop24, method);
}
void Delegate_Invoke_mF4923867EB16C9EB4E8B71E48F04C5173E122D3A_OpenStaticInvoker(Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakePostExposure0, float ___remapPostExposureZero1, float ___remapPostExposureOne2, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeHueShift3, float ___remapHueShiftZero4, float ___remapHueShiftOne5, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeSaturation6, float ___remapSaturationZero7, float ___remapSaturationOne8, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeContrast9, float ___remapContrastZero10, float ___remapContrastOne11, int32_t ___colorFilterMode12, Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E* ___colorFilterGradient13, Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___colorFilterDestination14, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___colorFilterCurve15, float ___duration16, bool ___relativeValues17, float ___attenuation18, int32_t ___channel19, bool ___resetShakerValuesAfterShake20, bool ___resetTargetValuesAfterShake21, bool ___forwardDirection22, int32_t ___timescaleMode23, bool ___stop24, const RuntimeMethod* method)
{
	InvokerActionInvoker25< AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, int32_t, Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E*, Color_tD001788D726C3A7F1379BEED0260B9591F440C1F, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(__this->___method_ptr_0, method, NULL, ___shakePostExposure0, ___remapPostExposureZero1, ___remapPostExposureOne2, ___shakeHueShift3, ___remapHueShiftZero4, ___remapHueShiftOne5, ___shakeSaturation6, ___remapSaturationZero7, ___remapSaturationOne8, ___shakeContrast9, ___remapContrastZero10, ___remapContrastOne11, ___colorFilterMode12, ___colorFilterGradient13, ___colorFilterDestination14, ___colorFilterCurve15, ___duration16, ___relativeValues17, ___attenuation18, ___channel19, ___resetShakerValuesAfterShake20, ___resetTargetValuesAfterShake21, ___forwardDirection22, ___timescaleMode23, ___stop24);
}
void Delegate_Invoke_mF4923867EB16C9EB4E8B71E48F04C5173E122D3A_ClosedStaticInvoker(Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakePostExposure0, float ___remapPostExposureZero1, float ___remapPostExposureOne2, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeHueShift3, float ___remapHueShiftZero4, float ___remapHueShiftOne5, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeSaturation6, float ___remapSaturationZero7, float ___remapSaturationOne8, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeContrast9, float ___remapContrastZero10, float ___remapContrastOne11, int32_t ___colorFilterMode12, Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E* ___colorFilterGradient13, Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___colorFilterDestination14, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___colorFilterCurve15, float ___duration16, bool ___relativeValues17, float ___attenuation18, int32_t ___channel19, bool ___resetShakerValuesAfterShake20, bool ___resetTargetValuesAfterShake21, bool ___forwardDirection22, int32_t ___timescaleMode23, bool ___stop24, const RuntimeMethod* method)
{
	InvokerActionInvoker26< RuntimeObject*, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, int32_t, Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E*, Color_tD001788D726C3A7F1379BEED0260B9591F440C1F, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(__this->___method_ptr_0, method, NULL, __this->___m_target_2, ___shakePostExposure0, ___remapPostExposureZero1, ___remapPostExposureOne2, ___shakeHueShift3, ___remapHueShiftZero4, ___remapHueShiftOne5, ___shakeSaturation6, ___remapSaturationZero7, ___remapSaturationOne8, ___shakeContrast9, ___remapContrastZero10, ___remapContrastOne11, ___colorFilterMode12, ___colorFilterGradient13, ___colorFilterDestination14, ___colorFilterCurve15, ___duration16, ___relativeValues17, ___attenuation18, ___channel19, ___resetShakerValuesAfterShake20, ___resetTargetValuesAfterShake21, ___forwardDirection22, ___timescaleMode23, ___stop24);
}
void Delegate_Invoke_mF4923867EB16C9EB4E8B71E48F04C5173E122D3A_OpenVirtual(Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakePostExposure0, float ___remapPostExposureZero1, float ___remapPostExposureOne2, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeHueShift3, float ___remapHueShiftZero4, float ___remapHueShiftOne5, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeSaturation6, float ___remapSaturationZero7, float ___remapSaturationOne8, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeContrast9, float ___remapContrastZero10, float ___remapContrastOne11, int32_t ___colorFilterMode12, Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E* ___colorFilterGradient13, Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___colorFilterDestination14, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___colorFilterCurve15, float ___duration16, bool ___relativeValues17, float ___attenuation18, int32_t ___channel19, bool ___resetShakerValuesAfterShake20, bool ___resetTargetValuesAfterShake21, bool ___forwardDirection22, int32_t ___timescaleMode23, bool ___stop24, const RuntimeMethod* method)
{
	NullCheck(___shakePostExposure0);
	VirtualActionInvoker24< float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, int32_t, Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E*, Color_tD001788D726C3A7F1379BEED0260B9591F440C1F, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(il2cpp_codegen_method_get_slot(method), ___shakePostExposure0, ___remapPostExposureZero1, ___remapPostExposureOne2, ___shakeHueShift3, ___remapHueShiftZero4, ___remapHueShiftOne5, ___shakeSaturation6, ___remapSaturationZero7, ___remapSaturationOne8, ___shakeContrast9, ___remapContrastZero10, ___remapContrastOne11, ___colorFilterMode12, ___colorFilterGradient13, ___colorFilterDestination14, ___colorFilterCurve15, ___duration16, ___relativeValues17, ___attenuation18, ___channel19, ___resetShakerValuesAfterShake20, ___resetTargetValuesAfterShake21, ___forwardDirection22, ___timescaleMode23, ___stop24);
}
void Delegate_Invoke_mF4923867EB16C9EB4E8B71E48F04C5173E122D3A_OpenInterface(Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakePostExposure0, float ___remapPostExposureZero1, float ___remapPostExposureOne2, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeHueShift3, float ___remapHueShiftZero4, float ___remapHueShiftOne5, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeSaturation6, float ___remapSaturationZero7, float ___remapSaturationOne8, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeContrast9, float ___remapContrastZero10, float ___remapContrastOne11, int32_t ___colorFilterMode12, Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E* ___colorFilterGradient13, Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___colorFilterDestination14, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___colorFilterCurve15, float ___duration16, bool ___relativeValues17, float ___attenuation18, int32_t ___channel19, bool ___resetShakerValuesAfterShake20, bool ___resetTargetValuesAfterShake21, bool ___forwardDirection22, int32_t ___timescaleMode23, bool ___stop24, const RuntimeMethod* method)
{
	NullCheck(___shakePostExposure0);
	InterfaceActionInvoker24< float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, int32_t, Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E*, Color_tD001788D726C3A7F1379BEED0260B9591F440C1F, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(il2cpp_codegen_method_get_slot(method), il2cpp_codegen_method_get_declaring_type(method), ___shakePostExposure0, ___remapPostExposureZero1, ___remapPostExposureOne2, ___shakeHueShift3, ___remapHueShiftZero4, ___remapHueShiftOne5, ___shakeSaturation6, ___remapSaturationZero7, ___remapSaturationOne8, ___shakeContrast9, ___remapContrastZero10, ___remapContrastOne11, ___colorFilterMode12, ___colorFilterGradient13, ___colorFilterDestination14, ___colorFilterCurve15, ___duration16, ___relativeValues17, ___attenuation18, ___channel19, ___resetShakerValuesAfterShake20, ___resetTargetValuesAfterShake21, ___forwardDirection22, ___timescaleMode23, ___stop24);
}
void Delegate_Invoke_mF4923867EB16C9EB4E8B71E48F04C5173E122D3A_OpenGenericVirtual(Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakePostExposure0, float ___remapPostExposureZero1, float ___remapPostExposureOne2, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeHueShift3, float ___remapHueShiftZero4, float ___remapHueShiftOne5, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeSaturation6, float ___remapSaturationZero7, float ___remapSaturationOne8, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeContrast9, float ___remapContrastZero10, float ___remapContrastOne11, int32_t ___colorFilterMode12, Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E* ___colorFilterGradient13, Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___colorFilterDestination14, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___colorFilterCurve15, float ___duration16, bool ___relativeValues17, float ___attenuation18, int32_t ___channel19, bool ___resetShakerValuesAfterShake20, bool ___resetTargetValuesAfterShake21, bool ___forwardDirection22, int32_t ___timescaleMode23, bool ___stop24, const RuntimeMethod* method)
{
	NullCheck(___shakePostExposure0);
	GenericVirtualActionInvoker24< float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, int32_t, Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E*, Color_tD001788D726C3A7F1379BEED0260B9591F440C1F, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(method, ___shakePostExposure0, ___remapPostExposureZero1, ___remapPostExposureOne2, ___shakeHueShift3, ___remapHueShiftZero4, ___remapHueShiftOne5, ___shakeSaturation6, ___remapSaturationZero7, ___remapSaturationOne8, ___shakeContrast9, ___remapContrastZero10, ___remapContrastOne11, ___colorFilterMode12, ___colorFilterGradient13, ___colorFilterDestination14, ___colorFilterCurve15, ___duration16, ___relativeValues17, ___attenuation18, ___channel19, ___resetShakerValuesAfterShake20, ___resetTargetValuesAfterShake21, ___forwardDirection22, ___timescaleMode23, ___stop24);
}
void Delegate_Invoke_mF4923867EB16C9EB4E8B71E48F04C5173E122D3A_OpenGenericInterface(Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakePostExposure0, float ___remapPostExposureZero1, float ___remapPostExposureOne2, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeHueShift3, float ___remapHueShiftZero4, float ___remapHueShiftOne5, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeSaturation6, float ___remapSaturationZero7, float ___remapSaturationOne8, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeContrast9, float ___remapContrastZero10, float ___remapContrastOne11, int32_t ___colorFilterMode12, Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E* ___colorFilterGradient13, Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___colorFilterDestination14, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___colorFilterCurve15, float ___duration16, bool ___relativeValues17, float ___attenuation18, int32_t ___channel19, bool ___resetShakerValuesAfterShake20, bool ___resetTargetValuesAfterShake21, bool ___forwardDirection22, int32_t ___timescaleMode23, bool ___stop24, const RuntimeMethod* method)
{
	NullCheck(___shakePostExposure0);
	GenericInterfaceActionInvoker24< float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, int32_t, Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E*, Color_tD001788D726C3A7F1379BEED0260B9591F440C1F, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(method, ___shakePostExposure0, ___remapPostExposureZero1, ___remapPostExposureOne2, ___shakeHueShift3, ___remapHueShiftZero4, ___remapHueShiftOne5, ___shakeSaturation6, ___remapSaturationZero7, ___remapSaturationOne8, ___shakeContrast9, ___remapContrastZero10, ___remapContrastOne11, ___colorFilterMode12, ___colorFilterGradient13, ___colorFilterDestination14, ___colorFilterCurve15, ___duration16, ___relativeValues17, ___attenuation18, ___channel19, ___resetShakerValuesAfterShake20, ___resetTargetValuesAfterShake21, ___forwardDirection22, ___timescaleMode23, ___stop24);
}
IL2CPP_EXTERN_C  void DelegatePInvokeWrapper_Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19 (Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakePostExposure0, float ___remapPostExposureZero1, float ___remapPostExposureOne2, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeHueShift3, float ___remapHueShiftZero4, float ___remapHueShiftOne5, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeSaturation6, float ___remapSaturationZero7, float ___remapSaturationOne8, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeContrast9, float ___remapContrastZero10, float ___remapContrastOne11, int32_t ___colorFilterMode12, Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E* ___colorFilterGradient13, Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___colorFilterDestination14, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___colorFilterCurve15, float ___duration16, bool ___relativeValues17, float ___attenuation18, int32_t ___channel19, bool ___resetShakerValuesAfterShake20, bool ___resetTargetValuesAfterShake21, bool ___forwardDirection22, int32_t ___timescaleMode23, bool ___stop24, const RuntimeMethod* method)
{












	typedef void (DEFAULT_CALL *PInvokeFunc)(AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshaled_pinvoke*, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshaled_pinvoke*, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshaled_pinvoke*, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshaled_pinvoke*, float, float, int32_t, Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E_marshaled_pinvoke*, Color_tD001788D726C3A7F1379BEED0260B9591F440C1F, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshaled_pinvoke*, float, int32_t, float, int32_t, int32_t, int32_t, int32_t, int32_t, int32_t);
	PInvokeFunc il2cppPInvokeFunc = reinterpret_cast<PInvokeFunc>(il2cpp_codegen_get_reverse_pinvoke_function_ptr(__this));
	// Marshaling of parameter '___shakePostExposure0' to native representation
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshaled_pinvoke ____shakePostExposure0_marshaled = {};
	if (___shakePostExposure0 != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke(*___shakePostExposure0, ____shakePostExposure0_marshaled);
	}

	// Marshaling of parameter '___shakeHueShift3' to native representation
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshaled_pinvoke ____shakeHueShift3_marshaled = {};
	if (___shakeHueShift3 != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke(*___shakeHueShift3, ____shakeHueShift3_marshaled);
	}

	// Marshaling of parameter '___shakeSaturation6' to native representation
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshaled_pinvoke ____shakeSaturation6_marshaled = {};
	if (___shakeSaturation6 != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke(*___shakeSaturation6, ____shakeSaturation6_marshaled);
	}

	// Marshaling of parameter '___shakeContrast9' to native representation
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshaled_pinvoke ____shakeContrast9_marshaled = {};
	if (___shakeContrast9 != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke(*___shakeContrast9, ____shakeContrast9_marshaled);
	}

	// Marshaling of parameter '___colorFilterGradient13' to native representation
	Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E_marshaled_pinvoke ____colorFilterGradient13_marshaled = {};
	if (___colorFilterGradient13 != NULL)
	{
		Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E_marshal_pinvoke(*___colorFilterGradient13, ____colorFilterGradient13_marshaled);
	}

	// Marshaling of parameter '___colorFilterCurve15' to native representation
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshaled_pinvoke ____colorFilterCurve15_marshaled = {};
	if (___colorFilterCurve15 != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke(*___colorFilterCurve15, ____colorFilterCurve15_marshaled);
	}

	// Native function invocation
	il2cppPInvokeFunc(___shakePostExposure0 != NULL ? (&____shakePostExposure0_marshaled) : NULL, ___remapPostExposureZero1, ___remapPostExposureOne2, ___shakeHueShift3 != NULL ? (&____shakeHueShift3_marshaled) : NULL, ___remapHueShiftZero4, ___remapHueShiftOne5, ___shakeSaturation6 != NULL ? (&____shakeSaturation6_marshaled) : NULL, ___remapSaturationZero7, ___remapSaturationOne8, ___shakeContrast9 != NULL ? (&____shakeContrast9_marshaled) : NULL, ___remapContrastZero10, ___remapContrastOne11, ___colorFilterMode12, ___colorFilterGradient13 != NULL ? (&____colorFilterGradient13_marshaled) : NULL, ___colorFilterDestination14, ___colorFilterCurve15 != NULL ? (&____colorFilterCurve15_marshaled) : NULL, ___duration16, static_cast<int32_t>(___relativeValues17), ___attenuation18, ___channel19, static_cast<int32_t>(___resetShakerValuesAfterShake20), static_cast<int32_t>(___resetTargetValuesAfterShake21), static_cast<int32_t>(___forwardDirection22), ___timescaleMode23, static_cast<int32_t>(___stop24));

	// Marshaling of parameter '___shakePostExposure0' back from native representation
	if (___shakePostExposure0 != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke_back(____shakePostExposure0_marshaled, *___shakePostExposure0);
	}

	// Marshaling cleanup of parameter '___shakePostExposure0' native representation
	if ((&____shakePostExposure0_marshaled) != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke_cleanup(____shakePostExposure0_marshaled);
	}

	// Marshaling of parameter '___shakeHueShift3' back from native representation
	if (___shakeHueShift3 != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke_back(____shakeHueShift3_marshaled, *___shakeHueShift3);
	}

	// Marshaling cleanup of parameter '___shakeHueShift3' native representation
	if ((&____shakeHueShift3_marshaled) != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke_cleanup(____shakeHueShift3_marshaled);
	}

	// Marshaling of parameter '___shakeSaturation6' back from native representation
	if (___shakeSaturation6 != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke_back(____shakeSaturation6_marshaled, *___shakeSaturation6);
	}

	// Marshaling cleanup of parameter '___shakeSaturation6' native representation
	if ((&____shakeSaturation6_marshaled) != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke_cleanup(____shakeSaturation6_marshaled);
	}

	// Marshaling of parameter '___shakeContrast9' back from native representation
	if (___shakeContrast9 != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke_back(____shakeContrast9_marshaled, *___shakeContrast9);
	}

	// Marshaling cleanup of parameter '___shakeContrast9' native representation
	if ((&____shakeContrast9_marshaled) != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke_cleanup(____shakeContrast9_marshaled);
	}

	// Marshaling of parameter '___colorFilterGradient13' back from native representation
	if (___colorFilterGradient13 != NULL)
	{
		Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E_marshal_pinvoke_back(____colorFilterGradient13_marshaled, *___colorFilterGradient13);
	}

	// Marshaling cleanup of parameter '___colorFilterGradient13' native representation
	if ((&____colorFilterGradient13_marshaled) != NULL)
	{
		Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E_marshal_pinvoke_cleanup(____colorFilterGradient13_marshaled);
	}

	// Marshaling of parameter '___colorFilterCurve15' back from native representation
	if (___colorFilterCurve15 != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke_back(____colorFilterCurve15_marshaled, *___colorFilterCurve15);
	}

	// Marshaling cleanup of parameter '___colorFilterCurve15' native representation
	if ((&____colorFilterCurve15_marshaled) != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke_cleanup(____colorFilterCurve15_marshaled);
	}

}
// System.Void MoreMountains.FeedbacksForThirdParty.MMColorAdjustmentsShakeEvent_HDRP/Delegate::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Delegate__ctor_m97E65EB7302F876DE070BF69272A56B7AB94C029 (Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19* __this, RuntimeObject* ___object0, intptr_t ___method1, const RuntimeMethod* method) 
{
	__this->___method_ptr_0 = il2cpp_codegen_get_virtual_call_method_pointer((RuntimeMethod*)___method1);
	__this->___method_3 = ___method1;
	__this->___m_target_2 = ___object0;
	Il2CppCodeGenWriteBarrier((void**)(&__this->___m_target_2), (void*)___object0);
	int parameterCount = il2cpp_codegen_method_parameter_count((RuntimeMethod*)___method1);
	__this->___method_code_6 = (intptr_t)__this;
	if (MethodIsStatic((RuntimeMethod*)___method1))
	{
		bool isOpen = parameterCount == 25;
		if (il2cpp_codegen_call_method_via_invoker((RuntimeMethod*)___method1))
			if (isOpen)
				__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mF4923867EB16C9EB4E8B71E48F04C5173E122D3A_OpenStaticInvoker;
			else
				__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mF4923867EB16C9EB4E8B71E48F04C5173E122D3A_ClosedStaticInvoker;
		else
			if (isOpen)
				__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mF4923867EB16C9EB4E8B71E48F04C5173E122D3A_OpenStatic;
			else
				{
					__this->___invoke_impl_1 = (intptr_t)__this->___method_ptr_0;
					__this->___method_code_6 = (intptr_t)__this->___m_target_2;
				}
	}
	else
	{
		bool isOpen = parameterCount == 24;
		if (isOpen)
		{
			if (__this->___method_is_virtual_12)
			{
				if (il2cpp_codegen_method_is_generic_instance_method((RuntimeMethod*)___method1))
					if (il2cpp_codegen_method_is_interface_method((RuntimeMethod*)___method1))
						__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mF4923867EB16C9EB4E8B71E48F04C5173E122D3A_OpenGenericInterface;
					else
						__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mF4923867EB16C9EB4E8B71E48F04C5173E122D3A_OpenGenericVirtual;
				else
					if (il2cpp_codegen_method_is_interface_method((RuntimeMethod*)___method1))
						__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mF4923867EB16C9EB4E8B71E48F04C5173E122D3A_OpenInterface;
					else
						__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mF4923867EB16C9EB4E8B71E48F04C5173E122D3A_OpenVirtual;
			}
			else
			{
				__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mF4923867EB16C9EB4E8B71E48F04C5173E122D3A_OpenInst;
			}
		}
		else
		{
			if (___object0 == NULL)
				il2cpp_codegen_raise_exception(il2cpp_codegen_get_argument_exception(NULL, "Delegate to an instance method cannot have null 'this'."), NULL);
			__this->___invoke_impl_1 = (intptr_t)__this->___method_ptr_0;
			__this->___method_code_6 = (intptr_t)__this->___m_target_2;
		}
	}
	__this->___extra_arg_5 = (intptr_t)&Delegate_Invoke_mF4923867EB16C9EB4E8B71E48F04C5173E122D3A_Multicast;
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMColorAdjustmentsShakeEvent_HDRP/Delegate::Invoke(UnityEngine.AnimationCurve,System.Single,System.Single,UnityEngine.AnimationCurve,System.Single,System.Single,UnityEngine.AnimationCurve,System.Single,System.Single,UnityEngine.AnimationCurve,System.Single,System.Single,MoreMountains.FeedbacksForThirdParty.MMColorAdjustmentsShaker_HDRP/ColorFilterModes,UnityEngine.Gradient,UnityEngine.Color,UnityEngine.AnimationCurve,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Delegate_Invoke_mF4923867EB16C9EB4E8B71E48F04C5173E122D3A (Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakePostExposure0, float ___remapPostExposureZero1, float ___remapPostExposureOne2, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeHueShift3, float ___remapHueShiftZero4, float ___remapHueShiftOne5, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeSaturation6, float ___remapSaturationZero7, float ___remapSaturationOne8, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeContrast9, float ___remapContrastZero10, float ___remapContrastOne11, int32_t ___colorFilterMode12, Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E* ___colorFilterGradient13, Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___colorFilterDestination14, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___colorFilterCurve15, float ___duration16, bool ___relativeValues17, float ___attenuation18, int32_t ___channel19, bool ___resetShakerValuesAfterShake20, bool ___resetTargetValuesAfterShake21, bool ___forwardDirection22, int32_t ___timescaleMode23, bool ___stop24, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, int32_t, Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E*, Color_tD001788D726C3A7F1379BEED0260B9591F440C1F, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___shakePostExposure0, ___remapPostExposureZero1, ___remapPostExposureOne2, ___shakeHueShift3, ___remapHueShiftZero4, ___remapHueShiftOne5, ___shakeSaturation6, ___remapSaturationZero7, ___remapSaturationOne8, ___shakeContrast9, ___remapContrastZero10, ___remapContrastOne11, ___colorFilterMode12, ___colorFilterGradient13, ___colorFilterDestination14, ___colorFilterCurve15, ___duration16, ___relativeValues17, ___attenuation18, ___channel19, ___resetShakerValuesAfterShake20, ___resetTargetValuesAfterShake21, ___forwardDirection22, ___timescaleMode23, ___stop24, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
// System.IAsyncResult MoreMountains.FeedbacksForThirdParty.MMColorAdjustmentsShakeEvent_HDRP/Delegate::BeginInvoke(UnityEngine.AnimationCurve,System.Single,System.Single,UnityEngine.AnimationCurve,System.Single,System.Single,UnityEngine.AnimationCurve,System.Single,System.Single,UnityEngine.AnimationCurve,System.Single,System.Single,MoreMountains.FeedbacksForThirdParty.MMColorAdjustmentsShaker_HDRP/ColorFilterModes,UnityEngine.Gradient,UnityEngine.Color,UnityEngine.AnimationCurve,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean,System.AsyncCallback,System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* Delegate_BeginInvoke_m56893DFF8B5B2A766DDAE965BB45CCFEC4CA9FA2 (Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakePostExposure0, float ___remapPostExposureZero1, float ___remapPostExposureOne2, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeHueShift3, float ___remapHueShiftZero4, float ___remapHueShiftOne5, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeSaturation6, float ___remapSaturationZero7, float ___remapSaturationOne8, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeContrast9, float ___remapContrastZero10, float ___remapContrastOne11, int32_t ___colorFilterMode12, Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E* ___colorFilterGradient13, Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___colorFilterDestination14, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___colorFilterCurve15, float ___duration16, bool ___relativeValues17, float ___attenuation18, int32_t ___channel19, bool ___resetShakerValuesAfterShake20, bool ___resetTargetValuesAfterShake21, bool ___forwardDirection22, int32_t ___timescaleMode23, bool ___stop24, AsyncCallback_t7FEF460CBDCFB9C5FA2EF776984778B9A4145F4C* ___callback25, RuntimeObject* ___object26, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ColorFilterModes_t7B7A4B63C0D7B36E482FEC816A9A5B0BED8F79DA_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Color_tD001788D726C3A7F1379BEED0260B9591F440C1F_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TimescaleModes_t567213DC39EEE1AA073F8E8473E19F2B71FC9A68_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	void *__d_args[26] = {0};
	__d_args[0] = ___shakePostExposure0;
	__d_args[1] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___remapPostExposureZero1);
	__d_args[2] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___remapPostExposureOne2);
	__d_args[3] = ___shakeHueShift3;
	__d_args[4] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___remapHueShiftZero4);
	__d_args[5] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___remapHueShiftOne5);
	__d_args[6] = ___shakeSaturation6;
	__d_args[7] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___remapSaturationZero7);
	__d_args[8] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___remapSaturationOne8);
	__d_args[9] = ___shakeContrast9;
	__d_args[10] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___remapContrastZero10);
	__d_args[11] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___remapContrastOne11);
	__d_args[12] = Box(ColorFilterModes_t7B7A4B63C0D7B36E482FEC816A9A5B0BED8F79DA_il2cpp_TypeInfo_var, &___colorFilterMode12);
	__d_args[13] = ___colorFilterGradient13;
	__d_args[14] = Box(Color_tD001788D726C3A7F1379BEED0260B9591F440C1F_il2cpp_TypeInfo_var, &___colorFilterDestination14);
	__d_args[15] = ___colorFilterCurve15;
	__d_args[16] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___duration16);
	__d_args[17] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___relativeValues17);
	__d_args[18] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___attenuation18);
	__d_args[19] = Box(Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var, &___channel19);
	__d_args[20] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___resetShakerValuesAfterShake20);
	__d_args[21] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___resetTargetValuesAfterShake21);
	__d_args[22] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___forwardDirection22);
	__d_args[23] = Box(TimescaleModes_t567213DC39EEE1AA073F8E8473E19F2B71FC9A68_il2cpp_TypeInfo_var, &___timescaleMode23);
	__d_args[24] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___stop24);
	return (RuntimeObject*)il2cpp_codegen_delegate_begin_invoke((RuntimeDelegate*)__this, __d_args, (RuntimeDelegate*)___callback25, (RuntimeObject*)___object26);
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMColorAdjustmentsShakeEvent_HDRP/Delegate::EndInvoke(System.IAsyncResult)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Delegate_EndInvoke_m6221464ECAADB76F9357520957E2F1F38E3EBFCB (Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19* __this, RuntimeObject* ___result0, const RuntimeMethod* method) 
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
// System.Void MoreMountains.FeedbacksForThirdParty.MMExposureShaker_HDRP::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMExposureShaker_HDRP__ctor_mDAFF2C89AD6B5F27743917E4285955B00BAC2183 (MMExposureShaker_HDRP_t178AB71E45D967A121DFA78C5761DC7F02CC94BD* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public AnimationCurve ShakeFixedExposure = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
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
		__this->___ShakeFixedExposure_21 = L_7;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ShakeFixedExposure_21), (void*)L_7);
		// public float RemapFixedExposureZero = 8.5f;
		__this->___RemapFixedExposureZero_22 = (8.5f);
		// public float RemapFixedExposureOne = 6f;
		__this->___RemapFixedExposureOne_23 = (6.0f);
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
// System.Void MoreMountains.FeedbacksForThirdParty.MMExposureShakeEvent_HDRP::add_OnEvent(MoreMountains.FeedbacksForThirdParty.MMExposureShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMExposureShakeEvent_HDRP_add_OnEvent_mA396F83872851E4C98D4979DB69DA5871A3AF03B (Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0* ___value0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMExposureShakeEvent_HDRP_t429034491DB8574CF83B64B4D3052EF37D8AE226_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0* V_0 = NULL;
	Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0* V_1 = NULL;
	Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0* V_2 = NULL;
	{
		Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0* L_0 = ((MMExposureShakeEvent_HDRP_t429034491DB8574CF83B64B4D3052EF37D8AE226_StaticFields*)il2cpp_codegen_static_fields_for(MMExposureShakeEvent_HDRP_t429034491DB8574CF83B64B4D3052EF37D8AE226_il2cpp_TypeInfo_var))->___OnEvent_0;
		V_0 = L_0;
	}

IL_0006:
	{
		Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0* L_1 = V_0;
		V_1 = L_1;
		Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0* L_2 = V_1;
		Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0* L_3 = ___value0;
		Delegate_t* L_4;
		L_4 = Delegate_Combine_m1F725AEF318BE6F0426863490691A6F4606E7D00(L_2, L_3, NULL);
		V_2 = ((Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0*)CastclassSealed((RuntimeObject*)L_4, Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0_il2cpp_TypeInfo_var));
		Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0* L_5 = V_2;
		Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0* L_6 = V_1;
		Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0* L_7;
		L_7 = InterlockedCompareExchangeImpl<Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0*>((&((MMExposureShakeEvent_HDRP_t429034491DB8574CF83B64B4D3052EF37D8AE226_StaticFields*)il2cpp_codegen_static_fields_for(MMExposureShakeEvent_HDRP_t429034491DB8574CF83B64B4D3052EF37D8AE226_il2cpp_TypeInfo_var))->___OnEvent_0), L_5, L_6);
		V_0 = L_7;
		Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0* L_8 = V_0;
		Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0* L_9 = V_1;
		if ((!(((RuntimeObject*)(Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0*)L_8) == ((RuntimeObject*)(Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0*)L_9))))
		{
			goto IL_0006;
		}
	}
	{
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMExposureShakeEvent_HDRP::remove_OnEvent(MoreMountains.FeedbacksForThirdParty.MMExposureShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMExposureShakeEvent_HDRP_remove_OnEvent_m2437F0ED157BD98B104D7279467B576072CB9EA3 (Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0* ___value0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMExposureShakeEvent_HDRP_t429034491DB8574CF83B64B4D3052EF37D8AE226_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0* V_0 = NULL;
	Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0* V_1 = NULL;
	Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0* V_2 = NULL;
	{
		Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0* L_0 = ((MMExposureShakeEvent_HDRP_t429034491DB8574CF83B64B4D3052EF37D8AE226_StaticFields*)il2cpp_codegen_static_fields_for(MMExposureShakeEvent_HDRP_t429034491DB8574CF83B64B4D3052EF37D8AE226_il2cpp_TypeInfo_var))->___OnEvent_0;
		V_0 = L_0;
	}

IL_0006:
	{
		Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0* L_1 = V_0;
		V_1 = L_1;
		Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0* L_2 = V_1;
		Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0* L_3 = ___value0;
		Delegate_t* L_4;
		L_4 = Delegate_Remove_m8B7DD5661308FA972E23CA1CC3FC9CEB355504E3(L_2, L_3, NULL);
		V_2 = ((Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0*)CastclassSealed((RuntimeObject*)L_4, Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0_il2cpp_TypeInfo_var));
		Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0* L_5 = V_2;
		Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0* L_6 = V_1;
		Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0* L_7;
		L_7 = InterlockedCompareExchangeImpl<Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0*>((&((MMExposureShakeEvent_HDRP_t429034491DB8574CF83B64B4D3052EF37D8AE226_StaticFields*)il2cpp_codegen_static_fields_for(MMExposureShakeEvent_HDRP_t429034491DB8574CF83B64B4D3052EF37D8AE226_il2cpp_TypeInfo_var))->___OnEvent_0), L_5, L_6);
		V_0 = L_7;
		Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0* L_8 = V_0;
		Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0* L_9 = V_1;
		if ((!(((RuntimeObject*)(Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0*)L_8) == ((RuntimeObject*)(Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0*)L_9))))
		{
			goto IL_0006;
		}
	}
	{
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMExposureShakeEvent_HDRP::Register(MoreMountains.FeedbacksForThirdParty.MMExposureShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMExposureShakeEvent_HDRP_Register_m095F0685C3C3948E071AD26D069D70801B10B793 (Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0* ___callback0, const RuntimeMethod* method) 
{
	{
		// OnEvent += callback;
		Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0* L_0 = ___callback0;
		MMExposureShakeEvent_HDRP_add_OnEvent_mA396F83872851E4C98D4979DB69DA5871A3AF03B(L_0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMExposureShakeEvent_HDRP::Unregister(MoreMountains.FeedbacksForThirdParty.MMExposureShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMExposureShakeEvent_HDRP_Unregister_m85204E9581497D305F0C76CBD71FDED46A465311 (Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0* ___callback0, const RuntimeMethod* method) 
{
	{
		// OnEvent -= callback;
		Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0* L_0 = ___callback0;
		MMExposureShakeEvent_HDRP_remove_OnEvent_m2437F0ED157BD98B104D7279467B576072CB9EA3(L_0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMExposureShakeEvent_HDRP::Trigger(UnityEngine.AnimationCurve,System.Single,System.Single,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMExposureShakeEvent_HDRP_Trigger_m1896AC3294CC9A9ECAC33EBE25DD0E9FD7E816A6 (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___fixedExposure0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeFixedExposure4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMExposureShakeEvent_HDRP_t429034491DB8574CF83B64B4D3052EF37D8AE226_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0* G_B2_0 = NULL;
	Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0* G_B1_0 = NULL;
	{
		// OnEvent?.Invoke(fixedExposure, duration, remapMin, remapMax, relativeFixedExposure, attenuation, channel, resetShakerValuesAfterShake, resetTargetValuesAfterShake, forwardDirection, timescaleMode, stop);
		Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0* L_0 = ((MMExposureShakeEvent_HDRP_t429034491DB8574CF83B64B4D3052EF37D8AE226_StaticFields*)il2cpp_codegen_static_fields_for(MMExposureShakeEvent_HDRP_t429034491DB8574CF83B64B4D3052EF37D8AE226_il2cpp_TypeInfo_var))->___OnEvent_0;
		Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0* L_1 = L_0;
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
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_2 = ___fixedExposure0;
		float L_3 = ___duration1;
		float L_4 = ___remapMin2;
		float L_5 = ___remapMax3;
		bool L_6 = ___relativeFixedExposure4;
		float L_7 = ___attenuation5;
		int32_t L_8 = ___channel6;
		bool L_9 = ___resetShakerValuesAfterShake7;
		bool L_10 = ___resetTargetValuesAfterShake8;
		bool L_11 = ___forwardDirection9;
		int32_t L_12 = ___timescaleMode10;
		bool L_13 = ___stop11;
		NullCheck(G_B2_0);
		Delegate_Invoke_mB3B6C56776FE0B118D170C735745148F1F55D1E8_inline(G_B2_0, L_2, L_3, L_4, L_5, L_6, L_7, L_8, L_9, L_10, L_11, L_12, L_13, NULL);
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
void Delegate_Invoke_mB3B6C56776FE0B118D170C735745148F1F55D1E8_Multicast(Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___fixedExposure0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeFixedExposure4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	il2cpp_array_size_t length = __this->___delegates_13->max_length;
	Delegate_t** delegatesToInvoke = reinterpret_cast<Delegate_t**>(__this->___delegates_13->GetAddressAtUnchecked(0));
	for (il2cpp_array_size_t i = 0; i < length; i++)
	{
		Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0* currentDelegate = reinterpret_cast<Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0*>(delegatesToInvoke[i]);
		typedef void (*FunctionPointerType) (RuntimeObject*, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
		((FunctionPointerType)currentDelegate->___invoke_impl_1)((Il2CppObject*)currentDelegate->___method_code_6, ___fixedExposure0, ___duration1, ___remapMin2, ___remapMax3, ___relativeFixedExposure4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11, reinterpret_cast<RuntimeMethod*>(currentDelegate->___method_3));
	}
}
void Delegate_Invoke_mB3B6C56776FE0B118D170C735745148F1F55D1E8_OpenInst(Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___fixedExposure0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeFixedExposure4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	NullCheck(___fixedExposure0);
	typedef void (*FunctionPointerType) (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___method_ptr_0)(___fixedExposure0, ___duration1, ___remapMin2, ___remapMax3, ___relativeFixedExposure4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11, method);
}
void Delegate_Invoke_mB3B6C56776FE0B118D170C735745148F1F55D1E8_OpenStatic(Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___fixedExposure0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeFixedExposure4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	typedef void (*FunctionPointerType) (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___method_ptr_0)(___fixedExposure0, ___duration1, ___remapMin2, ___remapMax3, ___relativeFixedExposure4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11, method);
}
void Delegate_Invoke_mB3B6C56776FE0B118D170C735745148F1F55D1E8_OpenStaticInvoker(Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___fixedExposure0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeFixedExposure4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	InvokerActionInvoker12< AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(__this->___method_ptr_0, method, NULL, ___fixedExposure0, ___duration1, ___remapMin2, ___remapMax3, ___relativeFixedExposure4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11);
}
void Delegate_Invoke_mB3B6C56776FE0B118D170C735745148F1F55D1E8_ClosedStaticInvoker(Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___fixedExposure0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeFixedExposure4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	InvokerActionInvoker13< RuntimeObject*, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(__this->___method_ptr_0, method, NULL, __this->___m_target_2, ___fixedExposure0, ___duration1, ___remapMin2, ___remapMax3, ___relativeFixedExposure4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11);
}
void Delegate_Invoke_mB3B6C56776FE0B118D170C735745148F1F55D1E8_OpenVirtual(Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___fixedExposure0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeFixedExposure4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	NullCheck(___fixedExposure0);
	VirtualActionInvoker11< float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(il2cpp_codegen_method_get_slot(method), ___fixedExposure0, ___duration1, ___remapMin2, ___remapMax3, ___relativeFixedExposure4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11);
}
void Delegate_Invoke_mB3B6C56776FE0B118D170C735745148F1F55D1E8_OpenInterface(Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___fixedExposure0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeFixedExposure4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	NullCheck(___fixedExposure0);
	InterfaceActionInvoker11< float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(il2cpp_codegen_method_get_slot(method), il2cpp_codegen_method_get_declaring_type(method), ___fixedExposure0, ___duration1, ___remapMin2, ___remapMax3, ___relativeFixedExposure4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11);
}
void Delegate_Invoke_mB3B6C56776FE0B118D170C735745148F1F55D1E8_OpenGenericVirtual(Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___fixedExposure0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeFixedExposure4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	NullCheck(___fixedExposure0);
	GenericVirtualActionInvoker11< float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(method, ___fixedExposure0, ___duration1, ___remapMin2, ___remapMax3, ___relativeFixedExposure4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11);
}
void Delegate_Invoke_mB3B6C56776FE0B118D170C735745148F1F55D1E8_OpenGenericInterface(Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___fixedExposure0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeFixedExposure4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	NullCheck(___fixedExposure0);
	GenericInterfaceActionInvoker11< float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(method, ___fixedExposure0, ___duration1, ___remapMin2, ___remapMax3, ___relativeFixedExposure4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11);
}
IL2CPP_EXTERN_C  void DelegatePInvokeWrapper_Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0 (Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___fixedExposure0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeFixedExposure4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{


	typedef void (DEFAULT_CALL *PInvokeFunc)(AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshaled_pinvoke*, float, float, float, int32_t, float, int32_t, int32_t, int32_t, int32_t, int32_t, int32_t);
	PInvokeFunc il2cppPInvokeFunc = reinterpret_cast<PInvokeFunc>(il2cpp_codegen_get_reverse_pinvoke_function_ptr(__this));
	// Marshaling of parameter '___fixedExposure0' to native representation
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshaled_pinvoke ____fixedExposure0_marshaled = {};
	if (___fixedExposure0 != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke(*___fixedExposure0, ____fixedExposure0_marshaled);
	}

	// Native function invocation
	il2cppPInvokeFunc(___fixedExposure0 != NULL ? (&____fixedExposure0_marshaled) : NULL, ___duration1, ___remapMin2, ___remapMax3, static_cast<int32_t>(___relativeFixedExposure4), ___attenuation5, ___channel6, static_cast<int32_t>(___resetShakerValuesAfterShake7), static_cast<int32_t>(___resetTargetValuesAfterShake8), static_cast<int32_t>(___forwardDirection9), ___timescaleMode10, static_cast<int32_t>(___stop11));

	// Marshaling of parameter '___fixedExposure0' back from native representation
	if (___fixedExposure0 != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke_back(____fixedExposure0_marshaled, *___fixedExposure0);
	}

	// Marshaling cleanup of parameter '___fixedExposure0' native representation
	if ((&____fixedExposure0_marshaled) != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke_cleanup(____fixedExposure0_marshaled);
	}

}
// System.Void MoreMountains.FeedbacksForThirdParty.MMExposureShakeEvent_HDRP/Delegate::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Delegate__ctor_mB3AEE2D117D36F83EFD510581427C3EBFDBBEA1E (Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0* __this, RuntimeObject* ___object0, intptr_t ___method1, const RuntimeMethod* method) 
{
	__this->___method_ptr_0 = il2cpp_codegen_get_virtual_call_method_pointer((RuntimeMethod*)___method1);
	__this->___method_3 = ___method1;
	__this->___m_target_2 = ___object0;
	Il2CppCodeGenWriteBarrier((void**)(&__this->___m_target_2), (void*)___object0);
	int parameterCount = il2cpp_codegen_method_parameter_count((RuntimeMethod*)___method1);
	__this->___method_code_6 = (intptr_t)__this;
	if (MethodIsStatic((RuntimeMethod*)___method1))
	{
		bool isOpen = parameterCount == 12;
		if (il2cpp_codegen_call_method_via_invoker((RuntimeMethod*)___method1))
			if (isOpen)
				__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mB3B6C56776FE0B118D170C735745148F1F55D1E8_OpenStaticInvoker;
			else
				__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mB3B6C56776FE0B118D170C735745148F1F55D1E8_ClosedStaticInvoker;
		else
			if (isOpen)
				__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mB3B6C56776FE0B118D170C735745148F1F55D1E8_OpenStatic;
			else
				{
					__this->___invoke_impl_1 = (intptr_t)__this->___method_ptr_0;
					__this->___method_code_6 = (intptr_t)__this->___m_target_2;
				}
	}
	else
	{
		bool isOpen = parameterCount == 11;
		if (isOpen)
		{
			if (__this->___method_is_virtual_12)
			{
				if (il2cpp_codegen_method_is_generic_instance_method((RuntimeMethod*)___method1))
					if (il2cpp_codegen_method_is_interface_method((RuntimeMethod*)___method1))
						__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mB3B6C56776FE0B118D170C735745148F1F55D1E8_OpenGenericInterface;
					else
						__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mB3B6C56776FE0B118D170C735745148F1F55D1E8_OpenGenericVirtual;
				else
					if (il2cpp_codegen_method_is_interface_method((RuntimeMethod*)___method1))
						__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mB3B6C56776FE0B118D170C735745148F1F55D1E8_OpenInterface;
					else
						__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mB3B6C56776FE0B118D170C735745148F1F55D1E8_OpenVirtual;
			}
			else
			{
				__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mB3B6C56776FE0B118D170C735745148F1F55D1E8_OpenInst;
			}
		}
		else
		{
			if (___object0 == NULL)
				il2cpp_codegen_raise_exception(il2cpp_codegen_get_argument_exception(NULL, "Delegate to an instance method cannot have null 'this'."), NULL);
			__this->___invoke_impl_1 = (intptr_t)__this->___method_ptr_0;
			__this->___method_code_6 = (intptr_t)__this->___m_target_2;
		}
	}
	__this->___extra_arg_5 = (intptr_t)&Delegate_Invoke_mB3B6C56776FE0B118D170C735745148F1F55D1E8_Multicast;
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMExposureShakeEvent_HDRP/Delegate::Invoke(UnityEngine.AnimationCurve,System.Single,System.Single,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Delegate_Invoke_mB3B6C56776FE0B118D170C735745148F1F55D1E8 (Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___fixedExposure0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeFixedExposure4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___fixedExposure0, ___duration1, ___remapMin2, ___remapMax3, ___relativeFixedExposure4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
// System.IAsyncResult MoreMountains.FeedbacksForThirdParty.MMExposureShakeEvent_HDRP/Delegate::BeginInvoke(UnityEngine.AnimationCurve,System.Single,System.Single,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean,System.AsyncCallback,System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* Delegate_BeginInvoke_mB37E3C720D30E6739DA279AC8293A0B85CBEBC7C (Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___fixedExposure0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeFixedExposure4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, AsyncCallback_t7FEF460CBDCFB9C5FA2EF776984778B9A4145F4C* ___callback12, RuntimeObject* ___object13, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TimescaleModes_t567213DC39EEE1AA073F8E8473E19F2B71FC9A68_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	void *__d_args[13] = {0};
	__d_args[0] = ___fixedExposure0;
	__d_args[1] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___duration1);
	__d_args[2] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___remapMin2);
	__d_args[3] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___remapMax3);
	__d_args[4] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___relativeFixedExposure4);
	__d_args[5] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___attenuation5);
	__d_args[6] = Box(Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var, &___channel6);
	__d_args[7] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___resetShakerValuesAfterShake7);
	__d_args[8] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___resetTargetValuesAfterShake8);
	__d_args[9] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___forwardDirection9);
	__d_args[10] = Box(TimescaleModes_t567213DC39EEE1AA073F8E8473E19F2B71FC9A68_il2cpp_TypeInfo_var, &___timescaleMode10);
	__d_args[11] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___stop11);
	return (RuntimeObject*)il2cpp_codegen_delegate_begin_invoke((RuntimeDelegate*)__this, __d_args, (RuntimeDelegate*)___callback12, (RuntimeObject*)___object13);
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMExposureShakeEvent_HDRP/Delegate::EndInvoke(System.IAsyncResult)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Delegate_EndInvoke_m1306C4D1902F45B5E8A245B78B93F50B85F23094 (Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0* __this, RuntimeObject* ___result0, const RuntimeMethod* method) 
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
// System.Void MoreMountains.FeedbacksForThirdParty.MMFilmGrainShaker_HDRP::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFilmGrainShaker_HDRP__ctor_m7F165ABB45ED5B5953B594801BBC364BB4B353BC (MMFilmGrainShaker_HDRP_t642417F8C9001ECE6687F790C023D752011D9BC9* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public AnimationCurve ShakeIntensity = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
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
		__this->___ShakeIntensity_21 = L_7;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ShakeIntensity_21), (void*)L_7);
		// public float RemapIntensityOne = 1f;
		__this->___RemapIntensityOne_23 = (1.0f);
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
// System.Void MoreMountains.FeedbacksForThirdParty.MMFilmGrainShakeEvent_HDRP::add_OnEvent(MoreMountains.FeedbacksForThirdParty.MMFilmGrainShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFilmGrainShakeEvent_HDRP_add_OnEvent_mAADB23B251FEA84CA61F5FB4BEB2385DE7F0F507 (Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15* ___value0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMFilmGrainShakeEvent_HDRP_t6EE5990F0D1EFCAA1EEE776CFE548DA66CB1D52B_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15* V_0 = NULL;
	Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15* V_1 = NULL;
	Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15* V_2 = NULL;
	{
		Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15* L_0 = ((MMFilmGrainShakeEvent_HDRP_t6EE5990F0D1EFCAA1EEE776CFE548DA66CB1D52B_StaticFields*)il2cpp_codegen_static_fields_for(MMFilmGrainShakeEvent_HDRP_t6EE5990F0D1EFCAA1EEE776CFE548DA66CB1D52B_il2cpp_TypeInfo_var))->___OnEvent_0;
		V_0 = L_0;
	}

IL_0006:
	{
		Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15* L_1 = V_0;
		V_1 = L_1;
		Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15* L_2 = V_1;
		Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15* L_3 = ___value0;
		Delegate_t* L_4;
		L_4 = Delegate_Combine_m1F725AEF318BE6F0426863490691A6F4606E7D00(L_2, L_3, NULL);
		V_2 = ((Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15*)CastclassSealed((RuntimeObject*)L_4, Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15_il2cpp_TypeInfo_var));
		Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15* L_5 = V_2;
		Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15* L_6 = V_1;
		Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15* L_7;
		L_7 = InterlockedCompareExchangeImpl<Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15*>((&((MMFilmGrainShakeEvent_HDRP_t6EE5990F0D1EFCAA1EEE776CFE548DA66CB1D52B_StaticFields*)il2cpp_codegen_static_fields_for(MMFilmGrainShakeEvent_HDRP_t6EE5990F0D1EFCAA1EEE776CFE548DA66CB1D52B_il2cpp_TypeInfo_var))->___OnEvent_0), L_5, L_6);
		V_0 = L_7;
		Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15* L_8 = V_0;
		Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15* L_9 = V_1;
		if ((!(((RuntimeObject*)(Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15*)L_8) == ((RuntimeObject*)(Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15*)L_9))))
		{
			goto IL_0006;
		}
	}
	{
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFilmGrainShakeEvent_HDRP::remove_OnEvent(MoreMountains.FeedbacksForThirdParty.MMFilmGrainShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFilmGrainShakeEvent_HDRP_remove_OnEvent_mA677E16C938DEB6380C0F737358347A8EB7C15A0 (Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15* ___value0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMFilmGrainShakeEvent_HDRP_t6EE5990F0D1EFCAA1EEE776CFE548DA66CB1D52B_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15* V_0 = NULL;
	Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15* V_1 = NULL;
	Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15* V_2 = NULL;
	{
		Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15* L_0 = ((MMFilmGrainShakeEvent_HDRP_t6EE5990F0D1EFCAA1EEE776CFE548DA66CB1D52B_StaticFields*)il2cpp_codegen_static_fields_for(MMFilmGrainShakeEvent_HDRP_t6EE5990F0D1EFCAA1EEE776CFE548DA66CB1D52B_il2cpp_TypeInfo_var))->___OnEvent_0;
		V_0 = L_0;
	}

IL_0006:
	{
		Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15* L_1 = V_0;
		V_1 = L_1;
		Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15* L_2 = V_1;
		Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15* L_3 = ___value0;
		Delegate_t* L_4;
		L_4 = Delegate_Remove_m8B7DD5661308FA972E23CA1CC3FC9CEB355504E3(L_2, L_3, NULL);
		V_2 = ((Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15*)CastclassSealed((RuntimeObject*)L_4, Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15_il2cpp_TypeInfo_var));
		Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15* L_5 = V_2;
		Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15* L_6 = V_1;
		Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15* L_7;
		L_7 = InterlockedCompareExchangeImpl<Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15*>((&((MMFilmGrainShakeEvent_HDRP_t6EE5990F0D1EFCAA1EEE776CFE548DA66CB1D52B_StaticFields*)il2cpp_codegen_static_fields_for(MMFilmGrainShakeEvent_HDRP_t6EE5990F0D1EFCAA1EEE776CFE548DA66CB1D52B_il2cpp_TypeInfo_var))->___OnEvent_0), L_5, L_6);
		V_0 = L_7;
		Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15* L_8 = V_0;
		Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15* L_9 = V_1;
		if ((!(((RuntimeObject*)(Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15*)L_8) == ((RuntimeObject*)(Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15*)L_9))))
		{
			goto IL_0006;
		}
	}
	{
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFilmGrainShakeEvent_HDRP::Register(MoreMountains.FeedbacksForThirdParty.MMFilmGrainShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFilmGrainShakeEvent_HDRP_Register_mF31CF12A8F9861963D813797D4DFC9C34D2863E0 (Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15* ___callback0, const RuntimeMethod* method) 
{
	{
		// OnEvent += callback;
		Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15* L_0 = ___callback0;
		MMFilmGrainShakeEvent_HDRP_add_OnEvent_mAADB23B251FEA84CA61F5FB4BEB2385DE7F0F507(L_0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFilmGrainShakeEvent_HDRP::Unregister(MoreMountains.FeedbacksForThirdParty.MMFilmGrainShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFilmGrainShakeEvent_HDRP_Unregister_mBE719C06AD3B28CD18FEAB8A85C5CCC4A9370384 (Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15* ___callback0, const RuntimeMethod* method) 
{
	{
		// OnEvent -= callback;
		Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15* L_0 = ___callback0;
		MMFilmGrainShakeEvent_HDRP_remove_OnEvent_mA677E16C938DEB6380C0F737358347A8EB7C15A0(L_0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFilmGrainShakeEvent_HDRP::Trigger(UnityEngine.AnimationCurve,System.Single,System.Single,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMFilmGrainShakeEvent_HDRP_Trigger_mE93E1C6A7C883DD107BBDFDFAA8D8FDC6090D147 (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMFilmGrainShakeEvent_HDRP_t6EE5990F0D1EFCAA1EEE776CFE548DA66CB1D52B_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15* G_B2_0 = NULL;
	Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15* G_B1_0 = NULL;
	{
		// OnEvent?.Invoke(intensity, duration, remapMin, remapMax, relativeIntensity, attenuation, channel, resetShakerValuesAfterShake, resetTargetValuesAfterShake, forwardDirection, timescaleMode, stop);
		Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15* L_0 = ((MMFilmGrainShakeEvent_HDRP_t6EE5990F0D1EFCAA1EEE776CFE548DA66CB1D52B_StaticFields*)il2cpp_codegen_static_fields_for(MMFilmGrainShakeEvent_HDRP_t6EE5990F0D1EFCAA1EEE776CFE548DA66CB1D52B_il2cpp_TypeInfo_var))->___OnEvent_0;
		Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15* L_1 = L_0;
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
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_2 = ___intensity0;
		float L_3 = ___duration1;
		float L_4 = ___remapMin2;
		float L_5 = ___remapMax3;
		bool L_6 = ___relativeIntensity4;
		float L_7 = ___attenuation5;
		int32_t L_8 = ___channel6;
		bool L_9 = ___resetShakerValuesAfterShake7;
		bool L_10 = ___resetTargetValuesAfterShake8;
		bool L_11 = ___forwardDirection9;
		int32_t L_12 = ___timescaleMode10;
		bool L_13 = ___stop11;
		NullCheck(G_B2_0);
		Delegate_Invoke_mA4BC5FEA6FD70F9E70251A4AC32D5E91CD5D0ED3_inline(G_B2_0, L_2, L_3, L_4, L_5, L_6, L_7, L_8, L_9, L_10, L_11, L_12, L_13, NULL);
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
void Delegate_Invoke_mA4BC5FEA6FD70F9E70251A4AC32D5E91CD5D0ED3_Multicast(Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	il2cpp_array_size_t length = __this->___delegates_13->max_length;
	Delegate_t** delegatesToInvoke = reinterpret_cast<Delegate_t**>(__this->___delegates_13->GetAddressAtUnchecked(0));
	for (il2cpp_array_size_t i = 0; i < length; i++)
	{
		Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15* currentDelegate = reinterpret_cast<Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15*>(delegatesToInvoke[i]);
		typedef void (*FunctionPointerType) (RuntimeObject*, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
		((FunctionPointerType)currentDelegate->___invoke_impl_1)((Il2CppObject*)currentDelegate->___method_code_6, ___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11, reinterpret_cast<RuntimeMethod*>(currentDelegate->___method_3));
	}
}
void Delegate_Invoke_mA4BC5FEA6FD70F9E70251A4AC32D5E91CD5D0ED3_OpenInst(Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	NullCheck(___intensity0);
	typedef void (*FunctionPointerType) (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___method_ptr_0)(___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11, method);
}
void Delegate_Invoke_mA4BC5FEA6FD70F9E70251A4AC32D5E91CD5D0ED3_OpenStatic(Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	typedef void (*FunctionPointerType) (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___method_ptr_0)(___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11, method);
}
void Delegate_Invoke_mA4BC5FEA6FD70F9E70251A4AC32D5E91CD5D0ED3_OpenStaticInvoker(Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	InvokerActionInvoker12< AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(__this->___method_ptr_0, method, NULL, ___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11);
}
void Delegate_Invoke_mA4BC5FEA6FD70F9E70251A4AC32D5E91CD5D0ED3_ClosedStaticInvoker(Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	InvokerActionInvoker13< RuntimeObject*, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(__this->___method_ptr_0, method, NULL, __this->___m_target_2, ___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11);
}
void Delegate_Invoke_mA4BC5FEA6FD70F9E70251A4AC32D5E91CD5D0ED3_OpenVirtual(Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	NullCheck(___intensity0);
	VirtualActionInvoker11< float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(il2cpp_codegen_method_get_slot(method), ___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11);
}
void Delegate_Invoke_mA4BC5FEA6FD70F9E70251A4AC32D5E91CD5D0ED3_OpenInterface(Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	NullCheck(___intensity0);
	InterfaceActionInvoker11< float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(il2cpp_codegen_method_get_slot(method), il2cpp_codegen_method_get_declaring_type(method), ___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11);
}
void Delegate_Invoke_mA4BC5FEA6FD70F9E70251A4AC32D5E91CD5D0ED3_OpenGenericVirtual(Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	NullCheck(___intensity0);
	GenericVirtualActionInvoker11< float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(method, ___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11);
}
void Delegate_Invoke_mA4BC5FEA6FD70F9E70251A4AC32D5E91CD5D0ED3_OpenGenericInterface(Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	NullCheck(___intensity0);
	GenericInterfaceActionInvoker11< float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(method, ___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11);
}
IL2CPP_EXTERN_C  void DelegatePInvokeWrapper_Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15 (Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{


	typedef void (DEFAULT_CALL *PInvokeFunc)(AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshaled_pinvoke*, float, float, float, int32_t, float, int32_t, int32_t, int32_t, int32_t, int32_t, int32_t);
	PInvokeFunc il2cppPInvokeFunc = reinterpret_cast<PInvokeFunc>(il2cpp_codegen_get_reverse_pinvoke_function_ptr(__this));
	// Marshaling of parameter '___intensity0' to native representation
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshaled_pinvoke ____intensity0_marshaled = {};
	if (___intensity0 != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke(*___intensity0, ____intensity0_marshaled);
	}

	// Native function invocation
	il2cppPInvokeFunc(___intensity0 != NULL ? (&____intensity0_marshaled) : NULL, ___duration1, ___remapMin2, ___remapMax3, static_cast<int32_t>(___relativeIntensity4), ___attenuation5, ___channel6, static_cast<int32_t>(___resetShakerValuesAfterShake7), static_cast<int32_t>(___resetTargetValuesAfterShake8), static_cast<int32_t>(___forwardDirection9), ___timescaleMode10, static_cast<int32_t>(___stop11));

	// Marshaling of parameter '___intensity0' back from native representation
	if (___intensity0 != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke_back(____intensity0_marshaled, *___intensity0);
	}

	// Marshaling cleanup of parameter '___intensity0' native representation
	if ((&____intensity0_marshaled) != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke_cleanup(____intensity0_marshaled);
	}

}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFilmGrainShakeEvent_HDRP/Delegate::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Delegate__ctor_m5B1B9C36B9A4466589F524885F6EB4BA76D7306A (Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15* __this, RuntimeObject* ___object0, intptr_t ___method1, const RuntimeMethod* method) 
{
	__this->___method_ptr_0 = il2cpp_codegen_get_virtual_call_method_pointer((RuntimeMethod*)___method1);
	__this->___method_3 = ___method1;
	__this->___m_target_2 = ___object0;
	Il2CppCodeGenWriteBarrier((void**)(&__this->___m_target_2), (void*)___object0);
	int parameterCount = il2cpp_codegen_method_parameter_count((RuntimeMethod*)___method1);
	__this->___method_code_6 = (intptr_t)__this;
	if (MethodIsStatic((RuntimeMethod*)___method1))
	{
		bool isOpen = parameterCount == 12;
		if (il2cpp_codegen_call_method_via_invoker((RuntimeMethod*)___method1))
			if (isOpen)
				__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mA4BC5FEA6FD70F9E70251A4AC32D5E91CD5D0ED3_OpenStaticInvoker;
			else
				__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mA4BC5FEA6FD70F9E70251A4AC32D5E91CD5D0ED3_ClosedStaticInvoker;
		else
			if (isOpen)
				__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mA4BC5FEA6FD70F9E70251A4AC32D5E91CD5D0ED3_OpenStatic;
			else
				{
					__this->___invoke_impl_1 = (intptr_t)__this->___method_ptr_0;
					__this->___method_code_6 = (intptr_t)__this->___m_target_2;
				}
	}
	else
	{
		bool isOpen = parameterCount == 11;
		if (isOpen)
		{
			if (__this->___method_is_virtual_12)
			{
				if (il2cpp_codegen_method_is_generic_instance_method((RuntimeMethod*)___method1))
					if (il2cpp_codegen_method_is_interface_method((RuntimeMethod*)___method1))
						__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mA4BC5FEA6FD70F9E70251A4AC32D5E91CD5D0ED3_OpenGenericInterface;
					else
						__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mA4BC5FEA6FD70F9E70251A4AC32D5E91CD5D0ED3_OpenGenericVirtual;
				else
					if (il2cpp_codegen_method_is_interface_method((RuntimeMethod*)___method1))
						__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mA4BC5FEA6FD70F9E70251A4AC32D5E91CD5D0ED3_OpenInterface;
					else
						__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mA4BC5FEA6FD70F9E70251A4AC32D5E91CD5D0ED3_OpenVirtual;
			}
			else
			{
				__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mA4BC5FEA6FD70F9E70251A4AC32D5E91CD5D0ED3_OpenInst;
			}
		}
		else
		{
			if (___object0 == NULL)
				il2cpp_codegen_raise_exception(il2cpp_codegen_get_argument_exception(NULL, "Delegate to an instance method cannot have null 'this'."), NULL);
			__this->___invoke_impl_1 = (intptr_t)__this->___method_ptr_0;
			__this->___method_code_6 = (intptr_t)__this->___m_target_2;
		}
	}
	__this->___extra_arg_5 = (intptr_t)&Delegate_Invoke_mA4BC5FEA6FD70F9E70251A4AC32D5E91CD5D0ED3_Multicast;
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFilmGrainShakeEvent_HDRP/Delegate::Invoke(UnityEngine.AnimationCurve,System.Single,System.Single,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Delegate_Invoke_mA4BC5FEA6FD70F9E70251A4AC32D5E91CD5D0ED3 (Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
// System.IAsyncResult MoreMountains.FeedbacksForThirdParty.MMFilmGrainShakeEvent_HDRP/Delegate::BeginInvoke(UnityEngine.AnimationCurve,System.Single,System.Single,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean,System.AsyncCallback,System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* Delegate_BeginInvoke_m9210F988BF39A7D8403F94C7802B4048B0F13D39 (Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, AsyncCallback_t7FEF460CBDCFB9C5FA2EF776984778B9A4145F4C* ___callback12, RuntimeObject* ___object13, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TimescaleModes_t567213DC39EEE1AA073F8E8473E19F2B71FC9A68_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	void *__d_args[13] = {0};
	__d_args[0] = ___intensity0;
	__d_args[1] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___duration1);
	__d_args[2] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___remapMin2);
	__d_args[3] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___remapMax3);
	__d_args[4] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___relativeIntensity4);
	__d_args[5] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___attenuation5);
	__d_args[6] = Box(Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var, &___channel6);
	__d_args[7] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___resetShakerValuesAfterShake7);
	__d_args[8] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___resetTargetValuesAfterShake8);
	__d_args[9] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___forwardDirection9);
	__d_args[10] = Box(TimescaleModes_t567213DC39EEE1AA073F8E8473E19F2B71FC9A68_il2cpp_TypeInfo_var, &___timescaleMode10);
	__d_args[11] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___stop11);
	return (RuntimeObject*)il2cpp_codegen_delegate_begin_invoke((RuntimeDelegate*)__this, __d_args, (RuntimeDelegate*)___callback12, (RuntimeObject*)___object13);
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMFilmGrainShakeEvent_HDRP/Delegate::EndInvoke(System.IAsyncResult)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Delegate_EndInvoke_m57CC293197FD12921FBB17A51FF906D6B7D50B4A (Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15* __this, RuntimeObject* ___result0, const RuntimeMethod* method) 
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
// System.Void MoreMountains.FeedbacksForThirdParty.MMLensDistortionShaker_HDRP::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMLensDistortionShaker_HDRP__ctor_m8A8B30A4416DC0DF3EE9A53D0A3A985E45E1BAF3 (MMLensDistortionShaker_HDRP_t0B49054863BD3B0C6DEBFDCD95FD027FC66E31A4* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public AnimationCurve ShakeIntensity = new AnimationCurve(new Keyframe(0, 0),
		//     new Keyframe(0.2f, 1),
		//     new Keyframe(0.25f, -1),
		//     new Keyframe(0.35f, 0.7f),
		//     new Keyframe(0.4f, -0.7f),
		//     new Keyframe(0.6f, 0.3f),
		//     new Keyframe(0.65f, -0.3f),
		//     new Keyframe(0.8f, 0.1f),
		//     new Keyframe(0.85f, -0.1f),
		//     new Keyframe(1, 0));
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_0 = (KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3*)(KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3*)SZArrayNew(KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var, (uint32_t)((int32_t)10));
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_1 = L_0;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_2;
		memset((&L_2), 0, sizeof(L_2));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_2), (0.0f), (0.0f), /*hidden argument*/NULL);
		NullCheck(L_1);
		(L_1)->SetAt(static_cast<il2cpp_array_size_t>(0), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_2);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_3 = L_1;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_4;
		memset((&L_4), 0, sizeof(L_4));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_4), (0.200000003f), (1.0f), /*hidden argument*/NULL);
		NullCheck(L_3);
		(L_3)->SetAt(static_cast<il2cpp_array_size_t>(1), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_4);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_5 = L_3;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_6;
		memset((&L_6), 0, sizeof(L_6));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_6), (0.25f), (-1.0f), /*hidden argument*/NULL);
		NullCheck(L_5);
		(L_5)->SetAt(static_cast<il2cpp_array_size_t>(2), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_6);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_7 = L_5;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_8;
		memset((&L_8), 0, sizeof(L_8));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_8), (0.349999994f), (0.699999988f), /*hidden argument*/NULL);
		NullCheck(L_7);
		(L_7)->SetAt(static_cast<il2cpp_array_size_t>(3), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_8);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_9 = L_7;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_10;
		memset((&L_10), 0, sizeof(L_10));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_10), (0.400000006f), (-0.699999988f), /*hidden argument*/NULL);
		NullCheck(L_9);
		(L_9)->SetAt(static_cast<il2cpp_array_size_t>(4), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_10);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_11 = L_9;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_12;
		memset((&L_12), 0, sizeof(L_12));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_12), (0.600000024f), (0.300000012f), /*hidden argument*/NULL);
		NullCheck(L_11);
		(L_11)->SetAt(static_cast<il2cpp_array_size_t>(5), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_12);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_13 = L_11;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_14;
		memset((&L_14), 0, sizeof(L_14));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_14), (0.649999976f), (-0.300000012f), /*hidden argument*/NULL);
		NullCheck(L_13);
		(L_13)->SetAt(static_cast<il2cpp_array_size_t>(6), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_14);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_15 = L_13;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_16;
		memset((&L_16), 0, sizeof(L_16));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_16), (0.800000012f), (0.100000001f), /*hidden argument*/NULL);
		NullCheck(L_15);
		(L_15)->SetAt(static_cast<il2cpp_array_size_t>(7), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_16);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_17 = L_15;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_18;
		memset((&L_18), 0, sizeof(L_18));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_18), (0.850000024f), (-0.100000001f), /*hidden argument*/NULL);
		NullCheck(L_17);
		(L_17)->SetAt(static_cast<il2cpp_array_size_t>(8), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_18);
		KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3* L_19 = L_17;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 L_20;
		memset((&L_20), 0, sizeof(L_20));
		Keyframe__ctor_mECF144086B28785BE911A22C06194A9E0FBF3C34((&L_20), (1.0f), (0.0f), /*hidden argument*/NULL);
		NullCheck(L_19);
		(L_19)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)9)), (Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0)L_20);
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_21 = (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*)il2cpp_codegen_object_new(AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		NullCheck(L_21);
		AnimationCurve__ctor_mEABC98C03805713354D61E50D9340766BD5B717E(L_21, L_19, NULL);
		__this->___ShakeIntensity_21 = L_21;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ShakeIntensity_21), (void*)L_21);
		// public float RemapIntensityOne = 0.5f;
		__this->___RemapIntensityOne_23 = (0.5f);
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
// System.Void MoreMountains.FeedbacksForThirdParty.MMLensDistortionShakeEvent_HDRP::add_OnEvent(MoreMountains.FeedbacksForThirdParty.MMLensDistortionShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMLensDistortionShakeEvent_HDRP_add_OnEvent_m5659AB86CAA44AA21940C4D9388C8654ECAAB464 (Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994* ___value0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMLensDistortionShakeEvent_HDRP_tB04E28FAD0419A5DD447624B6D4171E4660134C6_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994* V_0 = NULL;
	Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994* V_1 = NULL;
	Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994* V_2 = NULL;
	{
		Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994* L_0 = ((MMLensDistortionShakeEvent_HDRP_tB04E28FAD0419A5DD447624B6D4171E4660134C6_StaticFields*)il2cpp_codegen_static_fields_for(MMLensDistortionShakeEvent_HDRP_tB04E28FAD0419A5DD447624B6D4171E4660134C6_il2cpp_TypeInfo_var))->___OnEvent_0;
		V_0 = L_0;
	}

IL_0006:
	{
		Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994* L_1 = V_0;
		V_1 = L_1;
		Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994* L_2 = V_1;
		Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994* L_3 = ___value0;
		Delegate_t* L_4;
		L_4 = Delegate_Combine_m1F725AEF318BE6F0426863490691A6F4606E7D00(L_2, L_3, NULL);
		V_2 = ((Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994*)CastclassSealed((RuntimeObject*)L_4, Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994_il2cpp_TypeInfo_var));
		Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994* L_5 = V_2;
		Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994* L_6 = V_1;
		Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994* L_7;
		L_7 = InterlockedCompareExchangeImpl<Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994*>((&((MMLensDistortionShakeEvent_HDRP_tB04E28FAD0419A5DD447624B6D4171E4660134C6_StaticFields*)il2cpp_codegen_static_fields_for(MMLensDistortionShakeEvent_HDRP_tB04E28FAD0419A5DD447624B6D4171E4660134C6_il2cpp_TypeInfo_var))->___OnEvent_0), L_5, L_6);
		V_0 = L_7;
		Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994* L_8 = V_0;
		Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994* L_9 = V_1;
		if ((!(((RuntimeObject*)(Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994*)L_8) == ((RuntimeObject*)(Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994*)L_9))))
		{
			goto IL_0006;
		}
	}
	{
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMLensDistortionShakeEvent_HDRP::remove_OnEvent(MoreMountains.FeedbacksForThirdParty.MMLensDistortionShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMLensDistortionShakeEvent_HDRP_remove_OnEvent_mD8296A9B3F361FA3CC53A486795BF188100EF1C4 (Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994* ___value0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMLensDistortionShakeEvent_HDRP_tB04E28FAD0419A5DD447624B6D4171E4660134C6_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994* V_0 = NULL;
	Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994* V_1 = NULL;
	Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994* V_2 = NULL;
	{
		Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994* L_0 = ((MMLensDistortionShakeEvent_HDRP_tB04E28FAD0419A5DD447624B6D4171E4660134C6_StaticFields*)il2cpp_codegen_static_fields_for(MMLensDistortionShakeEvent_HDRP_tB04E28FAD0419A5DD447624B6D4171E4660134C6_il2cpp_TypeInfo_var))->___OnEvent_0;
		V_0 = L_0;
	}

IL_0006:
	{
		Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994* L_1 = V_0;
		V_1 = L_1;
		Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994* L_2 = V_1;
		Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994* L_3 = ___value0;
		Delegate_t* L_4;
		L_4 = Delegate_Remove_m8B7DD5661308FA972E23CA1CC3FC9CEB355504E3(L_2, L_3, NULL);
		V_2 = ((Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994*)CastclassSealed((RuntimeObject*)L_4, Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994_il2cpp_TypeInfo_var));
		Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994* L_5 = V_2;
		Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994* L_6 = V_1;
		Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994* L_7;
		L_7 = InterlockedCompareExchangeImpl<Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994*>((&((MMLensDistortionShakeEvent_HDRP_tB04E28FAD0419A5DD447624B6D4171E4660134C6_StaticFields*)il2cpp_codegen_static_fields_for(MMLensDistortionShakeEvent_HDRP_tB04E28FAD0419A5DD447624B6D4171E4660134C6_il2cpp_TypeInfo_var))->___OnEvent_0), L_5, L_6);
		V_0 = L_7;
		Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994* L_8 = V_0;
		Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994* L_9 = V_1;
		if ((!(((RuntimeObject*)(Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994*)L_8) == ((RuntimeObject*)(Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994*)L_9))))
		{
			goto IL_0006;
		}
	}
	{
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMLensDistortionShakeEvent_HDRP::Register(MoreMountains.FeedbacksForThirdParty.MMLensDistortionShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMLensDistortionShakeEvent_HDRP_Register_m33D05D97AC6C25281B2AEC5DEAB499DA0192FC16 (Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994* ___callback0, const RuntimeMethod* method) 
{
	{
		// OnEvent += callback;
		Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994* L_0 = ___callback0;
		MMLensDistortionShakeEvent_HDRP_add_OnEvent_m5659AB86CAA44AA21940C4D9388C8654ECAAB464(L_0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMLensDistortionShakeEvent_HDRP::Unregister(MoreMountains.FeedbacksForThirdParty.MMLensDistortionShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMLensDistortionShakeEvent_HDRP_Unregister_mD7E6DC9E5EBB62CF2A3F741F36022CDF20FCF5F1 (Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994* ___callback0, const RuntimeMethod* method) 
{
	{
		// OnEvent -= callback;
		Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994* L_0 = ___callback0;
		MMLensDistortionShakeEvent_HDRP_remove_OnEvent_mD8296A9B3F361FA3CC53A486795BF188100EF1C4(L_0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMLensDistortionShakeEvent_HDRP::Trigger(UnityEngine.AnimationCurve,System.Single,System.Single,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMLensDistortionShakeEvent_HDRP_Trigger_mDACE6D0F2A1411F1F1D8914EF04250023C3065BC (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMLensDistortionShakeEvent_HDRP_tB04E28FAD0419A5DD447624B6D4171E4660134C6_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994* G_B2_0 = NULL;
	Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994* G_B1_0 = NULL;
	{
		// OnEvent?.Invoke(intensity, duration, remapMin, remapMax, relativeIntensity, attenuation, channel, resetShakerValuesAfterShake, resetTargetValuesAfterShake, forwardDirection, timescaleMode, stop);
		Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994* L_0 = ((MMLensDistortionShakeEvent_HDRP_tB04E28FAD0419A5DD447624B6D4171E4660134C6_StaticFields*)il2cpp_codegen_static_fields_for(MMLensDistortionShakeEvent_HDRP_tB04E28FAD0419A5DD447624B6D4171E4660134C6_il2cpp_TypeInfo_var))->___OnEvent_0;
		Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994* L_1 = L_0;
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
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_2 = ___intensity0;
		float L_3 = ___duration1;
		float L_4 = ___remapMin2;
		float L_5 = ___remapMax3;
		bool L_6 = ___relativeIntensity4;
		float L_7 = ___attenuation5;
		int32_t L_8 = ___channel6;
		bool L_9 = ___resetShakerValuesAfterShake7;
		bool L_10 = ___resetTargetValuesAfterShake8;
		bool L_11 = ___forwardDirection9;
		int32_t L_12 = ___timescaleMode10;
		bool L_13 = ___stop11;
		NullCheck(G_B2_0);
		Delegate_Invoke_mDA47912E1B3F9FE408E601FA5C1227E138AEABAD_inline(G_B2_0, L_2, L_3, L_4, L_5, L_6, L_7, L_8, L_9, L_10, L_11, L_12, L_13, NULL);
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
void Delegate_Invoke_mDA47912E1B3F9FE408E601FA5C1227E138AEABAD_Multicast(Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	il2cpp_array_size_t length = __this->___delegates_13->max_length;
	Delegate_t** delegatesToInvoke = reinterpret_cast<Delegate_t**>(__this->___delegates_13->GetAddressAtUnchecked(0));
	for (il2cpp_array_size_t i = 0; i < length; i++)
	{
		Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994* currentDelegate = reinterpret_cast<Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994*>(delegatesToInvoke[i]);
		typedef void (*FunctionPointerType) (RuntimeObject*, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
		((FunctionPointerType)currentDelegate->___invoke_impl_1)((Il2CppObject*)currentDelegate->___method_code_6, ___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11, reinterpret_cast<RuntimeMethod*>(currentDelegate->___method_3));
	}
}
void Delegate_Invoke_mDA47912E1B3F9FE408E601FA5C1227E138AEABAD_OpenInst(Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	NullCheck(___intensity0);
	typedef void (*FunctionPointerType) (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___method_ptr_0)(___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11, method);
}
void Delegate_Invoke_mDA47912E1B3F9FE408E601FA5C1227E138AEABAD_OpenStatic(Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	typedef void (*FunctionPointerType) (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___method_ptr_0)(___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11, method);
}
void Delegate_Invoke_mDA47912E1B3F9FE408E601FA5C1227E138AEABAD_OpenStaticInvoker(Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	InvokerActionInvoker12< AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(__this->___method_ptr_0, method, NULL, ___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11);
}
void Delegate_Invoke_mDA47912E1B3F9FE408E601FA5C1227E138AEABAD_ClosedStaticInvoker(Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	InvokerActionInvoker13< RuntimeObject*, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(__this->___method_ptr_0, method, NULL, __this->___m_target_2, ___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11);
}
void Delegate_Invoke_mDA47912E1B3F9FE408E601FA5C1227E138AEABAD_OpenVirtual(Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	NullCheck(___intensity0);
	VirtualActionInvoker11< float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(il2cpp_codegen_method_get_slot(method), ___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11);
}
void Delegate_Invoke_mDA47912E1B3F9FE408E601FA5C1227E138AEABAD_OpenInterface(Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	NullCheck(___intensity0);
	InterfaceActionInvoker11< float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(il2cpp_codegen_method_get_slot(method), il2cpp_codegen_method_get_declaring_type(method), ___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11);
}
void Delegate_Invoke_mDA47912E1B3F9FE408E601FA5C1227E138AEABAD_OpenGenericVirtual(Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	NullCheck(___intensity0);
	GenericVirtualActionInvoker11< float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(method, ___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11);
}
void Delegate_Invoke_mDA47912E1B3F9FE408E601FA5C1227E138AEABAD_OpenGenericInterface(Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	NullCheck(___intensity0);
	GenericInterfaceActionInvoker11< float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(method, ___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11);
}
IL2CPP_EXTERN_C  void DelegatePInvokeWrapper_Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994 (Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{


	typedef void (DEFAULT_CALL *PInvokeFunc)(AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshaled_pinvoke*, float, float, float, int32_t, float, int32_t, int32_t, int32_t, int32_t, int32_t, int32_t);
	PInvokeFunc il2cppPInvokeFunc = reinterpret_cast<PInvokeFunc>(il2cpp_codegen_get_reverse_pinvoke_function_ptr(__this));
	// Marshaling of parameter '___intensity0' to native representation
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshaled_pinvoke ____intensity0_marshaled = {};
	if (___intensity0 != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke(*___intensity0, ____intensity0_marshaled);
	}

	// Native function invocation
	il2cppPInvokeFunc(___intensity0 != NULL ? (&____intensity0_marshaled) : NULL, ___duration1, ___remapMin2, ___remapMax3, static_cast<int32_t>(___relativeIntensity4), ___attenuation5, ___channel6, static_cast<int32_t>(___resetShakerValuesAfterShake7), static_cast<int32_t>(___resetTargetValuesAfterShake8), static_cast<int32_t>(___forwardDirection9), ___timescaleMode10, static_cast<int32_t>(___stop11));

	// Marshaling of parameter '___intensity0' back from native representation
	if (___intensity0 != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke_back(____intensity0_marshaled, *___intensity0);
	}

	// Marshaling cleanup of parameter '___intensity0' native representation
	if ((&____intensity0_marshaled) != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke_cleanup(____intensity0_marshaled);
	}

}
// System.Void MoreMountains.FeedbacksForThirdParty.MMLensDistortionShakeEvent_HDRP/Delegate::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Delegate__ctor_mC101A020A82846B960F4251679689CC0599DE240 (Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994* __this, RuntimeObject* ___object0, intptr_t ___method1, const RuntimeMethod* method) 
{
	__this->___method_ptr_0 = il2cpp_codegen_get_virtual_call_method_pointer((RuntimeMethod*)___method1);
	__this->___method_3 = ___method1;
	__this->___m_target_2 = ___object0;
	Il2CppCodeGenWriteBarrier((void**)(&__this->___m_target_2), (void*)___object0);
	int parameterCount = il2cpp_codegen_method_parameter_count((RuntimeMethod*)___method1);
	__this->___method_code_6 = (intptr_t)__this;
	if (MethodIsStatic((RuntimeMethod*)___method1))
	{
		bool isOpen = parameterCount == 12;
		if (il2cpp_codegen_call_method_via_invoker((RuntimeMethod*)___method1))
			if (isOpen)
				__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mDA47912E1B3F9FE408E601FA5C1227E138AEABAD_OpenStaticInvoker;
			else
				__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mDA47912E1B3F9FE408E601FA5C1227E138AEABAD_ClosedStaticInvoker;
		else
			if (isOpen)
				__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mDA47912E1B3F9FE408E601FA5C1227E138AEABAD_OpenStatic;
			else
				{
					__this->___invoke_impl_1 = (intptr_t)__this->___method_ptr_0;
					__this->___method_code_6 = (intptr_t)__this->___m_target_2;
				}
	}
	else
	{
		bool isOpen = parameterCount == 11;
		if (isOpen)
		{
			if (__this->___method_is_virtual_12)
			{
				if (il2cpp_codegen_method_is_generic_instance_method((RuntimeMethod*)___method1))
					if (il2cpp_codegen_method_is_interface_method((RuntimeMethod*)___method1))
						__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mDA47912E1B3F9FE408E601FA5C1227E138AEABAD_OpenGenericInterface;
					else
						__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mDA47912E1B3F9FE408E601FA5C1227E138AEABAD_OpenGenericVirtual;
				else
					if (il2cpp_codegen_method_is_interface_method((RuntimeMethod*)___method1))
						__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mDA47912E1B3F9FE408E601FA5C1227E138AEABAD_OpenInterface;
					else
						__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mDA47912E1B3F9FE408E601FA5C1227E138AEABAD_OpenVirtual;
			}
			else
			{
				__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mDA47912E1B3F9FE408E601FA5C1227E138AEABAD_OpenInst;
			}
		}
		else
		{
			if (___object0 == NULL)
				il2cpp_codegen_raise_exception(il2cpp_codegen_get_argument_exception(NULL, "Delegate to an instance method cannot have null 'this'."), NULL);
			__this->___invoke_impl_1 = (intptr_t)__this->___method_ptr_0;
			__this->___method_code_6 = (intptr_t)__this->___m_target_2;
		}
	}
	__this->___extra_arg_5 = (intptr_t)&Delegate_Invoke_mDA47912E1B3F9FE408E601FA5C1227E138AEABAD_Multicast;
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMLensDistortionShakeEvent_HDRP/Delegate::Invoke(UnityEngine.AnimationCurve,System.Single,System.Single,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Delegate_Invoke_mDA47912E1B3F9FE408E601FA5C1227E138AEABAD (Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
// System.IAsyncResult MoreMountains.FeedbacksForThirdParty.MMLensDistortionShakeEvent_HDRP/Delegate::BeginInvoke(UnityEngine.AnimationCurve,System.Single,System.Single,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean,System.AsyncCallback,System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* Delegate_BeginInvoke_m1CEE87D8A3898D6C86514A4041F68350019BDD86 (Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, AsyncCallback_t7FEF460CBDCFB9C5FA2EF776984778B9A4145F4C* ___callback12, RuntimeObject* ___object13, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TimescaleModes_t567213DC39EEE1AA073F8E8473E19F2B71FC9A68_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	void *__d_args[13] = {0};
	__d_args[0] = ___intensity0;
	__d_args[1] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___duration1);
	__d_args[2] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___remapMin2);
	__d_args[3] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___remapMax3);
	__d_args[4] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___relativeIntensity4);
	__d_args[5] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___attenuation5);
	__d_args[6] = Box(Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var, &___channel6);
	__d_args[7] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___resetShakerValuesAfterShake7);
	__d_args[8] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___resetTargetValuesAfterShake8);
	__d_args[9] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___forwardDirection9);
	__d_args[10] = Box(TimescaleModes_t567213DC39EEE1AA073F8E8473E19F2B71FC9A68_il2cpp_TypeInfo_var, &___timescaleMode10);
	__d_args[11] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___stop11);
	return (RuntimeObject*)il2cpp_codegen_delegate_begin_invoke((RuntimeDelegate*)__this, __d_args, (RuntimeDelegate*)___callback12, (RuntimeObject*)___object13);
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMLensDistortionShakeEvent_HDRP/Delegate::EndInvoke(System.IAsyncResult)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Delegate_EndInvoke_m8B5E565F7BA384494BB0C5E0FBA75A58215B1E2B (Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994* __this, RuntimeObject* ___result0, const RuntimeMethod* method) 
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
// System.Void MoreMountains.FeedbacksForThirdParty.MMMotionBlurShaker_HDRP::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMMotionBlurShaker_HDRP__ctor_mCCDEC97A809C016DCE3C1D7E5ADEDE9BD2E92AC9 (MMMotionBlurShaker_HDRP_t2143D5FAF199B1BF22C56DC7A080A2A0BA6AEC3A* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public AnimationCurve ShakeIntensity = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
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
		__this->___ShakeIntensity_21 = L_7;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ShakeIntensity_21), (void*)L_7);
		// public float RemapIntensityOne = 1000f;
		__this->___RemapIntensityOne_23 = (1000.0f);
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
// System.Void MoreMountains.FeedbacksForThirdParty.MMMotionBlurShakeEvent_HDRP::add_OnEvent(MoreMountains.FeedbacksForThirdParty.MMMotionBlurShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMMotionBlurShakeEvent_HDRP_add_OnEvent_m2B55597C397FF978CFC7D73923DC247A8E24B312 (Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8* ___value0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMMotionBlurShakeEvent_HDRP_tA8E616DFF1071517A558A6C7CA356B15F8CFC3F9_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8* V_0 = NULL;
	Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8* V_1 = NULL;
	Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8* V_2 = NULL;
	{
		Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8* L_0 = ((MMMotionBlurShakeEvent_HDRP_tA8E616DFF1071517A558A6C7CA356B15F8CFC3F9_StaticFields*)il2cpp_codegen_static_fields_for(MMMotionBlurShakeEvent_HDRP_tA8E616DFF1071517A558A6C7CA356B15F8CFC3F9_il2cpp_TypeInfo_var))->___OnEvent_0;
		V_0 = L_0;
	}

IL_0006:
	{
		Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8* L_1 = V_0;
		V_1 = L_1;
		Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8* L_2 = V_1;
		Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8* L_3 = ___value0;
		Delegate_t* L_4;
		L_4 = Delegate_Combine_m1F725AEF318BE6F0426863490691A6F4606E7D00(L_2, L_3, NULL);
		V_2 = ((Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8*)CastclassSealed((RuntimeObject*)L_4, Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8_il2cpp_TypeInfo_var));
		Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8* L_5 = V_2;
		Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8* L_6 = V_1;
		Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8* L_7;
		L_7 = InterlockedCompareExchangeImpl<Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8*>((&((MMMotionBlurShakeEvent_HDRP_tA8E616DFF1071517A558A6C7CA356B15F8CFC3F9_StaticFields*)il2cpp_codegen_static_fields_for(MMMotionBlurShakeEvent_HDRP_tA8E616DFF1071517A558A6C7CA356B15F8CFC3F9_il2cpp_TypeInfo_var))->___OnEvent_0), L_5, L_6);
		V_0 = L_7;
		Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8* L_8 = V_0;
		Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8* L_9 = V_1;
		if ((!(((RuntimeObject*)(Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8*)L_8) == ((RuntimeObject*)(Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8*)L_9))))
		{
			goto IL_0006;
		}
	}
	{
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMMotionBlurShakeEvent_HDRP::remove_OnEvent(MoreMountains.FeedbacksForThirdParty.MMMotionBlurShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMMotionBlurShakeEvent_HDRP_remove_OnEvent_m8D97E1F5258AE3BB04715EA773F43BF08A8D99E0 (Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8* ___value0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMMotionBlurShakeEvent_HDRP_tA8E616DFF1071517A558A6C7CA356B15F8CFC3F9_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8* V_0 = NULL;
	Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8* V_1 = NULL;
	Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8* V_2 = NULL;
	{
		Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8* L_0 = ((MMMotionBlurShakeEvent_HDRP_tA8E616DFF1071517A558A6C7CA356B15F8CFC3F9_StaticFields*)il2cpp_codegen_static_fields_for(MMMotionBlurShakeEvent_HDRP_tA8E616DFF1071517A558A6C7CA356B15F8CFC3F9_il2cpp_TypeInfo_var))->___OnEvent_0;
		V_0 = L_0;
	}

IL_0006:
	{
		Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8* L_1 = V_0;
		V_1 = L_1;
		Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8* L_2 = V_1;
		Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8* L_3 = ___value0;
		Delegate_t* L_4;
		L_4 = Delegate_Remove_m8B7DD5661308FA972E23CA1CC3FC9CEB355504E3(L_2, L_3, NULL);
		V_2 = ((Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8*)CastclassSealed((RuntimeObject*)L_4, Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8_il2cpp_TypeInfo_var));
		Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8* L_5 = V_2;
		Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8* L_6 = V_1;
		Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8* L_7;
		L_7 = InterlockedCompareExchangeImpl<Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8*>((&((MMMotionBlurShakeEvent_HDRP_tA8E616DFF1071517A558A6C7CA356B15F8CFC3F9_StaticFields*)il2cpp_codegen_static_fields_for(MMMotionBlurShakeEvent_HDRP_tA8E616DFF1071517A558A6C7CA356B15F8CFC3F9_il2cpp_TypeInfo_var))->___OnEvent_0), L_5, L_6);
		V_0 = L_7;
		Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8* L_8 = V_0;
		Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8* L_9 = V_1;
		if ((!(((RuntimeObject*)(Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8*)L_8) == ((RuntimeObject*)(Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8*)L_9))))
		{
			goto IL_0006;
		}
	}
	{
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMMotionBlurShakeEvent_HDRP::Register(MoreMountains.FeedbacksForThirdParty.MMMotionBlurShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMMotionBlurShakeEvent_HDRP_Register_mA23E3D89FD6A75BA569BD7EFC19769E69AA93C75 (Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8* ___callback0, const RuntimeMethod* method) 
{
	{
		// OnEvent += callback;
		Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8* L_0 = ___callback0;
		MMMotionBlurShakeEvent_HDRP_add_OnEvent_m2B55597C397FF978CFC7D73923DC247A8E24B312(L_0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMMotionBlurShakeEvent_HDRP::Unregister(MoreMountains.FeedbacksForThirdParty.MMMotionBlurShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMMotionBlurShakeEvent_HDRP_Unregister_mBE39F717313B2DF14425FB85789E9D86699E3435 (Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8* ___callback0, const RuntimeMethod* method) 
{
	{
		// OnEvent -= callback;
		Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8* L_0 = ___callback0;
		MMMotionBlurShakeEvent_HDRP_remove_OnEvent_m8D97E1F5258AE3BB04715EA773F43BF08A8D99E0(L_0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMMotionBlurShakeEvent_HDRP::Trigger(UnityEngine.AnimationCurve,System.Single,System.Single,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMMotionBlurShakeEvent_HDRP_Trigger_m91FD70589D40180513688CF1469168B97995EE6C (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMMotionBlurShakeEvent_HDRP_tA8E616DFF1071517A558A6C7CA356B15F8CFC3F9_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8* G_B2_0 = NULL;
	Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8* G_B1_0 = NULL;
	{
		// OnEvent?.Invoke(intensity, duration, remapMin, remapMax, relativeIntensity, attenuation, channel, resetShakerValuesAfterShake, resetTargetValuesAfterShake, forwardDirection, timescaleMode, stop);
		Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8* L_0 = ((MMMotionBlurShakeEvent_HDRP_tA8E616DFF1071517A558A6C7CA356B15F8CFC3F9_StaticFields*)il2cpp_codegen_static_fields_for(MMMotionBlurShakeEvent_HDRP_tA8E616DFF1071517A558A6C7CA356B15F8CFC3F9_il2cpp_TypeInfo_var))->___OnEvent_0;
		Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8* L_1 = L_0;
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
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_2 = ___intensity0;
		float L_3 = ___duration1;
		float L_4 = ___remapMin2;
		float L_5 = ___remapMax3;
		bool L_6 = ___relativeIntensity4;
		float L_7 = ___attenuation5;
		int32_t L_8 = ___channel6;
		bool L_9 = ___resetShakerValuesAfterShake7;
		bool L_10 = ___resetTargetValuesAfterShake8;
		bool L_11 = ___forwardDirection9;
		int32_t L_12 = ___timescaleMode10;
		bool L_13 = ___stop11;
		NullCheck(G_B2_0);
		Delegate_Invoke_mDC19B891E8784D90FDB7B09764639E93850BC2EA_inline(G_B2_0, L_2, L_3, L_4, L_5, L_6, L_7, L_8, L_9, L_10, L_11, L_12, L_13, NULL);
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
void Delegate_Invoke_mDC19B891E8784D90FDB7B09764639E93850BC2EA_Multicast(Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	il2cpp_array_size_t length = __this->___delegates_13->max_length;
	Delegate_t** delegatesToInvoke = reinterpret_cast<Delegate_t**>(__this->___delegates_13->GetAddressAtUnchecked(0));
	for (il2cpp_array_size_t i = 0; i < length; i++)
	{
		Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8* currentDelegate = reinterpret_cast<Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8*>(delegatesToInvoke[i]);
		typedef void (*FunctionPointerType) (RuntimeObject*, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
		((FunctionPointerType)currentDelegate->___invoke_impl_1)((Il2CppObject*)currentDelegate->___method_code_6, ___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11, reinterpret_cast<RuntimeMethod*>(currentDelegate->___method_3));
	}
}
void Delegate_Invoke_mDC19B891E8784D90FDB7B09764639E93850BC2EA_OpenInst(Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	NullCheck(___intensity0);
	typedef void (*FunctionPointerType) (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___method_ptr_0)(___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11, method);
}
void Delegate_Invoke_mDC19B891E8784D90FDB7B09764639E93850BC2EA_OpenStatic(Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	typedef void (*FunctionPointerType) (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___method_ptr_0)(___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11, method);
}
void Delegate_Invoke_mDC19B891E8784D90FDB7B09764639E93850BC2EA_OpenStaticInvoker(Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	InvokerActionInvoker12< AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(__this->___method_ptr_0, method, NULL, ___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11);
}
void Delegate_Invoke_mDC19B891E8784D90FDB7B09764639E93850BC2EA_ClosedStaticInvoker(Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	InvokerActionInvoker13< RuntimeObject*, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(__this->___method_ptr_0, method, NULL, __this->___m_target_2, ___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11);
}
void Delegate_Invoke_mDC19B891E8784D90FDB7B09764639E93850BC2EA_OpenVirtual(Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	NullCheck(___intensity0);
	VirtualActionInvoker11< float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(il2cpp_codegen_method_get_slot(method), ___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11);
}
void Delegate_Invoke_mDC19B891E8784D90FDB7B09764639E93850BC2EA_OpenInterface(Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	NullCheck(___intensity0);
	InterfaceActionInvoker11< float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(il2cpp_codegen_method_get_slot(method), il2cpp_codegen_method_get_declaring_type(method), ___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11);
}
void Delegate_Invoke_mDC19B891E8784D90FDB7B09764639E93850BC2EA_OpenGenericVirtual(Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	NullCheck(___intensity0);
	GenericVirtualActionInvoker11< float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(method, ___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11);
}
void Delegate_Invoke_mDC19B891E8784D90FDB7B09764639E93850BC2EA_OpenGenericInterface(Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	NullCheck(___intensity0);
	GenericInterfaceActionInvoker11< float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(method, ___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11);
}
IL2CPP_EXTERN_C  void DelegatePInvokeWrapper_Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8 (Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{


	typedef void (DEFAULT_CALL *PInvokeFunc)(AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshaled_pinvoke*, float, float, float, int32_t, float, int32_t, int32_t, int32_t, int32_t, int32_t, int32_t);
	PInvokeFunc il2cppPInvokeFunc = reinterpret_cast<PInvokeFunc>(il2cpp_codegen_get_reverse_pinvoke_function_ptr(__this));
	// Marshaling of parameter '___intensity0' to native representation
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshaled_pinvoke ____intensity0_marshaled = {};
	if (___intensity0 != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke(*___intensity0, ____intensity0_marshaled);
	}

	// Native function invocation
	il2cppPInvokeFunc(___intensity0 != NULL ? (&____intensity0_marshaled) : NULL, ___duration1, ___remapMin2, ___remapMax3, static_cast<int32_t>(___relativeIntensity4), ___attenuation5, ___channel6, static_cast<int32_t>(___resetShakerValuesAfterShake7), static_cast<int32_t>(___resetTargetValuesAfterShake8), static_cast<int32_t>(___forwardDirection9), ___timescaleMode10, static_cast<int32_t>(___stop11));

	// Marshaling of parameter '___intensity0' back from native representation
	if (___intensity0 != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke_back(____intensity0_marshaled, *___intensity0);
	}

	// Marshaling cleanup of parameter '___intensity0' native representation
	if ((&____intensity0_marshaled) != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke_cleanup(____intensity0_marshaled);
	}

}
// System.Void MoreMountains.FeedbacksForThirdParty.MMMotionBlurShakeEvent_HDRP/Delegate::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Delegate__ctor_m0259C5B0B96F2D474BAE78A57494210F0D90A42F (Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8* __this, RuntimeObject* ___object0, intptr_t ___method1, const RuntimeMethod* method) 
{
	__this->___method_ptr_0 = il2cpp_codegen_get_virtual_call_method_pointer((RuntimeMethod*)___method1);
	__this->___method_3 = ___method1;
	__this->___m_target_2 = ___object0;
	Il2CppCodeGenWriteBarrier((void**)(&__this->___m_target_2), (void*)___object0);
	int parameterCount = il2cpp_codegen_method_parameter_count((RuntimeMethod*)___method1);
	__this->___method_code_6 = (intptr_t)__this;
	if (MethodIsStatic((RuntimeMethod*)___method1))
	{
		bool isOpen = parameterCount == 12;
		if (il2cpp_codegen_call_method_via_invoker((RuntimeMethod*)___method1))
			if (isOpen)
				__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mDC19B891E8784D90FDB7B09764639E93850BC2EA_OpenStaticInvoker;
			else
				__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mDC19B891E8784D90FDB7B09764639E93850BC2EA_ClosedStaticInvoker;
		else
			if (isOpen)
				__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mDC19B891E8784D90FDB7B09764639E93850BC2EA_OpenStatic;
			else
				{
					__this->___invoke_impl_1 = (intptr_t)__this->___method_ptr_0;
					__this->___method_code_6 = (intptr_t)__this->___m_target_2;
				}
	}
	else
	{
		bool isOpen = parameterCount == 11;
		if (isOpen)
		{
			if (__this->___method_is_virtual_12)
			{
				if (il2cpp_codegen_method_is_generic_instance_method((RuntimeMethod*)___method1))
					if (il2cpp_codegen_method_is_interface_method((RuntimeMethod*)___method1))
						__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mDC19B891E8784D90FDB7B09764639E93850BC2EA_OpenGenericInterface;
					else
						__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mDC19B891E8784D90FDB7B09764639E93850BC2EA_OpenGenericVirtual;
				else
					if (il2cpp_codegen_method_is_interface_method((RuntimeMethod*)___method1))
						__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mDC19B891E8784D90FDB7B09764639E93850BC2EA_OpenInterface;
					else
						__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mDC19B891E8784D90FDB7B09764639E93850BC2EA_OpenVirtual;
			}
			else
			{
				__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mDC19B891E8784D90FDB7B09764639E93850BC2EA_OpenInst;
			}
		}
		else
		{
			if (___object0 == NULL)
				il2cpp_codegen_raise_exception(il2cpp_codegen_get_argument_exception(NULL, "Delegate to an instance method cannot have null 'this'."), NULL);
			__this->___invoke_impl_1 = (intptr_t)__this->___method_ptr_0;
			__this->___method_code_6 = (intptr_t)__this->___m_target_2;
		}
	}
	__this->___extra_arg_5 = (intptr_t)&Delegate_Invoke_mDC19B891E8784D90FDB7B09764639E93850BC2EA_Multicast;
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMMotionBlurShakeEvent_HDRP/Delegate::Invoke(UnityEngine.AnimationCurve,System.Single,System.Single,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Delegate_Invoke_mDC19B891E8784D90FDB7B09764639E93850BC2EA (Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
// System.IAsyncResult MoreMountains.FeedbacksForThirdParty.MMMotionBlurShakeEvent_HDRP/Delegate::BeginInvoke(UnityEngine.AnimationCurve,System.Single,System.Single,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean,System.AsyncCallback,System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* Delegate_BeginInvoke_m7D69C787F8F26E220F265AF8AB643F8D6AC8B088 (Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, AsyncCallback_t7FEF460CBDCFB9C5FA2EF776984778B9A4145F4C* ___callback12, RuntimeObject* ___object13, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TimescaleModes_t567213DC39EEE1AA073F8E8473E19F2B71FC9A68_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	void *__d_args[13] = {0};
	__d_args[0] = ___intensity0;
	__d_args[1] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___duration1);
	__d_args[2] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___remapMin2);
	__d_args[3] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___remapMax3);
	__d_args[4] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___relativeIntensity4);
	__d_args[5] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___attenuation5);
	__d_args[6] = Box(Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var, &___channel6);
	__d_args[7] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___resetShakerValuesAfterShake7);
	__d_args[8] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___resetTargetValuesAfterShake8);
	__d_args[9] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___forwardDirection9);
	__d_args[10] = Box(TimescaleModes_t567213DC39EEE1AA073F8E8473E19F2B71FC9A68_il2cpp_TypeInfo_var, &___timescaleMode10);
	__d_args[11] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___stop11);
	return (RuntimeObject*)il2cpp_codegen_delegate_begin_invoke((RuntimeDelegate*)__this, __d_args, (RuntimeDelegate*)___callback12, (RuntimeObject*)___object13);
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMMotionBlurShakeEvent_HDRP/Delegate::EndInvoke(System.IAsyncResult)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Delegate_EndInvoke_m0ED41C54D3A8CE1B5858F87D41AD1F2D4856A0ED (Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8* __this, RuntimeObject* ___result0, const RuntimeMethod* method) 
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
// System.Void MoreMountains.FeedbacksForThirdParty.MMPaniniProjectionShaker_HDRP::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMPaniniProjectionShaker_HDRP__ctor_m4F75385787E54859394D0BF2DF3608E409EA3B0F (MMPaniniProjectionShaker_HDRP_t8AD69F4068D255EDE69BA9597B9EAF1AB4641054* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public AnimationCurve ShakeDistance = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
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
		__this->___ShakeDistance_21 = L_7;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ShakeDistance_21), (void*)L_7);
		// public float RemapDistanceOne = 1f;
		__this->___RemapDistanceOne_23 = (1.0f);
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
// System.Void MoreMountains.FeedbacksForThirdParty.MMPaniniProjectionShakeEvent_HDRP::add_OnEvent(MoreMountains.FeedbacksForThirdParty.MMPaniniProjectionShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMPaniniProjectionShakeEvent_HDRP_add_OnEvent_m1EA38950F7D81041ACD9CBF4A07581A3F8554DC6 (Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79* ___value0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMPaniniProjectionShakeEvent_HDRP_tFA1A61153E3701522C4E4A3464D9F9F85C50B884_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79* V_0 = NULL;
	Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79* V_1 = NULL;
	Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79* V_2 = NULL;
	{
		Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79* L_0 = ((MMPaniniProjectionShakeEvent_HDRP_tFA1A61153E3701522C4E4A3464D9F9F85C50B884_StaticFields*)il2cpp_codegen_static_fields_for(MMPaniniProjectionShakeEvent_HDRP_tFA1A61153E3701522C4E4A3464D9F9F85C50B884_il2cpp_TypeInfo_var))->___OnEvent_0;
		V_0 = L_0;
	}

IL_0006:
	{
		Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79* L_1 = V_0;
		V_1 = L_1;
		Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79* L_2 = V_1;
		Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79* L_3 = ___value0;
		Delegate_t* L_4;
		L_4 = Delegate_Combine_m1F725AEF318BE6F0426863490691A6F4606E7D00(L_2, L_3, NULL);
		V_2 = ((Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79*)CastclassSealed((RuntimeObject*)L_4, Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79_il2cpp_TypeInfo_var));
		Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79* L_5 = V_2;
		Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79* L_6 = V_1;
		Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79* L_7;
		L_7 = InterlockedCompareExchangeImpl<Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79*>((&((MMPaniniProjectionShakeEvent_HDRP_tFA1A61153E3701522C4E4A3464D9F9F85C50B884_StaticFields*)il2cpp_codegen_static_fields_for(MMPaniniProjectionShakeEvent_HDRP_tFA1A61153E3701522C4E4A3464D9F9F85C50B884_il2cpp_TypeInfo_var))->___OnEvent_0), L_5, L_6);
		V_0 = L_7;
		Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79* L_8 = V_0;
		Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79* L_9 = V_1;
		if ((!(((RuntimeObject*)(Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79*)L_8) == ((RuntimeObject*)(Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79*)L_9))))
		{
			goto IL_0006;
		}
	}
	{
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMPaniniProjectionShakeEvent_HDRP::remove_OnEvent(MoreMountains.FeedbacksForThirdParty.MMPaniniProjectionShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMPaniniProjectionShakeEvent_HDRP_remove_OnEvent_m1060630D1CE706CD84255E6DA2F7EED5796C8FE5 (Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79* ___value0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMPaniniProjectionShakeEvent_HDRP_tFA1A61153E3701522C4E4A3464D9F9F85C50B884_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79* V_0 = NULL;
	Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79* V_1 = NULL;
	Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79* V_2 = NULL;
	{
		Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79* L_0 = ((MMPaniniProjectionShakeEvent_HDRP_tFA1A61153E3701522C4E4A3464D9F9F85C50B884_StaticFields*)il2cpp_codegen_static_fields_for(MMPaniniProjectionShakeEvent_HDRP_tFA1A61153E3701522C4E4A3464D9F9F85C50B884_il2cpp_TypeInfo_var))->___OnEvent_0;
		V_0 = L_0;
	}

IL_0006:
	{
		Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79* L_1 = V_0;
		V_1 = L_1;
		Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79* L_2 = V_1;
		Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79* L_3 = ___value0;
		Delegate_t* L_4;
		L_4 = Delegate_Remove_m8B7DD5661308FA972E23CA1CC3FC9CEB355504E3(L_2, L_3, NULL);
		V_2 = ((Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79*)CastclassSealed((RuntimeObject*)L_4, Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79_il2cpp_TypeInfo_var));
		Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79* L_5 = V_2;
		Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79* L_6 = V_1;
		Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79* L_7;
		L_7 = InterlockedCompareExchangeImpl<Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79*>((&((MMPaniniProjectionShakeEvent_HDRP_tFA1A61153E3701522C4E4A3464D9F9F85C50B884_StaticFields*)il2cpp_codegen_static_fields_for(MMPaniniProjectionShakeEvent_HDRP_tFA1A61153E3701522C4E4A3464D9F9F85C50B884_il2cpp_TypeInfo_var))->___OnEvent_0), L_5, L_6);
		V_0 = L_7;
		Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79* L_8 = V_0;
		Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79* L_9 = V_1;
		if ((!(((RuntimeObject*)(Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79*)L_8) == ((RuntimeObject*)(Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79*)L_9))))
		{
			goto IL_0006;
		}
	}
	{
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMPaniniProjectionShakeEvent_HDRP::Register(MoreMountains.FeedbacksForThirdParty.MMPaniniProjectionShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMPaniniProjectionShakeEvent_HDRP_Register_m15DD151C328BD8EE38D664C1A4F542DE68C87ADF (Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79* ___callback0, const RuntimeMethod* method) 
{
	{
		// OnEvent += callback;
		Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79* L_0 = ___callback0;
		MMPaniniProjectionShakeEvent_HDRP_add_OnEvent_m1EA38950F7D81041ACD9CBF4A07581A3F8554DC6(L_0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMPaniniProjectionShakeEvent_HDRP::Unregister(MoreMountains.FeedbacksForThirdParty.MMPaniniProjectionShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMPaniniProjectionShakeEvent_HDRP_Unregister_m3E14FCA4BFC9AD49161A24FB4D5662A49F8EABBE (Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79* ___callback0, const RuntimeMethod* method) 
{
	{
		// OnEvent -= callback;
		Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79* L_0 = ___callback0;
		MMPaniniProjectionShakeEvent_HDRP_remove_OnEvent_m1060630D1CE706CD84255E6DA2F7EED5796C8FE5(L_0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMPaniniProjectionShakeEvent_HDRP::Trigger(UnityEngine.AnimationCurve,System.Single,System.Single,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMPaniniProjectionShakeEvent_HDRP_Trigger_m8BC36B04EDE4E0A775110B51573142062BE2209F (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___distance0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeDistance4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMPaniniProjectionShakeEvent_HDRP_tFA1A61153E3701522C4E4A3464D9F9F85C50B884_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79* G_B2_0 = NULL;
	Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79* G_B1_0 = NULL;
	{
		// OnEvent?.Invoke(distance, duration, remapMin, remapMax, relativeDistance, attenuation, channel, resetShakerValuesAfterShake, resetTargetValuesAfterShake, forwardDirection, timescaleMode, stop);
		Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79* L_0 = ((MMPaniniProjectionShakeEvent_HDRP_tFA1A61153E3701522C4E4A3464D9F9F85C50B884_StaticFields*)il2cpp_codegen_static_fields_for(MMPaniniProjectionShakeEvent_HDRP_tFA1A61153E3701522C4E4A3464D9F9F85C50B884_il2cpp_TypeInfo_var))->___OnEvent_0;
		Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79* L_1 = L_0;
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
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_2 = ___distance0;
		float L_3 = ___duration1;
		float L_4 = ___remapMin2;
		float L_5 = ___remapMax3;
		bool L_6 = ___relativeDistance4;
		float L_7 = ___attenuation5;
		int32_t L_8 = ___channel6;
		bool L_9 = ___resetShakerValuesAfterShake7;
		bool L_10 = ___resetTargetValuesAfterShake8;
		bool L_11 = ___forwardDirection9;
		int32_t L_12 = ___timescaleMode10;
		bool L_13 = ___stop11;
		NullCheck(G_B2_0);
		Delegate_Invoke_m6BBDE2816C59B866513C70D4B1CE63FE43C95414_inline(G_B2_0, L_2, L_3, L_4, L_5, L_6, L_7, L_8, L_9, L_10, L_11, L_12, L_13, NULL);
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
void Delegate_Invoke_m6BBDE2816C59B866513C70D4B1CE63FE43C95414_Multicast(Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___distance0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeDistance4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	il2cpp_array_size_t length = __this->___delegates_13->max_length;
	Delegate_t** delegatesToInvoke = reinterpret_cast<Delegate_t**>(__this->___delegates_13->GetAddressAtUnchecked(0));
	for (il2cpp_array_size_t i = 0; i < length; i++)
	{
		Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79* currentDelegate = reinterpret_cast<Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79*>(delegatesToInvoke[i]);
		typedef void (*FunctionPointerType) (RuntimeObject*, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
		((FunctionPointerType)currentDelegate->___invoke_impl_1)((Il2CppObject*)currentDelegate->___method_code_6, ___distance0, ___duration1, ___remapMin2, ___remapMax3, ___relativeDistance4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11, reinterpret_cast<RuntimeMethod*>(currentDelegate->___method_3));
	}
}
void Delegate_Invoke_m6BBDE2816C59B866513C70D4B1CE63FE43C95414_OpenInst(Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___distance0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeDistance4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	NullCheck(___distance0);
	typedef void (*FunctionPointerType) (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___method_ptr_0)(___distance0, ___duration1, ___remapMin2, ___remapMax3, ___relativeDistance4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11, method);
}
void Delegate_Invoke_m6BBDE2816C59B866513C70D4B1CE63FE43C95414_OpenStatic(Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___distance0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeDistance4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	typedef void (*FunctionPointerType) (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___method_ptr_0)(___distance0, ___duration1, ___remapMin2, ___remapMax3, ___relativeDistance4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11, method);
}
void Delegate_Invoke_m6BBDE2816C59B866513C70D4B1CE63FE43C95414_OpenStaticInvoker(Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___distance0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeDistance4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	InvokerActionInvoker12< AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(__this->___method_ptr_0, method, NULL, ___distance0, ___duration1, ___remapMin2, ___remapMax3, ___relativeDistance4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11);
}
void Delegate_Invoke_m6BBDE2816C59B866513C70D4B1CE63FE43C95414_ClosedStaticInvoker(Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___distance0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeDistance4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	InvokerActionInvoker13< RuntimeObject*, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(__this->___method_ptr_0, method, NULL, __this->___m_target_2, ___distance0, ___duration1, ___remapMin2, ___remapMax3, ___relativeDistance4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11);
}
void Delegate_Invoke_m6BBDE2816C59B866513C70D4B1CE63FE43C95414_OpenVirtual(Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___distance0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeDistance4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	NullCheck(___distance0);
	VirtualActionInvoker11< float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(il2cpp_codegen_method_get_slot(method), ___distance0, ___duration1, ___remapMin2, ___remapMax3, ___relativeDistance4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11);
}
void Delegate_Invoke_m6BBDE2816C59B866513C70D4B1CE63FE43C95414_OpenInterface(Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___distance0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeDistance4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	NullCheck(___distance0);
	InterfaceActionInvoker11< float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(il2cpp_codegen_method_get_slot(method), il2cpp_codegen_method_get_declaring_type(method), ___distance0, ___duration1, ___remapMin2, ___remapMax3, ___relativeDistance4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11);
}
void Delegate_Invoke_m6BBDE2816C59B866513C70D4B1CE63FE43C95414_OpenGenericVirtual(Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___distance0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeDistance4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	NullCheck(___distance0);
	GenericVirtualActionInvoker11< float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(method, ___distance0, ___duration1, ___remapMin2, ___remapMax3, ___relativeDistance4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11);
}
void Delegate_Invoke_m6BBDE2816C59B866513C70D4B1CE63FE43C95414_OpenGenericInterface(Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___distance0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeDistance4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	NullCheck(___distance0);
	GenericInterfaceActionInvoker11< float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(method, ___distance0, ___duration1, ___remapMin2, ___remapMax3, ___relativeDistance4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11);
}
IL2CPP_EXTERN_C  void DelegatePInvokeWrapper_Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79 (Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___distance0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeDistance4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{


	typedef void (DEFAULT_CALL *PInvokeFunc)(AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshaled_pinvoke*, float, float, float, int32_t, float, int32_t, int32_t, int32_t, int32_t, int32_t, int32_t);
	PInvokeFunc il2cppPInvokeFunc = reinterpret_cast<PInvokeFunc>(il2cpp_codegen_get_reverse_pinvoke_function_ptr(__this));
	// Marshaling of parameter '___distance0' to native representation
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshaled_pinvoke ____distance0_marshaled = {};
	if (___distance0 != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke(*___distance0, ____distance0_marshaled);
	}

	// Native function invocation
	il2cppPInvokeFunc(___distance0 != NULL ? (&____distance0_marshaled) : NULL, ___duration1, ___remapMin2, ___remapMax3, static_cast<int32_t>(___relativeDistance4), ___attenuation5, ___channel6, static_cast<int32_t>(___resetShakerValuesAfterShake7), static_cast<int32_t>(___resetTargetValuesAfterShake8), static_cast<int32_t>(___forwardDirection9), ___timescaleMode10, static_cast<int32_t>(___stop11));

	// Marshaling of parameter '___distance0' back from native representation
	if (___distance0 != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke_back(____distance0_marshaled, *___distance0);
	}

	// Marshaling cleanup of parameter '___distance0' native representation
	if ((&____distance0_marshaled) != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke_cleanup(____distance0_marshaled);
	}

}
// System.Void MoreMountains.FeedbacksForThirdParty.MMPaniniProjectionShakeEvent_HDRP/Delegate::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Delegate__ctor_m5656E31DF229B3CDD57D2388AA6CE110891E6981 (Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79* __this, RuntimeObject* ___object0, intptr_t ___method1, const RuntimeMethod* method) 
{
	__this->___method_ptr_0 = il2cpp_codegen_get_virtual_call_method_pointer((RuntimeMethod*)___method1);
	__this->___method_3 = ___method1;
	__this->___m_target_2 = ___object0;
	Il2CppCodeGenWriteBarrier((void**)(&__this->___m_target_2), (void*)___object0);
	int parameterCount = il2cpp_codegen_method_parameter_count((RuntimeMethod*)___method1);
	__this->___method_code_6 = (intptr_t)__this;
	if (MethodIsStatic((RuntimeMethod*)___method1))
	{
		bool isOpen = parameterCount == 12;
		if (il2cpp_codegen_call_method_via_invoker((RuntimeMethod*)___method1))
			if (isOpen)
				__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_m6BBDE2816C59B866513C70D4B1CE63FE43C95414_OpenStaticInvoker;
			else
				__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_m6BBDE2816C59B866513C70D4B1CE63FE43C95414_ClosedStaticInvoker;
		else
			if (isOpen)
				__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_m6BBDE2816C59B866513C70D4B1CE63FE43C95414_OpenStatic;
			else
				{
					__this->___invoke_impl_1 = (intptr_t)__this->___method_ptr_0;
					__this->___method_code_6 = (intptr_t)__this->___m_target_2;
				}
	}
	else
	{
		bool isOpen = parameterCount == 11;
		if (isOpen)
		{
			if (__this->___method_is_virtual_12)
			{
				if (il2cpp_codegen_method_is_generic_instance_method((RuntimeMethod*)___method1))
					if (il2cpp_codegen_method_is_interface_method((RuntimeMethod*)___method1))
						__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_m6BBDE2816C59B866513C70D4B1CE63FE43C95414_OpenGenericInterface;
					else
						__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_m6BBDE2816C59B866513C70D4B1CE63FE43C95414_OpenGenericVirtual;
				else
					if (il2cpp_codegen_method_is_interface_method((RuntimeMethod*)___method1))
						__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_m6BBDE2816C59B866513C70D4B1CE63FE43C95414_OpenInterface;
					else
						__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_m6BBDE2816C59B866513C70D4B1CE63FE43C95414_OpenVirtual;
			}
			else
			{
				__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_m6BBDE2816C59B866513C70D4B1CE63FE43C95414_OpenInst;
			}
		}
		else
		{
			if (___object0 == NULL)
				il2cpp_codegen_raise_exception(il2cpp_codegen_get_argument_exception(NULL, "Delegate to an instance method cannot have null 'this'."), NULL);
			__this->___invoke_impl_1 = (intptr_t)__this->___method_ptr_0;
			__this->___method_code_6 = (intptr_t)__this->___m_target_2;
		}
	}
	__this->___extra_arg_5 = (intptr_t)&Delegate_Invoke_m6BBDE2816C59B866513C70D4B1CE63FE43C95414_Multicast;
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMPaniniProjectionShakeEvent_HDRP/Delegate::Invoke(UnityEngine.AnimationCurve,System.Single,System.Single,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Delegate_Invoke_m6BBDE2816C59B866513C70D4B1CE63FE43C95414 (Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___distance0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeDistance4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___distance0, ___duration1, ___remapMin2, ___remapMax3, ___relativeDistance4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
// System.IAsyncResult MoreMountains.FeedbacksForThirdParty.MMPaniniProjectionShakeEvent_HDRP/Delegate::BeginInvoke(UnityEngine.AnimationCurve,System.Single,System.Single,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean,System.AsyncCallback,System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* Delegate_BeginInvoke_mFCEA94D4BDBBF946C52D5BC3EB0FAE16BFC752FA (Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___distance0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeDistance4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, AsyncCallback_t7FEF460CBDCFB9C5FA2EF776984778B9A4145F4C* ___callback12, RuntimeObject* ___object13, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TimescaleModes_t567213DC39EEE1AA073F8E8473E19F2B71FC9A68_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	void *__d_args[13] = {0};
	__d_args[0] = ___distance0;
	__d_args[1] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___duration1);
	__d_args[2] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___remapMin2);
	__d_args[3] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___remapMax3);
	__d_args[4] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___relativeDistance4);
	__d_args[5] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___attenuation5);
	__d_args[6] = Box(Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var, &___channel6);
	__d_args[7] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___resetShakerValuesAfterShake7);
	__d_args[8] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___resetTargetValuesAfterShake8);
	__d_args[9] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___forwardDirection9);
	__d_args[10] = Box(TimescaleModes_t567213DC39EEE1AA073F8E8473E19F2B71FC9A68_il2cpp_TypeInfo_var, &___timescaleMode10);
	__d_args[11] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___stop11);
	return (RuntimeObject*)il2cpp_codegen_delegate_begin_invoke((RuntimeDelegate*)__this, __d_args, (RuntimeDelegate*)___callback12, (RuntimeObject*)___object13);
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMPaniniProjectionShakeEvent_HDRP/Delegate::EndInvoke(System.IAsyncResult)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Delegate_EndInvoke_m8AD324705D762FE41FA0B0D929DCAD05FD2B584E (Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79* __this, RuntimeObject* ___result0, const RuntimeMethod* method) 
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
// System.Void MoreMountains.FeedbacksForThirdParty.MMVignetteShaker_HDRP::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMVignetteShaker_HDRP__ctor_mFF1AF62333D2D6AE8BE9D9C8D59212EFDDB568F5 (MMVignetteShaker_HDRP_t210D4D7C056D8ECE4C934F3A13B817FA2EEDB376* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public AnimationCurve ShakeIntensity = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
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
		__this->___ShakeIntensity_21 = L_7;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ShakeIntensity_21), (void*)L_7);
		// public float RemapIntensityOne = 1f;
		__this->___RemapIntensityOne_23 = (1.0f);
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
// System.Void MoreMountains.FeedbacksForThirdParty.MMVignetteShakeEvent_HDRP::add_OnEvent(MoreMountains.FeedbacksForThirdParty.MMVignetteShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMVignetteShakeEvent_HDRP_add_OnEvent_m94469987DF4BA63AE35681FD67943A67B111FB21 (Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78* ___value0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMVignetteShakeEvent_HDRP_t34C7476BF07488DAEA4EC32082A29AC303604A21_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78* V_0 = NULL;
	Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78* V_1 = NULL;
	Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78* V_2 = NULL;
	{
		Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78* L_0 = ((MMVignetteShakeEvent_HDRP_t34C7476BF07488DAEA4EC32082A29AC303604A21_StaticFields*)il2cpp_codegen_static_fields_for(MMVignetteShakeEvent_HDRP_t34C7476BF07488DAEA4EC32082A29AC303604A21_il2cpp_TypeInfo_var))->___OnEvent_0;
		V_0 = L_0;
	}

IL_0006:
	{
		Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78* L_1 = V_0;
		V_1 = L_1;
		Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78* L_2 = V_1;
		Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78* L_3 = ___value0;
		Delegate_t* L_4;
		L_4 = Delegate_Combine_m1F725AEF318BE6F0426863490691A6F4606E7D00(L_2, L_3, NULL);
		V_2 = ((Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78*)CastclassSealed((RuntimeObject*)L_4, Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78_il2cpp_TypeInfo_var));
		Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78* L_5 = V_2;
		Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78* L_6 = V_1;
		Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78* L_7;
		L_7 = InterlockedCompareExchangeImpl<Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78*>((&((MMVignetteShakeEvent_HDRP_t34C7476BF07488DAEA4EC32082A29AC303604A21_StaticFields*)il2cpp_codegen_static_fields_for(MMVignetteShakeEvent_HDRP_t34C7476BF07488DAEA4EC32082A29AC303604A21_il2cpp_TypeInfo_var))->___OnEvent_0), L_5, L_6);
		V_0 = L_7;
		Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78* L_8 = V_0;
		Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78* L_9 = V_1;
		if ((!(((RuntimeObject*)(Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78*)L_8) == ((RuntimeObject*)(Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78*)L_9))))
		{
			goto IL_0006;
		}
	}
	{
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMVignetteShakeEvent_HDRP::remove_OnEvent(MoreMountains.FeedbacksForThirdParty.MMVignetteShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMVignetteShakeEvent_HDRP_remove_OnEvent_mB24A5FEF84AA3B83E933E4FF687006B351A6541B (Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78* ___value0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMVignetteShakeEvent_HDRP_t34C7476BF07488DAEA4EC32082A29AC303604A21_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78* V_0 = NULL;
	Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78* V_1 = NULL;
	Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78* V_2 = NULL;
	{
		Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78* L_0 = ((MMVignetteShakeEvent_HDRP_t34C7476BF07488DAEA4EC32082A29AC303604A21_StaticFields*)il2cpp_codegen_static_fields_for(MMVignetteShakeEvent_HDRP_t34C7476BF07488DAEA4EC32082A29AC303604A21_il2cpp_TypeInfo_var))->___OnEvent_0;
		V_0 = L_0;
	}

IL_0006:
	{
		Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78* L_1 = V_0;
		V_1 = L_1;
		Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78* L_2 = V_1;
		Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78* L_3 = ___value0;
		Delegate_t* L_4;
		L_4 = Delegate_Remove_m8B7DD5661308FA972E23CA1CC3FC9CEB355504E3(L_2, L_3, NULL);
		V_2 = ((Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78*)CastclassSealed((RuntimeObject*)L_4, Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78_il2cpp_TypeInfo_var));
		Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78* L_5 = V_2;
		Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78* L_6 = V_1;
		Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78* L_7;
		L_7 = InterlockedCompareExchangeImpl<Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78*>((&((MMVignetteShakeEvent_HDRP_t34C7476BF07488DAEA4EC32082A29AC303604A21_StaticFields*)il2cpp_codegen_static_fields_for(MMVignetteShakeEvent_HDRP_t34C7476BF07488DAEA4EC32082A29AC303604A21_il2cpp_TypeInfo_var))->___OnEvent_0), L_5, L_6);
		V_0 = L_7;
		Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78* L_8 = V_0;
		Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78* L_9 = V_1;
		if ((!(((RuntimeObject*)(Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78*)L_8) == ((RuntimeObject*)(Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78*)L_9))))
		{
			goto IL_0006;
		}
	}
	{
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMVignetteShakeEvent_HDRP::Register(MoreMountains.FeedbacksForThirdParty.MMVignetteShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMVignetteShakeEvent_HDRP_Register_mAC854D0A0CE95C599C528A394F76E59A5EFF1D54 (Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78* ___callback0, const RuntimeMethod* method) 
{
	{
		// OnEvent += callback;
		Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78* L_0 = ___callback0;
		MMVignetteShakeEvent_HDRP_add_OnEvent_m94469987DF4BA63AE35681FD67943A67B111FB21(L_0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMVignetteShakeEvent_HDRP::Unregister(MoreMountains.FeedbacksForThirdParty.MMVignetteShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMVignetteShakeEvent_HDRP_Unregister_m136BE639306DED91CBA6B4193CD7E60E810D938D (Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78* ___callback0, const RuntimeMethod* method) 
{
	{
		// OnEvent -= callback;
		Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78* L_0 = ___callback0;
		MMVignetteShakeEvent_HDRP_remove_OnEvent_mB24A5FEF84AA3B83E933E4FF687006B351A6541B(L_0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMVignetteShakeEvent_HDRP::Trigger(UnityEngine.AnimationCurve,System.Single,System.Single,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMVignetteShakeEvent_HDRP_Trigger_mF821317AF76CAA81B63DAD57A3D4DB379EF40B47 (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMVignetteShakeEvent_HDRP_t34C7476BF07488DAEA4EC32082A29AC303604A21_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78* G_B2_0 = NULL;
	Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78* G_B1_0 = NULL;
	{
		// OnEvent?.Invoke(intensity, duration, remapMin, remapMax, relativeIntensity, attenuation, channel, resetShakerValuesAfterShake, resetTargetValuesAfterShake, forwardDirection, timescaleMode, stop);
		Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78* L_0 = ((MMVignetteShakeEvent_HDRP_t34C7476BF07488DAEA4EC32082A29AC303604A21_StaticFields*)il2cpp_codegen_static_fields_for(MMVignetteShakeEvent_HDRP_t34C7476BF07488DAEA4EC32082A29AC303604A21_il2cpp_TypeInfo_var))->___OnEvent_0;
		Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78* L_1 = L_0;
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
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_2 = ___intensity0;
		float L_3 = ___duration1;
		float L_4 = ___remapMin2;
		float L_5 = ___remapMax3;
		bool L_6 = ___relativeIntensity4;
		float L_7 = ___attenuation5;
		int32_t L_8 = ___channel6;
		bool L_9 = ___resetShakerValuesAfterShake7;
		bool L_10 = ___resetTargetValuesAfterShake8;
		bool L_11 = ___forwardDirection9;
		int32_t L_12 = ___timescaleMode10;
		bool L_13 = ___stop11;
		NullCheck(G_B2_0);
		Delegate_Invoke_mE669B4A49B0DC7BA342141849CCF6770DCD7EE31_inline(G_B2_0, L_2, L_3, L_4, L_5, L_6, L_7, L_8, L_9, L_10, L_11, L_12, L_13, NULL);
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
void Delegate_Invoke_mE669B4A49B0DC7BA342141849CCF6770DCD7EE31_Multicast(Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	il2cpp_array_size_t length = __this->___delegates_13->max_length;
	Delegate_t** delegatesToInvoke = reinterpret_cast<Delegate_t**>(__this->___delegates_13->GetAddressAtUnchecked(0));
	for (il2cpp_array_size_t i = 0; i < length; i++)
	{
		Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78* currentDelegate = reinterpret_cast<Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78*>(delegatesToInvoke[i]);
		typedef void (*FunctionPointerType) (RuntimeObject*, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
		((FunctionPointerType)currentDelegate->___invoke_impl_1)((Il2CppObject*)currentDelegate->___method_code_6, ___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11, reinterpret_cast<RuntimeMethod*>(currentDelegate->___method_3));
	}
}
void Delegate_Invoke_mE669B4A49B0DC7BA342141849CCF6770DCD7EE31_OpenInst(Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	NullCheck(___intensity0);
	typedef void (*FunctionPointerType) (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___method_ptr_0)(___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11, method);
}
void Delegate_Invoke_mE669B4A49B0DC7BA342141849CCF6770DCD7EE31_OpenStatic(Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	typedef void (*FunctionPointerType) (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___method_ptr_0)(___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11, method);
}
void Delegate_Invoke_mE669B4A49B0DC7BA342141849CCF6770DCD7EE31_OpenStaticInvoker(Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	InvokerActionInvoker12< AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(__this->___method_ptr_0, method, NULL, ___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11);
}
void Delegate_Invoke_mE669B4A49B0DC7BA342141849CCF6770DCD7EE31_ClosedStaticInvoker(Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	InvokerActionInvoker13< RuntimeObject*, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(__this->___method_ptr_0, method, NULL, __this->___m_target_2, ___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11);
}
void Delegate_Invoke_mE669B4A49B0DC7BA342141849CCF6770DCD7EE31_OpenVirtual(Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	NullCheck(___intensity0);
	VirtualActionInvoker11< float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(il2cpp_codegen_method_get_slot(method), ___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11);
}
void Delegate_Invoke_mE669B4A49B0DC7BA342141849CCF6770DCD7EE31_OpenInterface(Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	NullCheck(___intensity0);
	InterfaceActionInvoker11< float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(il2cpp_codegen_method_get_slot(method), il2cpp_codegen_method_get_declaring_type(method), ___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11);
}
void Delegate_Invoke_mE669B4A49B0DC7BA342141849CCF6770DCD7EE31_OpenGenericVirtual(Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	NullCheck(___intensity0);
	GenericVirtualActionInvoker11< float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(method, ___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11);
}
void Delegate_Invoke_mE669B4A49B0DC7BA342141849CCF6770DCD7EE31_OpenGenericInterface(Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{
	NullCheck(___intensity0);
	GenericInterfaceActionInvoker11< float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(method, ___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11);
}
IL2CPP_EXTERN_C  void DelegatePInvokeWrapper_Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78 (Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method)
{


	typedef void (DEFAULT_CALL *PInvokeFunc)(AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshaled_pinvoke*, float, float, float, int32_t, float, int32_t, int32_t, int32_t, int32_t, int32_t, int32_t);
	PInvokeFunc il2cppPInvokeFunc = reinterpret_cast<PInvokeFunc>(il2cpp_codegen_get_reverse_pinvoke_function_ptr(__this));
	// Marshaling of parameter '___intensity0' to native representation
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshaled_pinvoke ____intensity0_marshaled = {};
	if (___intensity0 != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke(*___intensity0, ____intensity0_marshaled);
	}

	// Native function invocation
	il2cppPInvokeFunc(___intensity0 != NULL ? (&____intensity0_marshaled) : NULL, ___duration1, ___remapMin2, ___remapMax3, static_cast<int32_t>(___relativeIntensity4), ___attenuation5, ___channel6, static_cast<int32_t>(___resetShakerValuesAfterShake7), static_cast<int32_t>(___resetTargetValuesAfterShake8), static_cast<int32_t>(___forwardDirection9), ___timescaleMode10, static_cast<int32_t>(___stop11));

	// Marshaling of parameter '___intensity0' back from native representation
	if (___intensity0 != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke_back(____intensity0_marshaled, *___intensity0);
	}

	// Marshaling cleanup of parameter '___intensity0' native representation
	if ((&____intensity0_marshaled) != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke_cleanup(____intensity0_marshaled);
	}

}
// System.Void MoreMountains.FeedbacksForThirdParty.MMVignetteShakeEvent_HDRP/Delegate::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Delegate__ctor_mA6C7436FBD890384D1C6FB87B0CD6BAB39FFCD11 (Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78* __this, RuntimeObject* ___object0, intptr_t ___method1, const RuntimeMethod* method) 
{
	__this->___method_ptr_0 = il2cpp_codegen_get_virtual_call_method_pointer((RuntimeMethod*)___method1);
	__this->___method_3 = ___method1;
	__this->___m_target_2 = ___object0;
	Il2CppCodeGenWriteBarrier((void**)(&__this->___m_target_2), (void*)___object0);
	int parameterCount = il2cpp_codegen_method_parameter_count((RuntimeMethod*)___method1);
	__this->___method_code_6 = (intptr_t)__this;
	if (MethodIsStatic((RuntimeMethod*)___method1))
	{
		bool isOpen = parameterCount == 12;
		if (il2cpp_codegen_call_method_via_invoker((RuntimeMethod*)___method1))
			if (isOpen)
				__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mE669B4A49B0DC7BA342141849CCF6770DCD7EE31_OpenStaticInvoker;
			else
				__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mE669B4A49B0DC7BA342141849CCF6770DCD7EE31_ClosedStaticInvoker;
		else
			if (isOpen)
				__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mE669B4A49B0DC7BA342141849CCF6770DCD7EE31_OpenStatic;
			else
				{
					__this->___invoke_impl_1 = (intptr_t)__this->___method_ptr_0;
					__this->___method_code_6 = (intptr_t)__this->___m_target_2;
				}
	}
	else
	{
		bool isOpen = parameterCount == 11;
		if (isOpen)
		{
			if (__this->___method_is_virtual_12)
			{
				if (il2cpp_codegen_method_is_generic_instance_method((RuntimeMethod*)___method1))
					if (il2cpp_codegen_method_is_interface_method((RuntimeMethod*)___method1))
						__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mE669B4A49B0DC7BA342141849CCF6770DCD7EE31_OpenGenericInterface;
					else
						__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mE669B4A49B0DC7BA342141849CCF6770DCD7EE31_OpenGenericVirtual;
				else
					if (il2cpp_codegen_method_is_interface_method((RuntimeMethod*)___method1))
						__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mE669B4A49B0DC7BA342141849CCF6770DCD7EE31_OpenInterface;
					else
						__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mE669B4A49B0DC7BA342141849CCF6770DCD7EE31_OpenVirtual;
			}
			else
			{
				__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mE669B4A49B0DC7BA342141849CCF6770DCD7EE31_OpenInst;
			}
		}
		else
		{
			if (___object0 == NULL)
				il2cpp_codegen_raise_exception(il2cpp_codegen_get_argument_exception(NULL, "Delegate to an instance method cannot have null 'this'."), NULL);
			__this->___invoke_impl_1 = (intptr_t)__this->___method_ptr_0;
			__this->___method_code_6 = (intptr_t)__this->___m_target_2;
		}
	}
	__this->___extra_arg_5 = (intptr_t)&Delegate_Invoke_mE669B4A49B0DC7BA342141849CCF6770DCD7EE31_Multicast;
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMVignetteShakeEvent_HDRP/Delegate::Invoke(UnityEngine.AnimationCurve,System.Single,System.Single,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Delegate_Invoke_mE669B4A49B0DC7BA342141849CCF6770DCD7EE31 (Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
// System.IAsyncResult MoreMountains.FeedbacksForThirdParty.MMVignetteShakeEvent_HDRP/Delegate::BeginInvoke(UnityEngine.AnimationCurve,System.Single,System.Single,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean,System.AsyncCallback,System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* Delegate_BeginInvoke_mDEBA0EFAABC2AAF56053C1AE4A3D7CF005B3970E (Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, AsyncCallback_t7FEF460CBDCFB9C5FA2EF776984778B9A4145F4C* ___callback12, RuntimeObject* ___object13, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TimescaleModes_t567213DC39EEE1AA073F8E8473E19F2B71FC9A68_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	void *__d_args[13] = {0};
	__d_args[0] = ___intensity0;
	__d_args[1] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___duration1);
	__d_args[2] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___remapMin2);
	__d_args[3] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___remapMax3);
	__d_args[4] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___relativeIntensity4);
	__d_args[5] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___attenuation5);
	__d_args[6] = Box(Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var, &___channel6);
	__d_args[7] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___resetShakerValuesAfterShake7);
	__d_args[8] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___resetTargetValuesAfterShake8);
	__d_args[9] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___forwardDirection9);
	__d_args[10] = Box(TimescaleModes_t567213DC39EEE1AA073F8E8473E19F2B71FC9A68_il2cpp_TypeInfo_var, &___timescaleMode10);
	__d_args[11] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___stop11);
	return (RuntimeObject*)il2cpp_codegen_delegate_begin_invoke((RuntimeDelegate*)__this, __d_args, (RuntimeDelegate*)___callback12, (RuntimeObject*)___object13);
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMVignetteShakeEvent_HDRP/Delegate::EndInvoke(System.IAsyncResult)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Delegate_EndInvoke_mA10F784672CB85B68CBE09C5B92C456386F9FDD2 (Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78* __this, RuntimeObject* ___result0, const RuntimeMethod* method) 
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
// System.Void MoreMountains.FeedbacksForThirdParty.MMWhiteBalanceShaker_HDRP::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMWhiteBalanceShaker_HDRP__ctor_m30A331A6955E9CE67D5D7212132EEC6EF417258A (MMWhiteBalanceShaker_HDRP_t65113CD3FFAFC79CAE06093A6D758FB158F20A63* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&KeyframeU5BU5D_t63250A46914A6A07B2A6689850D47D7D19D80BA3_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public bool RelativeValues = true;
		__this->___RelativeValues_20 = (bool)1;
		// public AnimationCurve ShakeTemperature = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
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
		__this->___ShakeTemperature_21 = L_7;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ShakeTemperature_21), (void*)L_7);
		// public float RemapTemperatureOne = 100f;
		__this->___RemapTemperatureOne_23 = (100.0f);
		// public AnimationCurve ShakeTint = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0));
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
		__this->___ShakeTint_24 = L_15;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ShakeTint_24), (void*)L_15);
		// public float RemapTintOne = 100f;
		__this->___RemapTintOne_26 = (100.0f);
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
// System.Void MoreMountains.FeedbacksForThirdParty.MMWhiteBalanceShakeEvent_HDRP::add_OnEvent(MoreMountains.FeedbacksForThirdParty.MMWhiteBalanceShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMWhiteBalanceShakeEvent_HDRP_add_OnEvent_m5DEF76B1DA3AB60585FCBE0A6962354B11FBA6C6 (Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7* ___value0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMWhiteBalanceShakeEvent_HDRP_t974BEF62F681D273DAD8418106D7C1E817696F90_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7* V_0 = NULL;
	Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7* V_1 = NULL;
	Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7* V_2 = NULL;
	{
		Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7* L_0 = ((MMWhiteBalanceShakeEvent_HDRP_t974BEF62F681D273DAD8418106D7C1E817696F90_StaticFields*)il2cpp_codegen_static_fields_for(MMWhiteBalanceShakeEvent_HDRP_t974BEF62F681D273DAD8418106D7C1E817696F90_il2cpp_TypeInfo_var))->___OnEvent_0;
		V_0 = L_0;
	}

IL_0006:
	{
		Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7* L_1 = V_0;
		V_1 = L_1;
		Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7* L_2 = V_1;
		Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7* L_3 = ___value0;
		Delegate_t* L_4;
		L_4 = Delegate_Combine_m1F725AEF318BE6F0426863490691A6F4606E7D00(L_2, L_3, NULL);
		V_2 = ((Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7*)CastclassSealed((RuntimeObject*)L_4, Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7_il2cpp_TypeInfo_var));
		Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7* L_5 = V_2;
		Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7* L_6 = V_1;
		Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7* L_7;
		L_7 = InterlockedCompareExchangeImpl<Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7*>((&((MMWhiteBalanceShakeEvent_HDRP_t974BEF62F681D273DAD8418106D7C1E817696F90_StaticFields*)il2cpp_codegen_static_fields_for(MMWhiteBalanceShakeEvent_HDRP_t974BEF62F681D273DAD8418106D7C1E817696F90_il2cpp_TypeInfo_var))->___OnEvent_0), L_5, L_6);
		V_0 = L_7;
		Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7* L_8 = V_0;
		Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7* L_9 = V_1;
		if ((!(((RuntimeObject*)(Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7*)L_8) == ((RuntimeObject*)(Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7*)L_9))))
		{
			goto IL_0006;
		}
	}
	{
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMWhiteBalanceShakeEvent_HDRP::remove_OnEvent(MoreMountains.FeedbacksForThirdParty.MMWhiteBalanceShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMWhiteBalanceShakeEvent_HDRP_remove_OnEvent_m298BFA2E2BAE1232FEA8B604CE19155F362DCCFE (Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7* ___value0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMWhiteBalanceShakeEvent_HDRP_t974BEF62F681D273DAD8418106D7C1E817696F90_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7* V_0 = NULL;
	Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7* V_1 = NULL;
	Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7* V_2 = NULL;
	{
		Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7* L_0 = ((MMWhiteBalanceShakeEvent_HDRP_t974BEF62F681D273DAD8418106D7C1E817696F90_StaticFields*)il2cpp_codegen_static_fields_for(MMWhiteBalanceShakeEvent_HDRP_t974BEF62F681D273DAD8418106D7C1E817696F90_il2cpp_TypeInfo_var))->___OnEvent_0;
		V_0 = L_0;
	}

IL_0006:
	{
		Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7* L_1 = V_0;
		V_1 = L_1;
		Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7* L_2 = V_1;
		Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7* L_3 = ___value0;
		Delegate_t* L_4;
		L_4 = Delegate_Remove_m8B7DD5661308FA972E23CA1CC3FC9CEB355504E3(L_2, L_3, NULL);
		V_2 = ((Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7*)CastclassSealed((RuntimeObject*)L_4, Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7_il2cpp_TypeInfo_var));
		Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7* L_5 = V_2;
		Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7* L_6 = V_1;
		Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7* L_7;
		L_7 = InterlockedCompareExchangeImpl<Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7*>((&((MMWhiteBalanceShakeEvent_HDRP_t974BEF62F681D273DAD8418106D7C1E817696F90_StaticFields*)il2cpp_codegen_static_fields_for(MMWhiteBalanceShakeEvent_HDRP_t974BEF62F681D273DAD8418106D7C1E817696F90_il2cpp_TypeInfo_var))->___OnEvent_0), L_5, L_6);
		V_0 = L_7;
		Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7* L_8 = V_0;
		Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7* L_9 = V_1;
		if ((!(((RuntimeObject*)(Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7*)L_8) == ((RuntimeObject*)(Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7*)L_9))))
		{
			goto IL_0006;
		}
	}
	{
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMWhiteBalanceShakeEvent_HDRP::Register(MoreMountains.FeedbacksForThirdParty.MMWhiteBalanceShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMWhiteBalanceShakeEvent_HDRP_Register_mB47EEDA518324521F57B7F7C24644E12237D7336 (Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7* ___callback0, const RuntimeMethod* method) 
{
	{
		// OnEvent += callback;
		Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7* L_0 = ___callback0;
		MMWhiteBalanceShakeEvent_HDRP_add_OnEvent_m5DEF76B1DA3AB60585FCBE0A6962354B11FBA6C6(L_0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMWhiteBalanceShakeEvent_HDRP::Unregister(MoreMountains.FeedbacksForThirdParty.MMWhiteBalanceShakeEvent_HDRP/Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMWhiteBalanceShakeEvent_HDRP_Unregister_m1FCD8B22D363F885A161AB107EEFA65AA2417724 (Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7* ___callback0, const RuntimeMethod* method) 
{
	{
		// OnEvent -= callback;
		Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7* L_0 = ___callback0;
		MMWhiteBalanceShakeEvent_HDRP_remove_OnEvent_m298BFA2E2BAE1232FEA8B604CE19155F362DCCFE(L_0, NULL);
		// }
		return;
	}
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMWhiteBalanceShakeEvent_HDRP::Trigger(UnityEngine.AnimationCurve,System.Single,System.Single,System.Single,UnityEngine.AnimationCurve,System.Single,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MMWhiteBalanceShakeEvent_HDRP_Trigger_mAB52FBCD73353B6F59806FD3216FFCCA35F97A6D (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___temperature0, float ___duration1, float ___remapTemperatureMin2, float ___remapTemperatureMax3, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___tint4, float ___remapTintMin5, float ___remapTintMax6, bool ___relativeValues7, float ___attenuation8, int32_t ___channel9, bool ___resetShakerValuesAfterShake10, bool ___resetTargetValuesAfterShake11, bool ___forwardDirection12, int32_t ___timescaleMode13, bool ___stop14, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MMWhiteBalanceShakeEvent_HDRP_t974BEF62F681D273DAD8418106D7C1E817696F90_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7* G_B2_0 = NULL;
	Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7* G_B1_0 = NULL;
	{
		// OnEvent?.Invoke(temperature, duration, remapTemperatureMin, remapTemperatureMax,
		//     tint, remapTintMin, remapTintMax, relativeValues,
		//     attenuation, channel, resetShakerValuesAfterShake, resetTargetValuesAfterShake, forwardDirection, timescaleMode, stop);
		Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7* L_0 = ((MMWhiteBalanceShakeEvent_HDRP_t974BEF62F681D273DAD8418106D7C1E817696F90_StaticFields*)il2cpp_codegen_static_fields_for(MMWhiteBalanceShakeEvent_HDRP_t974BEF62F681D273DAD8418106D7C1E817696F90_il2cpp_TypeInfo_var))->___OnEvent_0;
		Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7* L_1 = L_0;
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
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_2 = ___temperature0;
		float L_3 = ___duration1;
		float L_4 = ___remapTemperatureMin2;
		float L_5 = ___remapTemperatureMax3;
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* L_6 = ___tint4;
		float L_7 = ___remapTintMin5;
		float L_8 = ___remapTintMax6;
		bool L_9 = ___relativeValues7;
		float L_10 = ___attenuation8;
		int32_t L_11 = ___channel9;
		bool L_12 = ___resetShakerValuesAfterShake10;
		bool L_13 = ___resetTargetValuesAfterShake11;
		bool L_14 = ___forwardDirection12;
		int32_t L_15 = ___timescaleMode13;
		bool L_16 = ___stop14;
		NullCheck(G_B2_0);
		Delegate_Invoke_mADB133D3DC64B7E1356EEE4F3C5461C4409AFF19_inline(G_B2_0, L_2, L_3, L_4, L_5, L_6, L_7, L_8, L_9, L_10, L_11, L_12, L_13, L_14, L_15, L_16, NULL);
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
void Delegate_Invoke_mADB133D3DC64B7E1356EEE4F3C5461C4409AFF19_Multicast(Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___temperature0, float ___duration1, float ___remapTemperatureMin2, float ___remapTemperatureMax3, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___tint4, float ___remapTintMin5, float ___remapTintMax6, bool ___relativeValues7, float ___attenuation8, int32_t ___channel9, bool ___resetShakerValuesAfterShake10, bool ___resetTargetValuesAfterShake11, bool ___forwardDirection12, int32_t ___timescaleMode13, bool ___stop14, const RuntimeMethod* method)
{
	il2cpp_array_size_t length = __this->___delegates_13->max_length;
	Delegate_t** delegatesToInvoke = reinterpret_cast<Delegate_t**>(__this->___delegates_13->GetAddressAtUnchecked(0));
	for (il2cpp_array_size_t i = 0; i < length; i++)
	{
		Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7* currentDelegate = reinterpret_cast<Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7*>(delegatesToInvoke[i]);
		typedef void (*FunctionPointerType) (RuntimeObject*, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
		((FunctionPointerType)currentDelegate->___invoke_impl_1)((Il2CppObject*)currentDelegate->___method_code_6, ___temperature0, ___duration1, ___remapTemperatureMin2, ___remapTemperatureMax3, ___tint4, ___remapTintMin5, ___remapTintMax6, ___relativeValues7, ___attenuation8, ___channel9, ___resetShakerValuesAfterShake10, ___resetTargetValuesAfterShake11, ___forwardDirection12, ___timescaleMode13, ___stop14, reinterpret_cast<RuntimeMethod*>(currentDelegate->___method_3));
	}
}
void Delegate_Invoke_mADB133D3DC64B7E1356EEE4F3C5461C4409AFF19_OpenInst(Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___temperature0, float ___duration1, float ___remapTemperatureMin2, float ___remapTemperatureMax3, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___tint4, float ___remapTintMin5, float ___remapTintMax6, bool ___relativeValues7, float ___attenuation8, int32_t ___channel9, bool ___resetShakerValuesAfterShake10, bool ___resetTargetValuesAfterShake11, bool ___forwardDirection12, int32_t ___timescaleMode13, bool ___stop14, const RuntimeMethod* method)
{
	NullCheck(___temperature0);
	typedef void (*FunctionPointerType) (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___method_ptr_0)(___temperature0, ___duration1, ___remapTemperatureMin2, ___remapTemperatureMax3, ___tint4, ___remapTintMin5, ___remapTintMax6, ___relativeValues7, ___attenuation8, ___channel9, ___resetShakerValuesAfterShake10, ___resetTargetValuesAfterShake11, ___forwardDirection12, ___timescaleMode13, ___stop14, method);
}
void Delegate_Invoke_mADB133D3DC64B7E1356EEE4F3C5461C4409AFF19_OpenStatic(Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___temperature0, float ___duration1, float ___remapTemperatureMin2, float ___remapTemperatureMax3, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___tint4, float ___remapTintMin5, float ___remapTintMax6, bool ___relativeValues7, float ___attenuation8, int32_t ___channel9, bool ___resetShakerValuesAfterShake10, bool ___resetTargetValuesAfterShake11, bool ___forwardDirection12, int32_t ___timescaleMode13, bool ___stop14, const RuntimeMethod* method)
{
	typedef void (*FunctionPointerType) (AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___method_ptr_0)(___temperature0, ___duration1, ___remapTemperatureMin2, ___remapTemperatureMax3, ___tint4, ___remapTintMin5, ___remapTintMax6, ___relativeValues7, ___attenuation8, ___channel9, ___resetShakerValuesAfterShake10, ___resetTargetValuesAfterShake11, ___forwardDirection12, ___timescaleMode13, ___stop14, method);
}
void Delegate_Invoke_mADB133D3DC64B7E1356EEE4F3C5461C4409AFF19_OpenStaticInvoker(Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___temperature0, float ___duration1, float ___remapTemperatureMin2, float ___remapTemperatureMax3, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___tint4, float ___remapTintMin5, float ___remapTintMax6, bool ___relativeValues7, float ___attenuation8, int32_t ___channel9, bool ___resetShakerValuesAfterShake10, bool ___resetTargetValuesAfterShake11, bool ___forwardDirection12, int32_t ___timescaleMode13, bool ___stop14, const RuntimeMethod* method)
{
	InvokerActionInvoker15< AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(__this->___method_ptr_0, method, NULL, ___temperature0, ___duration1, ___remapTemperatureMin2, ___remapTemperatureMax3, ___tint4, ___remapTintMin5, ___remapTintMax6, ___relativeValues7, ___attenuation8, ___channel9, ___resetShakerValuesAfterShake10, ___resetTargetValuesAfterShake11, ___forwardDirection12, ___timescaleMode13, ___stop14);
}
void Delegate_Invoke_mADB133D3DC64B7E1356EEE4F3C5461C4409AFF19_ClosedStaticInvoker(Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___temperature0, float ___duration1, float ___remapTemperatureMin2, float ___remapTemperatureMax3, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___tint4, float ___remapTintMin5, float ___remapTintMax6, bool ___relativeValues7, float ___attenuation8, int32_t ___channel9, bool ___resetShakerValuesAfterShake10, bool ___resetTargetValuesAfterShake11, bool ___forwardDirection12, int32_t ___timescaleMode13, bool ___stop14, const RuntimeMethod* method)
{
	InvokerActionInvoker16< RuntimeObject*, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(__this->___method_ptr_0, method, NULL, __this->___m_target_2, ___temperature0, ___duration1, ___remapTemperatureMin2, ___remapTemperatureMax3, ___tint4, ___remapTintMin5, ___remapTintMax6, ___relativeValues7, ___attenuation8, ___channel9, ___resetShakerValuesAfterShake10, ___resetTargetValuesAfterShake11, ___forwardDirection12, ___timescaleMode13, ___stop14);
}
void Delegate_Invoke_mADB133D3DC64B7E1356EEE4F3C5461C4409AFF19_OpenVirtual(Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___temperature0, float ___duration1, float ___remapTemperatureMin2, float ___remapTemperatureMax3, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___tint4, float ___remapTintMin5, float ___remapTintMax6, bool ___relativeValues7, float ___attenuation8, int32_t ___channel9, bool ___resetShakerValuesAfterShake10, bool ___resetTargetValuesAfterShake11, bool ___forwardDirection12, int32_t ___timescaleMode13, bool ___stop14, const RuntimeMethod* method)
{
	NullCheck(___temperature0);
	VirtualActionInvoker14< float, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(il2cpp_codegen_method_get_slot(method), ___temperature0, ___duration1, ___remapTemperatureMin2, ___remapTemperatureMax3, ___tint4, ___remapTintMin5, ___remapTintMax6, ___relativeValues7, ___attenuation8, ___channel9, ___resetShakerValuesAfterShake10, ___resetTargetValuesAfterShake11, ___forwardDirection12, ___timescaleMode13, ___stop14);
}
void Delegate_Invoke_mADB133D3DC64B7E1356EEE4F3C5461C4409AFF19_OpenInterface(Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___temperature0, float ___duration1, float ___remapTemperatureMin2, float ___remapTemperatureMax3, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___tint4, float ___remapTintMin5, float ___remapTintMax6, bool ___relativeValues7, float ___attenuation8, int32_t ___channel9, bool ___resetShakerValuesAfterShake10, bool ___resetTargetValuesAfterShake11, bool ___forwardDirection12, int32_t ___timescaleMode13, bool ___stop14, const RuntimeMethod* method)
{
	NullCheck(___temperature0);
	InterfaceActionInvoker14< float, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(il2cpp_codegen_method_get_slot(method), il2cpp_codegen_method_get_declaring_type(method), ___temperature0, ___duration1, ___remapTemperatureMin2, ___remapTemperatureMax3, ___tint4, ___remapTintMin5, ___remapTintMax6, ___relativeValues7, ___attenuation8, ___channel9, ___resetShakerValuesAfterShake10, ___resetTargetValuesAfterShake11, ___forwardDirection12, ___timescaleMode13, ___stop14);
}
void Delegate_Invoke_mADB133D3DC64B7E1356EEE4F3C5461C4409AFF19_OpenGenericVirtual(Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___temperature0, float ___duration1, float ___remapTemperatureMin2, float ___remapTemperatureMax3, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___tint4, float ___remapTintMin5, float ___remapTintMax6, bool ___relativeValues7, float ___attenuation8, int32_t ___channel9, bool ___resetShakerValuesAfterShake10, bool ___resetTargetValuesAfterShake11, bool ___forwardDirection12, int32_t ___timescaleMode13, bool ___stop14, const RuntimeMethod* method)
{
	NullCheck(___temperature0);
	GenericVirtualActionInvoker14< float, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(method, ___temperature0, ___duration1, ___remapTemperatureMin2, ___remapTemperatureMax3, ___tint4, ___remapTintMin5, ___remapTintMax6, ___relativeValues7, ___attenuation8, ___channel9, ___resetShakerValuesAfterShake10, ___resetTargetValuesAfterShake11, ___forwardDirection12, ___timescaleMode13, ___stop14);
}
void Delegate_Invoke_mADB133D3DC64B7E1356EEE4F3C5461C4409AFF19_OpenGenericInterface(Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___temperature0, float ___duration1, float ___remapTemperatureMin2, float ___remapTemperatureMax3, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___tint4, float ___remapTintMin5, float ___remapTintMax6, bool ___relativeValues7, float ___attenuation8, int32_t ___channel9, bool ___resetShakerValuesAfterShake10, bool ___resetTargetValuesAfterShake11, bool ___forwardDirection12, int32_t ___timescaleMode13, bool ___stop14, const RuntimeMethod* method)
{
	NullCheck(___temperature0);
	GenericInterfaceActionInvoker14< float, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool >::Invoke(method, ___temperature0, ___duration1, ___remapTemperatureMin2, ___remapTemperatureMax3, ___tint4, ___remapTintMin5, ___remapTintMax6, ___relativeValues7, ___attenuation8, ___channel9, ___resetShakerValuesAfterShake10, ___resetTargetValuesAfterShake11, ___forwardDirection12, ___timescaleMode13, ___stop14);
}
IL2CPP_EXTERN_C  void DelegatePInvokeWrapper_Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7 (Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___temperature0, float ___duration1, float ___remapTemperatureMin2, float ___remapTemperatureMax3, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___tint4, float ___remapTintMin5, float ___remapTintMax6, bool ___relativeValues7, float ___attenuation8, int32_t ___channel9, bool ___resetShakerValuesAfterShake10, bool ___resetTargetValuesAfterShake11, bool ___forwardDirection12, int32_t ___timescaleMode13, bool ___stop14, const RuntimeMethod* method)
{




	typedef void (DEFAULT_CALL *PInvokeFunc)(AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshaled_pinvoke*, float, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshaled_pinvoke*, float, float, int32_t, float, int32_t, int32_t, int32_t, int32_t, int32_t, int32_t);
	PInvokeFunc il2cppPInvokeFunc = reinterpret_cast<PInvokeFunc>(il2cpp_codegen_get_reverse_pinvoke_function_ptr(__this));
	// Marshaling of parameter '___temperature0' to native representation
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshaled_pinvoke ____temperature0_marshaled = {};
	if (___temperature0 != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke(*___temperature0, ____temperature0_marshaled);
	}

	// Marshaling of parameter '___tint4' to native representation
	AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshaled_pinvoke ____tint4_marshaled = {};
	if (___tint4 != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke(*___tint4, ____tint4_marshaled);
	}

	// Native function invocation
	il2cppPInvokeFunc(___temperature0 != NULL ? (&____temperature0_marshaled) : NULL, ___duration1, ___remapTemperatureMin2, ___remapTemperatureMax3, ___tint4 != NULL ? (&____tint4_marshaled) : NULL, ___remapTintMin5, ___remapTintMax6, static_cast<int32_t>(___relativeValues7), ___attenuation8, ___channel9, static_cast<int32_t>(___resetShakerValuesAfterShake10), static_cast<int32_t>(___resetTargetValuesAfterShake11), static_cast<int32_t>(___forwardDirection12), ___timescaleMode13, static_cast<int32_t>(___stop14));

	// Marshaling of parameter '___temperature0' back from native representation
	if (___temperature0 != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke_back(____temperature0_marshaled, *___temperature0);
	}

	// Marshaling cleanup of parameter '___temperature0' native representation
	if ((&____temperature0_marshaled) != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke_cleanup(____temperature0_marshaled);
	}

	// Marshaling of parameter '___tint4' back from native representation
	if (___tint4 != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke_back(____tint4_marshaled, *___tint4);
	}

	// Marshaling cleanup of parameter '___tint4' native representation
	if ((&____tint4_marshaled) != NULL)
	{
		AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354_marshal_pinvoke_cleanup(____tint4_marshaled);
	}

}
// System.Void MoreMountains.FeedbacksForThirdParty.MMWhiteBalanceShakeEvent_HDRP/Delegate::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Delegate__ctor_m2B40716B84A92B82E7DC710F9504D77FE59652DF (Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7* __this, RuntimeObject* ___object0, intptr_t ___method1, const RuntimeMethod* method) 
{
	__this->___method_ptr_0 = il2cpp_codegen_get_virtual_call_method_pointer((RuntimeMethod*)___method1);
	__this->___method_3 = ___method1;
	__this->___m_target_2 = ___object0;
	Il2CppCodeGenWriteBarrier((void**)(&__this->___m_target_2), (void*)___object0);
	int parameterCount = il2cpp_codegen_method_parameter_count((RuntimeMethod*)___method1);
	__this->___method_code_6 = (intptr_t)__this;
	if (MethodIsStatic((RuntimeMethod*)___method1))
	{
		bool isOpen = parameterCount == 15;
		if (il2cpp_codegen_call_method_via_invoker((RuntimeMethod*)___method1))
			if (isOpen)
				__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mADB133D3DC64B7E1356EEE4F3C5461C4409AFF19_OpenStaticInvoker;
			else
				__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mADB133D3DC64B7E1356EEE4F3C5461C4409AFF19_ClosedStaticInvoker;
		else
			if (isOpen)
				__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mADB133D3DC64B7E1356EEE4F3C5461C4409AFF19_OpenStatic;
			else
				{
					__this->___invoke_impl_1 = (intptr_t)__this->___method_ptr_0;
					__this->___method_code_6 = (intptr_t)__this->___m_target_2;
				}
	}
	else
	{
		bool isOpen = parameterCount == 14;
		if (isOpen)
		{
			if (__this->___method_is_virtual_12)
			{
				if (il2cpp_codegen_method_is_generic_instance_method((RuntimeMethod*)___method1))
					if (il2cpp_codegen_method_is_interface_method((RuntimeMethod*)___method1))
						__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mADB133D3DC64B7E1356EEE4F3C5461C4409AFF19_OpenGenericInterface;
					else
						__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mADB133D3DC64B7E1356EEE4F3C5461C4409AFF19_OpenGenericVirtual;
				else
					if (il2cpp_codegen_method_is_interface_method((RuntimeMethod*)___method1))
						__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mADB133D3DC64B7E1356EEE4F3C5461C4409AFF19_OpenInterface;
					else
						__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mADB133D3DC64B7E1356EEE4F3C5461C4409AFF19_OpenVirtual;
			}
			else
			{
				__this->___invoke_impl_1 = (intptr_t)&Delegate_Invoke_mADB133D3DC64B7E1356EEE4F3C5461C4409AFF19_OpenInst;
			}
		}
		else
		{
			if (___object0 == NULL)
				il2cpp_codegen_raise_exception(il2cpp_codegen_get_argument_exception(NULL, "Delegate to an instance method cannot have null 'this'."), NULL);
			__this->___invoke_impl_1 = (intptr_t)__this->___method_ptr_0;
			__this->___method_code_6 = (intptr_t)__this->___m_target_2;
		}
	}
	__this->___extra_arg_5 = (intptr_t)&Delegate_Invoke_mADB133D3DC64B7E1356EEE4F3C5461C4409AFF19_Multicast;
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMWhiteBalanceShakeEvent_HDRP/Delegate::Invoke(UnityEngine.AnimationCurve,System.Single,System.Single,System.Single,UnityEngine.AnimationCurve,System.Single,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Delegate_Invoke_mADB133D3DC64B7E1356EEE4F3C5461C4409AFF19 (Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___temperature0, float ___duration1, float ___remapTemperatureMin2, float ___remapTemperatureMax3, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___tint4, float ___remapTintMin5, float ___remapTintMax6, bool ___relativeValues7, float ___attenuation8, int32_t ___channel9, bool ___resetShakerValuesAfterShake10, bool ___resetTargetValuesAfterShake11, bool ___forwardDirection12, int32_t ___timescaleMode13, bool ___stop14, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___temperature0, ___duration1, ___remapTemperatureMin2, ___remapTemperatureMax3, ___tint4, ___remapTintMin5, ___remapTintMax6, ___relativeValues7, ___attenuation8, ___channel9, ___resetShakerValuesAfterShake10, ___resetTargetValuesAfterShake11, ___forwardDirection12, ___timescaleMode13, ___stop14, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
// System.IAsyncResult MoreMountains.FeedbacksForThirdParty.MMWhiteBalanceShakeEvent_HDRP/Delegate::BeginInvoke(UnityEngine.AnimationCurve,System.Single,System.Single,System.Single,UnityEngine.AnimationCurve,System.Single,System.Single,System.Boolean,System.Single,System.Int32,System.Boolean,System.Boolean,System.Boolean,MoreMountains.Feedbacks.TimescaleModes,System.Boolean,System.AsyncCallback,System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* Delegate_BeginInvoke_m1EF156002B30DA8B104E0477869E4A17F0023B8A (Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___temperature0, float ___duration1, float ___remapTemperatureMin2, float ___remapTemperatureMax3, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___tint4, float ___remapTintMin5, float ___remapTintMax6, bool ___relativeValues7, float ___attenuation8, int32_t ___channel9, bool ___resetShakerValuesAfterShake10, bool ___resetTargetValuesAfterShake11, bool ___forwardDirection12, int32_t ___timescaleMode13, bool ___stop14, AsyncCallback_t7FEF460CBDCFB9C5FA2EF776984778B9A4145F4C* ___callback15, RuntimeObject* ___object16, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TimescaleModes_t567213DC39EEE1AA073F8E8473E19F2B71FC9A68_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	void *__d_args[16] = {0};
	__d_args[0] = ___temperature0;
	__d_args[1] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___duration1);
	__d_args[2] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___remapTemperatureMin2);
	__d_args[3] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___remapTemperatureMax3);
	__d_args[4] = ___tint4;
	__d_args[5] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___remapTintMin5);
	__d_args[6] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___remapTintMax6);
	__d_args[7] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___relativeValues7);
	__d_args[8] = Box(Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_il2cpp_TypeInfo_var, &___attenuation8);
	__d_args[9] = Box(Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var, &___channel9);
	__d_args[10] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___resetShakerValuesAfterShake10);
	__d_args[11] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___resetTargetValuesAfterShake11);
	__d_args[12] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___forwardDirection12);
	__d_args[13] = Box(TimescaleModes_t567213DC39EEE1AA073F8E8473E19F2B71FC9A68_il2cpp_TypeInfo_var, &___timescaleMode13);
	__d_args[14] = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &___stop14);
	return (RuntimeObject*)il2cpp_codegen_delegate_begin_invoke((RuntimeDelegate*)__this, __d_args, (RuntimeDelegate*)___callback15, (RuntimeObject*)___object16);
}
// System.Void MoreMountains.FeedbacksForThirdParty.MMWhiteBalanceShakeEvent_HDRP/Delegate::EndInvoke(System.IAsyncResult)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Delegate_EndInvoke_m7102A3B78A5B6FEF8F14751607D49D40DB0928B8 (Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7* __this, RuntimeObject* ___result0, const RuntimeMethod* method) 
{
	il2cpp_codegen_delegate_end_invoke((Il2CppAsyncResult*) ___result0, 0);
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Color_tD001788D726C3A7F1379BEED0260B9591F440C1F Color_get_yellow_m66637FA14383E8D74F24AE256B577CE1D55D469F_inline (const RuntimeMethod* method) 
{
	Color_tD001788D726C3A7F1379BEED0260B9591F440C1F V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F L_0;
		memset((&L_0), 0, sizeof(L_0));
		Color__ctor_m3786F0D6E510D9CFA544523A955870BD2A514C8C_inline((&L_0), (1.0f), (0.921568632f), (0.0156862754f), (1.0f), /*hidden argument*/NULL);
		V_0 = L_0;
		goto IL_001d;
	}

IL_001d:
	{
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F L_1 = V_0;
		return L_1;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Delegate_Invoke_mF7FAC8B0ACC743B9DE90ADF2388F38135399AD35_inline (Delegate_tB6CC2C7C128CF9330EFD4B7B916A995C9F3D25B8* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___threshold4, float ___remapThresholdMin5, float ___remapThresholdMax6, bool ___relativeIntensity7, float ___attenuation8, int32_t ___channel9, bool ___resetShakerValuesAfterShake10, bool ___resetTargetValuesAfterShake11, bool ___forwardDirection12, int32_t ___timescaleMode13, bool ___stop14, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___threshold4, ___remapThresholdMin5, ___remapThresholdMax6, ___relativeIntensity7, ___attenuation8, ___channel9, ___resetShakerValuesAfterShake10, ___resetTargetValuesAfterShake11, ___forwardDirection12, ___timescaleMode13, ___stop14, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Delegate_Invoke_m1BF2E87CE04FB3085F026AEF72BB8D6BB6AE1483_inline (Delegate_t0D12254D6C1FCD5956A3C75F9DC98577FD33A176* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeRed0, float ___remapRedZero1, float ___remapRedOne2, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeGreen3, float ___remapGreenZero4, float ___remapGreenOne5, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeBlue6, float ___remapBlueZero7, float ___remapBlueOne8, float ___duration9, bool ___relativeValues10, float ___attenuation11, int32_t ___channel12, bool ___resetShakerValuesAfterShake13, bool ___resetTargetValuesAfterShake14, bool ___forwardDirection15, int32_t ___timescaleMode16, bool ___stop17, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___shakeRed0, ___remapRedZero1, ___remapRedOne2, ___shakeGreen3, ___remapGreenZero4, ___remapGreenOne5, ___shakeBlue6, ___remapBlueZero7, ___remapBlueOne8, ___duration9, ___relativeValues10, ___attenuation11, ___channel12, ___resetShakerValuesAfterShake13, ___resetTargetValuesAfterShake14, ___forwardDirection15, ___timescaleMode16, ___stop17, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Delegate_Invoke_mD47FC069DCC89CDB71DF4618BC9D58ABA8AF77A3_inline (Delegate_tA1AC722C106B521DE629E6B346B96F850820A3A2* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Delegate_Invoke_mF4923867EB16C9EB4E8B71E48F04C5173E122D3A_inline (Delegate_tA7B7E0BCB9629872798A575B525C0C685B292B19* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakePostExposure0, float ___remapPostExposureZero1, float ___remapPostExposureOne2, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeHueShift3, float ___remapHueShiftZero4, float ___remapHueShiftOne5, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeSaturation6, float ___remapSaturationZero7, float ___remapSaturationOne8, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___shakeContrast9, float ___remapContrastZero10, float ___remapContrastOne11, int32_t ___colorFilterMode12, Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E* ___colorFilterGradient13, Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___colorFilterDestination14, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___colorFilterCurve15, float ___duration16, bool ___relativeValues17, float ___attenuation18, int32_t ___channel19, bool ___resetShakerValuesAfterShake20, bool ___resetTargetValuesAfterShake21, bool ___forwardDirection22, int32_t ___timescaleMode23, bool ___stop24, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, int32_t, Gradient_tA7FEBE2FDB4929FFF6C997134841046F713DAC1E*, Color_tD001788D726C3A7F1379BEED0260B9591F440C1F, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___shakePostExposure0, ___remapPostExposureZero1, ___remapPostExposureOne2, ___shakeHueShift3, ___remapHueShiftZero4, ___remapHueShiftOne5, ___shakeSaturation6, ___remapSaturationZero7, ___remapSaturationOne8, ___shakeContrast9, ___remapContrastZero10, ___remapContrastOne11, ___colorFilterMode12, ___colorFilterGradient13, ___colorFilterDestination14, ___colorFilterCurve15, ___duration16, ___relativeValues17, ___attenuation18, ___channel19, ___resetShakerValuesAfterShake20, ___resetTargetValuesAfterShake21, ___forwardDirection22, ___timescaleMode23, ___stop24, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Delegate_Invoke_mB3B6C56776FE0B118D170C735745148F1F55D1E8_inline (Delegate_tB708D138CC078105B8138CE52CB5FDF7B7D1E0A0* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___fixedExposure0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeFixedExposure4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___fixedExposure0, ___duration1, ___remapMin2, ___remapMax3, ___relativeFixedExposure4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Delegate_Invoke_mA4BC5FEA6FD70F9E70251A4AC32D5E91CD5D0ED3_inline (Delegate_t9F4074DE74405ABE031B748C6B52630D6D5C3C15* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Delegate_Invoke_mDA47912E1B3F9FE408E601FA5C1227E138AEABAD_inline (Delegate_t9513911CEED79D0C403D9C54E3A30AB15CDF2994* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Delegate_Invoke_mDC19B891E8784D90FDB7B09764639E93850BC2EA_inline (Delegate_t76E7FC0557DA35C1481B1217416A02E6FDEF12E8* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Delegate_Invoke_m6BBDE2816C59B866513C70D4B1CE63FE43C95414_inline (Delegate_t56DB6A91187B048A5CD616CFFD1C280DE8256A79* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___distance0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeDistance4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___distance0, ___duration1, ___remapMin2, ___remapMax3, ___relativeDistance4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Delegate_Invoke_mE669B4A49B0DC7BA342141849CCF6770DCD7EE31_inline (Delegate_t114A48A7D5C0788E8CF726A5F52C3C0A3B48BE78* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___intensity0, float ___duration1, float ___remapMin2, float ___remapMax3, bool ___relativeIntensity4, float ___attenuation5, int32_t ___channel6, bool ___resetShakerValuesAfterShake7, bool ___resetTargetValuesAfterShake8, bool ___forwardDirection9, int32_t ___timescaleMode10, bool ___stop11, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___intensity0, ___duration1, ___remapMin2, ___remapMax3, ___relativeIntensity4, ___attenuation5, ___channel6, ___resetShakerValuesAfterShake7, ___resetTargetValuesAfterShake8, ___forwardDirection9, ___timescaleMode10, ___stop11, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Delegate_Invoke_mADB133D3DC64B7E1356EEE4F3C5461C4409AFF19_inline (Delegate_tA9F18EA77383AA70C57215D6FF8B256812F4D4C7* __this, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___temperature0, float ___duration1, float ___remapTemperatureMin2, float ___remapTemperatureMax3, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354* ___tint4, float ___remapTintMin5, float ___remapTintMax6, bool ___relativeValues7, float ___attenuation8, int32_t ___channel9, bool ___resetShakerValuesAfterShake10, bool ___resetTargetValuesAfterShake11, bool ___forwardDirection12, int32_t ___timescaleMode13, bool ___stop14, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, float, AnimationCurve_tCBFFAAD05CEBB35EF8D8631BD99914BE1A6BB354*, float, float, bool, float, int32_t, bool, bool, bool, int32_t, bool, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___temperature0, ___duration1, ___remapTemperatureMin2, ___remapTemperatureMax3, ___tint4, ___remapTintMin5, ___remapTintMax6, ___relativeValues7, ___attenuation8, ___channel9, ___resetShakerValuesAfterShake10, ___resetTargetValuesAfterShake11, ___forwardDirection12, ___timescaleMode13, ___stop14, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Color__ctor_m3786F0D6E510D9CFA544523A955870BD2A514C8C_inline (Color_tD001788D726C3A7F1379BEED0260B9591F440C1F* __this, float ___r0, float ___g1, float ___b2, float ___a3, const RuntimeMethod* method) 
{
	{
		float L_0 = ___r0;
		__this->___r_0 = L_0;
		float L_1 = ___g1;
		__this->___g_1 = L_1;
		float L_2 = ___b2;
		__this->___b_2 = L_2;
		float L_3 = ___a3;
		__this->___a_3 = L_3;
		return;
	}
}
