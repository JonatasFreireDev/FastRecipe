import React from 'react';
import { render } from '@testing-library/react-native';
import { StackScreenProps } from '@react-navigation/stack';
import { LoginRegisterStack } from '../../interface/IRoutes';
import Login from '../../pages/Login';

describe('Login page', () => {
  it('should contains email/password inputs', () => {
    const { getByTestId } = render(<Login />);
  });
});
