﻿namespace Practice.Client.Services
{
	#region

	using System;
	using System.ServiceModel;

	#endregion

	/// <summary>
	///     Sample of using Calles to methods:
	///     <code>
	/// using (var client = new ServiceClient<IEmployeeService>
	///                                          ("EmployeeEndpoint"))
	///                                          {
	///                                          var response = client.ServiceOperation
	///                                          <EmployeeResponse>
	///                                              (
	///                                              c => c.SaveEmployee(request));
	///                                              }
	/// </code>
	/// </summary>
	/// <typeparam name="TContract"></typeparam>
	public abstract class WcfProxy<TContract> : IDisposable where TContract : class
	{

		private static readonly object _locker = new object();
		private readonly string _endpointAddress;
		private TContract _channel;
		private ChannelFactory<TContract> _channelFactory;
		private bool _disposed;

		protected WcfProxy(string endpointName)
		{
			_endpointAddress = endpointName;
		}

		protected TContract Channel
		{
			get
			{
				Initialise();
				return _channel;
			}
		}

		#region IDisposable Members

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		#endregion

		~WcfProxy()
		{
			Dispose(false);
		}

		public TResult ServiceOperation<TResult>(Func<TContract, TResult> operation)
		{
			return operation(_channel);
		}

		/// <summary>
		///     Calls an operation on the service.
		/// </summary>
		/// <param name="operation">The operation to call.</param>
		public void ServiceOperation(Action<TContract> operation)
		{
			operation(_channel);
		}

		private void Dispose(bool disposed)
		{
			if (_disposed)
			{
				return;
			}

			if (disposed)
			{
				lock (_locker)
				{
					CloseChannel();
					if (_channelFactory != null)
					{
						((IDisposable)_channelFactory).Dispose();
					}

					_channel = null;
					_channelFactory = null;
				}
			}
			_disposed = true;
		}

		protected void CloseChannel()
		{
			if (_channel != null)
			{
				//((ICommunicationObject) _channel).Close();
				var channel = _channel as IClientChannel;
				if (channel != null && channel.State == CommunicationState.Faulted)
				{
					channel.Abort();
				}
				else
				{
					if (channel != null)
					{
						channel.Close();
					}
				}
			}
		}

		private void Initialise()
		{
			lock (_locker)
			{
				if (_channel != null)
				{
					return;
				}

				_channelFactory = new ChannelFactory<TContract>(new BasicHttpBinding());
				_channel = _channelFactory.CreateChannel(new EndpointAddress(_endpointAddress));
			}
		}

	}
}
