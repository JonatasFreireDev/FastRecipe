import React from 'react';

import { StackScreenProps } from '@react-navigation/stack';
import { View, Text, Button } from 'react-native';
import { MyProfileStack } from '../../../interface/IRoutes';

const HelpUs: React.FC<StackScreenProps<MyProfileStack, 'HelpUs'>> = ({
  navigation,
}) => {
  return (
    <>
      <View style={{ flex: 1, justifyContent: 'center', alignItems: 'center' }}>
        <Text> HelpUs</Text>
      </View>
    </>
  );
};

export default HelpUs;
